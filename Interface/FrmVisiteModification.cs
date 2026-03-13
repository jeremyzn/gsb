using Donnee;
using Interface.Properties;
using Metier;
using System.Data;

namespace Interface
{
    public partial class FrmVisiteModification : FrmBase
    {
        public FrmVisiteModification(Session uneSession) : base(uneSession)
        {
            InitializeComponent();
        }

        #region procédures événementielles

        private void FrmVisiteModification_Load(object sender, EventArgs e)
        {
            parametrerComposant();
            remplirDgv();
        }

        private void dgvVisites_SelectionChanged(object sender, EventArgs e)
        {
            afficherVisite();
        }

        private void dgvVisites_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (e.ColumnIndex == 1)
            {
                supprimer(e.RowIndex);
            }
        }

        private void btnModifier_Click(object sender, EventArgs e)
        {
            modifier();
        }

        #endregion

        #region procédures

        private void parametrerComposant()
        {
            this.lblTitre.Text = "Modifier une visite";

            dtpDate.Format = DateTimePickerFormat.Custom;
            dtpDate.CustomFormat = "dd/MM/yyyy HH:mm";

            parametrerDgv(dgvVisites);
        }

        private void parametrerDgv(DataGridView dgv)
        {
            dgv.Columns.Clear();
            dgv.Rows.Clear();

            #region paramètrage concernant le datagridview dans son ensemble

            dgv.Enabled = true;
            dgv.BorderStyle = BorderStyle.FixedSingle;
            dgv.BackgroundColor = Color.White;
            dgv.ForeColor = Color.Black;
            dgv.DefaultCellStyle.Font = new Font("Georgia", 11);
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.MultiSelect = false;
            dgv.AllowUserToDeleteRows = false;
            dgv.AllowUserToAddRows = false;
            dgv.EditMode = DataGridViewEditMode.EditProgrammatically;
            dgv.AllowUserToResizeColumns = false;
            dgv.AllowUserToResizeRows = false;
            dgv.AllowUserToOrderColumns = false;
            dgv.AllowDrop = false;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            #endregion

            #region paramètrage concernant la ligne d'entête

            dgv.ColumnHeadersVisible = true;
            dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgv.EnableHeadersVisualStyles = false;
            DataGridViewCellStyle style = dgv.ColumnHeadersDefaultCellStyle;
            style.BackColor = Color.WhiteSmoke;
            style.ForeColor = Color.Black;
            style.SelectionBackColor = Color.WhiteSmoke;
            style.SelectionForeColor = Color.Black;
            style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            style.Font = new Font("Georgia", 12, FontStyle.Bold);
            dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dgv.ColumnHeadersHeight = 40;

            #endregion

            #region paramètrage concernant l'entête de ligne

            dgv.RowHeadersVisible = false;
            dgv.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;

            #endregion

            #region paramètrage au niveau des lignes

            dgv.RowTemplate.Height = 30;

            #endregion

            #region paramètrage au niveau des cellules

            dgv.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dgv.RowsDefaultCellStyle.BackColor = Color.White;

            #endregion

            #region paramètrage au niveau de la zone sélectionnée

            dgv.RowsDefaultCellStyle.SelectionBackColor = System.Drawing.Color.SteelBlue;
            dgv.RowsDefaultCellStyle.SelectionForeColor = System.Drawing.Color.White;

            #endregion

            #region paramètrage des colonnes

            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            DataGridViewColumn col;

            // Colonne 0 : objet Visite (cachée)
            col = new DataGridViewTextBoxColumn();
            col.Name = "Visite";
            col.HeaderText = "";
            col.Visible = false;
            dgv.Columns.Add(col);

            // Colonne 1 : image de suppression
            DataGridViewImageColumn colImg = new DataGridViewImageColumn();
            colImg.Name = "Supprimer";
            colImg.HeaderText = "";
            colImg.Image = Resources.supprimer;
            colImg.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colImg.ImageLayout = DataGridViewImageCellLayout.Zoom;
            dgv.Columns.Add(colImg);

            // Colonne 2 : La date de la visite
            col = new DataGridViewTextBoxColumn();
            col.Name = "Date";
            col.HeaderText = "Programmée le";
            col.Width = 200;
            col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgv.Columns.Add(col);

            // Colonne 3 : heure du rendez-vous
            col = new DataGridViewTextBoxColumn();
            col.Name = "Heure";
            col.HeaderText = "à";
            col.Width = 50;
            col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.Columns.Add(col);

            // Colonne 4 : ville du rendez-vous
            col = new DataGridViewTextBoxColumn();
            col.Name = "Lieu";
            col.HeaderText = "sur";
            col.Width = 200;
            col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgv.Columns.Add(col);

            // Colonne 5 : praticien à rencontrer
            col = new DataGridViewTextBoxColumn();
            col.Name = "Praticien";
            col.HeaderText = "chez";
            col.Width = 250;
            col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgv.Columns.Add(col);

            for (int i = 0; i < dgv.ColumnCount; i++)
                dgv.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;

            #endregion
        }

