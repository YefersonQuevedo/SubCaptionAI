namespace WhisperTranscriber
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        // --- Controles ---
        private System.Windows.Forms.Label lblPython;
        private System.Windows.Forms.TextBox txtPythonPath;
        private System.Windows.Forms.Label lblScript;
        private System.Windows.Forms.TextBox txtScriptPath;
        private System.Windows.Forms.Label lblOut;
        private System.Windows.Forms.TextBox txtOutDir;
        private System.Windows.Forms.Button btnOutDir;
        private System.Windows.Forms.Label lblModel;
        private System.Windows.Forms.ComboBox cmbModel;
        private System.Windows.Forms.Label lblDevice;
        private System.Windows.Forms.ComboBox cmbDevice;
        private System.Windows.Forms.Label lblMode;
        private System.Windows.Forms.ComboBox cmbMode;
        private System.Windows.Forms.Button btnAddFiles;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnTranscribe;
        private System.Windows.Forms.ListView lvFiles;
        private System.Windows.Forms.TextBox txtLog;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  NO modifiques a mano fuera de este bloque.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();

            var panel1 = new System.Windows.Forms.Panel();
            var panel2 = new System.Windows.Forms.Panel();
            var lblFilesTitle = new System.Windows.Forms.Label();
            var lblLogTitle = new System.Windows.Forms.Label();

            lblPython = new System.Windows.Forms.Label();
            txtPythonPath = new System.Windows.Forms.TextBox();
            lblScript = new System.Windows.Forms.Label();
            txtScriptPath = new System.Windows.Forms.TextBox();
            lblOut = new System.Windows.Forms.Label();
            txtOutDir = new System.Windows.Forms.TextBox();
            btnOutDir = new System.Windows.Forms.Button();
            lblModel = new System.Windows.Forms.Label();
            cmbModel = new System.Windows.Forms.ComboBox();
            lblDevice = new System.Windows.Forms.Label();
            cmbDevice = new System.Windows.Forms.ComboBox();
            lblMode = new System.Windows.Forms.Label();
            cmbMode = new System.Windows.Forms.ComboBox();
            btnAddFiles = new System.Windows.Forms.Button();
            btnRemove = new System.Windows.Forms.Button();
            btnTranscribe = new System.Windows.Forms.Button();
            lvFiles = new System.Windows.Forms.ListView();
            txtLog = new System.Windows.Forms.TextBox();

            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();

            // panel1 - Panel superior de configuración
            panel1.BackColor = System.Drawing.Color.FromArgb(240, 240, 245);
            panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            panel1.Dock = System.Windows.Forms.DockStyle.Top;
            panel1.Location = new System.Drawing.Point(0, 0);
            panel1.Name = "panel1";
            panel1.Padding = new System.Windows.Forms.Padding(15);
            panel1.Size = new System.Drawing.Size(1000, 190);

            // lblPython
            lblPython.AutoSize = true;
            lblPython.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            lblPython.ForeColor = System.Drawing.Color.FromArgb(50, 50, 50);
            lblPython.Location = new System.Drawing.Point(15, 18);
            lblPython.Name = "lblPython";
            lblPython.Size = new System.Drawing.Size(140, 15);
            lblPython.Text = "Python (python.exe):";

            // txtPythonPath
            txtPythonPath.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
            txtPythonPath.Font = new System.Drawing.Font("Consolas", 9F);
            txtPythonPath.Location = new System.Drawing.Point(180, 15);
            txtPythonPath.Name = "txtPythonPath";
            txtPythonPath.Size = new System.Drawing.Size(785, 22);
            txtPythonPath.Text = "python";

            // lblScript
            lblScript.AutoSize = true;
            lblScript.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            lblScript.ForeColor = System.Drawing.Color.FromArgb(50, 50, 50);
            lblScript.Location = new System.Drawing.Point(15, 50);
            lblScript.Name = "lblScript";
            lblScript.Size = new System.Drawing.Size(135, 15);
            lblScript.Text = "Script (transcribe.py):";

            // txtScriptPath
            txtScriptPath.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
            txtScriptPath.Font = new System.Drawing.Font("Consolas", 9F);
            txtScriptPath.Location = new System.Drawing.Point(180, 47);
            txtScriptPath.Name = "txtScriptPath";
            txtScriptPath.Size = new System.Drawing.Size(785, 22);

            // lblOut
            lblOut.AutoSize = true;
            lblOut.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            lblOut.ForeColor = System.Drawing.Color.FromArgb(50, 50, 50);
            lblOut.Location = new System.Drawing.Point(15, 82);
            lblOut.Name = "lblOut";
            lblOut.Size = new System.Drawing.Size(100, 15);
            lblOut.Text = "Carpeta salida:";

            // txtOutDir
            txtOutDir.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
            txtOutDir.Font = new System.Drawing.Font("Consolas", 9F);
            txtOutDir.Location = new System.Drawing.Point(180, 79);
            txtOutDir.Name = "txtOutDir";
            txtOutDir.Size = new System.Drawing.Size(680, 22);

            // btnOutDir
            btnOutDir.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
            btnOutDir.BackColor = System.Drawing.Color.FromArgb(70, 130, 180);
            btnOutDir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnOutDir.ForeColor = System.Drawing.Color.White;
            btnOutDir.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            btnOutDir.Location = new System.Drawing.Point(868, 77);
            btnOutDir.Name = "btnOutDir";
            btnOutDir.Size = new System.Drawing.Size(97, 26);
            btnOutDir.Text = "Elegir...";
            btnOutDir.UseVisualStyleBackColor = false;
            btnOutDir.Click += btnOutDir_Click;

            // lblModel
            lblModel.AutoSize = true;
            lblModel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            lblModel.ForeColor = System.Drawing.Color.FromArgb(50, 50, 50);
            lblModel.Location = new System.Drawing.Point(15, 118);
            lblModel.Name = "lblModel";
            lblModel.Size = new System.Drawing.Size(54, 15);
            lblModel.Text = "Modelo:";

            // cmbModel
            cmbModel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cmbModel.Font = new System.Drawing.Font("Segoe UI", 9F);
            cmbModel.Location = new System.Drawing.Point(180, 115);
            cmbModel.Name = "cmbModel";
            cmbModel.Size = new System.Drawing.Size(180, 23);

            // lblDevice
            lblDevice.AutoSize = true;
            lblDevice.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            lblDevice.ForeColor = System.Drawing.Color.FromArgb(50, 50, 50);
            lblDevice.Location = new System.Drawing.Point(390, 118);
            lblDevice.Name = "lblDevice";
            lblDevice.Size = new System.Drawing.Size(75, 15);
            lblDevice.Text = "Dispositivo:";

            // cmbDevice
            cmbDevice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cmbDevice.Font = new System.Drawing.Font("Segoe UI", 9F);
            cmbDevice.Location = new System.Drawing.Point(475, 115);
            cmbDevice.Name = "cmbDevice";
            cmbDevice.Size = new System.Drawing.Size(180, 23);

            // lblMode
            lblMode.AutoSize = true;
            lblMode.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            lblMode.ForeColor = System.Drawing.Color.FromArgb(50, 50, 50);
            lblMode.Location = new System.Drawing.Point(665, 118);
            lblMode.Name = "lblMode";
            lblMode.Text = "Modo:";

            // cmbMode
            cmbMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cmbMode.Font = new System.Drawing.Font("Segoe UI", 9F);
            cmbMode.Location = new System.Drawing.Point(720, 115);
            cmbMode.Name = "cmbMode";
            cmbMode.Size = new System.Drawing.Size(245, 23);
            cmbMode.SelectedIndexChanged += cmbMode_SelectedIndexChanged;

            // btnAddFiles
            btnAddFiles.BackColor = System.Drawing.Color.FromArgb(60, 179, 113);
            btnAddFiles.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnAddFiles.ForeColor = System.Drawing.Color.White;
            btnAddFiles.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            btnAddFiles.Location = new System.Drawing.Point(15, 150);
            btnAddFiles.Name = "btnAddFiles";
            btnAddFiles.Size = new System.Drawing.Size(160, 32);
            btnAddFiles.Text = "➕ Agregar archivos";
            btnAddFiles.UseVisualStyleBackColor = false;
            btnAddFiles.Click += btnAddFiles_Click;

            // btnRemove
            btnRemove.BackColor = System.Drawing.Color.FromArgb(220, 20, 60);
            btnRemove.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnRemove.ForeColor = System.Drawing.Color.White;
            btnRemove.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            btnRemove.Location = new System.Drawing.Point(185, 150);
            btnRemove.Name = "btnRemove";
            btnRemove.Size = new System.Drawing.Size(175, 32);
            btnRemove.Text = "➖ Quitar seleccionados";
            btnRemove.UseVisualStyleBackColor = false;
            btnRemove.Click += btnRemove_Click;

            // btnTranscribe
            btnTranscribe.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
            btnTranscribe.BackColor = System.Drawing.Color.FromArgb(255, 140, 0);
            btnTranscribe.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnTranscribe.ForeColor = System.Drawing.Color.White;
            btnTranscribe.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            btnTranscribe.Location = new System.Drawing.Point(803, 148);
            btnTranscribe.Name = "btnTranscribe";
            btnTranscribe.Size = new System.Drawing.Size(162, 34);
            btnTranscribe.Text = "▶ TRANSCRIBIR";
            btnTranscribe.UseVisualStyleBackColor = false;
            btnTranscribe.Click += btnTranscribe_Click;

            // panel2 - Panel de archivos
            panel2.BackColor = System.Drawing.Color.White;
            panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            panel2.Dock = System.Windows.Forms.DockStyle.Top;
            panel2.Location = new System.Drawing.Point(0, 190);
            panel2.Name = "panel2";
            panel2.Padding = new System.Windows.Forms.Padding(15, 10, 15, 10);
            panel2.Size = new System.Drawing.Size(1000, 220);

            // lblFilesTitle
            lblFilesTitle.AutoSize = true;
            lblFilesTitle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            lblFilesTitle.ForeColor = System.Drawing.Color.FromArgb(50, 50, 50);
            lblFilesTitle.Location = new System.Drawing.Point(15, 12);
            lblFilesTitle.Name = "lblFilesTitle";
            lblFilesTitle.Size = new System.Drawing.Size(150, 19);
            lblFilesTitle.Text = "📁 Archivos a transcribir";

            // lvFiles
            lvFiles.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
            lvFiles.BackColor = System.Drawing.Color.FromArgb(250, 250, 252);
            lvFiles.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            lvFiles.Font = new System.Drawing.Font("Segoe UI", 9F);
            lvFiles.FullRowSelect = true;
            lvFiles.GridLines = true;
            lvFiles.Location = new System.Drawing.Point(15, 38);
            lvFiles.Name = "lvFiles";
            lvFiles.Size = new System.Drawing.Size(950, 156);
            lvFiles.View = System.Windows.Forms.View.Details;

            // Agregar columnas al ListView
            lvFiles.Columns.Add("Archivo", 500, System.Windows.Forms.HorizontalAlignment.Left);
            lvFiles.Columns.Add("Estado", 200, System.Windows.Forms.HorizontalAlignment.Left);
            lvFiles.Columns.Add("Progreso", 230, System.Windows.Forms.HorizontalAlignment.Left);

            // lblLogTitle
            lblLogTitle.AutoSize = true;
            lblLogTitle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            lblLogTitle.ForeColor = System.Drawing.Color.FromArgb(50, 50, 50);
            lblLogTitle.Location = new System.Drawing.Point(15, 420);
            lblLogTitle.Name = "lblLogTitle";
            lblLogTitle.Size = new System.Drawing.Size(100, 19);
            lblLogTitle.Text = "📋 Registro";

            // txtLog
            txtLog.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
            txtLog.BackColor = System.Drawing.Color.FromArgb(30, 30, 30);
            txtLog.ForeColor = System.Drawing.Color.FromArgb(220, 220, 220);
            txtLog.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txtLog.Font = new System.Drawing.Font("Consolas", 9F);
            txtLog.Location = new System.Drawing.Point(15, 445);
            txtLog.Multiline = true;
            txtLog.Name = "txtLog";
            txtLog.ReadOnly = true;
            txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            txtLog.Size = new System.Drawing.Size(970, 235);
            txtLog.WordWrap = false;

            // Agregar controles a panel1
            panel1.Controls.Add(lblPython);
            panel1.Controls.Add(txtPythonPath);
            panel1.Controls.Add(lblScript);
            panel1.Controls.Add(txtScriptPath);
            panel1.Controls.Add(lblOut);
            panel1.Controls.Add(txtOutDir);
            panel1.Controls.Add(btnOutDir);
            panel1.Controls.Add(lblModel);
            panel1.Controls.Add(cmbModel);
            panel1.Controls.Add(lblDevice);
            panel1.Controls.Add(cmbDevice);
            panel1.Controls.Add(lblMode);
            panel1.Controls.Add(cmbMode);
            panel1.Controls.Add(btnAddFiles);
            panel1.Controls.Add(btnRemove);
            panel1.Controls.Add(btnTranscribe);

            // Agregar controles a panel2
            panel2.Controls.Add(lblFilesTitle);
            panel2.Controls.Add(lvFiles);

            // Form1
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.FromArgb(245, 245, 250);
            ClientSize = new System.Drawing.Size(1000, 700);
            Controls.Add(panel1);
            Controls.Add(panel2);
            Controls.Add(lblLogTitle);
            Controls.Add(txtLog);
            MinimumSize = new System.Drawing.Size(900, 600);
            Name = "Form1";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "🎤 Whisper Transcriber - AI Transcription";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
    }
}
