


/*Programmeur :   Lydianne , Labib, Mohamed
*      Date :          30 Octobre 2025
*   
*      Solution:       AchatJeuxVideo.sln
* Projet:         AchatJeuxVideo.csproj
* Classe:         AchatJeuxVideo.cs
*
* But:            Calculer le prix d'achat d'un jeu vidéo en fonction de la plateforme et du genre.
* 
*      Info:           Phase C.
*/


using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

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
        #region Déclarations des tableaux

        private string[] tPlatforme;
        private string[] tGenre;
        private decimal[,] tPrix;

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

        private void InitPrix()
        {
            tPrix = new decimal[5, 4]
            {
                { 19.99m, 29.99m, 39.99m, 49.99m },
                { 49.99m, 59.99m, 69.99m, 79.99m },
                { 39.99m, 49.99m, 59.99m, 69.99m },
                { 29.99m, 39.99m, 49.99m, 59.99m },
                { 9.99m, 14.99m, 19.99m, 24.99m }
            };
        }

        #endregion

        #region Constructeurs

        /// <summary>
        /// Constructeur par défaut
        /// </summary>
        public Transactions()
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

        public decimal GetPrix(int platforme, int genre)
        {
            if (platforme < 0 || platforme >= tPlatforme.Length)
                throw new ArgumentOutOfRangeException(nameof(platforme), "Indice de plateforme hors limites!");
            if (genre < 0 || genre >= tGenre.Length)
                throw new ArgumentOutOfRangeException(nameof(genre), "Indice de genre hors limites!");
            return tPrix[platforme, genre];
        }

        public decimal GetPrix(string platforme, string genre)
        {
            int posPlatforme = Array.IndexOf(tPlatforme, platforme);
            int posGenre = Array.IndexOf(tGenre, genre);
            if (posPlatforme < 0)
                throw new ArgumentException("Plateforme inconnue!", nameof(platforme));
            if (posGenre < 0)
                throw new ArgumentException("Genre inconnu!", nameof(genre));
            return tPrix[posPlatforme, posGenre];
        }

        #endregion
    }
}
