/*Programmeur :   Lydianne , Labib, Mohamed
*      Date :     17 Novembre 2025
*   
* Solution:       AchatJeuxVideo.sln
* Projet:         AchatJeuxVideo.csproj
* Classe:         Transactions.cs
*
* But:            Enregistrer une transaction d’achat  selon la plateforme et le genre .
* 
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;     // AJOUT IMPORTANT

namespace TransactionsNS
{
    public class Transactions
    {
        #region Déclarations des tableaux

        private string[] tPlatforme;
        private string[] tGenre;
        private decimal[,] tPrix;

        #endregion

        #region Déclarations des variables

        private const string REGEX_CODE_POSTAL = @"^[A-Za-z]\d[A-Za-z][ -]?\d[A-Za-z]\d$";
        private const string REGEX_TELEPHONE = @"^\(?\d{3}\)?[ -.]?\d{3}[ -.]?\d{4}$";

        //variable publique statique pour numéro de transaction
        public static int CompteurTransactions = 0;

        private int id;
        private string nomClient;
        private string nomJeu;
        private string platforme;
        private string genre;
        private decimal prix;
        private int quantite;
        private decimal total;
        private DateTime dateTransaction;
        private DateTime datePaiement;

        private string codePostal;
        private string telephone;

        private enum CodesErreurs
        {
            NomObligatoire,
            PrenomObligatoire,
            PlateformeObligatoire,
            GenreObligatoire,
            PrixInvalide,
            DateLivraisonInvalide,
            DateTransactionObligatoire,
            ErreurIndeterminee
        }

        private string[] tMessagesErreurs;

        #endregion

        #region Initialisation

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

        private void InitMessagesErreurs()
        {
            tMessagesErreurs = new string[Enum.GetNames(typeof(CodesErreurs)).Length];
            tMessagesErreurs[(int)CodesErreurs.NomObligatoire] = "Le nom est obligatoire.";
            tMessagesErreurs[(int)CodesErreurs.PrenomObligatoire] = "Le prénom est obligatoire.";
            tMessagesErreurs[(int)CodesErreurs.PlateformeObligatoire] = "La plateforme est obligatoire.";
            tMessagesErreurs[(int)CodesErreurs.GenreObligatoire] = "Le genre est obligatoire.";
            tMessagesErreurs[(int)CodesErreurs.PrixInvalide] = "Le prix doit être supérieur à 0 et correspondre à la grille.";
            tMessagesErreurs[(int)CodesErreurs.DateLivraisonInvalide] = "La date de livraison doit être dans les 15 jours avant ou après la date courante.";
            tMessagesErreurs[(int)CodesErreurs.ErreurIndeterminee] = "Erreur indéterminée.";
            tMessagesErreurs[(int)CodesErreurs.DateTransactionObligatoire] = "La date d'achat est obligatoire.";
            

        }

        #endregion

        #region Constructeurs

        public Transactions()
        {
            InitPlatforme();
            InitGenre();
            InitPrix();
            InitMessagesErreurs();
        }

        #endregion

        #region Propriétés avec validations 

        public int Id => id;

        public string NomClient
        {
            get => nomClient;
            set
            {
                if (value != null)
                {
                    value = value.Trim();
                    if (value != string.Empty)
                        nomClient = value;
                    else
                        throw new ArgumentException(tMessagesErreurs[(int)CodesErreurs.NomObligatoire]);
                }
                else
                    throw new ArgumentNullException(tMessagesErreurs[(int)CodesErreurs.NomObligatoire]);
            }
        }

        public string NomJeu
        {
            get => nomJeu;
            set
            {
                if (value != null)
                {
                    value = value.Trim();
                    if (value != string.Empty)
                        nomJeu = value;
                    else
                        throw new ArgumentException(tMessagesErreurs[(int)CodesErreurs.PrenomObligatoire]);
                }
                else
                    throw new ArgumentNullException(tMessagesErreurs[(int)CodesErreurs.PrenomObligatoire]);
            }
        }

        public string Platforme
        {
            get => platforme;
            set
            {
                if (value != null)
                {
                    value = value.Trim();
                    if (Array.IndexOf(tPlatforme, value) != -1)
                        platforme = value;
                    else
                        throw new ArgumentOutOfRangeException(tMessagesErreurs[(int)CodesErreurs.PlateformeObligatoire]);
                }
                else
                    throw new ArgumentNullException(tMessagesErreurs[(int)CodesErreurs.PlateformeObligatoire]);
            }
        }

        public string Genre
        {
            get => genre;
            set
            {
                if (value != null)
                {
                    value = value.Trim();
                    if (Array.IndexOf(tGenre, value) != -1)
                        genre = value;
                    else
                        throw new ArgumentOutOfRangeException(tMessagesErreurs[(int)CodesErreurs.GenreObligatoire]);
                }
                else
                    throw new ArgumentNullException(tMessagesErreurs[(int)CodesErreurs.GenreObligatoire]);
            }
        }

        public int Quantite
        {
            get => quantite;
            set => quantite = value > 0 ? value : throw new ArgumentOutOfRangeException("La quantité doit être positive.");
        }

        public DateTime DateTransaction
        {
            get => dateTransaction;
            set
            {
                if (value == default)
                    throw new ArgumentNullException(tMessagesErreurs[(int)CodesErreurs.DateTransactionObligatoire]);

                DateTime today = DateTime.Today;
                if (value >= today.AddDays(-15) && value <= today.AddDays(15))
                {
                    dateTransaction = value;
                    datePaiement = dateTransaction.AddDays(30);
                }
                else
                    throw new ArgumentOutOfRangeException(
                        tMessagesErreurs[(int)CodesErreurs.DateLivraisonInvalide]);
            }
        }

        public DateTime DatePaiement => datePaiement;

        public decimal Prix
        {
            get => prix;
            set
            {
                if (value <= 0)
                    throw new ArgumentOutOfRangeException(tMessagesErreurs[(int)CodesErreurs.PrixInvalide]);

                int iPlat = Array.IndexOf(tPlatforme, Platforme);
                int iGenre = Array.IndexOf(tGenre, Genre);

                if (iPlat >= 0 && iGenre >= 0)
                {
                    if (tPrix[iPlat, iGenre] == value)
                        prix = value;
                    else
                        throw new ArgumentException(tMessagesErreurs[(int)CodesErreurs.PrixInvalide]);
                }
                else
                {
                    throw new ArgumentNullException(tMessagesErreurs[(int)CodesErreurs.PrixInvalide]);
                }
            }
        }

        public decimal Total
        {
            get => total;
            set => total = value;
        }


        public string CodePostal
        {
            get => codePostal;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Le code postal est obligatoire.");

                if (!Regex.IsMatch(value.Trim(), REGEX_CODE_POSTAL))
                    throw new ArgumentException("Code postal canadien invalide (ex: H2X 3L4).");

                codePostal = value.Trim().ToUpper();
            }
        }

        public string Telephone
        {
            get => telephone;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Le téléphone est obligatoire.");

                if (!Regex.IsMatch(value.Trim(), REGEX_TELEPHONE))
                    throw new ArgumentException("Téléphone canadien invalide (ex: 514-555-1234).");

                telephone = value.Trim();
            }
        }

        #endregion

        #region Méthodes principales

        public void Enregistrer()
        {
            // incrémentation du numéro de transaction
            CompteurTransactions++;
            id = CompteurTransactions;

            Console.WriteLine("Transaction enregistrée :");
            Console.WriteLine($"ID: {Id}, Client: {NomClient}, Produit: {NomJeu}");
            Console.WriteLine($"Plateforme: {Platforme}, Genre: {Genre}");
            Console.WriteLine($"Quantité: {Quantite}, Prix: {Prix:C}, Total: {Total:C}");
            Console.WriteLine($"Code Postal: {CodePostal}, Téléphone: {Telephone}");
            Console.WriteLine($"Date: {DateTransaction:d}, Paiement dû: {DatePaiement:d}");
        }

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
                throw new ArgumentException("Marque inconnue!", nameof(platforme));
            if (posGenre < 0)
                throw new ArgumentException("Genre inconnu!", nameof(genre));
            return tPrix[posPlatforme, posGenre];
        }

        #endregion
        
    }
}
