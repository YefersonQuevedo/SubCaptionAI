using System.Diagnostics;
using System.Linq;
// (opcional si aplicas la validación de archivo)
using System.IO;
namespace WhisperTranscriber
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            cmbModel.Items.AddRange(new[] { "tiny", "base", "small", "medium", "large" });
            cmbModel.SelectedIndex = 1;
            cmbDevice.Items.AddRange(new[] { "cpu", "cuda" });
            cmbDevice.SelectedIndex = 0;
            cmbMode.Items.AddRange(new[] {
                "⚡ Rápido  (menos preciso)",
                "⚖ Balanceado",
                "🎯 Preciso  (más lento)"
            });
            cmbMode.SelectedIndex = 1;
            txtPythonPath.Text = "python";

            var languages = new System.Collections.Generic.List<System.Collections.Generic.KeyValuePair<string, string>>
            {
                new("auto", "Auto-detectar"),
                new("es", "Español"),
                new("en", "English"),
                new("zh", "Chinese (中文)"),
                new("de", "Deutsch"),
                new("ru", "Русский"),
                new("ko", "한국어"),
                new("fr", "Français"),
                new("ja", "日本語"),
                new("pt", "Português"),
                new("tr", "Türkçe"),
                new("pl", "Polski"),
                new("nl", "Nederlands"),
                new("ar", "العربية"),
                new("sv", "Svenska"),
                new("it", "Italiano"),
                new("id", "Bahasa Indonesia"),
                new("hi", "हिन्दी"),
                new("fi", "Suomi"),
                new("vi", "Tiếng Việt"),
                new("he", "עברית"),
                new("uk", "Українська"),
                new("el", "Ελληνικά"),
                new("ms", "Bahasa Melayu"),
                new("cs", "Čeština"),
                new("ro", "Română"),
                new("da", "Dansk"),
                new("hu", "Magyar"),
                new("ta", "தமிழ்"),
                new("no", "Norsk"),
                new("th", "ภาษาไทย"),
                new("ur", "اردو"),
                new("hr", "Hrvatski"),
                new("bg", "Български"),
                new("lt", "Lietuvių"),
                new("la", "Latina"),
                new("sk", "Slovenčina"),
                new("fa", "فارسی"),
                new("lv", "Latviešu"),
                new("bn", "বাংলা"),
                new("sr", "Српски"),
                new("az", "Azərbaycan"),
                new("sl", "Slovenščina"),
                new("kn", "ಕನ್ನಡ"),
                new("et", "Eesti"),
                new("mk", "Македонски"),
                new("is", "Íslenska"),
                new("hy", "Հայերեն"),
                new("ne", "नेपाली"),
                new("mn", "Монгол"),
                new("bs", "Bosanski"),
                new("kk", "Қазақ"),
                new("sq", "Shqip"),
                new("sw", "Kiswahili"),
                new("gl", "Galego"),
                new("mr", "मराठी"),
                new("pa", "ਪੰਜਾਬੀ"),
                new("ka", "ქართული"),
                new("be", "Беларуская"),
                new("tg", "Тоҷикӣ"),
                new("gu", "ગુજરાતી"),
                new("am", "አማርኛ"),
                new("uz", "O'zbek"),
                new("mt", "Malti"),
                new("tl", "Filipino"),
                new("haw", "Hawaiian"),
                new("ha", "Hausa"),
                new("yo", "Yorùbá"),
                new("af", "Afrikaans"),
                new("cy", "Cymraeg"),
                new("mi", "Māori"),
            };
            cmbLanguage.DataSource = languages;
            cmbLanguage.DisplayMember = "Value";
            cmbLanguage.ValueMember = "Key";
            cmbLanguage.SelectedValue = "es";
        }

        // Modelos recomendados por modo (mismo orden que cmbMode)
        private static readonly string[] ModoModelos = { "base", "small", "large" };
        private static readonly string[] ModoArgs    = { "rapido", "balanceado", "preciso" };

        private void cmbMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            var idx = cmbMode.SelectedIndex;
            if (idx >= 0 && idx < ModoModelos.Length)
                cmbModel.SelectedItem = ModoModelos[idx];
        }

        private void btnAddFiles_Click(object sender, EventArgs e)
        {
            using var ofd = new OpenFileDialog
            {
                Multiselect = true,
                Filter = "Videos|*.mp4;*.mkv;*.mov;*.avi;*.wav;*.mp3"
            };
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                foreach (var f in ofd.FileNames)
                {
                    // Verificar que no esté duplicado
                    bool exists = false;
                    foreach (ListViewItem item in lvFiles.Items)
                    {
                        if (item.SubItems[0].Text == f)
                        {
                            exists = true;
                            break;
                        }
                    }

                    if (!exists)
                    {
                        var lvi = new ListViewItem(f);
                        lvi.SubItems.Add("Pendiente");
                        lvi.SubItems.Add("");
                        lvFiles.Items.Add(lvi);
                    }
                }
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            var sel = lvFiles.SelectedItems.Cast<ListViewItem>().ToList();
            foreach (var s in sel) lvFiles.Items.Remove(s);
        }

        private void btnOutDir_Click(object sender, EventArgs e)
        {
            using var fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
                txtOutDir.Text = fbd.SelectedPath;
        }

        private async void btnTranscribe_Click(object sender, EventArgs e)
        {
            if (lvFiles.Items.Count == 0)
            {
                MessageBox.Show("Agrega al menos un archivo.");
                return;
            }
            if (string.IsNullOrWhiteSpace(txtOutDir.Text))
            {
                MessageBox.Show("Elige la carpeta de salida.");
                return;
            }
            if (string.IsNullOrWhiteSpace(txtScriptPath.Text) || !File.Exists(txtScriptPath.Text))
            {
                MessageBox.Show("Indica la ruta a transcribe.py (archivo no encontrado).");
                return;
            }

            Directory.CreateDirectory(txtOutDir.Text);

            btnTranscribe.Enabled = false;
            var py = txtPythonPath.Text.Trim();
            var script = txtScriptPath.Text.Trim();
            var modelNames = new[] { "tiny", "base", "small", "medium", "large" };
            var modelIdx   = cmbModel.SelectedIndex;
            var model      = (modelIdx >= 0 && modelIdx < modelNames.Length) ? modelNames[modelIdx] : "base";
            var device     = cmbDevice.SelectedItem?.ToString() ?? "cpu";
            var modeIdx    = cmbMode.SelectedIndex >= 0 ? cmbMode.SelectedIndex : 1;
            var mode       = ModoArgs[modeIdx];
            var language   = (cmbLanguage.SelectedItem is System.Collections.Generic.KeyValuePair<string, string> kv) ? kv.Key : "es";

            try
            {
                AppendLog($"\n=== Transcribiendo {lvFiles.Items.Count} archivo(s) ===\n");

                // Resetear estados
                foreach (ListViewItem item in lvFiles.Items)
                {
                    UpdateFileStatus(item, "Esperando...", "");
                }

                var psi = new ProcessStartInfo
                {
                    FileName = py,
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    CreateNoWindow = true,
                };
                psi.ArgumentList.Add(script);

                // Agregar todos los archivos como argumentos
                foreach (ListViewItem item in lvFiles.Items)
                {
                    psi.ArgumentList.Add(item.SubItems[0].Text);
                }

                psi.ArgumentList.Add("--out");    psi.ArgumentList.Add(txtOutDir.Text);
                psi.ArgumentList.Add("--model");  psi.ArgumentList.Add(model);
                psi.ArgumentList.Add("--device"); psi.ArgumentList.Add(device);
                psi.ArgumentList.Add("--mode");     psi.ArgumentList.Add(mode);
                psi.ArgumentList.Add("--language"); psi.ArgumentList.Add(language);

                using var proc = new Process { StartInfo = psi };
                proc.OutputDataReceived += (_, a) => {
                    if (a.Data != null)
                    {
                        AppendLog(a.Data + "\n");
                        ProcessOutputLine(a.Data);
                    }
                };
                proc.ErrorDataReceived  += (_, a) => { if (a.Data != null) AppendLog("[ERR] " + a.Data + "\n"); };

                proc.Start();
                proc.BeginOutputReadLine();
                proc.BeginErrorReadLine();
                await Task.Run(() => proc.WaitForExit());
                AppendLog($"[EXIT] Código: {proc.ExitCode}\n");

                // Marcar archivos sin estado final como completados o con error
                foreach (ListViewItem item in lvFiles.Items)
                {
                    if (item.SubItems[1].Text == "Esperando..." || item.SubItems[1].Text == "Transcribiendo")
                    {
                        if (proc.ExitCode == 0)
                            UpdateFileStatus(item, "✓ Completado", "Finalizado");
                        else
                            UpdateFileStatus(item, "✗ Error", "Verificar log");
                    }
                }

                AppendLog("\n*** Proceso terminado ***\n");
            }
            catch (Exception ex)
            {
                AppendLog($"[EXCEPTION] {ex.Message}\n");
            }
            finally
            {
                btnTranscribe.Enabled = true;
            }
        }

        private void ProcessOutputLine(string line)
        {
            // Procesar líneas de progreso del script Python
            // Formato esperado: [PROGRESS] archivo.mp4 | estado | progreso
            if (line.StartsWith("[PROGRESS]"))
            {
                var parts = line.Substring(11).Split('|');
                if (parts.Length >= 3)
                {
                    var filename = parts[0].Trim();
                    var status = parts[1].Trim();
                    var progress = parts[2].Trim();

                    AppendLog($"[DEBUG] Buscando archivo: '{filename}'\n");

                    // Buscar el item en el ListView por nombre de archivo
                    ListViewItem foundItem = null;
                    foreach (ListViewItem item in lvFiles.Items)
                    {
                        var itemFilename = System.IO.Path.GetFileName(item.SubItems[0].Text);
                        AppendLog($"[DEBUG] Comparando con: '{itemFilename}'\n");

                        if (itemFilename.Equals(filename, StringComparison.OrdinalIgnoreCase))
                        {
                            foundItem = item;
                            break;
                        }
                    }

                    if (foundItem != null)
                    {
                        AppendLog($"[DEBUG] Archivo encontrado! Actualizando estado: {status} - {progress}\n");
                        UpdateFileStatus(foundItem, status, progress);
                    }
                    else
                    {
                        AppendLog($"[DEBUG] Archivo NO encontrado en la lista\n");
                    }
                }
            }
        }

        private void UpdateFileStatus(ListViewItem item, string status, string progress)
        {
            if (lvFiles.InvokeRequired)
            {
                lvFiles.Invoke(new Action<ListViewItem, string, string>(UpdateFileStatus), item, status, progress);
            }
            else
            {
                item.SubItems[1].Text = status;
                item.SubItems[2].Text = progress;

                // Colorear según estado
                if (status.Contains("Completado") || status.Contains("OK"))
                    item.BackColor = System.Drawing.Color.FromArgb(220, 255, 220);
                else if (status.Contains("Error") || status.Contains("ERROR"))
                    item.BackColor = System.Drawing.Color.FromArgb(255, 220, 220);
                else if (status.Contains("Procesando") || status.Contains("Transcribiendo"))
                    item.BackColor = System.Drawing.Color.FromArgb(255, 250, 205);
                else
                    item.BackColor = System.Drawing.Color.White;
            }
        }


        private void btnAiReview_Click(object sender, EventArgs e)
        {
            var form = new AiReviewForm();
            form.Show();
        }

        private void AppendLog(string msg)
        {
            if (txtLog.InvokeRequired)
                txtLog.Invoke(new Action<string>(AppendLog), msg);
            else
                txtLog.AppendText(msg);
        }
    }
}
