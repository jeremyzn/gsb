using Donnee;
using Interface.Properties;
using Metier;
using System.Data;

namespace Interface
{
    public partial class FrmEnregistrerBilan : FrmBase
    {
        private List<Visite> lesVisitesNonCompletees = new();
        private int indexVisiteCourante = 0;

        private Button? btnPrecedent;
        private Button? btnSuivant;
        private Label? message;
        private Label? lblResumeVisite;
        private Label? msgPremierMedicament;
        private Label? msgSecondMedicament;
        private Label? msgBilan;

        public FrmEnregistrerBilan(Session uneSession) : base(uneSession)
        {
            InitializeComponent();
            centrerFormulaire();

            btnAjouter.Click += btnAjouter_Click;
            btnEnregistrer.Click += btnEnregistrer_Click;
            cbxPremierMedicament.SelectedIndexChanged += (_, _) => { if (msgPremierMedicament != null) msgPremierMedicament.Text = string.Empty; };
            cbxSecondMedicament.SelectedIndexChanged += (_, _) => { if (msgSecondMedicament != null) msgSecondMedicament.Text = string.Empty; };
            txtBilan.TextChanged += (_, _) => { if (msgBilan != null) msgBilan.Text = string.Empty; };
        }

        # region procédures événementielles

        private void FrmEnregistrerBilan_Load(object sender, EventArgs e)
        {
            parametrerComposant();
            chargerLesVisites();
        }

        private void FrmEnregistrerBilan_Resize(object sender, EventArgs e)
        {
            centrerFormulaire();
        }

        private void btnPrecedent_Click(object? sender, EventArgs e)
        {
            changerVisite(-1);
        }

        private void btnSuivant_Click(object? sender, EventArgs e)
        {
            changerVisite(1);
        }

        private void btnAjouter_Click(object? sender, EventArgs e)
        {
            ajouterEchantillon();
        }

        private void btnEnregistrer_Click(object? sender, EventArgs e)
        {
            enregistrer();
        }

        private void dgvEchantillon_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            Visite? visite = getVisiteCourante();
            if (visite == null) return;

            Medicament? medicament = dgvEchantillon.Rows[e.RowIndex].Cells["ObjetMedicament"].Value as Medicament;
            if (medicament == null) return;

            if (e.ColumnIndex == 3)
            {
                int quantiteActuelle = visite.getQuantite(medicament);
                if (quantiteActuelle < 10)
                {
                    visite.ajouterEchantillon(medicament, 1);
                }
            }
            else if (e.ColumnIndex == 4)
            {
                int quantiteActuelle = visite.getQuantite(medicament);
                visite.supprimerEchantillon(medicament);
                if (quantiteActuelle - 1 > 0)
                {
                    visite.ajouterEchantillon(medicament, quantiteActuelle - 1);
                }
            }
            else if (e.ColumnIndex == 5)
            {
                visite.supprimerEchantillon(medicament);
            }

            remplirDgvEchantillons(visite);
        }

        #endregion

        #region procédures

        private void parametrerComposant()
        {
            lblTitre.Text = "Enregistrement du bilan d'une visite";

            panel.Anchor = AnchorStyles.None;
            panelCentral.Anchor = AnchorStyles.None;
            panelHaut.Anchor = AnchorStyles.None;
            panelGauche.Anchor = AnchorStyles.None;
            panelDroite.Anchor = AnchorStyles.None;

            initialiserControlesDynamique();

            cbxPremierMedicament.DropDownStyle = ComboBoxStyle.DropDownList;
            cbxSecondMedicament.DropDownStyle = ComboBoxStyle.DropDownList;
            cbxEchantillon.DropDownStyle = ComboBoxStyle.DropDownList;

            var lesMedicaments = session.LesMedicaments.OrderBy(m => m.Nom).ToList();

            cbxPremierMedicament.DataSource = lesMedicaments.ToList();
            cbxPremierMedicament.DisplayMember = "Nom";
            cbxPremierMedicament.ValueMember = "Id";

            cbxSecondMedicament.DataSource = lesMedicaments.ToList();
            cbxSecondMedicament.DisplayMember = "Nom";
            cbxSecondMedicament.ValueMember = "Id";
            cbxSecondMedicament.SelectedIndex = -1;

            cbxEchantillon.DataSource = lesMedicaments.ToList();
            cbxEchantillon.DisplayMember = "Nom";
            cbxEchantillon.ValueMember = "Id";
            cbxEchantillon.SelectedIndex = -1;

            cptQuantite.Minimum = 1;
            cptQuantite.Maximum = 10;
            cptQuantite.Value = 1;

            txtBilan.Multiline = true;

            btnAjouter.Text = "Ajouter";
            btnEnregistrer.Text = "Enregistrer la fiche visite";

            parametrerDgvEchantillon();
            ViderAffichage();
        }