        private void remplirDgv()
        {
            dgvVisites.Rows.Clear();
            foreach (Visite v in session.MesVisites.Where(v => v.Bilan is null).OrderBy(v => v.DateEtHeure))
            {
                dgvVisites.Rows.Add(
                    v,
                    Resources.supprimer,
                    v.DateEtHeure.ToLongDateString(),
                    v.DateEtHeure.ToShortTimeString(),
                    v.LePraticien.Ville,
                    v.LePraticien.NomPrenom);
            }
        }

        private void afficherVisite()
        {
            if (dgvVisites.SelectedRows.Count == 0) return;

            Visite? v = getVisiteSelectionnee();
            if (v == null) return;

            lblNom.Text = v.LePraticien.NomPrenom;
            lblDate.Text = v.DateEtHeure.ToString("dd/MM/yyyy HH:mm");
            dtpDate.Value = v.DateEtHeure;
        }

        private Visite? getVisiteSelectionnee()
        {
            if (dgvVisites.SelectedRows.Count == 0) return null;
            return dgvVisites.SelectedRows[0].Cells["Visite"].Value as Visite;
        }

        private void supprimer(int rowIndex)
        {
            Visite? v = dgvVisites.Rows[rowIndex].Cells["Visite"].Value as Visite;
            if (v == null) return;

            DialogResult result = MessageBox.Show(
                $"Voulez-vous vraiment supprimer la visite chez {v.LePraticien.NomPrenom} le {v.DateEtHeure:dd/MM/yyyy} ?",
                "Confirmation",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result != DialogResult.Yes) return;

            try
            {
                Passerelle.supprimerRendezVous(v.Id);
                session.MesVisites.Remove(v);
                remplirDgv();

                lblNom.Text = "";
                lblDate.Text = "";

                MessageBox.Show("La visite a été supprimée avec succès.", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Une erreur est survenue lors de la suppression : " + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void modifier()
        {
            if (dgvVisites.SelectedRows.Count == 0)
            {
                MessageBox.Show("Veuillez sélectionner une visite à modifier.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (dtpDate.Value < DateTime.Now.AddHours(1))
            {
                MessageBox.Show("Veuillez sélectionner une date et une heure futures.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (dtpDate.Value.DayOfWeek == DayOfWeek.Sunday)
            {
                MessageBox.Show("Veuillez sélectionner une date qui n'est pas un dimanche.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (dtpDate.Value.Hour < 8 || dtpDate.Value.Hour >= 19)
            {
                MessageBox.Show("Veuillez sélectionner une heure entre 8 h et 19 h.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (dtpDate.Value > DateTime.Today.AddDays(60).AddHours(19))
            {
                MessageBox.Show("Veuillez sélectionner une date dans les 2 mois à venir.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                Visite? v = getVisiteSelectionnee();
                if (v == null) return;

                DateTime nouvelleDate = dtpDate.Value;

                Passerelle.modifierRendezVous(v.Id, nouvelleDate);
                v.deplacer(nouvelleDate);

                remplirDgv();
                afficherVisite();

                MessageBox.Show("La visite a été modifiée avec succès.", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Une erreur est survenue lors de la modification de la visite : " + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion
    }
}