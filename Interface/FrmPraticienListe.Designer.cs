namespace Interface
{
    partial class FrmPraticienListe
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPraticienListe));
            panelCentral = new Panel();
            dgvPraticiens = new DataGridView();
            panelCentral.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPraticiens).BeginInit();
            SuspendLayout();
            // 
            // lblTitre
            // 
            lblTitre.Size = new Size(1281, 74);
            // 
            // panelCentral
            // 
            panelCentral.Controls.Add(dgvPraticiens);
            panelCentral.Location = new Point(26, 98);
            panelCentral.Name = "panelCentral";
            panelCentral.Size = new Size(1229, 370);
            panelCentral.TabIndex = 13;
            // 
            // dgvPraticiens
            // 
            dgvPraticiens.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPraticiens.Location = new Point(0, 0);
            dgvPraticiens.Name = "dgvPraticiens";
            dgvPraticiens.Size = new Size(1229, 370);
            dgvPraticiens.TabIndex = 0;
            // 
            // FrmPraticienListe
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1281, 513);
            Controls.Add(panelCentral);
            Icon = (Icon)resources.GetObject("$this.Icon");
            KeyPreview = true;
            Location = new Point(0, 0);
            Name = "FrmPraticienListe";
            Text = "FrmPraticienListe";
            Load += FrmPraticienListe_Load;
            Resize += FrmPraticienListe_Resize;
            Controls.SetChildIndex(lblTitre, 0);
            Controls.SetChildIndex(panelCentral, 0);
            panelCentral.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvPraticiens).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panelCentral;
        private DataGridView dgvPraticiens;
    }
}