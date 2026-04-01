using Donnee;
using Metier;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Interface
{
    public partial class FrmVisiteConsultation : FrmBase
    {
        private readonly Color couleurVisitePassee = Color.FromArgb(208, 245, 208);

        public FrmVisiteConsultation(Session uneSession) : base(uneSession)
        {
            InitializeComponent();
        }

        #region procédures événementielles

        private void FrmConsultation_Load(object sender, EventArgs e)
        {
            parametrerComposant();
            centrerFormulaire();

            if (session.MesVisites.Count > 0)
            {
                remplirDgvVisites();
                afficher();
            }
            else
            {
                label1.Text = "Aucune visite enregistrée.";
            }
        }

        private void FrmVisiteConsultation_Resize(object sender, EventArgs e)
        {
            centrerFormulaire();
        }

        private void dgvVisites_SelectionChanged(object sender, EventArgs e)
        {
            afficher();
        }

        #endregion

        #region procédures

        private void parametrerComposant()
        {
            lblTitre.Text = "Consultation des visites";
            panelCentral.Anchor = AnchorStyles.None;

            parametrerDgv(dgvVisites);
            parametrerDgvEchantillons();

            lstMedicament.Items.Clear();
            ViderAffichage();
        }

        private void parametrerDgvEchantillons()
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
            style.Font = new Font("Georgia", 12, FontStyle.Bold);

            dgvEchantillon.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dgvEchantillon.ColumnHeadersHeight = 40;

            dgvEchantillon.RowHeadersVisible = false;
            dgvEchantillon.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvEchantillon.RowTemplate.Height = 28;
            dgvEchantillon.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dgvEchantillon.RowsDefaultCellStyle.BackColor = Color.White;
            dgvEchantillon.RowsDefaultCellStyle.SelectionBackColor = Color.White;
            dgvEchantillon.RowsDefaultCellStyle.SelectionForeColor = Color.Black;

            DataGridViewColumn col;

            col = new DataGridViewTextBoxColumn();
            col.Name = "Medicament";
            col.HeaderText = "Médicament";
            col.Width = 200;
            dgvEchantillon.Columns.Add(col);

            col = new DataGridViewTextBoxColumn();
            col.Name = "Quantite";
            col.HeaderText = "Qté";
            col.Width = 100;
            col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvEchantillon.Columns.Add(col);

            for (int i = 0; i < dgvEchantillon.ColumnCount; i++)
            {
                dgvEchantillon.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            dgvEchantillon.Width = getLargeur(dgvEchantillon);
        }

        private void parametrerDgv(DataGridView dgv)
        {
            dgv.Columns.Clear();
            dgv.Rows.Clear();

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
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;

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

            dgv.RowHeadersVisible = false;
            dgv.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgv.RowTemplate.Height = 30;

            dgv.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dgv.RowsDefaultCellStyle.BackColor = Color.White;
            dgv.RowsDefaultCellStyle.SelectionBackColor = Color.White;
            dgv.RowsDefaultCellStyle.SelectionForeColor = Color.Black;

            DataGridViewColumn col;

            col = new DataGridViewTextBoxColumn();
            col.Name = "Visite";
            col.HeaderText = "";
            col.Visible = false;
            col.Width = 0;
            dgv.Columns.Add(col);

            col = new DataGridViewTextBoxColumn();
            col.Name = "Date";
            col.HeaderText = "Date";
            col.Width = 200;
            col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgv.Columns.Add(col);

            col = new DataGridViewTextBoxColumn();
            col.Name = "Heure";
            col.HeaderText = "à";
            col.Width = 50;
            col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.Columns.Add(col);

            col = new DataGridViewTextBoxColumn();
            col.Name = "Lieu";
            col.HeaderText = "Lieu";
            col.Width = 200;
            col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgv.Columns.Add(col);

            for (int i = 0; i < dgv.ColumnCount; i++)
            {
                dgv.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            dgv.Width = getLargeur(dgv);
        }

        private int getLargeur(DataGridView dgv)
        {
            int largeur = 0;
            foreach (DataGridViewColumn col in dgv.Columns)
            {
                if (col.Visible)
                {
                    largeur += col.Width;
                }
            }
            if (dgv.RowHeadersVisible)
            {
                largeur += dgv.RowHeadersWidth;
            }
            return largeur + 2;
        }

        private void centrerFormulaire()
        {
            panelCentral.Left = (this.ClientSize.Width - panelCentral.Width) / 2;
        }

        private void remplirDgvVisites()
        {
            dgvVisites.Rows.Clear();

            foreach (Visite visite in session.MesVisites.OrderBy(v => v.DateEtHeure))
            {
                int rowIndex = dgvVisites.Rows.Add(
                    visite,
                    visite.DateEtHeure.ToLongDateString(),
                    visite.DateEtHeure.ToShortTimeString(),
                    visite.LePraticien.Ville);

                if (!string.IsNullOrWhiteSpace(visite.Bilan))
                {
                    dgvVisites.Rows[rowIndex].DefaultCellStyle.BackColor = couleurVisitePassee;
                }
            }

            if (dgvVisites.Rows.Count > 0)
            {
                dgvVisites.Rows[0].Selected = true;
            }
        }

        private void afficher()
        {
            if (dgvVisites.SelectedRows.Count > 0)
            {
                Visite? visite = (Visite?)dgvVisites.SelectedRows[0].Cells["Visite"].Value;
                if (visite == null)
                {
                    ViderAffichage();
                    return;
                }

                lblPraticien.Text = visite.LePraticien.NomPrenom;
                lblRue.Text = $"{visite.LePraticien.Rue} - {visite.LePraticien.CodePostal} {visite.LePraticien.Ville}";
                lblTelephone.Text = visite.LePraticien.Telephone;
                lblEmail.Text = visite.LePraticien.Email;
                lblType.Text = visite.LePraticien.Type?.Libelle ?? string.Empty;
                lblSpecialite.Text = visite.LePraticien.Specialite?.Libelle ?? string.Empty;
                lblMotif.Text = visite.LeMotif.Libelle;
                lblBilan.Text = visite.Bilan ?? string.Empty;

                lstMedicament.Items.Clear();
                if (visite.PremierMedicament != null)
                {
                    lstMedicament.Items.Add(visite.PremierMedicament.Nom);
                }
                if (visite.SecondMedicament != null)
                {
                    lstMedicament.Items.Add(visite.SecondMedicament.Nom);
                }

                dgvEchantillon.Rows.Clear();
                foreach (KeyValuePair<Medicament, int> echantillon in visite)
                {
                    dgvEchantillon.Rows.Add(echantillon.Key.Nom, echantillon.Value);
                }
            }
        }

        private void ViderAffichage()
        {
            lblPraticien.Text = string.Empty;
            lblRue.Text = string.Empty;
            lblTelephone.Text = string.Empty;
            lblEmail.Text = string.Empty;
            lblType.Text = string.Empty;
            lblSpecialite.Text = string.Empty;
            lblMotif.Text = string.Empty;
            lblBilan.Text = string.Empty;
            lstMedicament.Items.Clear();
            dgvEchantillon.Rows.Clear();
        }

        private Visite? getVisite()
        {
            if (dgvVisites.SelectedRows.Count == 0)
            {
                return null;
            }

            return dgvVisites.SelectedRows[0].Cells["Visite"].Value as Visite;
        }

        #endregion
    }
}