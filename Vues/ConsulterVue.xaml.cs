using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MySql.Data.MySqlClient;
using System.Data;
namespace MonStagiaire.Vues
{
    /// <summary>
    /// Logique d'interaction pour ConsulterVue.xaml
    /// </summary>
    public partial class ConsulterVue : UserControl
    {

       
        public class Stagiaire
        {
            public string NumeroEtudiant { get; set; }
            public string Nom { get; set; }
            public string Prenom { get; set; }
            public string NomProgramme { get; set; }
        }


         public List<Stagiaire> stagiaires;
        public List<Stagiaire> _listeStagiaires;
        public void MettreAJourListeStagiaires()
        {
            _listeStagiaires.Clear();
            _listeStagiaires.AddRange(ChargerStagiairesDepuisBaseDeDonnees());
            lstStagiaires.ItemsSource = null;
            lstStagiaires.ItemsSource = _listeStagiaires;
        }

        public ConsulterVue()
        {
            
            InitializeComponent();
            ChargerDonneesDepuisBaseDeDonnees();
            stagiaires = new List<Stagiaire>();
            // Ajoutez des exemples de stagiaires à votre liste
            stagiaires.Add(new Stagiaire { NumeroEtudiant = "1234567", Nom = "Durelle", Prenom = "John", NomProgramme = "Informatique" });
            stagiaires.Add(new Stagiaire { NumeroEtudiant = "7654321", Nom = "Lafleur", Prenom = "Orelie", NomProgramme = "Administration" });
            stagiaires.Add(new Stagiaire { NumeroEtudiant = "1340328", Nom = "Varenne", Prenom = "Mbo ", NomProgramme = "Soins Infirmier" });
            stagiaires.Add(new Stagiaire { NumeroEtudiant = "1340328", Nom = "Rodrigue ", Prenom = " Stephane", NomProgramme = "Soins Infirmier" });
            lstStagiaires.ItemsSource = _listeStagiaires;

        }

        private void ChargerDonneesDepuisBaseDeDonnees()
        {
            _listeStagiaires = ChargerStagiairesDepuisBaseDeDonnees();
            lstStagiaires.ItemsSource = _listeStagiaires;
        }

        private List<Stagiaire> ChargerStagiairesDepuisBaseDeDonnees()
        {
            // Code pour récupérer les données depuis la base de données (utilisez votre connexion à la base de données)
            MySqlConnection connection = new MySqlConnection("Server=localhost;Database=basestagiaire;User Id=root;Password=;");

            // Exécutez votre requête SQL pour récupérer les données des stagiaires
            string query = "SELECT * FROM stagiaire";
            MySqlCommand command = new MySqlCommand(query, connection);

            List<Stagiaire> listeStagiaires = new List<Stagiaire>();

            try
            {
                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {// Créez des objets StagiaireModel à partir des données récupérées
                    Stagiaire stagiaire = new Stagiaire
                    {
                        Nom = reader["Nom"].ToString(),
                        Prenom = reader["Prenom"].ToString(),
                        NumeroEtudiant = reader["idEtudiant"].ToString(),                       
                        NomProgramme = reader["Programme"].ToString()
                    };

                    listeStagiaires.Add(stagiaire);
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                // Gérez les exceptions liées à la récupération des données depuis la base de données
                MessageBox.Show("Erreur lors de la récupération des données depuis la base de données.\nErreur : " + ex.Message);
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }

            return listeStagiaires;
        }
    



   private void Search_Click(object sender, RoutedEventArgs e)
{
    string searchText = TexteRech.Text.ToLower();

    // Exécutez votre requête SQL pour récupérer les données filtrées depuis la base de données
    string query = "SELECT * FROM stagiaire " +
                   "WHERE LOWER(Nom) LIKE '%" + searchText + "%' " +
                   "OR LOWER(Prenom) LIKE '%" + searchText + "%' " +
                   "OR LOWER(idEtudiant) LIKE '%" + searchText + "%' " +
                   "OR LOWER(Programme) LIKE '%" + searchText + "%'";
         
            MySqlConnection connection = new MySqlConnection("Server=localhost;Database=basestagiaire;User Id=root;Password=;");
            MySqlCommand command = new MySqlCommand(query, connection);
            List<Stagiaire> filteredStagiaires = new List<Stagiaire>();
             
    try
    {
        connection.Open();
        MySqlDataReader reader = command.ExecuteReader();

        while (reader.Read())
        {
            // Créez des objets StagiaireModel à partir des données récupérées
            Stagiaire stagiaire = new Stagiaire
            {
                Nom = reader["Nom"].ToString(),
                Prenom = reader["Prenom"].ToString(),
                NumeroEtudiant = reader["idEtudiant"].ToString(),                       
                NomProgramme = reader["Programme"].ToString()
            };
            filteredStagiaires.Add(stagiaire);
        }

        reader.Close();
    }
    catch (Exception ex)
    {
        // Gérez les exceptions liées à la récupération des données depuis la base de données
        MessageBox.Show("Erreur lors de la récupération des données depuis la base de données.\nErreur : " + ex.Message);
    }
    finally
    {
        if (connection.State == ConnectionState.Open)
        {
            connection.Close();
        }
    }

    lstStagiaires.ItemsSource = filteredStagiaires;
}


        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            Keyboard.Focus(TexteRech); // Met le focus sur le TextBox
        }

       
    }

    }
