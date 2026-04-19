using System.Drawing;

namespace WhisperTranscriber
{
    public partial class AiReviewForm : Form
    {
        private List<SrtBlock> _blocks = new();
        private CancellationTokenSource? _cts;
        private readonly OllamaClient _ollama = new();

        public AiReviewForm()
        {
            InitializeComponent();
        }

        public AiReviewForm(string srtPath) : this()
        {
            txtSrtPath.Text = srtPath;
        }

        // ── Abrir SRT ──────────────────────────────────────────────
        private void btnOpenSrt_Click(object sender, EventArgs e)
        {
            using var ofd = new OpenFileDialog { Filter = "Subtítulos|*.srt" };
            if (ofd.ShowDialog() == DialogResult.OK)
                txtSrtPath.Text = ofd.FileName;
        }

        // ── Analizar ───────────────────────────────────────────────
        private async void btnAnalyze_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSrtPath.Text) || !File.Exists(txtSrtPath.Text))
            {
                MessageBox.Show("Selecciona un archivo .srt válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrWhiteSpace(txtContext.Text))
            {
                MessageBox.Show("Escribe el contexto (nombre de la película/serie, idioma, etc.).", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!await _ollama.IsAvailableAsync())
            {
                MessageBox.Show("No se puede conectar a Ollama en localhost:11434.\nAsegúrate de que Ollama esté corriendo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var content = await File.ReadAllTextAsync(txtSrtPath.Text);
            _blocks = SrtParser.Parse(content);

            if (_blocks.Count == 0)
            {
                MessageBox.Show("No se encontraron subtítulos en el archivo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            dgvChanges.Rows.Clear();
            btnApply.Enabled = false;
            btnAnalyze.Enabled = false;
            btnCancel.Enabled = true;
            progressBar.Value = 0;
            lblStatus.Text = "Iniciando...";

            _cts = new CancellationTokenSource();
            var chunkSize = (int)numChunkSize.Value;
            var model = txtModel.Text.Trim();
            var context = txtContext.Text.Trim();
            var byNumber = _blocks.ToDictionary(b => b.Number);

            var chunks = _blocks
                .Select((b, i) => (b, i))
                .GroupBy(x => x.i / chunkSize)
                .Select(g => g.Select(x => x.b).ToList())
                .ToList();

            progressBar.Maximum = chunks.Count;

            try
            {
                for (int i = 0; i < chunks.Count; i++)
                {
                    if (_cts.Token.IsCancellationRequested) break;

                    SetStatus($"Analizando bloque {i + 1} de {chunks.Count}...");
                    progressBar.Value = i;

                    var prompt = BuildPrompt(context, chunks[i]);
                    string response;
                    try
                    {
                        response = await _ollama.GenerateAsync(model, prompt, _cts.Token);
                    }
                    catch (OperationCanceledException) { break; }
                    catch (Exception ex)
                    {
                        SetStatus($"Error en bloque {i + 1}: {ex.Message}");
                        continue;
                    }

                    SrtParser.ApplyResponse(response, byNumber);

                    var changed = chunks[i].Where(b => b.HasChange).ToList();
                    foreach (var b in changed)
                        AddRow(b);

                    progressBar.Value = i + 1;
                }

                var total = _blocks.Count(b => b.HasChange);
                SetStatus($"Listo — {total} cambio(s) sugerido(s)");
                UpdateStats();
                btnApply.Enabled = dgvChanges.Rows.Count > 0;
            }
            finally
            {
                btnAnalyze.Enabled = true;
                btnCancel.Enabled = false;
                _cts?.Dispose();
                _cts = null;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            _cts?.Cancel();
            SetStatus("Cancelando...");
        }

        // ── Grid helpers ───────────────────────────────────────────
        private void AddRow(SrtBlock b)
        {
            if (dgvChanges.InvokeRequired)
            {
                dgvChanges.Invoke(() => AddRow(b));
                return;
            }
            var idx = dgvChanges.Rows.Add(true, b.Number, b.OriginalText, b.ProposedText);
            dgvChanges.Rows[idx].Tag = b;
            dgvChanges.Rows[idx].DefaultCellStyle.BackColor = Color.FromArgb(232, 245, 233);
        }

        private void dgvChanges_CurrentCellDirtyStateChanged(object? sender, EventArgs e)
        {
            if (dgvChanges.IsCurrentCellDirty)
                dgvChanges.CommitEdit(System.Windows.Forms.DataGridViewDataErrorContexts.Commit);
        }

        private void dgvChanges_CellValueChanged(object? sender, System.Windows.Forms.DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == colApply.Index && e.RowIndex >= 0)
            {
                var apply = (bool)(dgvChanges.Rows[e.RowIndex].Cells[colApply.Index].Value ?? false);
                dgvChanges.Rows[e.RowIndex].DefaultCellStyle.BackColor = apply
                    ? Color.FromArgb(232, 245, 233)
                    : Color.FromArgb(255, 235, 238);
                UpdateStats();
            }
        }

        private void btnSelectAll_Click(object sender, EventArgs e) => SetAllChecked(true);
        private void btnSelectNone_Click(object sender, EventArgs e) => SetAllChecked(false);

        private void SetAllChecked(bool value)
        {
            foreach (System.Windows.Forms.DataGridViewRow row in dgvChanges.Rows)
            {
                row.Cells[colApply.Index].Value = value;
                row.DefaultCellStyle.BackColor = value
                    ? Color.FromArgb(232, 245, 233)
                    : Color.FromArgb(255, 235, 238);
            }
            UpdateStats();
        }

        private void UpdateStats()
        {
            int total = dgvChanges.Rows.Count;
            int selected = dgvChanges.Rows.Cast<System.Windows.Forms.DataGridViewRow>()
                .Count(r => (bool)(r.Cells[colApply.Index].Value ?? false));
            lblStats.Text = $"Cambios encontrados: {total}   Seleccionados: {selected}";
        }

        // ── Aplicar ────────────────────────────────────────────────
        private void btnApply_Click(object sender, EventArgs e)
        {
            var accepted = new HashSet<int>();
            foreach (System.Windows.Forms.DataGridViewRow row in dgvChanges.Rows)
            {
                if ((bool)(row.Cells[colApply.Index].Value ?? false) && row.Tag is SrtBlock b)
                    accepted.Add(b.Number);
            }

            if (accepted.Count == 0)
            {
                MessageBox.Show("No hay cambios seleccionados.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var newContent = SrtParser.Serialize(_blocks, accepted);

            var path = txtSrtPath.Text;
            var dir = Path.GetDirectoryName(path)!;
            var name = Path.GetFileNameWithoutExtension(path);
            var outPath = Path.Combine(dir, name + "_revisado.srt");

            File.WriteAllText(outPath, newContent, System.Text.Encoding.UTF8);
            MessageBox.Show($"Guardado en:\n{outPath}", "✔ Listo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // ── Prompt ─────────────────────────────────────────────────
        private static string BuildPrompt(string context, List<SrtBlock> chunk)
        {
            var srtChunk = SrtParser.BlocksToSrtString(chunk);
            return $"""
Eres un corrector de subtítulos en español.

Contexto: {context}

INSTRUCCIONES ESTRICTAS:
- Corrige ÚNICAMENTE inconsistencias de terminología, nombres propios y coherencia con el contexto dado
- NO cambies gramática menor ni estilo si no está relacionado con el contexto
- Devuelve SOLO los bloques que necesiten corrección en formato SRT exacto
- NO modifiques los números de bloque ni los timestamps
- Si un bloque está correcto, NO lo incluyas en la respuesta
- Responde ÚNICAMENTE con bloques SRT, sin texto adicional ni explicaciones

Subtítulos a revisar:
{srtChunk}
""";
        }

        private void SetStatus(string msg)
        {
            if (lblStatus.InvokeRequired)
                lblStatus.Invoke(() => lblStatus.Text = msg);
            else
                lblStatus.Text = msg;
        }
    }
}
