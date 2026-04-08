namespace Interface
{
    partial class FrmPraticienModification
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPraticienModification));
            panelCentral = new Panel();
            cbxPraticien = new ComboBox();
            label9 = new Label();
            btnModifier = new Button();
            btnSupprimer = new Button();
            messageSpecialite = new Label();
            label8 = new Label();
            cbxSpecialite = new ComboBox();
            messageEmail = new Label();
            label6 = new Label();
            txtEmail = new TextBox();
            label7 = new Label();
            cbxType = new ComboBox();
            messageTelephone = new Label();
            label5 = new Label();
            mtbTelephone = new MaskedTextBox();
            messageVille = new Label();
            label4 = new Label();
            cbxVille = new ComboBox();
            messageRue = new Label();
            label3 = new Label();
            txtRue = new TextBox();
            messagePrenom = new Label();
            label2 = new Label();
            txtPrenom = new TextBox();
            label1 = new Label();
            txtNom = new TextBox();
            messageNom = new Label();
            panelCentral.SuspendLayout();
            SuspendLayout();
            // 
            // lblTitre
            // 
            lblTitre.Size = new Size(1141, 74);
            // 
            // panelCentral
            // 
            panelCentral.Controls.Add(cbxPraticien);
            panelCentral.Controls.Add(label9);
            panelCentral.Controls.Add(btnModifier);
            panelCentral.Controls.Add(btnSupprimer);
            panelCentral.Controls.Add(messageSpecialite);
            panelCentral.Controls.Add(label8);
            panelCentral.Controls.Add(cbxSpecialite);
            panelCentral.Controls.Add(messageEmail);
            panelCentral.Controls.Add(label6);
            panelCentral.Controls.Add(txtEmail);
            panelCentral.Controls.Add(label7);
            panelCentral.Controls.Add(cbxType);
            panelCentral.Controls.Add(messageTelephone);
            panelCentral.Controls.Add(label5);
            panelCentral.Controls.Add(mtbTelephone);
            panelCentral.Controls.Add(messageVille);
            panelCentral.Controls.Add(label4);
            panelCentral.Controls.Add(cbxVille);
            panelCentral.Controls.Add(messageRue);
            panelCentral.Controls.Add(label3);
            panelCentral.Controls.Add(txtRue);
            panelCentral.Controls.Add(messagePrenom);
            panelCentral.Controls.Add(label2);
            panelCentral.Controls.Add(txtPrenom);
            panelCentral.Controls.Add(label1);
            panelCentral.Controls.Add(txtNom);
            panelCentral.Controls.Add(messageNom);
            panelCentral.Location = new Point(108, 101);
            panelCentral.Name = "panelCentral";
            panelCentral.Size = new Size(946, 500);
            panelCentral.TabIndex = 13;
            // 
            // cbxPraticien
            // 
            cbxPraticien.FormattingEnabled = true;
            cbxPraticien.Location = new Point(64, 41);
            cbxPraticien.Name = "cbxPraticien";
            cbxPraticien.Size = new Size(810, 23);
            cbxPraticien.TabIndex = 1;
            cbxPraticien.SelectedIndexChanged += cbxPraticien_SelectedIndexChanged;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(64, 23);
            label9.Name = "label9";
            label9.Size = new Size(108, 15);
            label9.TabIndex = 0;
            label9.Text = "Praticien recherché";
            // 
            // btnModifier
            // 
            btnModifier.BackColor = Color.White;
            btnModifier.ForeColor = SystemColors.ActiveCaption;
            btnModifier.Location = new Point(64, 445);
            btnModifier.Name = "btnModifier";
            btnModifier.Size = new Size(269, 35);
            btnModifier.TabIndex = 17;
            btnModifier.Text = "Modifier la fiche du praticien";
            btnModifier.UseVisualStyleBackColor = false;
            btnModifier.Click += btnModifier_Click;
            // 
            // btnSupprimer
            // 
            btnSupprimer.BackColor = Color.White;
            btnSupprimer.ForeColor = Color.Red;
            btnSupprimer.Location = new Point(605, 445);
            btnSupprimer.Name = "btnSupprimer";
            btnSupprimer.Size = new Size(269, 35);
            btnSupprimer.TabIndex = 18;
            btnSupprimer.Text = "Supprimer la fiche du praticien";
            btnSupprimer.UseVisualStyleBackColor = false;
            btnSupprimer.Click += btnSupprimer_Click;
            // 
            // messageSpecialite
            // 
            messageSpecialite.AutoSize = true;
            messageSpecialite.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            messageSpecialite.ForeColor = Color.Red;
            messageSpecialite.Location = new Point(605, 401);
            messageSpecialite.Name = "messageSpecialite";
            messageSpecialite.Size = new Size(30, 15);
            messageSpecialite.TabIndex = 16;
            messageSpecialite.Text = "msg";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(605, 357);
            label8.Name = "label8";
            label8.Size = new Size(57, 15);
            label8.TabIndex = 14;
            label8.Text = "Spécialité";
            // 
            // cbxSpecialite
            // 
            cbxSpecialite.FormattingEnabled = true;
            cbxSpecialite.Location = new Point(605, 375);
            cbxSpecialite.Name = "cbxSpecialite";
            cbxSpecialite.Size = new Size(269, 23);
            cbxSpecialite.TabIndex = 15;
            // 
            // messageEmail
            // 
            messageEmail.AutoSize = true;
            messageEmail.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            messageEmail.ForeColor = Color.Red;
            messageEmail.Location = new Point(605, 327);
            messageEmail.Name = "messageEmail";
            messageEmail.Size = new Size(30, 15);
            messageEmail.TabIndex = 13;
            messageEmail.Text = "msg";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(605, 283);
            label6.Name = "label6";
            label6.Size = new Size(36, 15);
            label6.TabIndex = 11;
            label6.Text = "Email";
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(605, 301);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(269, 23);
            txtEmail.TabIndex = 12;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(64, 357);
            label7.Name = "label7";
            label7.Size = new Size(31, 15);
            label7.TabIndex = 9;
            label7.Text = "Type";
            // 
            // cbxType
            // 
            cbxType.FormattingEnabled = true;
            cbxType.Location = new Point(64, 375);
            cbxType.Name = "cbxType";
            cbxType.Size = new Size(286, 23);
            cbxType.TabIndex = 10;
            // 
            // messageTelephone
            // 
            messageTelephone.AutoSize = true;
            messageTelephone.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            messageTelephone.ForeColor = Color.Red;
            messageTelephone.Location = new Point(64, 327);
            messageTelephone.Name = "messageTelephone";
            messageTelephone.Size = new Size(30, 15);
            messageTelephone.TabIndex = 8;
            messageTelephone.Text = "msg";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(64, 283);
            label5.Name = "label5";
            label5.Size = new Size(61, 15);
            label5.TabIndex = 6;
            label5.Text = "Téléphone";
            // 
            // mtbTelephone
            // 
            mtbTelephone.Location = new Point(64, 301);
            mtbTelephone.Mask = "00 00 00 00 00 00";
            mtbTelephone.Name = "mtbTelephone";
            mtbTelephone.Size = new Size(286, 23);
            mtbTelephone.TabIndex = 7;
            // 
            // messageVille
            // 
            messageVille.AutoSize = true;
            messageVille.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            messageVille.ForeColor = Color.Red;
            messageVille.Location = new Point(64, 257);
            messageVille.Name = "messageVille";
            messageVille.Size = new Size(30, 15);
            messageVille.TabIndex = 5;
            messageVille.Text = "msg";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(64, 213);
            label4.Name = "label4";
            label4.Size = new Size(29, 15);
            label4.TabIndex = 3;
            label4.Text = "Ville";
            // 
            // cbxVille
            // 
            cbxVille.FormattingEnabled = true;
            cbxVille.Location = new Point(64, 231);
            cbxVille.Name = "cbxVille";
            cbxVille.Size = new Size(384, 23);
            cbxVille.TabIndex = 4;
            // 
            // messageRue
            // 
            messageRue.AutoSize = true;
            messageRue.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            messageRue.ForeColor = Color.Red;
            messageRue.Location = new Point(64, 187);
            messageRue.Name = "messageRue";
            messageRue.Size = new Size(30, 15);
            messageRue.TabIndex = 2;
            messageRue.Text = "msg";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(64, 143);
            label3.Name = "label3";
            label3.Size = new Size(27, 15);
            label3.TabIndex = 0;
            label3.Text = "Rue";
            // 
            // txtRue
            // 
            txtRue.Location = new Point(64, 161);
            txtRue.Name = "txtRue";
            txtRue.Size = new Size(384, 23);
            txtRue.TabIndex = 1;
            // 
            // messagePrenom
            // 
            messagePrenom.AutoSize = true;
            messagePrenom.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            messagePrenom.ForeColor = Color.Red;
            messagePrenom.Location = new Point(605, 117);
            messagePrenom.Name = "messagePrenom";
            messagePrenom.Size = new Size(30, 15);
            messagePrenom.TabIndex = 8;
            messagePrenom.Text = "msg";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(605, 73);
            label2.Name = "label2";
            label2.Size = new Size(49, 15);
            label2.TabIndex = 6;
            label2.Text = "Prénom";
            // 
            // txtPrenom
            // 
            txtPrenom.Location = new Point(605, 91);
            txtPrenom.Name = "txtPrenom";
            txtPrenom.Size = new Size(269, 23);
            txtPrenom.TabIndex = 7;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(64, 73);
            label1.Name = "label1";
            label1.Size = new Size(34, 15);
            label1.TabIndex = 4;
            label1.Text = "Nom";
            // 
            // txtNom
            // 
            txtNom.Location = new Point(64, 91);
            txtNom.Name = "txtNom";
            txtNom.Size = new Size(286, 23);
            txtNom.TabIndex = 5;
            // 
            // messageNom
            // 
            messageNom.AutoSize = true;
            messageNom.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            messageNom.ForeColor = Color.Red;
            messageNom.Location = new Point(64, 117);
            messageNom.Name = "messageNom";
            messageNom.Size = new Size(30, 15);
            messageNom.TabIndex = 7;
            messageNom.Text = "msg";
            // 
            // FrmPraticienModification
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1141, 676);
            Controls.Add(panelCentral);
            Icon = (Icon)resources.GetObject("$this.Icon");
            KeyPreview = true;
            Location = new Point(0, 0);
            Name = "FrmPraticienModification";
            Text = "Modification d'un praticien";
            Load += FrmPraticienModification_Load;
            Resize += FrmPraticienModification_Resize;
            Controls.SetChildIndex(lblTitre, 0);
            Controls.SetChildIndex(panelCentral, 0);
            panelCentral.ResumeLayout(false);
            panelCentral.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panelCentral;
        private Label label3;
        private TextBox txtRue;
        private Label messagePrenom;
        private Label label2;
        private TextBox txtPrenom;
        private Label label1;
        private TextBox txtNom;
        private Label messageNom;
        private Label label4;
        private ComboBox cbxVille;
        private Label messageRue;
        private Label messageVille;
        private Button btnSupprimer;
        private Label messageSpecialite;
        private Label label8;
        private ComboBox cbxSpecialite;
        private Label messageEmail;
        private Label label6;
        private TextBox txtEmail;
        private Label label7;
        private ComboBox cbxType;
        private Label messageTelephone;
        private Label label5;
        private MaskedTextBox mtbTelephone;
        private Button btnModifier;
        private ComboBox cbxPraticien;
        private Label label9;
    }
}