using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clemence
{
    public class Recette
    {
        private int idRecette;
        private string nomRecette;
        private DateTime dateCreation;
        private List<Composition> lesCompo;
        private MySqlConnection conn;
        private string myconnection;

        public Recette()
        {
            this.myconnection = "server=172.19.0.29;uid=clientsql;pwd=0550002D;database=brasserie_clemence;";
            this.conn = new MySql.Data.MySqlClient.MySqlConnection();
            this.conn.ConnectionString = this.myconnection;
        }
        public Recette(int id, string nom, DateTime date)
        {
            this.idRecette = id;
            this.nomRecette = nom;
            this.dateCreation = date;
            this.lesCompo = new List<Composition>();

            this.myconnection = "server=172.19.0.29;uid=clientsql;pwd=0550002D;database=brasserie_clemence;";
            this.conn = new MySql.Data.MySqlClient.MySqlConnection();
            this.conn.ConnectionString = this.myconnection;
        }
        public Recette(string nom, DateTime date)
        {
            this.idRecette = 0;
            this.nomRecette = nom;
            this.dateCreation = date;
            this.lesCompo = new List<Composition>();
            
            this.myconnection = "server=172.19.0.29;uid=clientsql;pwd=0550002D;database=brasserie_clemence;";
            this.conn = new MySql.Data.MySqlClient.MySqlConnection();
            this.conn.ConnectionString = this.myconnection;
        }

        public int IdRecette { get => idRecette; set => idRecette = value; }
        public string NomRecette { get => nomRecette; set => nomRecette = value; }
        public DateTime DateCreation { get => dateCreation; set => dateCreation = value; }
        public List<Composition> LesCompo { get => lesCompo; set => lesCompo = value; }

        public void setLaComposition()
        {
            
            conn.Open();
            string requete = "select Quantite, Ingredient.ID, Ingredient.Nom, Ingredient.Fournisseur from Compositions inner join Ingredient on Compositions.ID = Ingredient.ID where ID_Recette = " +this.idRecette+ ";";
            MySqlCommand cmd = new MySqlCommand(requete, conn);
            MySqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {

                this.lesCompo.Add(new Composition(Convert.ToDecimal(rdr[0]), new Ingredient(Convert.ToInt32(rdr[1]), Convert.ToString(rdr[2]), Convert.ToString(rdr[3]))));
            }
            rdr.Close();
            conn.Close();
        }
        public List<string> getLaComposition()
        {
            List<string> getcompo = new List<string>();
            foreach(Composition c in this.lesCompo)
            {
                getcompo.Add("- " + c.UnIngredient.NomIngredient + " : " + c.Quantite);
            }
            return getcompo;
        }
        public bool estBio()
        {
            bool bio = true;
            foreach (Composition c in this.lesCompo)
            {
                if(c.UnIngredient.NumBio == null)
                {
                    bio = false;
                }
            }
            return bio;
        }
        public void setIdRecette()
        {
            conn.Open();
            string requete = "SELECT COUNT(ID) FROM Recette";
            MySqlCommand cmd = new MySqlCommand(requete, conn);
            MySqlDataReader rdr = cmd.ExecuteReader();
            rdr.Read();
            this.idRecette = Convert.ToInt32(rdr[0])+1;
            rdr.Close();
            conn.Close();
        }
        public void ajoutRecette()
        {
            setIdRecette();
            conn.Open();
            string requete = "INSERT INTO Recette (ID, Nom, DateCrea) VALUES (" + this.idRecette + ", '" + this.nomRecette + "', " + this.dateCreation.Year + "" + this.dateCreation.Month+""+this.dateCreation.Day+");";
            MySqlCommand cmd = new MySqlCommand(requete, conn);
            MySqlDataReader rdr = cmd.ExecuteReader();
            conn.Close();
            ajoutCompo();
        }
        public Ingredient GetIngredient(int id)
        {
            conn.Open();
            string requete = "SELECT * FROM Ingredient WHERE ID = " + id + ";";
            MySqlCommand cmd = new MySqlCommand(requete, conn);
            MySqlDataReader rdr = cmd.ExecuteReader();
            rdr.Read();
            Ingredient ingredient = new Ingredient(Convert.ToInt32(rdr[0]), Convert.ToString(rdr[1]), Convert.ToString(rdr[2]));
            rdr.Close();
            conn.Close();
            return ingredient;
        }
        public int setIdIngredient()
        {
            conn.Open();
            string requete = "SELECT COUNT(ID) FROM Ingredient";
            MySqlCommand cmd = new MySqlCommand(requete, conn);
            MySqlDataReader rdr = cmd.ExecuteReader();
            rdr.Read();
            int id = Convert.ToInt32(rdr[0]) + 1;
            rdr.Close();
            conn.Close();
            return id;
        }
        public Ingredient ajoutIngredient(string nom, string fournisseur)
        {
            int id = setIdIngredient();
            conn.Open();
            string requete = "INSERT INTO Ingredient (ID, Nom, Fournisseur) VALUES (" + id + ", '" + nom + "', '" + fournisseur + "');";
            MySqlCommand cmd = new MySqlCommand(requete, conn);
            MySqlDataReader rdr = cmd.ExecuteReader();
            rdr.Read();
            rdr.Close();
            conn.Close();
            return new Ingredient(id, nom, fournisseur);
        }
        public void ajoutCompo()
        {
            foreach(Composition c in LesCompo)
            {
                string[] nb = Convert.ToString(c.Quantite).Split(',');
                conn.Open();
                string requete = "INSERT INTO Compositions (ID, ID_Recette, Quantite) VALUES (" + c.UnIngredient.IdIngredient + ", " + IdRecette + ", " + nb[0] + "." + nb[1] + ");";
                MySqlCommand cmd = new MySqlCommand(requete, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();
                rdr.Read();
                rdr.Close();
                conn.Close();
            }
        }
        public void supprimeCompo()
        {
            conn.Open();
            string requete = "DELETE FROM Compositions WHERE ID_Recette = " + this.idRecette + ";";
            MySqlCommand cmd = new MySqlCommand(requete, conn);
            MySqlDataReader rdr = cmd.ExecuteReader();
            rdr.Read();
            rdr.Close();
            conn.Close();
        }
        public void supprimeRecette()
        {
            supprimeCompo();
            conn.Open();
            string requete = "DELETE FROM Recette WHERE ID = " + this.idRecette + ";";
            MySqlCommand cmd = new MySqlCommand(requete, conn);
            MySqlDataReader rdr = cmd.ExecuteReader();
            rdr.Read();
            rdr.Close();
            conn.Close();
        }
    }
}
