
/*     Programmeur :   Lydianne , Labib, Mohamed
*      Date :          17 Octobre 2025
*   
*      Solution:       AchatJeuxVideo.sln
*      Projet:         AchatJeuxVideo.csproj
*      Classe:         AchatJeuxVideo.cs
*
*      But:            Calculer le prix d'achat d'un jeu vidéo en fonction de la plateforme et du genre.
* 
*      Info:           Phase H
*/

using System;
using System.Windows.Forms;
using TransactionsNS;
using g = AchatJeuxVideo.AchatJeuxVideoGeneraleClasse;
using ce = AchatJeuxVideo.AchatJeuxVideoGeneraleClasse.CodesErreurs;
using TypesNS;

namespace AchatJeuxVideo
{
    public partial class AchatJeuxVideo : Form
    {
        #region Déclaration

        Transactions oTrans;
        Types oTypes;

        #endregion

        #region Constructeur

        /// <summary>
        /// Constructeur principal du formulaire
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

                platformeComboBox.Items.Clear();
                genreComboBox.Items.Clear();

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

        #endregion

        #region Obtenir le prix

        private void PlatformeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (platformeComboBox.SelectedIndex != -1 && genreComboBox.SelectedIndex != -1)
                {
                    prixLabel.Text = oTrans.GetPrix(platformeComboBox.SelectedIndex, genreComboBox.SelectedIndex).ToString("C2");
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

        #region Quitter

        private void QuitterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        #region À propos

        private void AproposDeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmAPropos frm = new FrmAPropos();
            frm.ShowDialog();
        }

        #endregion

        //mohamed
        #region Enregistrement (test des 3 techniques)

        /// <summary>
        /// Enregistre la transaction en testant les 3 techniques de transfert
        /// </summary>
        private void EnregistrerButton_Click(object sender, EventArgs e)
        {
            try
            {
                string nomClient = nomMaskedTextBox.Text;
                string nomJeu = nomJeuMaskedTextBox.Text;
                string plateforme = platformeComboBox.Text;
                string genre = genreComboBox.Text;
                int quantite = 1;
                DateTime date = DateTime.Now;

                // Technique 1 : Par propriété
                oTrans.NomClient = nomClient;
                oTrans.NomJeu = nomJeu;
                oTrans.Platforme = plateforme;
                oTrans.Genre = genre;
                oTrans.Quantite = quantite;
                oTrans.DateTransaction = date;
                oTrans.Prix = oTrans.GetPrix(plateforme, genre);
                oTrans.Total = oTrans.Prix * quantite;
                oTrans.Enregistrer();

                // Technique 2 : Par méthode
                oTrans.Enregistrer(nomClient, nomJeu, plateforme, genre, quantite, date);

                // Technique 3 : Par constructeur
                //Transactions transConstructeur = new Transactions(nomClient, nomJeu, plateforme, genre, quantite, date);
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show("Erreur d'argument : " + ex.Message);
            }
            catch (FormatException ex)
            {
                MessageBox.Show("Erreur de format : " + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur inattendue : " + ex.Message);
            }

            MessageBox.Show("Date de paiement prévue : " + oTrans.DatePaiement.ToLongDateString());

        }

        #endregion

        #region Methode MaskedTextBox
        private void MaskedTextBoxEnter(object sender, EventArgs e)
        {
            if (sender is MaskedTextBox mtb)
            {
                mtb.SelectAll();
            }
        }

        #endregion


    }
}


