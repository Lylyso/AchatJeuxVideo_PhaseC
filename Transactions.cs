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
using System.IO; // AJOUTER CETTE DIRECTIVE

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

        // Lecture des plateformes depuis Marques.data
        private void InitPlatformes()
        {
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "plateformes.data");

            try
            {
                if (!File.Exists(filePath))
                    throw new FileNotFoundException("Fichier plateformes.data introuvable.", filePath);

                string[] lignes = File.ReadAllLines(filePath);

                if (lignes.Length == 0)
                    throw new FormatException("Le fichier plateformes.data est vide.");

                int nbPlatformes;

                // Respect EXACT du pseudo-code
                try
                {
                    nbPlatformes = int.Parse(lignes[0].Trim());
                }
                catch (FormatException)
                {
                    throw;
                }

                if (nbPlatformes <= 0)
                    throw new FormatException("Le nombre de plateformes est invalide.");

                if (lignes.Length - 1 < nbPlatformes)
                    throw new FormatException("Il manque des plateformes dans le fichier.");

                tPlatforme = new string[nbPlatformes];

                // Boucle EXACTE du pseudo-code
                for (int i = 0; i < nbPlatformes; i++)
                {
                    string ligne = lignes[i + 1].Trim();

                    if (string.IsNullOrWhiteSpace(ligne))
                        throw new FormatException("Une plateforme vide a été trouvée.");

                    tPlatforme[i] = ligne;
                }
            }
            catch (FileNotFoundException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new Exception("Erreur InitMarques", ex);
            }
        }

        // Lecture des genres (ici réutilise Marques.data volontairement selon votre version actuelle)
        private void InitGenre()
        {
            // NOTE: Peut être adapté pour un fichier Genres.data distinct
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "genres.data");

            try
            {
                // Vérifier l’existence du fichier
                if (!File.Exists(filePath))
                    throw new FileNotFoundException("Fichier genres.data introuvable", filePath);

                // Lecture de toutes les lignes
                string[] lignes = File.ReadAllLines(filePath);

                if (lignes.Length == 0)
                    throw new FormatException("Le fichier genres.data est vide.");

                int nbGenres;

                // Essayer de convertir la première ligne
                try
                {
                    nbGenres = int.Parse(lignes[0].Trim());
                }
                catch (FormatException)
                {
                    // Respect exact du pseudo-code
                    throw;
                }

                // Vérifier le nombre indiqué
                if (nbGenres <= 0)
                    throw new FormatException("Le nombre de genres est invalide.");

                // Vérifier que le fichier contient assez de lignes
                if (lignes.Length - 1 < nbGenres)
                    throw new FormatException("Le fichier ne contient pas assez de genres.");

                // Redimensionner et remplir
                tGenre = new string[nbGenres];

                for (int i = 0; i < nbGenres; i++)
                {
                    string ligne = lignes[i + 1].Trim();

                    if (string.IsNullOrWhiteSpace(ligne))
                        throw new FormatException("Un genre vide a été trouvé dans le fichier.");

                    tGenre[i] = ligne;
                }
            }
            catch (FileNotFoundException)
            {
                // Re-lancer exactement comme demandé
                throw;
            }
            catch (Exception ex)
            {
                // Exception générale enveloppée
                throw new Exception("Erreur InitGenres", ex);
            }
        }

        // Lecture du tableau des prix (dimensions + valeurs)
        private void InitPrix()
        {
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "Prix.data");

            try
            {
                if (!File.Exists(filePath))
                    throw new FileNotFoundException("Fichier Prix.data introuvable.", filePath);

                using (StreamReader sr = new StreamReader(filePath))
                {
                    // LIRE nbMarques
                    int nbMarques = 0;
                    try
                    {
                        nbMarques = int.Parse(sr.ReadLine().Trim());
                    }
                    catch (FormatException)
                    {
                        throw new FormatException("Le nombre de marques est invalide dans Prix.data.");
                    }

                    // LIRE nbGenres
                    int nbGenres = 0;
                    try
                    {
                        nbGenres = int.Parse(sr.ReadLine().Trim());
                    }
                    catch (FormatException)
                    {
                        throw new FormatException("Le nombre de genres est invalide dans Prix.data.");
                    }

                    if (nbMarques <= 0 || nbGenres <= 0)
                        throw new FormatException("Les dimensions du tableau de prix sont invalides.");

                    tPrix = new decimal[nbMarques, nbGenres];

                    // Boucles de lecture des prix
                    for (int i = 0; i < nbMarques; i++)
                    {
                        for (int j = 0; j < nbGenres; j++)
                        {
                            string ligne = sr.ReadLine();
                            if (ligne == null)
                                throw new FormatException("Données manquantes dans Prix.data.");

                            try { tPrix[i, j] = decimal.Parse(ligne.Trim()); }
                            catch (FormatException)
                            {
                                throw new FormatException($"Prix invalide à la ligne pour [{i},{j}].");
                            }
                        }
                    }
                }
            }
            catch (FileNotFoundException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new Exception("Erreur InitPrix", ex);
            }
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
            InitPlatforme();
            InitGenre();
            InitPrix();
            InitMessagesErreurs();
        }
        #endregion

        #region Propriétés avec validations 
        // Identifiant unique (attribué lors de Enregistrer)
        public int Id => id;

        // Nom du client (obligatoire, non vide)
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

        // Nom du jeu (obligatoire)
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

        // Plateforme choisie (doit exister dans le tableau)
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

        // Genre choisi (doit exister dans le tableau)
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

        // Quantité > 0
        public int Quantite
        {
            get => quantite;
            set => quantite = value > 0 ? value : throw new ArgumentOutOfRangeException("La quantité doit être positive.");
        }

        // Date de transaction valide ±15 jours autour d’aujourd’hui
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
                    datePaiement = dateTransaction.AddDays(30); // Paiement dans 30 jours
                }
                else
                    throw new ArgumentOutOfRangeException(tMessagesErreurs[(int)CodesErreurs.DateLivraisonInvalide]);
            }
        }

        // Date de paiement (calculée automatiquement)
        public DateTime DatePaiement => datePaiement;

        // Prix validé par rapport au tableau tPrix
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

        // Total (peut être recalculé après affectations)
        public decimal Total
        {
            get => total;
            set => total = value;
        }

        // Code postal (format canadien)
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

        // Téléphone (format canadien)
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
        // Enregistre la transaction en cours (affiche les détails)
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

        // Surcharge de la méthode Enregistrer avec paramètres explicites
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
        // Accesseurs directs pour les tableaux privés
        public string[] GetPlatforme() => tPlatforme;
        public string[] GetGenre() => tGenre;

        // Récupération du prix selon indices
        public decimal GetPrix(int platforme, int genre)
        {
            if (platforme < 0 || platforme >= tPlatforme.Length)
                throw new ArgumentOutOfRangeException(nameof(platforme), "Indice de plateforme hors limites!");
            if (genre < 0 || genre >= tGenre.Length)
                throw new ArgumentOutOfRangeException(nameof(genre), "Indice de genre hors limites!");
            return tPrix[platforme, genre];
        }

        // Récupération du prix selon noms de plateforme et genre
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
