using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clemence
{
    public class Ingredient
    {
        private int idIngredient;
        private string nomIngredient;
        private string fournisseur;
        private string numBio;

        public int IdIngredient { get => idIngredient; set => idIngredient = value; }
        public string NomIngredient { get => nomIngredient; set => nomIngredient = value; }
        public string Fournisseur { get => fournisseur; set => fournisseur = value; }
        public string NumBio { get => numBio; set => numBio = value; }

        public Ingredient(int id, string nom, string fournisseur)
        {
            this.idIngredient = id;
            this.nomIngredient = nom;
            this.fournisseur = fournisseur;
            this.numBio = null;
        }
        public Ingredient(int id, string nom, string fournisseur, string num)
        {
            this.idIngredient = id;
            this.nomIngredient = nom;
            this.fournisseur = fournisseur;
            this.numBio = num;
        }
        public Ingredient()
        {

        }
        
    }
}
