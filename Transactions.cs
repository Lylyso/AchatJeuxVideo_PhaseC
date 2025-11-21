/*     Programmeur :   Lydianne , Labib, Mohamed
*      Date :          21 Octobre 2025
*      Phase I
*
*      But: Enregistrer une transaction d’achat selon la plateforme et le genre.
*/

using System;
using System.Globalization;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

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
        // Culture requise par l’énoncé
        private static CultureInfo CultureEnCA = CultureInfo.GetCultureInfo("en-CA");
        // Les prix dans les fichiers sont en format US (point décimal)
        private static CultureInfo CultureEnUS = CultureInfo.GetCultureInfo("en-US");

        //----Mohamed-----

        // Délimiteur utilisé quand on écrit la transaction dans le fichier texte
        public const char DELIMITEUR = ';';

        // Propriété statique si la couche présentation veut formatter avec la même culture
        public static CultureInfo CulturePrix => CultureEnCA;
        //----------------

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

        #region Validation transaction

        /// <summary>
        /// Vérifie si toutes les données obligatoires de la transaction
        /// sont présentes et valides.
        /// Ne lance pas d’exception : retourne true/false
        /// et met un message d’erreur dans messageErreur.
        /// </summary>
        public bool TransactionCompletee(out string messageErreur)
        {
            // Nom client
            if (string.IsNullOrWhiteSpace(nomClient))
            {
                messageErreur = tMessagesErreurs[(int)CodesErreurs.NomObligatoire];
                return false;
            }

            // Nom du jeu (on réutilise le message "Prénom" de ton enum)
            if (string.IsNullOrWhiteSpace(nomJeu))
            {
                messageErreur = tMessagesErreurs[(int)CodesErreurs.PrenomObligatoire];
                return false;
            }

            // Plateforme
            if (string.IsNullOrWhiteSpace(platforme))
            {
                messageErreur = tMessagesErreurs[(int)CodesErreurs.PlateformeObligatoire];
                return false;
            }

            // Genre
            if (string.IsNullOrWhiteSpace(genre))
            {
                messageErreur = tMessagesErreurs[(int)CodesErreurs.GenreObligatoire];
                return false;
            }

            // Quantité
            if (quantite <= 0)
            {
                messageErreur = "La quantité doit être supérieure à 0.";
                return false;
            }

            // Prix
            if (prix <= 0)
            {
                messageErreur = tMessagesErreurs[(int)CodesErreurs.PrixInvalide];
                return false;
            }

            // Date d’achat
            if (dateTransaction == default(DateTime))
            {
                messageErreur = tMessagesErreurs[(int)CodesErreurs.DateTransactionObligatoire];
                return false;
            }

            // Code postal
            if (string.IsNullOrWhiteSpace(codePostal))
            {
                messageErreur = "Le code postal est obligatoire.";
                return false;
            }

            // Téléphone
            if (string.IsNullOrWhiteSpace(telephone))
            {
                messageErreur = "Le téléphone est obligatoire.";
                return false;
            }

            // Si tout est OK
            messageErreur = string.Empty;
            return true;
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
            //Verifier si la transaction est complète
            if (!TransactionCompletee(out string messageErreur))
            {
                throw new Exception("Transaction incomplète : " + messageErreur);
            }

            //Générer un ID unique basé sur DateTime.Now.Ticks
            id = (int)(DateTime.Now.Ticks % int.MaxValue);

            try
            {
                //Chemin vers Data\Transactions.data
                string dossier = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data");
                string fichier = Path.Combine(dossier, "Transactions.data");

                if (!Directory.Exists(dossier))
                    Directory.CreateDirectory(dossier);

                //Construire la ligne texte selon l’ordre des champs
                string ligne =
                    id + DELIMITEUR.ToString() +
                    nomClient + DELIMITEUR +
                    nomJeu + DELIMITEUR +
                    platforme + DELIMITEUR +
                    genre + DELIMITEUR +
                    quantite + DELIMITEUR +
                    prix.ToString("F2", CulturePrix) + DELIMITEUR +
                    total.ToString("F2", CulturePrix) + DELIMITEUR +
                    codePostal + DELIMITEUR +
                    telephone + DELIMITEUR +
                    dateTransaction.ToString("yyyy-MM-dd") + DELIMITEUR +
                    datePaiement.ToString("yyyy-MM-dd");

                //ecriture dans le fichier en mode append
                using (StreamWriter sw = new StreamWriter(fichier, true, Encoding.UTF8))
                {
                    sw.WriteLine(ligne);
                }
            }
            catch (UnauthorizedAccessException)
            {
                throw new Exception("Accès refusé : impossible d’écrire dans le fichier Transactions.data.");
            }
            catch (IOException ex)
            {
                throw new Exception("Erreur disque lors de l’écriture de la transaction : " + ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("Erreur inattendue lors de l’enregistrement : " + ex.Message);
            }
        }

        public void Enregistrer(string nomClient, string nomJeu, string platforme, string genre, int quantite, DateTime dateTransaction)
        {
            NomClient = nomClient;
            NomJeu = nomJeu;
            Platforme = platforme;
            Genre = genre;
            Quantite = quantite;
            DateTransaction = dateTransaction;
            Prix = GetPrix(platforme, genre);
            Total = Prix * Quantite;
            Enregistrer();
        }
        #endregion

        #region Méthodes utilitaires
        public string[] GetPlatforme() => tPlatforme;
        public string[] GetGenre() => tGenre;

        public decimal GetPrix(int platformeIndex, int genreIndex)
        {
            if (platformeIndex < 0 || platformeIndex >= tPlatforme.Length)
                throw new ArgumentOutOfRangeException(nameof(platformeIndex), "Indice de plateforme hors limites!");
            if (genreIndex < 0 || genreIndex >= tGenre.Length)
                throw new ArgumentOutOfRangeException(nameof(genreIndex), "Indice de genre hors limites!");
            return tPrix[platformeIndex, genreIndex];
        }

        public decimal GetPrix(string plateforme, string genreStr)
        {
            int posPlatforme = Array.IndexOf(tPlatforme, plateforme);
            int posGenre = Array.IndexOf(tGenre, genreStr);
            if (posPlatforme < 0) throw new ArgumentException("Plateforme inconnue!", nameof(plateforme));
            if (posGenre < 0) throw new ArgumentException("Genre inconnu!", nameof(genreStr));
            return tPrix[posPlatforme, posGenre];
        }

        private static string Sanit(string s) => string.IsNullOrEmpty(s) ? "" : s.Replace(";", " ").Trim();
        #endregion
    }
}