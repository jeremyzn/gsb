namespace Interface
{
    partial class FrmEnregistrerBilan
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmEnregistrerBilan));
            panel = new Panel();
            panelCentral = new Panel();
            panelDroite = new Panel();
            label6 = new Label();
            dgvEchantillon = new DataGridView();
            btnAjouter = new Button();
            label5 = new Label();
            cptQuantite = new NumericUpDown();
            cbxEchantillon = new ComboBox();
            label4 = new Label();
            label3 = new Label();
            panelGauche = new Panel();
            cbxSecondMedicament = new ComboBox();
            cbxPremierMedicament = new ComboBox();
            label7 = new Label();
            txtBilan = new TextBox();
            btnEnregistrer = new Button();
            label2 = new Label();
            label1 = new Label();
            panelHaut = new Panel();
            panel.SuspendLayout();
            panelCentral.SuspendLayout();
            panelDroite.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvEchantillon).BeginInit();
            ((System.ComponentModel.ISupportInitialize)cptQuantite).BeginInit();
            panelGauche.SuspendLayout();
            SuspendLayout();
            // 
            // lblTitre
            // 
            lblTitre.Size = new Size(1253, 74);
            // 
            // panel
            // 
            panel.BorderStyle = BorderStyle.FixedSingle;
            panel.Controls.Add(panelCentral);
            panel.Controls.Add(panelHaut);
            panel.Location = new Point(12, 90);
            panel.Name = "panel";
            panel.Size = new Size(1229, 449);
            panel.TabIndex = 13;
            // 
            // panelCentral
            // 
            panelCentral.Controls.Add(panelDroite);
            panelCentral.Controls.Add(panelGauche);
            panelCentral.Location = new Point(18, 92);
            panelCentral.Name = "panelCentral";
            panelCentral.Size = new Size(1206, 343);
            panelCentral.TabIndex = 1;
            // 
            // panelDroite
            // 
            panelDroite.Controls.Add(label6);
            panelDroite.Controls.Add(dgvEchantillon);
            panelDroite.Controls.Add(btnAjouter);
            panelDroite.Controls.Add(label5);
            panelDroite.Controls.Add(cptQuantite);
            panelDroite.Controls.Add(cbxEchantillon);
            panelDroite.Controls.Add(label4);
            panelDroite.Controls.Add(label3);
            panelDroite.Location = new Point(601, 17);
            panelDroite.Name = "panelDroite";
            panelDroite.Size = new Size(602, 323);
            panelDroite.TabIndex = 1;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(17, 81);
            label6.Name = "label6";
            label6.Size = new Size(181, 15);
            label6.TabIndex = 7;
            label6.Text = "Liste des médicaments distribués";
            // 
            // dgvEchantillon
            // 
            dgvEchantillon.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvEchantillon.Location = new Point(17, 99);
            dgvEchantillon.Name = "dgvEchantillon";
            dgvEchantillon.Size = new Size(564, 212);
            dgvEchantillon.TabIndex = 6;
            // 
            // btnAjouter
            // 
            btnAjouter.Location = new Point(350, 54);
            btnAjouter.Name = "btnAjouter";
            btnAjouter.Size = new Size(90, 23);
            btnAjouter.TabIndex = 5;
            btnAjouter.Text = "Ajouter";
            btnAjouter.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(250, 36);
            label5.Name = "label5";
            label5.Size = new Size(53, 15);
            label5.TabIndex = 4;
            label5.Text = "Quantité";
            // 
            // cptQuantite
            // 
            cptQuantite.Location = new Point(250, 54);
            cptQuantite.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            cptQuantite.Name = "cptQuantite";
            cptQuantite.Size = new Size(94, 23);
            cptQuantite.TabIndex = 3;
            cptQuantite.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // cbxEchantillon
            // 
            cbxEchantillon.FormattingEnabled = true;
            cbxEchantillon.Location = new Point(17, 54);
            cbxEchantillon.Name = "cbxEchantillon";
            cbxEchantillon.Size = new Size(227, 23);
            cbxEchantillon.TabIndex = 2;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(17, 36);
            label4.Name = "label4";
            label4.Size = new Size(74, 15);
            label4.TabIndex = 1;
            label4.Text = "Médicament";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(17, 14);
            label3.Name = "label3";
            label3.Size = new Size(125, 15);
            label3.TabIndex = 0;
            label3.Text = "Echantillons distribués";
            // 
            // panelGauche
            // 
            panelGauche.Controls.Add(cbxSecondMedicament);
            panelGauche.Controls.Add(cbxPremierMedicament);
            panelGauche.Controls.Add(label7);
            panelGauche.Controls.Add(txtBilan);
            panelGauche.Controls.Add(btnEnregistrer);
            panelGauche.Controls.Add(label2);
            panelGauche.Controls.Add(label1);
            panelGauche.Location = new Point(13, 17);
            panelGauche.Name = "panelGauche";
            panelGauche.Size = new Size(580, 323);
            panelGauche.TabIndex = 0;
            // 
            // cbxSecondMedicament
            // 
            cbxSecondMedicament.FormattingEnabled = true;
            cbxSecondMedicament.Location = new Point(391, 36);
            cbxSecondMedicament.Name = "cbxSecondMedicament";
            cbxSecondMedicament.Size = new Size(164, 23);
            cbxSecondMedicament.TabIndex = 6;
            // 
            // cbxPremierMedicament
            // 
            cbxPremierMedicament.FormattingEnabled = true;
            cbxPremierMedicament.Location = new Point(12, 36);
            cbxPremierMedicament.Name = "cbxPremierMedicament";
            cbxPremierMedicament.Size = new Size(166, 23);
            cbxPremierMedicament.TabIndex = 5;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(12, 81);
            label7.Name = "label7";
            label7.Size = new Size(91, 15);
            label7.TabIndex = 4;
            label7.Text = "Bilan de la visite";
            // 
            // txtBilan
            // 
            txtBilan.Location = new Point(12, 99);
            txtBilan.Multiline = true;
            txtBilan.Name = "txtBilan";
            txtBilan.Size = new Size(531, 173);
            txtBilan.TabIndex = 3;
            // 
            // btnEnregistrer
            // 
            btnEnregistrer.BackColor = Color.Red;
            btnEnregistrer.Location = new Point(404, 278);
            btnEnregistrer.Name = "btnEnregistrer";
            btnEnregistrer.Size = new Size(151, 33);
            btnEnregistrer.TabIndex = 2;
            btnEnregistrer.Text = "Enregistrer la fiche visite";
            btnEnregistrer.UseVisualStyleBackColor = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(391, 14);
            label2.Name = "label2";
            label2.Size = new Size(164, 15);
            label2.TabIndex = 1;
            label2.Text = "Second médicament présenté";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 14);
            label1.Name = "label1";
            label1.Size = new Size(166, 15);
            label1.TabIndex = 0;
            label1.Text = "Premier médicament présenté";
            // 
            // panelHaut
            // 
            panelHaut.BorderStyle = BorderStyle.FixedSingle;
            panelHaut.Location = new Point(18, 11);
            panelHaut.Name = "panelHaut";
            panelHaut.Size = new Size(1203, 75);
            panelHaut.TabIndex = 0;
            // 
            // FrmEnregistrerBilan
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1253, 590);
            Controls.Add(panel);
            Icon = (Icon)resources.GetObject("$this.Icon");
            KeyPreview = true;
            Location = new Point(0, 0);
            Name = "FrmEnregistrerBilan";
            Text = "FrmEnregistrerBilan";
            Load += FrmEnregistrerBilan_Load;
            Resize += FrmEnregistrerBilan_Resize;
            Controls.SetChildIndex(lblTitre, 0);
            Controls.SetChildIndex(panel, 0);
            panel.ResumeLayout(false);
            panelCentral.ResumeLayout(false);
            panelDroite.ResumeLayout(false);
            panelDroite.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvEchantillon).EndInit();
            ((System.ComponentModel.ISupportInitialize)cptQuantite).EndInit();
            panelGauche.ResumeLayout(false);
            panelGauche.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel;
        private Panel panelHaut;
        private Panel panelCentral;
        private Panel panelGauche;
        private Panel panelDroite;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private ComboBox cbxEchantillon;
        private Label label5;
        private NumericUpDown cptQuantite;
        private Button btnAjouter;
        private Label label6;
        private DataGridView dgvEchantillon;
        private Button btnEnregistrer;
        private TextBox txtBilan;
        private Label label7;
        private ComboBox cbxSecondMedicament;
        private ComboBox cbxPremierMedicament;
    }
}