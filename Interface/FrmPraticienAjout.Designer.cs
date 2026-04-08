namespace Interface
{
    partial class FrmPraticienAjout
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPraticienAjout));
            panelCentral = new Panel();
            btnAjouter = new Button();
            messageSpecialite = new Label();
            label8 = new Label();
            cbxSpecialite = new ComboBox();
            messageEmail = new Label();
            label6 = new Label();
            txtEmail = new TextBox();
            messageType = new Label();
            label7 = new Label();
            cbxType = new ComboBox();
            messageTelephone = new Label();
            label5 = new Label();
            mtbTelephone = new MaskedTextBox();
            messageVille = new Label();
            label4 = new Label();
            txtVille = new TextBox();
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
            panelCentral.Controls.Add(btnAjouter);
            panelCentral.Controls.Add(messageSpecialite);
            panelCentral.Controls.Add(label8);
            panelCentral.Controls.Add(cbxSpecialite);
            panelCentral.Controls.Add(messageEmail);
            panelCentral.Controls.Add(label6);
            panelCentral.Controls.Add(txtEmail);
            panelCentral.Controls.Add(messageType);
            panelCentral.Controls.Add(label7);
            panelCentral.Controls.Add(cbxType);
            panelCentral.Controls.Add(messageTelephone);
            panelCentral.Controls.Add(label5);
            panelCentral.Controls.Add(mtbTelephone);
            panelCentral.Controls.Add(messageVille);
            panelCentral.Controls.Add(label4);
            panelCentral.Controls.Add(txtVille);
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
            panelCentral.Size = new Size(946, 441);
            panelCentral.TabIndex = 13;
            // 
            // btnAjouter
            // 
            btnAjouter.BackColor = Color.Red;
            btnAjouter.Location = new Point(424, 383);
            btnAjouter.Name = "btnAjouter";
            btnAjouter.Size = new Size(110, 35);
            btnAjouter.TabIndex = 24;
            btnAjouter.Text = "Ajouter";
            btnAjouter.UseVisualStyleBackColor = false;
            btnAjouter.Click += btnAjouter_Click;
            // 
            // messageSpecialite
            // 
            messageSpecialite.AutoSize = true;
            messageSpecialite.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            messageSpecialite.ForeColor = Color.Red;
            messageSpecialite.Location = new Point(605, 356);
            messageSpecialite.Name = "messageSpecialite";
            messageSpecialite.Size = new Size(30, 15);
            messageSpecialite.TabIndex = 23;
            messageSpecialite.Text = "msg";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(605, 312);
            label8.Name = "label8";
            label8.Size = new Size(57, 15);
            label8.TabIndex = 22;
            label8.Text = "Spécialité";
            // 
            // cbxSpecialite
            // 
            cbxSpecialite.FormattingEnabled = true;
            cbxSpecialite.Location = new Point(605, 330);
            cbxSpecialite.Name = "cbxSpecialite";
            cbxSpecialite.Size = new Size(269, 23);
            cbxSpecialite.TabIndex = 21;
            // 
            // messageEmail
            // 
            messageEmail.AutoSize = true;
            messageEmail.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            messageEmail.ForeColor = Color.Red;
            messageEmail.Location = new Point(605, 282);
            messageEmail.Name = "messageEmail";
            messageEmail.Size = new Size(30, 15);
            messageEmail.TabIndex = 20;
            messageEmail.Text = "msg";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(605, 238);
            label6.Name = "label6";
            label6.Size = new Size(36, 15);
            label6.TabIndex = 19;
            label6.Text = "Email";
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(605, 256);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(269, 23);
            txtEmail.TabIndex = 18;
            // 
            // messageType
            // 
            messageType.AutoSize = true;
            messageType.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            messageType.ForeColor = Color.Red;
            messageType.Location = new Point(64, 356);
            messageType.Name = "messageType";
            messageType.Size = new Size(30, 15);
            messageType.TabIndex = 17;
            messageType.Text = "msg";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(64, 312);
            label7.Name = "label7";
            label7.Size = new Size(31, 15);
            label7.TabIndex = 16;
            label7.Text = "Type";
            // 
            // cbxType
            // 
            cbxType.FormattingEnabled = true;
            cbxType.Location = new Point(64, 330);
            cbxType.Name = "cbxType";
            cbxType.Size = new Size(286, 23);
            cbxType.TabIndex = 15;
            // 
            // messageTelephone
            // 
            messageTelephone.AutoSize = true;
            messageTelephone.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            messageTelephone.ForeColor = Color.Red;
            messageTelephone.Location = new Point(64, 282);
            messageTelephone.Name = "messageTelephone";
            messageTelephone.Size = new Size(30, 15);
            messageTelephone.TabIndex = 14;
            messageTelephone.Text = "msg";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(64, 238);
            label5.Name = "label5";
            label5.Size = new Size(61, 15);
            label5.TabIndex = 13;
            label5.Text = "Téléphone";
            // 
            // mtbTelephone
            // 
            mtbTelephone.Location = new Point(64, 256);
            mtbTelephone.Mask = "00 00 00 00 00 00";
            mtbTelephone.Name = "mtbTelephone";
            mtbTelephone.Size = new Size(286, 23);
            mtbTelephone.TabIndex = 12;
            // 
            // messageVille
            // 
            messageVille.AutoSize = true;
            messageVille.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            messageVille.ForeColor = Color.Red;
            messageVille.Location = new Point(64, 213);
            messageVille.Name = "messageVille";
            messageVille.Size = new Size(30, 15);
            messageVille.TabIndex = 11;
            messageVille.Text = "msg";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(64, 169);
            label4.Name = "label4";
            label4.Size = new Size(29, 15);
            label4.TabIndex = 10;
            label4.Text = "Ville";
            // 
            // txtVille
            // 
            txtVille.Location = new Point(64, 187);
            txtVille.Name = "txtVille";
            txtVille.Size = new Size(384, 23);
            txtVille.TabIndex = 9;
            // 
            // messageRue
            // 
            messageRue.AutoSize = true;
            messageRue.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            messageRue.ForeColor = Color.Red;
            messageRue.Location = new Point(64, 143);
            messageRue.Name = "messageRue";
            messageRue.Size = new Size(30, 15);
            messageRue.TabIndex = 8;
            messageRue.Text = "msg";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(64, 99);
            label3.Name = "label3";
            label3.Size = new Size(27, 15);
            label3.TabIndex = 7;
            label3.Text = "Rue";
            // 
            // txtRue
            // 
            txtRue.Location = new Point(64, 117);
            txtRue.Name = "txtRue";
            txtRue.Size = new Size(384, 23);
            txtRue.TabIndex = 6;
            // 
            // messagePrenom
            // 
            messagePrenom.AutoSize = true;
            messagePrenom.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            messagePrenom.ForeColor = Color.Red;
            messagePrenom.Location = new Point(605, 70);
            messagePrenom.Name = "messagePrenom";
            messagePrenom.Size = new Size(30, 15);
            messagePrenom.TabIndex = 5;
            messagePrenom.Text = "msg";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(605, 26);
            label2.Name = "label2";
            label2.Size = new Size(49, 15);
            label2.TabIndex = 4;
            label2.Text = "Prénom";
            // 
            // txtPrenom
            // 
            txtPrenom.Location = new Point(605, 44);
            txtPrenom.Name = "txtPrenom";
            txtPrenom.Size = new Size(269, 23);
            txtPrenom.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(64, 26);
            label1.Name = "label1";
            label1.Size = new Size(34, 15);
            label1.TabIndex = 2;
            label1.Text = "Nom";
            // 
            // txtNom
            // 
            txtNom.Location = new Point(64, 44);
            txtNom.Name = "txtNom";
            txtNom.Size = new Size(286, 23);
            txtNom.TabIndex = 1;
            // 
            // messageNom
            // 
            messageNom.AutoSize = true;
            messageNom.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            messageNom.ForeColor = Color.Red;
            messageNom.Location = new Point(64, 70);
            messageNom.Name = "messageNom";
            messageNom.Size = new Size(30, 15);
            messageNom.TabIndex = 0;
            messageNom.Text = "msg";
            // 
            // FrmAjoutPraticien
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1141, 615);
            Controls.Add(panelCentral);
            Icon = (Icon)resources.GetObject("$this.Icon");
            KeyPreview = true;
            Location = new Point(0, 0);
            Name = "FrmAjoutPraticien";
            Text = "Nouveau praticien";
            Load += FrmAjoutPraticien_Load;
            Resize += FrmAjoutPraticien_Resize;
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
        private TextBox txtVille;
        private Label messageRue;
        private Label messageVille;
        private Button btnAjouter;
        private Label messageSpecialite;
        private Label label8;
        private ComboBox cbxSpecialite;
        private Label messageEmail;
        private Label label6;
        private TextBox txtEmail;
        private Label messageType;
        private Label label7;
        private ComboBox cbxType;
        private Label messageTelephone;
        private Label label5;
        private MaskedTextBox mtbTelephone;
    }
}