        private void initialiserControlesDynamique()
        {
            if (btnPrecedent == null)
            {
                btnPrecedent = new Button
                {
                    Name = "btnPrecedent",
                    Text = "<",
                    Size = new Size(36, 23),
                    Location = new Point(15, 12),
                    BackColor = Color.LightGreen
                };
                btnPrecedent.Click += btnPrecedent_Click;
                panelHaut.Controls.Add(btnPrecedent);
            }

            if (btnSuivant == null)
            {
                btnSuivant = new Button
                {
                    Name = "btnSuivant",
                    Text = ">",
                    Size = new Size(36, 23),
                    Location = new Point(55, 12),
                    BackColor = Color.LightGreen
                };
                btnSuivant.Click += btnSuivant_Click;
                panelHaut.Controls.Add(btnSuivant);
            }

            if (message == null)
            {
                message = new Label
                {
                    Name = "message",
                    AutoSize = true,
                    Location = new Point(15, 42),
                    Text = string.Empty
                };
                panelHaut.Controls.Add(message);
            }

            if (lblResumeVisite == null)
            {
                lblResumeVisite = new Label
                {
                    Name = "lblResumeVisite",
                    AutoSize = false,
                    Location = new Point(95, 15),
                    Size = new Size(1080, 23),
                    Text = string.Empty
                };
                panelHaut.Controls.Add(lblResumeVisite);
            }

            if (msgPremierMedicament == null)
            {
                msgPremierMedicament = new Label
                {
                    Name = "msgPremierMedicament",
                    ForeColor = Color.Red,
                    AutoSize = true,
                    Location = new Point(12, 62),
                    Text = string.Empty
                };
                panelGauche.Controls.Add(msgPremierMedicament);
            }

            if (msgSecondMedicament == null)
            {
                msgSecondMedicament = new Label
                {
                    Name = "msgSecondMedicament",
                    ForeColor = Color.Red,
                    AutoSize = true,
                    Location = new Point(391, 62),
                    Text = string.Empty
                };
                panelGauche.Controls.Add(msgSecondMedicament);
            }

            if (msgBilan == null)
            {
                msgBilan = new Label
                {
                    Name = "msgBilan",
                    ForeColor = Color.Red,
                    AutoSize = true,
                    Location = new Point(12, 275),
                    Text = string.Empty
                };
                panelGauche.Controls.Add(msgBilan);
            }
        }

