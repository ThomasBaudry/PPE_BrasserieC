using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clemence
{
    public class Composition
    {
        private decimal quantite;
        private Ingredient unIngredient;

        public Composition(decimal quantite, Ingredient unIngredient)
        {
            this.quantite = quantite;
            this.unIngredient = unIngredient;
        }

        public decimal Quantite { get => quantite; set => quantite = value; }
        public Ingredient UnIngredient { get => unIngredient; set => unIngredient = value; }
    }
}
