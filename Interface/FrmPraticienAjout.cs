using Donnee;
using Metier;
using System.Text.RegularExpressions;

namespace Interface
{
    public partial class FrmPraticienAjout : FrmBase
    {
        private static readonly string[] noms =
        [
            "Lemoine", "Carrière", "Vidal", "Rivière", "Ménard", "Aubry", "Chevalier", "Daumier", "Fournel", "Prudhomme",
            "Garnier", "Lefèvre", "Renaud", "Brunet", "Marchand", "Arnaud", "Perrin", "Cordier", "Leroux", "Barbier",
            "Collet", "Masson", "Bourdon", "Boulanger", "Giraud", "Guillot", "Delorme", "Renard", "Camus", "Pichon",
            "Laplace", "Tessier", "Dumont", "Gallet", "Noiret", "Hamel", "Mallet", "Roussel", "Besson", "Granger"
        ];

        private static readonly string[] prenoms =
        [
            "Maël", "Inès", "Noémie", "Gabriel", "Léna", "Mathis", "Apolline", "Yanis", "Clémence", "Sacha",
            "Théo", "Camille", "Mila", "Raphaël", "Nina", "Bastien", "Manon", "Axel", "Élise", "Tom",
            "Jules", "Romane", "Émile", "Louna", "Arthur", "Zoé", "Nolan", "Lise", "Paul", "Sarah",
            "Victor", "Lola", "Adam", "Anaïs", "Hugo", "Jeanne", "Evan", "Agathe", "Noah", "Lou"
        ];

        private static readonly string[] rues =
        [
            "Rue des Tilleuls", "Avenue des Cerisiers", "Rue des Violettes", "Boulevard des Alizés", "Rue du Moulin Vert", "Impasse du Levant", "Allée des Jasmins", "Avenue du Belvédère",
            "Rue de la République", "Rue Victor Hugo", "Avenue Jean Jaurès", "Boulevard Gambetta", "Rue des Acacias", "Avenue des Érables", "Rue du Stade", "Rue du Château",
            "Rue des Écoles", "Rue Pasteur", "Avenue de la Gare", "Rue des Bleuets", "Allée des Platanes", "Rue des Marronniers", "Avenue de l'Europe", "Rue du Commerce"
        ];

        public FrmPraticienAjout(Session uneSession) : base(uneSession)
        {
            InitializeComponent();
            KeyPreview = true;
            KeyDown += FrmAjoutPraticien_KeyDown;
        }

        #region procédures événementielles

        private void FrmAjoutPraticien_Load(object sender, EventArgs e)
        {
            parametrerComposant();
            centrerFormulaire();
        }

        private void FrmAjoutPraticien_Resize(object sender, EventArgs e)
        {
            centrerFormulaire();
        }

        #endregion

        #region procédures