        private void parametrerDgvEchantillon()
        {
            dgvEchantillon.Columns.Clear();
            dgvEchantillon.Rows.Clear();

            dgvEchantillon.Enabled = true;
            dgvEchantillon.BorderStyle = BorderStyle.FixedSingle;
            dgvEchantillon.BackgroundColor = Color.White;
            dgvEchantillon.ForeColor = Color.Black;
            dgvEchantillon.DefaultCellStyle.Font = new Font("Georgia", 10);
            dgvEchantillon.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvEchantillon.MultiSelect = false;
            dgvEchantillon.AllowUserToDeleteRows = false;
            dgvEchantillon.AllowUserToAddRows = false;
            dgvEchantillon.EditMode = DataGridViewEditMode.EditProgrammatically;
            dgvEchantillon.AllowUserToResizeColumns = false;
            dgvEchantillon.AllowUserToResizeRows = false;
            dgvEchantillon.AllowUserToOrderColumns = false;
            dgvEchantillon.AllowDrop = false;
            dgvEchantillon.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;

            dgvEchantillon.ColumnHeadersVisible = true;
            dgvEchantillon.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvEchantillon.EnableHeadersVisualStyles = false;
            DataGridViewCellStyle style = dgvEchantillon.ColumnHeadersDefaultCellStyle;
            style.BackColor = Color.WhiteSmoke;
            style.ForeColor = Color.Black;
            style.SelectionBackColor = Color.WhiteSmoke;
            style.SelectionForeColor = Color.Black;
            style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            style.Font = new Font("Georgia", 10, FontStyle.Bold);

            dgvEchantillon.RowHeadersVisible = false;
            dgvEchantillon.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dgvEchantillon.RowsDefaultCellStyle.BackColor = Color.White;
            dgvEchantillon.RowsDefaultCellStyle.SelectionBackColor = Color.White;
            dgvEchantillon.RowsDefaultCellStyle.SelectionForeColor = Color.Black;

            DataGridViewColumn col;

            col = new DataGridViewTextBoxColumn();
            col.Name = "ObjetMedicament";
            col.Visible = false;
            dgvEchantillon.Columns.Add(col);

            col = new DataGridViewTextBoxColumn();
            col.Name = "Nom";
            col.HeaderText = "Médicament";
            col.Width = 220;
            dgvEchantillon.Columns.Add(col);

            col = new DataGridViewTextBoxColumn();
            col.Name = "Quantite";
            col.HeaderText = "Quantité";
            col.Width = 70;
            col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvEchantillon.Columns.Add(col);

            DataGridViewImageColumn colPlus = new DataGridViewImageColumn();
            colPlus.Name = "Plus";
            colPlus.HeaderText = "";
            colPlus.Image = Resources.plus;
            colPlus.ImageLayout = DataGridViewImageCellLayout.Zoom;
            colPlus.Width = 30;
            dgvEchantillon.Columns.Add(colPlus);

            DataGridViewImageColumn colMoins = new DataGridViewImageColumn();
            colMoins.Name = "Moins";
            colMoins.HeaderText = "";
            colMoins.Image = Resources.moins;
            colMoins.ImageLayout = DataGridViewImageCellLayout.Zoom;
            colMoins.Width = 30;
            dgvEchantillon.Columns.Add(colMoins);

            DataGridViewImageColumn colSupprimer = new DataGridViewImageColumn();
            colSupprimer.Name = "Supprimer";
            colSupprimer.HeaderText = "";
            colSupprimer.Image = Resources.supprimer;
            colSupprimer.ImageLayout = DataGridViewImageCellLayout.Zoom;
            colSupprimer.Width = 30;
            dgvEchantillon.Columns.Add(colSupprimer);

            for (int i = 0; i < dgvEchantillon.ColumnCount; i++)
            {
                dgvEchantillon.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            dgvEchantillon.CellClick -= dgvEchantillon_CellClick;
            dgvEchantillon.CellClick += dgvEchantillon_CellClick;
        }

        private void chargerLesVisites()
        {
            lesVisitesNonCompletees = session.MesVisites
                .FindAll(x => x.DateEtHeure <= DateTime.Now && x.Bilan == null)
                .OrderBy(x => x.DateEtHeure)
                .ToList();

            if (lesVisitesNonCompletees.Count == 0)
            {
                if (message != null)
                {
                    message.Text = "Toutes vos fiches sont complétées";
                }
                panelCentral.Visible = false;
                return;
            }

            panelCentral.Visible = true;
            indexVisiteCourante = 0;
            afficherVisite();
            mettreAJourNavigation();
        }

        private void changerVisite(int deplacement)
        {
            int count = lesVisitesNonCompletees.Count;
            if (count == 0)
            {
                return;
            }

            indexVisiteCourante = (indexVisiteCourante + deplacement + count) % count;
            afficherVisite();
            mettreAJourNavigation();
        }

        private void mettreAJourNavigation()
        {
            int count = lesVisitesNonCompletees.Count;
            if (btnSuivant != null) btnSuivant.Enabled = count > 1;
            if (btnPrecedent != null) btnPrecedent.Enabled = count > 1;

            if (message != null)
            {
                message.Visible = true;
                message.Text = count > 0 ? $"{indexVisiteCourante + 1} / {count}" : "Toutes vos fiches sont complétées";
            }
        }

        private void afficherVisite()
        {
            Visite? visite = getVisiteCourante();
            if (visite == null)
            {
                ViderAffichage();
                return;
            }

            if (lblResumeVisite != null)
            {
                lblResumeVisite.Text = $"Le {visite.DateEtHeure:dddd d MMMM yyyy 'à' HH:mm}      Chez {visite.LePraticien.NomPrenom}";
            }

            cbxPremierMedicament.SelectedItem = visite.PremierMedicament;
            cbxSecondMedicament.SelectedItem = visite.SecondMedicament;
            if (visite.SecondMedicament == null)
            {
                cbxSecondMedicament.SelectedIndex = -1;
            }
            txtBilan.Text = visite.Bilan ?? string.Empty;

            remplirDgvEchantillons(visite);

            cbxEchantillon.SelectedIndex = -1;
            cptQuantite.Value = 1;

            if (msgPremierMedicament != null) msgPremierMedicament.Text = string.Empty;
            if (msgSecondMedicament != null) msgSecondMedicament.Text = string.Empty;
            if (msgBilan != null) msgBilan.Text = string.Empty;
        }

        private void remplirDgvEchantillons(Visite visite)
        {
            dgvEchantillon.Rows.Clear();
            foreach (KeyValuePair<Medicament, int> echantillon in visite)
            {
                dgvEchantillon.Rows.Add(
                    echantillon.Key,
                    echantillon.Key.Nom,
                    echantillon.Value,
                    Resources.plus,
                    Resources.moins,
                    Resources.supprimer);
            }
        }

        private void ViderAffichage()
        {
            if (lblResumeVisite != null) lblResumeVisite.Text = string.Empty;
            cbxPremierMedicament.SelectedIndex = -1;
            cbxSecondMedicament.SelectedIndex = -1;
            cbxEchantillon.SelectedIndex = -1;
            txtBilan.Text = string.Empty;
            dgvEchantillon.Rows.Clear();
            if (msgPremierMedicament != null) msgPremierMedicament.Text = string.Empty;
            if (msgSecondMedicament != null) msgSecondMedicament.Text = string.Empty;
            if (msgBilan != null) msgBilan.Text = string.Empty;
        }

        private Visite? getVisiteCourante()
        {
            if (lesVisitesNonCompletees.Count == 0)
            {
                return null;
            }
            return lesVisitesNonCompletees[indexVisiteCourante];
        }

        private bool controlerPremierMedicament()
        {
            bool ok = cbxPremierMedicament.SelectedItem is Medicament;
            if (msgPremierMedicament != null)
            {
                msgPremierMedicament.Text = ok ? string.Empty : "Premier médicament obligatoire";
            }
            return ok;
        }

        private bool controlerSecondMedicament()
        {
            Medicament? premier = cbxPremierMedicament.SelectedItem as Medicament;
            Medicament? second = cbxSecondMedicament.SelectedItem as Medicament;

            bool ok = second == null || (premier != null && second.Id != premier.Id);
            if (msgSecondMedicament != null)
            {
                msgSecondMedicament.Text = ok ? string.Empty : "Le second médicament doit être différent";
            }
            return ok;
        }

        private bool controlerBilan()
        {
            bool ok = !string.IsNullOrWhiteSpace(txtBilan.Text);
            if (msgBilan != null)
            {
                msgBilan.Text = ok ? string.Empty : "Le bilan est obligatoire";
            }
            return ok;
        }

        private void ajouterEchantillon()
        {
            Visite? visite = getVisiteCourante();
            if (visite == null) return;

            Medicament? medicament = cbxEchantillon.SelectedItem as Medicament;
            if (medicament == null)
            {
                MessageBox.Show("Veuillez sélectionner un médicament.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int quantite = (int)cptQuantite.Value;
            int quantiteActuelle = visite.contenir(medicament) ? visite.getQuantite(medicament) : 0;
            if (quantiteActuelle + quantite > 10)
            {
                MessageBox.Show("La quantité totale pour ce médicament ne peut pas dépasser 10.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            visite.ajouterEchantillon(medicament, quantite);
            remplirDgvEchantillons(visite);
        }

        private void enregistrer()
        {
            bool premierMedicamentOk = controlerPremierMedicament();
            bool secondMedicamentOk = controlerSecondMedicament();
            bool bilanOk = controlerBilan();

            if (!(premierMedicamentOk && secondMedicamentOk && bilanOk))
            {
                return;
            }

            Medicament premierMedicament = (Medicament)cbxPremierMedicament.SelectedItem!;
            Medicament? secondMedicament = cbxSecondMedicament.SelectedItem as Medicament;
            Visite? visite = getVisiteCourante();
            if (visite == null) return;

            try
            {
                visite.enregistrerBilan(txtBilan.Text.Trim(), premierMedicament, secondMedicament);
                Passerelle.enregistrerBilan(visite);

                MessageBox.Show("Votre fiche visite est maintenant archivée", "Bilan enregistré", MessageBoxButtons.OK, MessageBoxIcon.Information);

                lesVisitesNonCompletees.RemoveAt(indexVisiteCourante);

                if (lesVisitesNonCompletees.Count > 0)
                {
                    changerVisite(0);
                }
                else
                {
                    if (message != null)
                    {
                        message.Text = "Toutes vos fiches sont complétées";
                    }
                    panelCentral.Visible = false;
                    mettreAJourNavigation();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Une erreur est survenue lors de l'enregistrement du bilan : " + ex.Message,
                    "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void centrerFormulaire()
        {
            panel.Left = (this.ClientSize.Width - panel.Width) / 2;
            panel.Top = (this.ClientSize.Height - panel.Height) / 2;
        }

        #endregion
    }
}
