using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace TypesNS
{
    public class Types
    {
        public enum CodeTypes
        {
            Plateforme,
            Genre
        }

        private string[] tPlateformes;
        private string[] tGenres ;

        public Types()
        {
            InitTypes();
            InitModeles();
        }

        private void InitTypes()
        {
            string chemin = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "Types.data");
            List<string> liste = new List<string>();
            StreamReader sr = null;

            try
            {
                // Vérifier si le fichier existe
                if (!File.Exists(chemin))
                    throw new FileNotFoundException("Le fichier Types.data est introuvable.", chemin);

                // Ouvrir le fichier en UTF-8
                sr = new StreamReader(chemin, Encoding.UTF8, true);

                string ligne;
                while ((ligne = sr.ReadLine()) != null)
                {
                    if (!string.IsNullOrWhiteSpace(ligne))
                        liste.Add(ligne.Trim()); // Ajouter au tableau
                }

                tPlateformes = liste.ToArray(); // Convertir en tableau
            }
            catch (FileNotFoundException)
            {
                throw; // relancer l'exception obligatoirement
            }
            catch (Exception ex)
            {
                throw new Exception("Erreur lors de l'initialisation des plateformes : " + ex.Message);
            }
            finally
            {
                sr?.Close();
            }
        }

        private void InitModeles()
        {
            string chemin = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "Modeles.data");
            List<string> liste = new List<string>();
            StreamReader sr = null;

            try
            {
                // Vérifier si le fichier existe
                if (!File.Exists(chemin))
                    throw new FileNotFoundException("Le fichier Modeles.data est introuvable.", chemin);

                // Ouvrir le fichier en UTF-8
                sr = new StreamReader(chemin, Encoding.UTF8, true);

                string ligne;
                while ((ligne = sr.ReadLine()) != null)
                {
                    if (!string.IsNullOrWhiteSpace(ligne))
                        liste.Add(ligne.Trim()); // Ajouter au tableau
                }

                tGenres = liste.ToArray(); // Convertir en tableau
            }
            catch (FileNotFoundException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new Exception("Erreur lors de l'initialisation des genres : " + ex.Message);
            }
            finally
            {
                sr?.Close();
            }
        }

        public string[] GetTypes(CodeTypes type)
        {
            switch (type)
            {
                case CodeTypes.Plateforme:
                    return tPlateformes;
                case CodeTypes.Genre:
                    return tGenres;
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), "Type invalide.");
            }
        }
    }
}
