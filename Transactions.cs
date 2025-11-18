
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
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TransactionsNS
{
    public class Transactions
    {
        #region Déclarations des tableaux
        // Tableaux dynamiques chargés à partir des fichiers
        private string[] tPlatforme;
        private string[] tGenre;
        private decimal[,] tPrix; // Tableau des prix par [plateforme, genre]
        #endregion

        #region Déclarations des variables

        // Culture 
        private static CultureInfo CultureEnCA = CultureInfo.GetCultureInfo("en-CA");
        // Les prix dans les fichiers sont en format US (point décimal)
        private static CultureInfo CultureEnUS = CultureInfo.GetCultureInfo("en-US");

        // Expressions régulières pour valider code postal et téléphone
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

        // Codes d’erreurs internes
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

        // Messages associés aux erreurs
        private string[] tMessagesErreurs;
        #endregion

        #region Initialisation (lectures des fichiers)
        // Lance l’initialisation des plateformes 
        private void InitPlatforme()
        {
            InitPlatformes();
        }

        // une plateforme par ligne
        // -------------------------------
        private void InitPlatformes()
        {
            try
            {
                string chemin = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "Platformes.data");

                using (StreamReader sr = new StreamReader(chemin))
                {
                    string first = sr.ReadLine();
                    int nb = int.Parse(first); // FormatException si invalide

                    Array.Resize(ref tPlatforme, nb);

                    for (int i = 0; i < nb; i++)
                    {
                        string ligne = sr.ReadLine();
                        if (ligne == null) throw new FormatException();
                        tPlatforme[i] = ligne.Trim();
                    }
                }
            }
            catch (FileNotFoundException)
            {
                // Rejeter tel quel
                throw new FileNotFoundException();
            }
            catch (FormatException)
            {
                throw new FormatException();
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        // -------------------------------
        // Méthode 1D : genres
        // Fichier: Data\genre.data 
        // -------------------------------
        private void InitGenre()
        {
            try
            {
                string chemin = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "Genre.data");

                using (StreamReader sr = new StreamReader(chemin))
                {
                    string first = sr.ReadLine();
                    int nb = int.Parse(first); // FormatException si invalide

                    Array.Resize(ref tGenre, nb);

                    for (int i = 0; i < nb; i++)
                    {
                        string ligne = sr.ReadLine();
                        if (ligne == null) throw new FormatException();
                        tGenre[i] = ligne.Trim();
                    }
                }
            }
            catch (FileNotFoundException)
            {
                throw new FileNotFoundException();
            }
            catch (FormatException)
            {
                throw new FormatException();
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        // -------------------------------
        private void InitPrix()
        {
            try
            {
                string chemin = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "Prix.data");

                int nbRangees = (tPlatforme == null) ? 0 : tPlatforme.Length;
                int nbColonnes = (tGenre == null) ? 0 : tGenre.Length;

                if (nbRangees <= 0 || nbColonnes <= 0)
                    throw new FormatException(); // dimensions inconnues

                ResizeArray(ref tPrix, nbRangees, nbColonnes);

                using (StreamReader sr = new StreamReader(chemin))
                {
                    for (int r = 0; r < nbRangees; r++)
                    {
                        for (int c = 0; c < nbColonnes; c++)
                        {
                            string ligne = sr.ReadLine();
                            if (ligne == null) throw new FormatException();

                            decimal val = decimal.Parse(ligne.Trim(), NumberStyles.Number, CultureEnUS);
                            tPrix[r, c] = val;
                        }
                    }
                }
            }
            catch (FileNotFoundException)
            {
                throw new FileNotFoundException();
            }
            catch (FormatException)
            {
                throw new FormatException();
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        // Redimensionnement d'un tableau 2D 
        private static void ResizeArray<T>(ref T[,] tableau, int nouvellesRangees, int nouvellesColonnes)
        {
            if (nouvellesRangees < 0 || nouvellesColonnes < 0)
                throw new ArgumentOutOfRangeException();
            
            T[,] nouveau = new T[nouvellesRangees, nouvellesColonnes];

            if (tableau != null && tableau.Length > 0)
            {
                int r = Math.Min(nouvellesRangees, tableau.GetLength(0));
                int c = Math.Min(nouvellesColonnes, tableau.GetLength(1));
                for (int i = 0; i < r; i++)
                    for (int j = 0; j < c; j++)
                        nouveau[i, j] = tableau[i, j];
            }

            tableau = nouveau;
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
        // Constructeur par défaut : initialise tous les tableaux et messages
        public Transactions()
        {
            // l'ordre garantit que InitPrix connaît les dimensions
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
                    throw new ArgumentOutOfRangeException(tMessagesErreurs[(int)CodesErreurs.DateLivraisonInvalide]);
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