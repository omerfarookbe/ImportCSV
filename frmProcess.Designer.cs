namespace ImportCSV
{
    partial class frmImport
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dialogFileImport = new System.Windows.Forms.OpenFileDialog();
            this.btnImport = new System.Windows.Forms.Button();
            this.lblProgress = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // dialogFileImport
            // 
            this.dialogFileImport.FileOk += new System.ComponentModel.CancelEventHandler(this.dialogFileImport_FileOk);
            // 
            // btnImport
            // 
            this.btnImport.Location = new System.Drawing.Point(241, 75);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(170, 41);
            this.btnImport.TabIndex = 0;
            this.btnImport.Text = "Import";
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // lblProgress
            // 
            this.lblProgress.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblProgress.Location = new System.Drawing.Point(0, 196);
            this.lblProgress.Name = "lblProgress";
            this.lblProgress.Size = new System.Drawing.Size(646, 20);
            this.lblProgress.TabIndex = 1;
            this.lblProgress.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmImport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(646, 216);
            this.Controls.Add(this.lblProgress);
            this.Controls.Add(this.btnImport);
            this.Font = new System.Drawing.Font("Arial", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmImport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Import CSV to Warehouse";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmImport_FormClosing);
            this.Load += new System.EventHandler(this.frmImport_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog dialogFileImport;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.Label lblProgress;
    }
}

