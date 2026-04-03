using Donnee;
using Interface.Properties;
using Metier;
using System.Data;

namespace Interface
{
    public partial class FrmPraticienListe : FrmBase
    {
        public FrmPraticienListe(Session uneSession) : base(uneSession)
        {
            InitializeComponent();
        }

        #region procédures événementielles

        private void FrmPraticienListe_Load(object sender, EventArgs e)
        {
            parametrerComposant();
            remplirDgv();
            centrerFormulaire();
        }

        private void FrmPraticienListe_Resize(object sender, EventArgs e)
        {
            centrerFormulaire();
        }

        #endregion

        #region procédures

        private void parametrerComposant()
        {
            lblTitre.Text = "Liste des praticiens";
            panelCentral.Anchor = AnchorStyles.None;
            parametrerDgv(dgvPraticiens);

            panelCentral.Width = dgvPraticiens.Width;
            dgvPraticiens.Left = 0;
            dgvPraticiens.Top = 0;
            dgvPraticiens.Height = panelCentral.Height;
        }

        private void parametrerDgv(DataGridView dgv)
        {
            dgv.Columns.Clear();
            dgv.Rows.Clear();

            dgv.Enabled = true;
            dgv.BorderStyle = BorderStyle.FixedSingle;
            dgv.BackgroundColor = Color.White;
            dgv.ForeColor = Color.Black;
            dgv.DefaultCellStyle.Font = new Font("Georgia", 10);
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
            style.Font = new Font("Georgia", 10, FontStyle.Bold);
            dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dgv.ColumnHeadersHeight = 40;

            dgv.RowHeadersVisible = false;
            dgv.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgv.RowTemplate.Height = 34;

            dgv.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dgv.RowsDefaultCellStyle.BackColor = Color.White;
            dgv.RowsDefaultCellStyle.SelectionBackColor = Color.White;
            dgv.RowsDefaultCellStyle.SelectionForeColor = Color.Black;

            DataGridViewColumn col;

            col = new DataGridViewTextBoxColumn();
            col.Name = "Praticien";
            col.Visible = false;
            col.Width = 0;
            dgv.Columns.Add(col);

            col = new DataGridViewTextBoxColumn();
            col.Name = "NomPrenom";
            col.HeaderText = "Nom et prénom";
            col.Width = 185;
            dgv.Columns.Add(col);

            col = new DataGridViewTextBoxColumn();
            col.Name = "Telephone";
            col.HeaderText = "Téléphone";
            col.Width = 95;
            dgv.Columns.Add(col);

            col = new DataGridViewTextBoxColumn();
            col.Name = "Email";
            col.HeaderText = "Email";
            col.Width = 200;
            dgv.Columns.Add(col);

            col = new DataGridViewTextBoxColumn();
            col.Name = "Adresse";
            col.HeaderText = "Adresse";
            col.Width = 395;
            col.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dgv.Columns.Add(col);

            col = new DataGridViewTextBoxColumn();
            col.Name = "DateDerniereVisite";
            col.HeaderText = "Date dernière\nvisite";
            col.Width = 150;
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

        private void remplirDgv()
        {
            dgvPraticiens.Rows.Clear();

            foreach (Praticien p in session.MesPraticiens.OrderBy(x => x.NomPrenom))
            {
                DateTime? derniereVisite = session.MesVisites
                    .Where(v => v.LePraticien == p && v.DateEtHeure <= DateTime.Now)
                    .OrderByDescending(v => v.DateEtHeure)
                    .Select(v => (DateTime?)v.DateEtHeure)
                    .FirstOrDefault();

                string texteDate = derniereVisite.HasValue
                    ? derniereVisite.Value.ToLongDateString()
                    : "Aucune visite";

                string adresse = $"{p.Rue}\n{p.CodePostal} {p.Ville}";

                int idx = dgvPraticiens.Rows.Add(
                    p,
                    p.NomPrenom,
                    p.Telephone,
                    p.Email,
                    adresse,
                    texteDate);

                if (!derniereVisite.HasValue)
                {
                    dgvPraticiens.Rows[idx].DefaultCellStyle.ForeColor = Color.Red;
                }
            }
        }

        private void centrerFormulaire()
        {
            panelCentral.Left = (this.ClientSize.Width - panelCentral.Width) / 2;
        }

        #endregion
    }
}