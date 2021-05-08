using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clemence
{
    public partial class Ajouter : Form
    {
        private Menu appelante;
        private bool type;
        public Recette larecette;
        public Ajouter(Menu appelante)
        {
            InitializeComponent();
            this.appelante = appelante;
            this.type = false;
            this.larecette = new Recette();
        }
        
        public Ajouter(Recette r, Menu appelante)
        {
            InitializeComponent();
            this.larecette = r;
            this.appelante = appelante;
            this.type = true;

        }
        private void Ajouter_Load(object sender, EventArgs e)
        {
            aj5_nom.Visible = false;
            aj5_nb.Visible = false;

            if (this.type == true)
            {
                aj_nom.Text = this.larecette.NomRecette;
                
                for(int i =0; i < this.larecette.LesCompo.Count(); i++)
                {
                    Composition c = this.larecette.LesCompo.ElementAt(i);
                    switch (i)
                    {
                        case 0:
                            aj1_nom.Text = c.UnIngredient.NomIngredient;
                            aj1_nb.Text = Convert.ToString(c.Quantite);
                            break;
                        case 1:
                            aj2_nom.Text = c.UnIngredient.NomIngredient;
                            aj2_nb.Text = Convert.ToString(c.Quantite);
                            break;
                        case 2:
                            aj3_nom.Text = c.UnIngredient.NomIngredient;
                            aj3_nb.Text = Convert.ToString(c.Quantite);
                            break;
                        case 3:
                            aj4_nom.Text = c.UnIngredient.NomIngredient;
                            aj4_nb.Text = Convert.ToString(c.Quantite);
                            break;
                        case 4:
                            aj5_nom.Visible = true;
                            aj5_nb.Visible = true;
                            aj5_nom.Text = c.UnIngredient.NomIngredient;
                            aj5_nb.Text = Convert.ToString(c.Quantite);
                            break;
                    }
                }
                spe_titre.Visible = false;
                spe_nom.Visible = false;
                spe_quantite.Visible = false;
                spe_fournisseur.Visible = false;
                aj_spe_nom.Visible = false;
                aj_spe.Visible = false;
                aj_spe_f.Visible = false;
            }
        }
        private void TextBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void Label8_Click(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if(type == true)
            {
                this.larecette.NomRecette = aj_nom.Text;
                this.larecette.LesCompo.ElementAt(0).Quantite = Convert.ToDecimal(aj1_nb.Text);
                this.larecette.LesCompo.ElementAt(1).Quantite = Convert.ToDecimal(aj2_nb.Text);
                this.larecette.LesCompo.ElementAt(2).Quantite = Convert.ToDecimal(aj3_nb.Text);
                this.larecette.LesCompo.ElementAt(3).Quantite = Convert.ToDecimal(aj4_nb.Text);
                if (this.larecette.LesCompo.Count() > 4)
                {
                    this.larecette.LesCompo.ElementAt(4).Quantite = Convert.ToDecimal(aj5_nb.Text);
                }
                MessageBox.Show("Biere Modifier");
            }
            else
            {
                this.larecette = new Recette(aj_nom.Text, DateTime.Now);
                this.larecette.LesCompo.Add(new Composition(Convert.ToDecimal(aj1_nb.Text), this.larecette.GetIngredient(1)));
                this.larecette.LesCompo.Add(new Composition(Convert.ToDecimal(aj2_nb.Text), this.larecette.GetIngredient(2)));
                this.larecette.LesCompo.Add(new Composition(Convert.ToDecimal(aj3_nb.Text), this.larecette.GetIngredient(3)));
                this.larecette.LesCompo.Add(new Composition(Convert.ToDecimal(aj4_nb.Text), this.larecette.GetIngredient(4)));
                if (!String.IsNullOrEmpty(aj_spe_nom.Text))
                {
                    this.larecette.LesCompo.Add(new Composition(Convert.ToDecimal(aj_spe.Text), this.larecette.ajoutIngredient(aj_spe_nom.Text, aj_spe_f.Text)));
                }
                this.larecette.ajoutRecette();
            }
            RetourMenu(out Recette r);
        }
        public void RetourMenu(out Recette r)
        {
            r = this.larecette;
            this.appelante.Visible = true;
            this.Close();
        }
    }
}
