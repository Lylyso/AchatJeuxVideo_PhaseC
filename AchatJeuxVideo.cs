/*
 *      Programmeur :   Lydianne , Labib , Mohamed
 *      Date :          23 Septembre 2025
 *   
 *      Solution:       AchatJeuxVideo.sln
 *      Projet:         AchatJeuxVideo.csproj
 *      Classe:         AchatJeuxVideo.cs
 *      
 *      But:            calculer le prix d'achat d'un jeu vidéo en fonction de la plateforme et du genre.
 * 
 *      Info:           Phase A.
 * 
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using TransactionsNS;
using g = AchatJeuxVideo.AchatJeuxVideoGeneraleClasse;
using ce = AchatJeuxVideo.AchatJeuxVideoGeneraleClasse.CodesErreurs;

using TypesNS;

namespace AchatJeuxVideo
{
    public partial class AchatJeuxVideo : Form
    {

        #region Declaration

        Transactions oTrans;
        Types oTypes;

        #endregion

        #region Constructeur

        /// <summary>
        /// Constructeur
        /// </summary>
        public AchatJeuxVideo()
        {
            InitializeComponent();
        }

        #endregion

        #region Initialisation

        private void AchatJeuxVideo_Load(object sender, EventArgs e)
        {
            try
            {
                g.InitMessagesErreurs();

                oTrans = new Transactions();
                oTypes = new Types();

                platformeComboBox.Items.AddRange(oTypes.GetTypes(Types.CodeTypes.Plateforme));
                genreComboBox.Items.AddRange(oTypes.GetTypes(Types.CodeTypes.Genre));

                platformeComboBox.SelectedIndex = 0;
                genreComboBox.SelectedIndex = 0;
            }
            catch (ArgumentOutOfRangeException ex)
            {
                MessageBox.Show("Erreur de plage : " + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur inattendue : " + ex.Message);
            }
        }

        private void PlatformeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (platformeComboBox.SelectedIndex != -1 && genreComboBox.SelectedIndex != -1)
                {
                    prixLabel.Text = oTrans.GetPrix(platformeComboBox.SelectedIndex, genreComboBox.SelectedIndex)
                                           .ToString("C2");
                }
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show("Erreur de paramètre : " + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors du calcul du prix : " + ex.Message);
            }
        }

        #endregion

        #region Obtenir le prix

        private void PlateformeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (platformeComboBox.SelectedIndex != -1 && genreComboBox.SelectedIndex != -1)
                    prixLabel.Text = oTrans.GetPrix(platformeComboBox.SelectedIndex, genreComboBox.SelectedIndex).ToString("C2");
            }
            catch (Exception)
            {
                MessageBox.Show(g.tMessages[(int)ce.ErreurPrix]);
            }
        }

        #endregion

        #region Quitter
        private void QuitterButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        private void aproposDeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmAPropos frm = new FrmAPropos();
            frm.ShowDialog();
        }
    }
}