        private void parametrerComposant()
        {
            lblTitre.Text = "Nouveau praticien";
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
            cbxSpecialite.SelectedIndex = -1;

            mtbTelephone.Mask = "00 00 00 00 00";
            mtbTelephone.TextMaskFormat = MaskFormat.IncludeLiterals;

            txtVille.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtVille.AutoCompleteSource = AutoCompleteSource.CustomSource;
            var source = new AutoCompleteStringCollection();
            foreach (Ville ville in session!.MesVilles)
            {
                source.Add(ville.Nom);
            }
            txtVille.AutoCompleteCustomSource = source;

            messageNom.Visible = false;
            messagePrenom.Visible = false;
            messageRue.Visible = false;
            messageVille.Visible = false;
            messageTelephone.Visible = false;
            messageEmail.Visible = false;
            messageType.Visible = false;
            messageSpecialite.Visible = false;
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
            if (string.IsNullOrWhiteSpace(txtVille.Text))
            {
                messageVille.Text = "La ville du praticien doit être précisée";
                messageVille.Visible = true;
                return false;
            }

            Ville? laVille = session!.MesVilles.Find(x => x.Nom == txtVille.Text);
            if (laVille is null)
            {
                messageVille.Text = "La ville saisie n'est pas valide";
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

        private bool controlerType()
        {
            if (cbxType.SelectedIndex == -1)
            {
                messageType.Text = "Veuillez sélectionner le type de praticien.";
                messageType.Visible = true;
                return false;
            }
            messageType.Text = string.Empty;
            messageType.Visible = false;
            return true;
        }

        private void ajout()
        {
            bool nomOk = controlerChamp(txtNom, messageNom, "Le nom du praticien doit être précisé");
            bool prenomOk = controlerChamp(txtPrenom, messagePrenom, "Le prénom du praticien doit être précisé");
            bool rueOk = controlerChamp(txtRue, messageRue, "La rue du praticien doit être précisée");
            bool villeOk = controlerVille();
            bool emailOk = controlerEmail();
            bool telephoneOk = controlerTelephone();
            bool typeOk = controlerType();

            if (nomOk && prenomOk && rueOk && villeOk && emailOk && telephoneOk && typeOk)
            {
                ajouter();
            }
        }

        private void ajouter()
        {
            try
            {
                string nom = txtNom.Text.Trim();
                string prenom = txtPrenom.Text.Trim();
                string rue = txtRue.Text.Trim();
                string ville = txtVille.Text;
                string telephone = mtbTelephone.Text.Trim();
                string email = txtEmail.Text.Trim();

                Ville laVille = session!.MesVilles.Find(x => x.Nom == txtVille.Text)!;
                string codePostal = laVille.Code;

                string idType = ((TypePraticien)cbxType.SelectedItem!).Id;
                string? idSpecialite = cbxSpecialite.SelectedIndex == -1
                    ? null
                    : ((Specialite)cbxSpecialite.SelectedItem!).Id;

                int id = Passerelle.ajouterPraticien(nom, prenom, rue, codePostal, laVille.Nom, telephone, email, idType, idSpecialite);

                TypePraticien? leType = session.LesTypesPraticien.Find(x => x.Id == idType);
                Specialite? laSpecialite = idSpecialite is null
                    ? null
                    : session.LesSpecialites.Find(x => x.Id == idSpecialite);

                Praticien unPraticien = new(id, nom, prenom, rue, codePostal, laVille.Nom, email, telephone, leType, laSpecialite);
                session.MesPraticiens.Add(unPraticien);
                session.MesPraticiens.Sort();

                viderChamps();
                MessageBox.Show("Le praticien a été ajouté avec succès.", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Une erreur est survenue lors de l'ajout du praticien : " + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void viderChamps()
        {
            txtNom.Clear();
            txtPrenom.Clear();
            txtRue.Clear();
            txtVille.Clear();
            txtEmail.Clear();
            mtbTelephone.Clear();
            cbxType.SelectedIndex = -1;
            cbxSpecialite.SelectedIndex = -1;
        }

        private void centrerFormulaire()
        {
            panelCentral.Left = (this.ClientSize.Width - panelCentral.Width) / 2;
        }

        private void remplirChampsAleatoires()
        {
            txtNom.Text = noms[Random.Shared.Next(noms.Length)];
            txtPrenom.Text = prenoms[Random.Shared.Next(prenoms.Length)];
            txtRue.Text = $"{Random.Shared.Next(1, 200)} {rues[Random.Shared.Next(rues.Length)]}";

            if (session.MesVilles.Count > 0)
            {
                txtVille.Text = session.MesVilles[Random.Shared.Next(session.MesVilles.Count)].Nom;
            }

            mtbTelephone.Text = $"0{Random.Shared.Next(1, 10)}{Random.Shared.Next(0, 100000000):00000000}";

            string prenomEmail = txtPrenom.Text.Trim().ToLowerInvariant().Replace(" ", string.Empty);
            string nomEmail = txtNom.Text.Trim().ToLowerInvariant().Replace(" ", string.Empty);
            txtEmail.Text = $"{prenomEmail}.{nomEmail}@laposte.net";

            if (cbxType.Items.Count > 0)
            {
                cbxType.SelectedIndex = Random.Shared.Next(cbxType.Items.Count);
            }

            cbxSpecialite.SelectedIndex = cbxSpecialite.Items.Count > 0 && Random.Shared.NextDouble() >= 0.5
                ? Random.Shared.Next(cbxSpecialite.Items.Count)
                : -1;
        }

        private void FrmAjoutPraticien_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F8)
            {
                remplirChampsAleatoires();
                e.Handled = true;
            }
        }

        private void btnAjouter_Click(object sender, EventArgs e)
        {
            ajout();
        }

        #endregion
    }
}