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
using System.Data;
//librairie mySQL pour ma connection
using MySql.Data.MySqlClient;

namespace MonStagiaire.Vues
{
    /// <summary>
    /// Logique d'interaction pour ProgrammeVue.xaml
    /// </summary>
    public partial class ProgrammeVue : UserControl
    {
     

        public ProgrammeVue()
        {
            InitializeComponent();
        

        }

        private void BtnEnregistrer_Click(object sender, RoutedEventArgs e)
        {
            MySqlConnection connection = new MySqlConnection("Server=localhost;Database=basestagiaire;User Id=root;Password=;");

            try
            {
                connection.Open();
                // Récupérer les valeurs des champs
                string nom = txtNom.Text;
                string numero = txtNumeroProgramme.Text;
                string Date = dpDateProgramme.Text;
                // Vérifier la longueur du numéro d'étudiant
                if (numero.Length != 7)
                {
                    MessageBox.Show("Le numéro d'étudiant doit contenir 7 chiffres.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                MessageBox.Show("La base de donnée est accessible");

                // Créer la commande SQL INSERT qui va rajouter ce nouveau programme à ma base de donnée
                string query = "INSERT INTO programmes (Nom, Idprogramme, Duree) VALUES (@Nom, @Duree, @Idprogramme)";
                MySqlCommand command = new MySqlCommand(query, connection);

                // Ajouter les paramètres à la commande
                command.Parameters.AddWithValue("@Nom", nom);
                command.Parameters.AddWithValue("@Idprogramme", Date);
                command.Parameters.AddWithValue("@Duree", numero);
               

                // Exécuter la commande
                int rowsAffected = command.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
//               MessageBox.Show("Programme enregistré avec succès", "Succès", MessageBoxButton.OK, MessageBoxImage.Information);
                    //message de confirmation
                    MessageBox.Show($"Nom Programme: {nom}\nNuméro Programme: {numero}\nDurée du Programme: {Date}");
                    MessageBox.Show("Programme enregistrés", "Succès", MessageBoxButton.OK, MessageBoxImage.Information);
                   // stagiaireVue.MettreAJourListeProgrammesDepuisBaseDeDonnees();

                }
                else
                {
                    MessageBox.Show("Erreur lors de l'enregistrement du programme", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                }

            } catch (MySqlException exept) 
            {
                MessageBox.Show("Vous n'êtes pas connecté à la base de données ou à une table en particulier.\nERREUR: "+ exept) ;
            }          
            // Ajouter le nom du programme à la liste dans StagiaireVue
            // stagiaireVue.AjouterNomProgramme(nom);

        }

        public void ChargerProgrammesDepuisBaseDeDonnees()
        {
            // Code pour récupérer les données depuis la base de données (utilisez votre connexion à la base de données)
            MySqlConnection connection = new MySqlConnection("Server=localhost;Database=basestagiaire;User Id=root;Password=;");

            // Exécutez votre requête SQL pour récupérer les noms de programmes depuis la base de données
            string query = "SELECT Nom FROM programmes";
            MySqlCommand command = new MySqlCommand(query, connection);

            try
            {
                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    // Ajoutez chaque nom de programme à la liste déroulante ou à votre structure de données appropriée
                    string nomProgramme = reader["Nom"].ToString();
                    AjouterNomProgramme(nomProgramme);
                 //   stagiaireVue.AjouterNomProgramme(nomProgramme); // Ajoutez le nom du programme à la liste dans StagiaireVue
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                // Gérez les exceptions liées à la récupération des données depuis la base de données
                MessageBox.Show("Erreur lors de la récupération des données des programmes depuis la base de données.\nErreur : " + ex.Message);
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }

            public void AjouterNomProgramme(string nomProgramme)
        {
          
        }

        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            Keyboard.Focus(textBox); // Met le focus sur le TextBox
        }

      
    }
}
