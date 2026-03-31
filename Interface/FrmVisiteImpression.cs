using Donnee;
using Metier;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Interface
{
    public partial class FrmVisiteImpression : FrmBase
    {
        // 3. Les données manipulées
        private List<Visite> lesVisites;

        public FrmVisiteImpression(Session uneSession) : base(uneSession)
        {
            InitializeComponent();

            // Raccordement manuel des méthodes événementielles manquantes dans le Designer
            this.Resize += FrmVisiteImpression_Resize;
            this.printRendezVous.PrintPage += printRendezVous_PrintPage;
        }

        #region procédures événementielles

        // 4. Load
        private void FrmVisiteImpression_Load(object sender, EventArgs e)
        {
            parametrerComposant();
            centrerFormulaire();

            // Initialise l'objet lesVisites (depuis l'objet session de FrmBase)
            // On récupère les visites dont la date et l'heure sont supérieures ou égales au moment présent
            lesVisites = session.MesVisites.Where(v => v.DateEtHeure >= DateTime.Now).ToList();

            // Si aucune visite ne correspond
            if (lesVisites.Count == 0)
            {
                message.Text = "Aucun rendez-vous planifié pour le moment.";
                panelSaisi.Visible = false; // Masque la zone de saisie
            }
            else
            {
                message.Text = string.Empty;
                panelSaisi.Visible = true;
            }
        }

        // 4. Resize
        private void FrmVisiteImpression_Resize(object sender, EventArgs e)
        {
            // Appel de la méthode centrerFormulaire
            centrerFormulaire();
        }

        // 4. dtpDebut_ValueChanged (dptDebut dans ton designer)
        private void dptDebut_ValueChanged(object sender, EventArgs e)
        {
            // Efface l'éventuel message affiché dans le label messageIntervale
            messageIntervale.Text = string.Empty;

            // Fixe la valeur minimale de dtpFin à dtpDebut + 7
            dptFin.MinDate = dptDebut.Value.AddDays(7);
        }

        // 4. dtpFin_ValueChanged (dptFin dans ton designer)
        private void dptFin_ValueChanged(object sender, EventArgs e)
        {
            // Efface l'éventuel message affiché dans le label messageIntervale
            messageIntervale.Text = string.Empty;
        }

        // 4. imgImprimer_Click
        private void imgImprimer_Click(object sender, EventArgs e)
        {
            // Vérifie qu'il existe au moins une visite dans l'intervalle demandé
            bool visiteExiste = lesVisites.Any(v => v.DateEtHeure.Date >= dptDebut.Value.Date && v.DateEtHeure.Date <= dptFin.Value.Date);

            if (!visiteExiste)
            {
                // Affiche le message d'erreur si aucune visite
                messageIntervale.Text = "Aucun rendez-vous planifié sur cette période.";
            }
            else
            {
                // Initialise les composants d'impression
                printRendezVous.DocumentName = "Rendez-vous";

                // Sélection de l'imprimante
                choixImprimante.Document = printRendezVous;
                DialogResult result = choixImprimante.ShowDialog();
                if (result == DialogResult.OK)
                {
                    printRendezVous.Print();
                }
            }
        }

        // 4. imgApercu_Click
        private void imgApercu_Click(object sender, EventArgs e)
        {
            // Même traitement que pour l'impression
            bool visiteExiste = lesVisites.Any(v => v.DateEtHeure.Date >= dptDebut.Value.Date && v.DateEtHeure.Date <= dptFin.Value.Date);

            if (!visiteExiste)
            {
                messageIntervale.Text = "Aucun rendez-vous planifié sur cette période.";
            }
            else
            {
                printRendezVous.DocumentName = "Rendez-vous";
                apercuRendezVous.Document = printRendezVous;
                apercuRendezVous.ShowDialog();
            }
        }

        // 4. printRendezVous_PrintPage
        private void printRendezVous_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            var lesColonnes = new[] {
                 new { Titre = "Date", Largeur = 170, Alignement = StringAlignment.Near },
                 new { Titre = "Heure", Largeur = 80, Alignement = StringAlignment.Center },
                 new { Titre = "Praticien", Largeur = 200, Alignement = StringAlignment.Near },
                 new { Titre = "Téléphone", Largeur = 120, Alignement = StringAlignment.Near },
                 new { Titre = "Lieu", Largeur = 200, Alignement = StringAlignment.Near },
                 new { Titre = "Motif", Largeur = 200, Alignement = StringAlignment.Near }
            };

            int margeHaut = e.MarginBounds.Top;
            int margeGauche = e.MarginBounds.Left;
            int hauteurLigne = 30;
            Font police = new Font("Arial", 10, FontStyle.Bold);
            Brush brush = Brushes.Black;

            int y = margeHaut + hauteurLigne + 10;
            int x = margeGauche;

            foreach (var col in lesColonnes)
            {
                Rectangle rect = new Rectangle(x, y, col.Largeur, hauteurLigne);
                e.Graphics.DrawString(col.Titre, police, brush, rect, new StringFormat { Alignment = col.Alignement, LineAlignment = StringAlignment.Center });
                x += col.Largeur;
            }

            // Imprimer le corps (les visites) — on considère une seule page
            int yCorps = y + hauteurLigne + 5;
            Font policeCorps = new Font("Arial", 9, FontStyle.Regular);

            // Filtrer les visites selon l'intervalle sélectionné
            var visitesAPrint = lesVisites.Where(v => v.DateEtHeure.Date >= dptDebut.Value.Date && v.DateEtHeure.Date <= dptFin.Value.Date).OrderBy(v => v.DateEtHeure).ToList();

            foreach (var visite in visitesAPrint)
            {
                int xCorps = margeGauche;

                // Date
                Rectangle rDate = new Rectangle(xCorps, yCorps, lesColonnes[0].Largeur, hauteurLigne);
                e.Graphics.DrawString(visite.DateEtHeure.ToShortDateString(), policeCorps, brush, rDate, new StringFormat { Alignment = lesColonnes[0].Alignement, LineAlignment = StringAlignment.Center });
                xCorps += lesColonnes[0].Largeur;

                // Heure
                Rectangle rHeure = new Rectangle(xCorps, yCorps, lesColonnes[1].Largeur, hauteurLigne);
                e.Graphics.DrawString(visite.DateEtHeure.ToShortTimeString(), policeCorps, brush, rHeure, new StringFormat { Alignment = lesColonnes[1].Alignement, LineAlignment = StringAlignment.Center });
                xCorps += lesColonnes[1].Largeur;

                // Praticien
                Rectangle rPraticien = new Rectangle(xCorps, yCorps, lesColonnes[2].Largeur, hauteurLigne);
                e.Graphics.DrawString(visite.LePraticien.NomPrenom, policeCorps, brush, rPraticien, new StringFormat { Alignment = lesColonnes[2].Alignement, LineAlignment = StringAlignment.Center });
                xCorps += lesColonnes[2].Largeur;

                // Téléphone
                Rectangle rTel = new Rectangle(xCorps, yCorps, lesColonnes[3].Largeur, hauteurLigne);
                e.Graphics.DrawString(visite.LePraticien.Telephone ?? string.Empty, policeCorps, brush, rTel, new StringFormat { Alignment = lesColonnes[3].Alignement, LineAlignment = StringAlignment.Center });
                xCorps += lesColonnes[3].Largeur;

                // Lieu
                Rectangle rLieu = new Rectangle(xCorps, yCorps, lesColonnes[4].Largeur, hauteurLigne);
                e.Graphics.DrawString(visite.LePraticien.Ville ?? string.Empty, policeCorps, brush, rLieu, new StringFormat { Alignment = lesColonnes[4].Alignement, LineAlignment = StringAlignment.Center });
                xCorps += lesColonnes[4].Largeur;

                // Motif
                Rectangle rMotif = new Rectangle(xCorps, yCorps, lesColonnes[5].Largeur, hauteurLigne);
                e.Graphics.DrawString(visite.LeMotif?.Libelle ?? string.Empty, policeCorps, brush, rMotif, new StringFormat { Alignment = lesColonnes[5].Alignement, LineAlignment = StringAlignment.Center });

                yCorps += hauteurLigne + 5;
            }

            e.HasMorePages = false;
        }

        #endregion

        #region procédures

        // 5. Les méthodes à mettre en place
        private void parametrerComposant()
        {
            this.lblTitre.Text = "Impression des rendez-vous sur une période";

            // fixe les propriétés MinDate et MaxDate du composant dptDebut (aujourd'hui à +53 jours)
            dptDebut.MinDate = DateTime.Today;
            dptDebut.MaxDate = DateTime.Today.AddDays(53);

            // fixe les propriétés MinDate et MaxDate du composant dptFin (aujourd'hui + 7 à aujourd'hui + 60)
            dptFin.MinDate = DateTime.Today.AddDays(7);
            dptFin.MaxDate = DateTime.Today.AddDays(60);
        }

        private void centrerFormulaire()
        {
            panelCentral.Left = (this.ClientSize.Width - panelCentral.Width) / 2;
        }

        #endregion
    }
}