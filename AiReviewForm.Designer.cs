namespace WhisperTranscriber
{
    partial class AiReviewForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Label lblSrtFile;
        private System.Windows.Forms.TextBox txtSrtPath;
        private System.Windows.Forms.Button btnOpenSrt;
        private System.Windows.Forms.Label lblContext;
        private System.Windows.Forms.TextBox txtContext;
        private System.Windows.Forms.Label lblModel;
        private System.Windows.Forms.TextBox txtModel;
        private System.Windows.Forms.Label lblChunkSize;
        private System.Windows.Forms.NumericUpDown numChunkSize;
        private System.Windows.Forms.Button btnAnalyze;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.DataGridView dgvChanges;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colApply;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOriginal;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProposed;
        private System.Windows.Forms.Panel pnlBottom;
        private System.Windows.Forms.Label lblStats;
        private System.Windows.Forms.Button btnSelectAll;
        private System.Windows.Forms.Button btnSelectNone;
        private System.Windows.Forms.Button btnApply;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();

            pnlTop = new System.Windows.Forms.Panel();
            lblSrtFile = new System.Windows.Forms.Label();
            txtSrtPath = new System.Windows.Forms.TextBox();
            btnOpenSrt = new System.Windows.Forms.Button();
            lblContext = new System.Windows.Forms.Label();
            txtContext = new System.Windows.Forms.TextBox();
            lblModel = new System.Windows.Forms.Label();
            txtModel = new System.Windows.Forms.TextBox();
            lblChunkSize = new System.Windows.Forms.Label();
            numChunkSize = new System.Windows.Forms.NumericUpDown();
            btnAnalyze = new System.Windows.Forms.Button();
            btnCancel = new System.Windows.Forms.Button();
            progressBar = new System.Windows.Forms.ProgressBar();
            lblStatus = new System.Windows.Forms.Label();
            dgvChanges = new System.Windows.Forms.DataGridView();
            colApply = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            colNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colOriginal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colProposed = new System.Windows.Forms.DataGridViewTextBoxColumn();
            pnlBottom = new System.Windows.Forms.Panel();
            lblStats = new System.Windows.Forms.Label();
            btnSelectAll = new System.Windows.Forms.Button();
            btnSelectNone = new System.Windows.Forms.Button();
            btnApply = new System.Windows.Forms.Button();

            pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvChanges).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numChunkSize).BeginInit();
            pnlBottom.SuspendLayout();
            SuspendLayout();

            // pnlTop
            pnlTop.BackColor = System.Drawing.Color.FromArgb(240, 240, 245);
            pnlTop.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            pnlTop.Padding = new System.Windows.Forms.Padding(15);
            pnlTop.Size = new System.Drawing.Size(1200, 175);

            // lblSrtFile
            lblSrtFile.AutoSize = true;
            lblSrtFile.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            lblSrtFile.ForeColor = System.Drawing.Color.FromArgb(50, 50, 50);
            lblSrtFile.Location = new System.Drawing.Point(15, 20);
            lblSrtFile.Text = "Archivo SRT:";

            // txtSrtPath
            txtSrtPath.Font = new System.Drawing.Font("Consolas", 9F);
            txtSrtPath.Location = new System.Drawing.Point(130, 17);
            txtSrtPath.Size = new System.Drawing.Size(860, 22);
            txtSrtPath.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;

            // btnOpenSrt
            btnOpenSrt.BackColor = System.Drawing.Color.FromArgb(70, 130, 180);
            btnOpenSrt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnOpenSrt.ForeColor = System.Drawing.Color.White;
            btnOpenSrt.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            btnOpenSrt.Location = new System.Drawing.Point(1000, 15);
            btnOpenSrt.Size = new System.Drawing.Size(100, 26);
            btnOpenSrt.Text = "Abrir...";
            btnOpenSrt.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnOpenSrt.Click += btnOpenSrt_Click;

            // lblContext
            lblContext.AutoSize = true;
            lblContext.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            lblContext.ForeColor = System.Drawing.Color.FromArgb(50, 50, 50);
            lblContext.Location = new System.Drawing.Point(15, 55);
            lblContext.Text = "Contexto:";

            // txtContext
            txtContext.Font = new System.Drawing.Font("Segoe UI", 9F);
            txtContext.Location = new System.Drawing.Point(130, 52);
            txtContext.Size = new System.Drawing.Size(970, 22);
            txtContext.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            txtContext.PlaceholderText = "Ej: Película Avatar: El último maestro del aire, doblaje en español latino";

            // lblModel
            lblModel.AutoSize = true;
            lblModel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            lblModel.ForeColor = System.Drawing.Color.FromArgb(50, 50, 50);
            lblModel.Location = new System.Drawing.Point(15, 92);
            lblModel.Text = "Modelo Ollama:";

            // txtModel
            txtModel.Font = new System.Drawing.Font("Consolas", 9F);
            txtModel.Location = new System.Drawing.Point(130, 89);
            txtModel.Size = new System.Drawing.Size(200, 22);
            txtModel.Text = "gemma4:26b";

            // lblChunkSize
            lblChunkSize.AutoSize = true;
            lblChunkSize.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            lblChunkSize.ForeColor = System.Drawing.Color.FromArgb(50, 50, 50);
            lblChunkSize.Location = new System.Drawing.Point(360, 92);
            lblChunkSize.Text = "Subtítulos por bloque:";

            // numChunkSize
            numChunkSize.Font = new System.Drawing.Font("Segoe UI", 9F);
            numChunkSize.Location = new System.Drawing.Point(530, 89);
            numChunkSize.Size = new System.Drawing.Size(70, 23);
            numChunkSize.Minimum = 20;
            numChunkSize.Maximum = 200;
            numChunkSize.Value = 80;

            // btnAnalyze
            btnAnalyze.BackColor = System.Drawing.Color.FromArgb(60, 179, 113);
            btnAnalyze.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnAnalyze.ForeColor = System.Drawing.Color.White;
            btnAnalyze.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            btnAnalyze.Location = new System.Drawing.Point(730, 85);
            btnAnalyze.Size = new System.Drawing.Size(180, 32);
            btnAnalyze.Text = "🔍 Analizar con IA";
            btnAnalyze.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnAnalyze.Click += btnAnalyze_Click;

            // btnCancel
            btnCancel.BackColor = System.Drawing.Color.FromArgb(180, 60, 60);
            btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnCancel.ForeColor = System.Drawing.Color.White;
            btnCancel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            btnCancel.Location = new System.Drawing.Point(920, 85);
            btnCancel.Size = new System.Drawing.Size(180, 32);
            btnCancel.Text = "⏹ Cancelar";
            btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnCancel.Enabled = false;
            btnCancel.Click += btnCancel_Click;

            // progressBar
            progressBar.Location = new System.Drawing.Point(130, 130);
            progressBar.Size = new System.Drawing.Size(600, 18);
            progressBar.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;

            // lblStatus
            lblStatus.AutoSize = true;
            lblStatus.Font = new System.Drawing.Font("Segoe UI", 9F);
            lblStatus.ForeColor = System.Drawing.Color.FromArgb(80, 80, 80);
            lblStatus.Location = new System.Drawing.Point(745, 131);
            lblStatus.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left;
            lblStatus.Text = "Listo";

            // Agregar controles a pnlTop
            pnlTop.Controls.Add(lblSrtFile);
            pnlTop.Controls.Add(txtSrtPath);
            pnlTop.Controls.Add(btnOpenSrt);
            pnlTop.Controls.Add(lblContext);
            pnlTop.Controls.Add(txtContext);
            pnlTop.Controls.Add(lblModel);
            pnlTop.Controls.Add(txtModel);
            pnlTop.Controls.Add(lblChunkSize);
            pnlTop.Controls.Add(numChunkSize);
            pnlTop.Controls.Add(btnAnalyze);
            pnlTop.Controls.Add(btnCancel);
            pnlTop.Controls.Add(progressBar);
            pnlTop.Controls.Add(lblStatus);

            // dgvChanges - columnas
            colApply.HeaderText = "Aplicar";
            colApply.Width = 60;
            colApply.Name = "colApply";

            colNumber.HeaderText = "#";
            colNumber.Width = 55;
            colNumber.Name = "colNumber";
            colNumber.ReadOnly = true;

            colOriginal.HeaderText = "Texto original";
            colOriginal.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            colOriginal.FillWeight = 50;
            colOriginal.Name = "colOriginal";
            colOriginal.ReadOnly = true;
            colOriginal.DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;

            colProposed.HeaderText = "Texto propuesto por IA";
            colProposed.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            colProposed.FillWeight = 50;
            colProposed.Name = "colProposed";
            colProposed.ReadOnly = true;
            colProposed.DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            colProposed.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(255, 253, 231);

            dgvChanges.Columns.AddRange(colApply, colNumber, colOriginal, colProposed);
            dgvChanges.Dock = System.Windows.Forms.DockStyle.Fill;
            dgvChanges.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            dgvChanges.BackgroundColor = System.Drawing.Color.White;
            dgvChanges.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dgvChanges.RowHeadersVisible = false;
            dgvChanges.AllowUserToAddRows = false;
            dgvChanges.AllowUserToDeleteRows = false;
            dgvChanges.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            dgvChanges.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            dgvChanges.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            dgvChanges.ColumnHeadersHeight = 30;
            dgvChanges.CellValueChanged += dgvChanges_CellValueChanged;
            dgvChanges.CurrentCellDirtyStateChanged += dgvChanges_CurrentCellDirtyStateChanged;

            // pnlBottom
            pnlBottom.BackColor = System.Drawing.Color.FromArgb(240, 240, 245);
            pnlBottom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            pnlBottom.Size = new System.Drawing.Size(1200, 50);
            pnlBottom.Padding = new System.Windows.Forms.Padding(10, 8, 10, 8);

            lblStats.AutoSize = true;
            lblStats.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            lblStats.Location = new System.Drawing.Point(15, 14);
            lblStats.Text = "Sin cambios";

            btnSelectAll.BackColor = System.Drawing.Color.FromArgb(100, 149, 237);
            btnSelectAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnSelectAll.ForeColor = System.Drawing.Color.White;
            btnSelectAll.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            btnSelectAll.Location = new System.Drawing.Point(700, 10);
            btnSelectAll.Size = new System.Drawing.Size(120, 28);
            btnSelectAll.Text = "Seleccionar todo";
            btnSelectAll.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnSelectAll.Click += btnSelectAll_Click;

            btnSelectNone.BackColor = System.Drawing.Color.FromArgb(150, 150, 150);
            btnSelectNone.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnSelectNone.ForeColor = System.Drawing.Color.White;
            btnSelectNone.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            btnSelectNone.Location = new System.Drawing.Point(830, 10);
            btnSelectNone.Size = new System.Drawing.Size(120, 28);
            btnSelectNone.Text = "Deseleccionar";
            btnSelectNone.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnSelectNone.Click += btnSelectNone_Click;

            btnApply.BackColor = System.Drawing.Color.FromArgb(255, 140, 0);
            btnApply.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnApply.ForeColor = System.Drawing.Color.White;
            btnApply.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            btnApply.Location = new System.Drawing.Point(960, 8);
            btnApply.Size = new System.Drawing.Size(200, 32);
            btnApply.Text = "✔ Aplicar seleccionados";
            btnApply.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnApply.Enabled = false;
            btnApply.Click += btnApply_Click;

            pnlBottom.Controls.Add(lblStats);
            pnlBottom.Controls.Add(btnSelectAll);
            pnlBottom.Controls.Add(btnSelectNone);
            pnlBottom.Controls.Add(btnApply);

            // Form
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.FromArgb(245, 245, 250);
            ClientSize = new System.Drawing.Size(1200, 750);
            Controls.Add(dgvChanges);
            Controls.Add(pnlBottom);
            Controls.Add(pnlTop);
            MinimumSize = new System.Drawing.Size(900, 600);
            Name = "AiReviewForm";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "🤖 Revisar SRT con IA — SubCaptionAI";

            pnlTop.ResumeLayout(false);
            pnlTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvChanges).EndInit();
            ((System.ComponentModel.ISupportInitialize)numChunkSize).EndInit();
            pnlBottom.ResumeLayout(false);
            pnlBottom.PerformLayout();
            ResumeLayout(false);
        }
    }
}
