using Donnee;
using Metier;
using System.Text.RegularExpressions;

namespace Interface
{
    public partial class FrmPraticienModification : FrmBase
    {
        public FrmPraticienModification(Session uneSession) : base(uneSession)
        {
            InitializeComponent();
        }

        #region procédures événementielles

        private void FrmPraticienModification_Load(object sender, EventArgs e)
        {
            parametrerComposant();
            centrerFormulaire();
        }

        private void FrmPraticienModification_Resize(object sender, EventArgs e)
        {
            centrerFormulaire();
        }

        private void cbxPraticien_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxPraticien.SelectedItem is Praticien lePraticien)
            {
                remplirPraticien(lePraticien);
            }

            mettreAJourEtatSuppression();
        }

        private void btnModifier_Click(object sender, EventArgs e)
        {
            modification();
        }

        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            suppression();
        }

        #endregion

        #region procédures

        private void parametrerComposant()
        {
            lblTitre.Text = "Mettre à jour les coordonnées d'un praticien";
            panelCentral.Anchor = AnchorStyles.None;

            cbxType.DataSource = session.LesTypesPraticien.OrderBy(x => x.Libelle).ToList();
            cbxType.DisplayMember = "Libelle";
            cbxType.ValueMember = "Id";
            cbxType.DropDownStyle = ComboBoxStyle.DropDownList;
            cbxType.SelectedIndex = -1;

            cbxSpecialite.DataSource = session.LesSpecialites.OrderBy(x => x.Libelle).ToList();
            cbxSpecialite.DisplayMember = "Libelle";
            cbxSpecialite.ValueMember = "Id";
            cbxSpecialite.DropDownStyle = ComboBoxStyle.DropDownList;
            cbxSpecialite.SelectedItem = null;

            cbxVille.DataSource = session.MesVilles.OrderBy(x => x.Nom).ToList();
            cbxVille.DisplayMember = "Nom";
            cbxVille.ValueMember = "Code";
            cbxVille.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cbxVille.AutoCompleteSource = AutoCompleteSource.ListItems;
            cbxVille.DropDownStyle = ComboBoxStyle.DropDown;
            cbxVille.SelectedIndex = -1;

            cbxPraticien.DisplayMember = "NomPrenom";
            cbxPraticien.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cbxPraticien.AutoCompleteSource = AutoCompleteSource.ListItems;
            cbxPraticien.DropDownStyle = ComboBoxStyle.DropDown;

            rafraichirListePraticiens(null);

            mtbTelephone.Mask = "00 00 00 00 00 00";
            mtbTelephone.TextMaskFormat = MaskFormat.IncludeLiterals;

            messageNom.Visible = false;
            messagePrenom.Visible = false;
            messageRue.Visible = false;
            messageVille.Visible = false;
            messageTelephone.Visible = false;
            messageEmail.Visible = false;
            messageSpecialite.Visible = false;
        }

        private void rafraichirListePraticiens(Praticien? praticienASelectionner)
        {
            session.MesPraticiens.Sort();

            cbxPraticien.Items.Clear();
            foreach (Praticien unPraticien in session.MesPraticiens)
            {
                cbxPraticien.Items.Add(unPraticien);
            }

            if (cbxPraticien.Items.Count == 0)
            {
                viderChamps();
                mettreAJourEtatSuppression();
                return;
            }

            if (praticienASelectionner is not null)
            {
                cbxPraticien.SelectedItem = praticienASelectionner;
            }

            if (cbxPraticien.SelectedIndex == -1)
            {
                cbxPraticien.SelectedIndex = 0;
            }

            mettreAJourEtatSuppression();
        }

        private void mettreAJourEtatSuppression()
        {
            if (cbxPraticien.SelectedItem is not Praticien lePraticien)
            {
                btnSupprimer.Visible = false;
                return;
            }

            bool possedeDesRendezVous = session.MesVisites.Any(v => v.LePraticien == lePraticien);
            btnSupprimer.Visible = !possedeDesRendezVous;
        }

        private void remplirPraticien(Praticien lePraticien)
        {
            txtNom.Text = lePraticien.Nom;
            txtPrenom.Text = lePraticien.Prenom;
            txtRue.Text = lePraticien.Rue;
            txtEmail.Text = lePraticien.Email;
            mtbTelephone.Text = lePraticien.Telephone;

            cbxVille.SelectedItem = session.MesVilles.FirstOrDefault(v => v.Code == lePraticien.CodePostal && v.Nom == lePraticien.Ville);
            cbxType.SelectedItem = session.LesTypesPraticien.FirstOrDefault(t => t.Id == lePraticien.Type?.Id);
            cbxSpecialite.SelectedItem = session.LesSpecialites.FirstOrDefault(s => s.Id == lePraticien.Specialite?.Id);
        }

        private bool controlerChamp(TextBox txt, Label lblMessage, string message)
        {
            if (string.IsNullOrWhiteSpace(txt.Text))
            {
                lblMessage.Text = message;
                lblMessage.Visible = true;
                return false;
            }
            lblMessage.Text = string.Empty;
            lblMessage.Visible = false;
            return true;
        }

        private bool controlerVille()
        {
            if (cbxVille.SelectedItem is null)
            {
                messageVille.Text = "La ville du praticien doit être précisée";
                messageVille.Visible = true;
                return false;
            }

            messageVille.Text = string.Empty;
            messageVille.Visible = false;
            return true;
        }

        private bool controlerTelephone()
        {
            if (!mtbTelephone.MaskFull)
            {
                messageTelephone.Text = "Le téléphone du praticien doit être précisé";
                messageTelephone.Visible = true;
                return false;
            }
            messageTelephone.Visible = false;
            return true;
        }

        private bool controlerEmail()
        {
            if (txtEmail.Text == string.Empty)
            {
                messageEmail.Text = "L'adresse mail du praticien doit être précisée";
                messageEmail.Visible = true;
                return false;
            }

            Regex uneExpression = new(@"^[^\s@]+@[^\s@]+\.[^\s@]+$");
            if (!uneExpression.IsMatch(txtEmail.Text))
            {
                messageEmail.Text = "L'adresse mail n'est pas valide";
                messageEmail.Visible = true;
                return false;
            }

            messageEmail.Text = string.Empty;
            messageEmail.Visible = false;
            return true;
        }

        private void modification()
        {
            bool nomOk = controlerChamp(txtNom, messageNom, "Le nom du praticien doit être précisé");
            bool prenomOk = controlerChamp(txtPrenom, messagePrenom, "Le prénom du praticien doit être précisé");
            bool rueOk = controlerChamp(txtRue, messageRue, "La rue du praticien doit être précisée");
            bool villeOk = controlerVille();
            bool emailOk = controlerEmail();
            bool telephoneOk = controlerTelephone();

            if (nomOk && prenomOk && rueOk && villeOk && emailOk && telephoneOk)
            {
                modifier();
            }
        }

        private void modifier()
        {
            try
            {
                if (cbxPraticien.SelectedItem is not Praticien lePraticien)
                {
                    MessageBox.Show("Veuillez sélectionner un praticien.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (cbxVille.SelectedItem is not Ville laVille)
                {
                    MessageBox.Show("Veuillez sélectionner une ville valide.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                lePraticien.Nom = txtNom.Text.Trim();
                lePraticien.Prenom = txtPrenom.Text.Trim();
                lePraticien.Rue = txtRue.Text.Trim();
                lePraticien.Ville = laVille.Nom;
                lePraticien.CodePostal = laVille.Code;
                lePraticien.Email = txtEmail.Text.Trim();
                lePraticien.Telephone = mtbTelephone.Text.Trim();
                lePraticien.Type = cbxType.SelectedItem as TypePraticien;
                lePraticien.Specialite = cbxSpecialite.SelectedIndex >= 0 ? cbxSpecialite.SelectedItem as Specialite : null;

                Passerelle.modifierPraticien(lePraticien);

                rafraichirListePraticiens(lePraticien);

                MessageBox.Show("Les coordonnées du praticien ont été modifiées.", "Modification d'un praticien", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Une erreur est survenue lors de la modification du praticien : " + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void suppression()
        {
            if (cbxPraticien.SelectedItem is not Praticien lePraticien)
            {
                MessageBox.Show("Veuillez sélectionner un praticien.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult resultat = MessageBox.Show(
                $"Voulez-vous vraiment supprimer la fiche de {lePraticien.NomPrenom} ?",
                "Confirmation",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (resultat != DialogResult.Yes)
            {
                return;
            }

            try
            {
                Passerelle.supprimerPraticien(lePraticien.Id);
                session.MesPraticiens.Remove(lePraticien);
                rafraichirListePraticiens(null);

                MessageBox.Show("La fiche du praticien a été supprimée.", "Suppression", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Une erreur est survenue lors de la suppression du praticien : " + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void viderChamps()
        {
            txtNom.Clear();
            txtPrenom.Clear();
            txtRue.Clear();
            txtEmail.Clear();
            mtbTelephone.Clear();
            cbxVille.SelectedIndex = -1;
            cbxType.SelectedIndex = -1;
            cbxSpecialite.SelectedIndex = -1;
        }

        private void centrerFormulaire()
        {
            panelCentral.Left = (this.ClientSize.Width - panelCentral.Width) / 2;
        }

        #endregion
    }
}