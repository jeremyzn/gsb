namespace Interface
{
    partial class FrmVisiteConsultation
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmVisiteConsultation));
            panelCentral = new Panel();
            label6 = new Label();
            lblBilan = new Label();
            lstMedicament = new ListBox();
            dgvEchantillon = new DataGridView();
            label5 = new Label();
            label4 = new Label();
            lblMotif = new Label();
            label3 = new Label();
            label2 = new Label();
            panelPraticien = new Panel();
            lblSpecialite = new Label();
            lblType = new Label();
            lblEmail = new Label();
            lblTelephone = new Label();
            lblRue = new Label();
            lblPraticien = new Label();
            label1 = new Label();
            dgvVisites = new DataGridView();
            panelMedicament = new Panel();
            printRendezVous = new System.Drawing.Printing.PrintDocument();
            choixImprimante = new PrintDialog();
            apercuRendezVous = new PrintPreviewDialog();
            panelCentral.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvEchantillon).BeginInit();
            panelPraticien.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvVisites).BeginInit();
            SuspendLayout();
            // 
            // lblTitre
            // 
            lblTitre.Size = new Size(1066, 74);
            // 
            // panelCentral
            // 
            panelCentral.Controls.Add(label6);
            panelCentral.Controls.Add(lblBilan);
            panelCentral.Controls.Add(lstMedicament);
            panelCentral.Controls.Add(dgvEchantillon);
            panelCentral.Controls.Add(label5);
            panelCentral.Controls.Add(label4);
            panelCentral.Controls.Add(lblMotif);
            panelCentral.Controls.Add(label3);
            panelCentral.Controls.Add(label2);
            panelCentral.Controls.Add(panelPraticien);
            panelCentral.Controls.Add(label1);
            panelCentral.Controls.Add(dgvVisites);
            panelCentral.Location = new Point(12, 88);
            panelCentral.Name = "panelCentral";
            panelCentral.Size = new Size(1042, 409);
            panelCentral.TabIndex = 13;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.Location = new Point(482, 289);
            label6.Name = "label6";
            label6.Size = new Size(140, 15);
            label6.TabIndex = 15;
            label6.Text = "Médicaments présentés";
            // 
            // lblBilan
            // 
            lblBilan.BorderStyle = BorderStyle.FixedSingle;
            lblBilan.Location = new Point(482, 219);
            lblBilan.Name = "lblBilan";
            lblBilan.Size = new Size(235, 55);
            lblBilan.TabIndex = 13;
            // 
            // lstMedicament
            // 
            lstMedicament.FormattingEnabled = true;
            lstMedicament.IntegralHeight = false;
            lstMedicament.Location = new Point(482, 307);
            lstMedicament.Name = "lstMedicament";
            lstMedicament.Size = new Size(235, 56);
            lstMedicament.TabIndex = 12;
            // 
            // dgvEchantillon
            // 
            dgvEchantillon.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvEchantillon.Location = new Point(737, 219);
            dgvEchantillon.Name = "dgvEchantillon";
            dgvEchantillon.Size = new Size(302, 167);
            dgvEchantillon.TabIndex = 11;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(737, 201);
            label5.Name = "label5";
            label5.Size = new Size(111, 15);
            label5.TabIndex = 10;
            label5.Text = "Echantillons fournis";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(482, 201);
            label4.Name = "label4";
            label4.Size = new Size(96, 15);
            label4.TabIndex = 9;
            label4.Text = "Bilan de la visite";
            // 
            // lblMotif
            // 
            lblMotif.AutoEllipsis = true;
            lblMotif.Location = new Point(538, 170);
            lblMotif.Name = "lblMotif";
            lblMotif.Size = new Size(497, 23);
            lblMotif.TabIndex = 8;
            lblMotif.Text = "label4";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(482, 170);
            label3.Name = "label3";
            label3.Size = new Size(38, 15);
            label3.TabIndex = 7;
            label3.Text = "Motif";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(482, 21);
            label2.Name = "label2";
            label2.Size = new Size(56, 15);
            label2.TabIndex = 6;
            label2.Text = "Praticien";
            // 
            // panelPraticien
            // 
            panelPraticien.Controls.Add(lblSpecialite);
            panelPraticien.Controls.Add(lblType);
            panelPraticien.Controls.Add(lblEmail);
            panelPraticien.Controls.Add(lblTelephone);
            panelPraticien.Controls.Add(lblRue);
            panelPraticien.Controls.Add(lblPraticien);
            panelPraticien.Location = new Point(482, 39);
            panelPraticien.Name = "panelPraticien";
            panelPraticien.Size = new Size(555, 111);
            panelPraticien.TabIndex = 5;
            // 
            // lblSpecialite
            // 
            lblSpecialite.AutoEllipsis = true;
            lblSpecialite.Location = new Point(340, 33);
            lblSpecialite.Name = "lblSpecialite";
            lblSpecialite.Size = new Size(210, 49);
            lblSpecialite.TabIndex = 5;
            lblSpecialite.Text = "label5";
            // 
            // lblType
            // 
            lblType.AutoEllipsis = true;
            lblType.Location = new Point(340, 9);
            lblType.Name = "lblType";
            lblType.Size = new Size(210, 23);
            lblType.TabIndex = 4;
            lblType.Text = "label5";
            // 
            // lblEmail
            // 
            lblEmail.AutoEllipsis = true;
            lblEmail.Location = new Point(18, 85);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(330, 23);
            lblEmail.TabIndex = 3;
            lblEmail.Text = "label5";
            // 
            // lblTelephone
            // 
            lblTelephone.AutoEllipsis = true;
            lblTelephone.Location = new Point(18, 58);
            lblTelephone.Name = "lblTelephone";
            lblTelephone.Size = new Size(330, 23);
            lblTelephone.TabIndex = 2;
            lblTelephone.Text = "label5";
            // 
            // lblRue
            // 
            lblRue.AutoEllipsis = true;
            lblRue.Location = new Point(18, 33);
            lblRue.Name = "lblRue";
            lblRue.Size = new Size(330, 23);
            lblRue.TabIndex = 1;
            lblRue.Text = "label5";
            // 
            // lblPraticien
            // 
            lblPraticien.AutoEllipsis = true;
            lblPraticien.Location = new Point(18, 9);
            lblPraticien.Name = "lblPraticien";
            lblPraticien.Size = new Size(330, 23);
            lblPraticien.TabIndex = 0;
            lblPraticien.Text = "label5";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(14, 10);
            label1.Name = "label1";
            label1.Size = new Size(229, 15);
            label1.TabIndex = 4;
            label1.Text = "Sélectionner la visite pour afficher le détail";
            // 
            // dgvVisites
            // 
            dgvVisites.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvVisites.Location = new Point(14, 26);
            dgvVisites.Name = "dgvVisites";
            dgvVisites.Size = new Size(293, 360);
            dgvVisites.TabIndex = 3;
            dgvVisites.SelectionChanged += dgvVisites_SelectionChanged;
            // 
            // panelMedicament
            // 
            panelMedicament.Location = new Point(429, 355);
            panelMedicament.Name = "panelMedicament";
            panelMedicament.Size = new Size(196, 31);
            panelMedicament.TabIndex = 14;
            // 
            // choixImprimante
            // 
            choixImprimante.UseEXDialog = true;
            // 
            // apercuRendezVous
            // 
            apercuRendezVous.AutoScrollMargin = new Size(0, 0);
            apercuRendezVous.AutoScrollMinSize = new Size(0, 0);
            apercuRendezVous.ClientSize = new Size(400, 300);
            apercuRendezVous.Enabled = true;
            apercuRendezVous.Icon = (Icon)resources.GetObject("apercuRendezVous.Icon");
            apercuRendezVous.Name = "apercuRendezVous";
            apercuRendezVous.Visible = false;
            // 
            // FrmVisiteConsultation
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1066, 549);
            Controls.Add(panelCentral);
            Icon = (Icon)resources.GetObject("$this.Icon");
            KeyPreview = true;
            Location = new Point(0, 0);
            Name = "FrmVisiteConsultation";
            Text = "FrmVisiteImpression";
            Load += FrmConsultation_Load;
            Resize += FrmVisiteConsultation_Resize;
            Controls.SetChildIndex(lblTitre, 0);
            Controls.SetChildIndex(panelCentral, 0);
            panelCentral.ResumeLayout(false);
            panelCentral.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvEchantillon).EndInit();
            panelPraticien.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvVisites).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panelCentral;
        private System.Drawing.Printing.PrintDocument printRendezVous;
        private PrintDialog choixImprimante;
        private PrintPreviewDialog apercuRendezVous;
        private Label label4;
        private Label lblMotif;
        private Label label3;
        private Label label2;
        private Panel panelPraticien;
        private Label label1;
        private DataGridView dgvVisites;
        private ListBox lstMedicament;
        private DataGridView dgvEchantillon;
        private Label label5;
        private Label lblSpecialite;
        private Label lblType;
        private Label lblEmail;
        private Label lblTelephone;
        private Label lblRue;
        private Label lblPraticien;
        private Label lblBilan;
        private Label label6;
        private Panel panelMedicament;
    }
}