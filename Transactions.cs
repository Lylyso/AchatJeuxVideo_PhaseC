/*
*  Programmeur :   Lydianne , Labib , Mohamed
*  Date :          23 Septembre 2025
*  
*  Solution :      AchatJeuxVideo.sln
*  Projet :        AchatJeuxVideo.csproj
*  Classe :        Transactions.cs
*  
*  But :            Gérer les transactions d’achat de jeux vidéo.
*                   Implémenter les trois techniques de transfert de données
*                   entre le formulaire principal et la classe métier :
*                     1) Par le constructeur
*                     2) Par les propriétés
*                     3) Par la méthode Enregistrer() avec paramètres
*                   
*  Info :           Phase C — PROG1236
*/

using System;
using System.Windows.Forms;

namespace TransactionsNS
{
    /// <summary>
    /// Classe Transactions permettant de gérer les achats de jeux vidéo.
    /// Contient les propriétés, les constructeurs et les méthodes d’enregistrement.
    /// </summary>
    public class Transactions
    {
        #region Champs privés
        private static int compteur = 1; // ID auto incrémenté
        private int idInt;
        private string nomStr;
        private string prenomStr;
        private string adresseStr;
        private string codePostalStr;
        private string telephoneStr;
        private string nomJeuStr;
        private string plateformeStr;
        private string genreStr;
        private DateTime dateAchatDateTime;
        private decimal prixDecimal;
        #endregion

        #region Propriétés publiques
        public int ID => idInt;

        public string Nom { get => nomStr; set => nomStr = value; }
        public string Prenom { get => prenomStr; set => prenomStr = value; }
        public string Adresse { get => adresseStr; set => adresseStr = value; }
        public string CodePostal { get => codePostalStr; set => codePostalStr = value; }
        public string Telephone { get => telephoneStr; set => telephoneStr = value; }
        public string NomJeu { get => nomJeuStr; set => nomJeuStr = value; }
        public string Plateforme { get => plateformeStr; set => plateformeStr = value; }
        public string Genre { get => genreStr; set => genreStr = value; }
        public DateTime DateAchat { get => dateAchatDateTime; set => dateAchatDateTime = value; }
        public decimal Prix { get => prixDecimal; set => prixDecimal = value; }
        #endregion

        #region Constructeurs
        public Transactions()
        {
            idInt = compteur++;
        }

        public Transactions(string nom, string prenom, string adresse, string codePostal,
                            string telephone, string nomJeu, string plateforme,
                            string genre, DateTime dateAchat, decimal prix)
        {
            idInt = compteur++;
            Nom = nom;
            Prenom = prenom;
            Adresse = adresse;
            CodePostal = codePostal;
            Telephone = telephone;
            NomJeu = nomJeu;
            Plateforme = plateforme;
            Genre = genre;
            DateAchat = dateAchat;
            Prix = prix;
        }
        #endregion

        #region Méthodes
        /// <summary>
        /// Méthode Enregistrer sans paramètre — 2ᵉ méthode de transfert.
        /// Affiche les données de la transaction dans une boîte de message.
        /// </summary>
        public void Enregistrer()
        {
            string info =

                $"ID : {ID}\n" +
                $"Nom : {Nom}\n" +
                $"Prénom : {Prenom}\n" +
                $"Adresse : {Adresse}\n" +
                $"Code postal : {CodePostal}\n" +
                $"Téléphone : {Telephone}\n" +
                $"Nom du jeu : {NomJeu}\n" +
                $"Plateforme : {Plateforme}\n" +
                $"Genre : {Genre}\n" +
                $"Date d'achat : {DateAchat:d}\n" +
                $"Prix : {Prix:C2}\n";
              

            MessageBox.Show(info, "Transaction enregistrée");
        }

        /// <summary>
        /// Méthode Enregistrer avec paramètres — 3ᵉ méthode de transfert.
        /// Initialise les propriétés et appelle la version sans paramètre.
        /// </summary>
        public void Enregistrer(string nom, string prenom, string adresse, string codePostal,
                                string telephone, string nomJeu, string plateforme,
                                string genre, DateTime dateAchat, decimal prix)
        {
            Nom = nom;
            Prenom = prenom;
            Adresse = adresse;
            CodePostal = codePostal;
            Telephone = telephone;
            NomJeu = nomJeu;
            Plateforme = plateforme;
            Genre = genre;
            DateAchat = dateAchat;
            Prix = prix;

            Enregistrer(); // Appelle la version sans paramètre
        }
        #endregion

        #region Tarification
        private string[] tPlatforme = { "PC", "PlayStation", "Xbox", "Switch", "Mobile" };
        private string[] tGenre = { "Action", "Aventure", "RPG", "Stratégie" };

        private decimal[,] tPrix = new decimal[5, 4]
        {
            { 19.99m, 29.99m, 39.99m, 49.99m },
            { 49.99m, 59.99m, 69.99m, 79.99m },
            { 39.99m, 49.99m, 59.99m, 69.99m },
            { 29.99m, 39.99m, 49.99m, 59.99m },
            { 9.99m, 14.99m, 19.99m, 24.99m }
        };

        public decimal GetPrix(int plateforme, int genre)
        {
            return tPrix[plateforme, genre];
        }

        public decimal GetPrix(string plateforme, string genre)
        {
            int i = Array.IndexOf(tPlatforme, plateforme);
            int j = Array.IndexOf(tGenre, genre);
            if (i == -1 || j == -1)
                throw new ArgumentException("Plateforme ou genre invalide!");
            return tPrix[i, j];
        }

        #endregion



    }
}
