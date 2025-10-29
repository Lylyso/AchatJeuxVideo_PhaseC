using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



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
        private string[] tGenres;

        public Types()
        {
            InitTableaux();
        }

        private void InitTableaux()
        {
            tPlateformes = new string[] { "Xbox", "PlayStation", "Nintendo Switch", "PC" };
            tGenres = new string[] { "Action", "Sport", "Aventure" };
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
