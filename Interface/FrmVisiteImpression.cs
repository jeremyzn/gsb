using Donnee;
using Metier;
using System.Data;

namespace Interface
{
    public partial class FrmVisiteImpression : FrmBase
    {
        public FrmVisiteImpression(Session uneSession) : base(uneSession)
        {
            InitializeComponent();
        }

        # region procédures événementielles

        private void FrmVisiteImpression_Load(object sender, EventArgs e)
        {
            parametrerComposant();
            centrerFormulaire();

        }

        #endregion

        #region procédures

        private void parametrerComposant()
        {
            this.lblTitre.Text = "Impression des rendez-vous sur une période";

        }

        private void centrerFormulaire()
        {
            panelCentral.Left = (this.ClientSize.Width - panelCentral.Width) / 2;
        }

        #endregion

        private void imgImprimer_Click(object sender, EventArgs e)
        {

        }

        private void dptDebut_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dptFin_ValueChanged(object sender, EventArgs e)
        {

        }

        private void imgApercu_Click(object sender, EventArgs e)
        {

        }
    }
}
