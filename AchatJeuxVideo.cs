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



namespace AchatJeuxVideo
{
    public partial class AchatJeuxVideo : Form
    {

        #region Declaration

        Transactions oTrans;
        

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

                // Remplir les ComboBox
                platformeComboBox.Items.AddRange(new string[] { "PC", "PlayStation", "Xbox", "Switch", "Mobile" });
                genreComboBox.Items.AddRange(new string[] { "Action", "Aventure", "RPG", "Stratégie" });

                platformeComboBox.SelectedIndex = 0;
                genreComboBox.SelectedIndex = 0;

                // Ajoute les événements pour sélectionner le texte automatiquement
                nomMaskedTextBox.Enter += MaskedTextBox_Enter;
                prenomMaskedTextBox.Enter += MaskedTextBox_Enter;
                adresseMaskedTextBox.Enter += MaskedTextBox_Enter;
                codePostalMaskedTextBox.Enter += MaskedTextBox_Enter;
                telephoneMaskedTextBox.Enter += MaskedTextBox_Enter;
                nomJeuMaskedTextBox.Enter += MaskedTextBox_Enter;
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

        private void enregistrerButton_Click(object sender, EventArgs e)
        {
          
            try
            {
                
                // Calcul du prix selon la plateforme et le genre
              
                decimal prix = oTrans.GetPrix(
                    platformeComboBox.SelectedIndex,
                    genreComboBox.SelectedIndex
                );

                
                // 1 ere technique Par constructeur
                
                Transactions t1 = new Transactions(
                    nomMaskedTextBox.Text,
                    prenomMaskedTextBox.Text,
                    adresseMaskedTextBox.Text,
                    codePostalMaskedTextBox.Text,
                    telephoneMaskedTextBox.Text,
                    nomJeuMaskedTextBox.Text,
                    platformeComboBox.Text,
                    genreComboBox.Text,
                    DateTime.Now,
                    prix
                );
                t1.Enregistrer();

               
                // technique : Par propriétés
                
                Transactions t2 = new Transactions();
                t2.Nom = nomMaskedTextBox.Text;
                t2.Prenom = prenomMaskedTextBox.Text;
                t2.Adresse = adresseMaskedTextBox.Text;
                t2.CodePostal = codePostalMaskedTextBox.Text;
                t2.Telephone = telephoneMaskedTextBox.Text;
                t2.NomJeu = nomJeuMaskedTextBox.Text;
                t2.Plateforme = platformeComboBox.Text;
                t2.Genre = genreComboBox.Text;
                t2.DateAchat = DateTime.Now;
                t2.Prix = prix;
                t2.Enregistrer();

                
                //3 eme technique Par méthode Enregistrer() avec paramètres
               
                Transactions t3 = new Transactions();
                t3.Enregistrer(
                    nomMaskedTextBox.Text,
                    prenomMaskedTextBox.Text,
                    adresseMaskedTextBox.Text,
                    codePostalMaskedTextBox.Text,
                    telephoneMaskedTextBox.Text,
                    nomJeuMaskedTextBox.Text,
                    platformeComboBox.Text,
                    genreComboBox.Text,
                    DateTime.Now,
                    prix
                );

 
              
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show("Erreur de paramètre : " + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur inattendue : " + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        /// <summary>
        /// Sélectionne automatiquement tout le texte quand une zone reçoit le focus.
        /// </summary>
        private void MaskedTextBox_Enter(object sender, EventArgs e)
        {
            if (sender is TextBox txt)
            {
                txt.SelectAll();
            }
        }

    }
}
