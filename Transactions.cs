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
    /// Classe Transactions permettant de récupérer les prix selon la plateforme et le genre.
    /// Implémente les 3 techniques de transfert :
    /// - Par propriétés : définir les propriétés puis appeler Enregistrer()
    /// - Par constructeur : fournir les valeurs au constructeur
    /// - Par méthode Enregistrer(...) : fournir les valeurs puis appeler Enregistrer() interne
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

        #region Déclarations des variables

        private static int compteurID = 0;
        private int id;
        private string nomClient;
        private string nomJeu;
        private string platforme;
        private string genre;
        private decimal prix;
        private int quantite;
        private decimal total;
        private DateTime dateTransaction;

        #endregion

        #region Propriétés publiques

        public int Id
        {
            get { return id; }
        }
        public string NomClient
        {
            get { return nomClient; }
            set { nomClient = value; }
        }
        public string NomJeu
        {
            get { return nomJeu; }
            set { nomJeu = value; }
        }
        public string Platforme
        {
            get { return platforme; }
            set { platforme = value; }
        }
        public string Genre
        {
            get { return genre; }
            set { genre = value; }
        }
        public int Quantite
        {
            get { return quantite; }
            set { quantite = value; }
        }
        public DateTime DateTransaction
        {
            get { return dateTransaction; }
            set { dateTransaction = value; }
        }
        public decimal Prix
        {
            get { return prix; }
            set { prix = value; }
        }
        public decimal Total
        {
            get { return total; }
            set { total = value; }
        }

        #endregion

        #region Initialisation des tableaux

        private void InitPlatforme()
        {
            tPlatforme = new string[] { "PC", "PlayStation", "Xbox", "Switch", "Mobile" };
        }

        private void InitGenre()
        {
            tGenre = new string[] { "Action", "Aventure", "RPG", "Stratégie" };
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

        #region Constructeurs

        /// <summary>
        /// Constructeur par défaut
        /// </summary>
        public void Enregistrer()
        {
            InitPlatforme();
            InitGenre();
            InitPrix();
            compteurID++;
            id = compteurID;
        }

        /// <summary>
        /// Constructeur avec paramètres
        /// </summary>
        public Transactions(string nomClient, string nomJeu, string platforme, string genre, int quantite, DateTime dateTransaction)
        {
            InitPlatforme();
            InitGenre();
            InitPrix();

            this.NomClient = nomClient;
            this.NomJeu = nomJeu;
            this.Platforme = platforme;
            this.Genre = genre;
            this.Quantite = quantite;
            this.DateTransaction = dateTransaction;
            this.Prix = GetPrix(platforme, genre);
            this.Total = this.Prix * this.Quantite;

            compteurID++;
            id = compteurID;

            Enregistrer();
        }

        #endregion

        //Partie Mohamed

        #region Méthodes principales

        /// <summary>
        /// Enregistre la transaction (console)
        /// </summary>
        public void Enregistrer()
        {
            Console.WriteLine("Transaction enregistrée :");
            Console.WriteLine($"ID: {Id}, Client: {NomClient}, Jeu: {NomJeu}, Plateforme: {Platforme}, Genre: {Genre}, Quantité: {Quantite}, Prix Unitaire: {Prix}, Total: {Total}, Date: {DateTransaction}");
        }

        /// <summary>
        /// Enregistre la transaction via paramètres
        /// </summary>
        public void Enregistrer(string nomClient, string nomJeu, string platforme, string genre, int quantite, DateTime dateTransaction)
        {
            this.NomClient = nomClient;
            this.NomJeu = nomJeu;
            this.Platforme = platforme;
            this.Genre = genre;
            this.Quantite = quantite;
            this.DateTransaction = dateTransaction;
            this.Prix = GetPrix(platforme, genre);
            this.Total = this.Prix * this.Quantite;

            Enregistrer();
        }

        #endregion

        #region Méthodes utilitaires

        public string[] GetPlatforme() => tPlatforme;
        public string[] GetGenre() => tGenre;

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

        public decimal GetPrix(string platforme, string genre)
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


