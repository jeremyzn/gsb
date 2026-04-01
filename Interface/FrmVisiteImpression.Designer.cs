namespace Interface
{
    partial class FrmVisiteImpression
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmVisiteImpression));
            panelCentral = new Panel();
            imgGsb = new PictureBox();
            panelSaisie = new Panel();
            dtpFin = new DateTimePicker();
            label2 = new Label();
            label1 = new Label();
            dtpDebut = new DateTimePicker();
            message = new Label();
            imgApercu = new PictureBox();
            imgImprimer = new PictureBox();
            printRendezVous = new System.Drawing.Printing.PrintDocument();
            choixImprimante = new PrintDialog();
            apercuRendezVous = new PrintPreviewDialog();
            messageIntervale = new Label();
            panelCentral.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)imgGsb).BeginInit();
            panelSaisie.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)imgApercu).BeginInit();
            ((System.ComponentModel.ISupportInitialize)imgImprimer).BeginInit();
            SuspendLayout();
            // 
            // lblTitre
            // 
            lblTitre.Size = new Size(1066, 74);
            // 
            // panelCentral
            // 
            panelCentral.Controls.Add(imgGsb);
            panelCentral.Controls.Add(panelSaisie);
            panelCentral.Controls.Add(message);
            panelCentral.Location = new Point(75, 88);
            panelCentral.Name = "panelCentral";
            panelCentral.Size = new Size(932, 409);
            panelCentral.TabIndex = 13;
            // 
            // imgGsb
            // 
            imgGsb.BackgroundImage = Properties.Resources.logoGSB;
            imgGsb.BackgroundImageLayout = ImageLayout.Center;
            imgGsb.Location = new Point(34, 56);
            imgGsb.Name = "imgGsb";
            imgGsb.Size = new Size(440, 284);
            imgGsb.TabIndex = 1;
            imgGsb.TabStop = false;
            // 
            // panelSaisie
            // 
            panelSaisie.Controls.Add(messageIntervale);
            panelSaisie.Controls.Add(dtpFin);
            panelSaisie.Controls.Add(label2);
            panelSaisie.Controls.Add(label1);
            panelSaisie.Controls.Add(dtpDebut);
            panelSaisie.Controls.Add(imgApercu);
            panelSaisie.Controls.Add(imgImprimer);
            panelSaisie.Location = new Point(519, 28);
            panelSaisie.Name = "panelSaisie";
            panelSaisie.Size = new Size(392, 366);
            panelSaisie.TabIndex = 0;
            // 
            // dtpFin
            // 
            dtpFin.Location = new Point(67, 75);
            dtpFin.Name = "dtpFin";
            dtpFin.Size = new Size(200, 23);
            dtpFin.TabIndex = 15;
            dtpFin.ValueChanged += dtpFin_ValueChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(34, 81);
            label2.Name = "label2";
            label2.Size = new Size(22, 15);
            label2.TabIndex = 5;
            label2.Text = "Au";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(34, 34);
            label1.Name = "label1";
            label1.Size = new Size(22, 15);
            label1.TabIndex = 4;
            label1.Text = "Du";
            // 
            // dtpDebut
            // 
            dtpDebut.Location = new Point(67, 28);
            dtpDebut.Name = "dtpDebut";
            dtpDebut.Size = new Size(200, 23);
            dtpDebut.TabIndex = 3;
            dtpDebut.ValueChanged += dtpDebut_ValueChanged;
            // 
            // message
            // 
            message.AutoSize = true;
            // Position relative to the form so the label stays visible when panelSaisi is hidden
            message.Location = new Point(537, 216);
            message.Name = "message";
            message.Size = new Size(38, 15);
            message.TabIndex = 2;
            message.Text = "label1";
            // 
            // imgApercu
            // 
            imgApercu.BackgroundImage = Properties.Resources.apercu;
            imgApercu.BackgroundImageLayout = ImageLayout.Stretch;
            imgApercu.Location = new Point(18, 222);
            imgApercu.Name = "imgApercu";
            imgApercu.Size = new Size(171, 130);
            imgApercu.TabIndex = 1;
            imgApercu.TabStop = false;
            imgApercu.Click += imgApercu_Click;
            // 
            // imgImprimer
            // 
            imgImprimer.BackgroundImage = Properties.Resources.imprimer;
            imgImprimer.BackgroundImageLayout = ImageLayout.Stretch;
            imgImprimer.Location = new Point(215, 222);
            imgImprimer.Name = "imgImprimer";
            imgImprimer.Size = new Size(139, 130);
            imgImprimer.TabIndex = 0;
            imgImprimer.TabStop = false;
            imgImprimer.Click += imgImprimer_Click;
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
            // messageIntervale
            // 
            messageIntervale.AutoSize = true;
            messageIntervale.Location = new Point(331, 10);
            messageIntervale.Name = "messageIntervale";
            messageIntervale.Size = new Size(38, 15);
            messageIntervale.TabIndex = 14;
            messageIntervale.Text = "label1";
            // 
            // printRendezVous
            // 
            printRendezVous.PrintPage += printRendezVous_PrintPage;
            // 
            // FrmVisiteImpression
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1066, 549);
            Controls.Add(panelCentral);
            Icon = (Icon)resources.GetObject("$this.Icon");
            KeyPreview = true;
            Location = new Point(0, 0);
            Name = "FrmVisiteImpression";
            Text = "FrmVisiteImpression";
            Load += FrmVisiteImpression_Load;
            Resize += FrmVisiteImpression_Resize;
            Controls.SetChildIndex(lblTitre, 0);
            Controls.SetChildIndex(panelCentral, 0);
            panelCentral.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)imgGsb).EndInit();
            panelSaisie.ResumeLayout(false);
            panelSaisie.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)imgApercu).EndInit();
            ((System.ComponentModel.ISupportInitialize)imgImprimer).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panelCentral;
        private System.Drawing.Printing.PrintDocument printRendezVous;
        private PrintDialog choixImprimante;
        private PrintPreviewDialog apercuRendezVous;
        private Panel panelSaisie;
        private PictureBox imgGsb;
        private PictureBox imgImprimer;
        private PictureBox imgApercu;
        private DateTimePicker dtpDebut;
        private Label message;
        private Label messageIntervale;
        private Label label1;
        private DateTimePicker dtpFin;
        private Label label2;
    }
}