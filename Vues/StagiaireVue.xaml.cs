using MonStagiaire.UserControls;
using MySql.Data.MySqlClient;
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
    /// Logique d'interaction pour StagiaireVue.xaml
    /// </summary>
    public partial class StagiaireVue : UserControl
    {
        public ConsulterVue ConsulterVue { get; set; }
        private List<string> _listeProgrammes = new List<string>();
        public StagiaireVue(ConsulterVue consulterVue)
        {
            InitializeComponent();
            this.ConsulterVue = consulterVue;
            ChargerProgrammesDepuisBaseDeDonnees();
        }

       


        private void BtnEnregistrer_Click(object sender, RoutedEventArgs e)
        {
            MySqlConnection connection = new MySqlConnection("Server=localhost;Database=basestagiaire;User Id=root;Password=;");
          
            try
            {
                connection.Open();
                MessageBox.Show("Vous vous êtes connecté avec succès à la base de donnée");
                // Récupérer les valeurs des champs
                string nom = txtnom.Text;
                string prenom = txtPrenom.Text;
                string numeroEtudiant = txtNumeroEtudiant.Text;
                string sexe = cmbSexe.Text;
                string dateAnniversaire = dpDateAnniversaire.Text;
                string nomProgramme = cmbNomProgramme.Text;

                // Vérifier la longueur du numéro d'étudiant
                if (numeroEtudiant.Length != 7)
                {
                    MessageBox.Show("Le numéro d'étudiant doit contenir 7 chiffres.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                // Créer la commande SQL INSERT qui va rajouter ce nouveau programme à ma base de donnée
                string query = "INSERT INTO stagiaire (Nom, Prenom, idEtudiant, sexe, DateAniverssaire, Programme) VALUES (@Nom, @Prenom, @idEtudiant, @sexe, @DateAniverssaire, @Programme)";
                MySqlCommand command = new MySqlCommand(query, connection);

                // Ajouter les paramètres à la commande
                command.Parameters.AddWithValue("@Nom", nom);
                command.Parameters.AddWithValue("@Prenom", prenom);
                command.Parameters.AddWithValue("@idEtudiant", numeroEtudiant);
                command.Parameters.AddWithValue("@sexe", sexe);
                command.Parameters.AddWithValue("@DateAniverssaire", dateAnniversaire);
                command.Parameters.AddWithValue("@Programme", nomProgramme);


                // Exécuter la commande
                int rowsAffected = command.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    //MessageBox.Show("Programme enregistré avec succès", "Succès", MessageBoxButton.OK, MessageBoxImage.Information);
                    //message de confirmation
                    MessageBox.Show($"Nom : {nom}\nPrénom: {prenom}\nNuméro Etudiant: {numeroEtudiant}\nSexe: {sexe}\nDate d'anniversaire: {dateAnniversaire}\nNom Programme: {nomProgramme}");
                    ConsulterVue.MettreAJourListeStagiaires();
                    MessageBox.Show("Informations enregistrées", "Succès", MessageBoxButton.OK, MessageBoxImage.Information);

                    
                   
                }
                else
                {
                    MessageBox.Show("Erreur lors de l'enregistrement du stagiaire", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                }

            }
            catch (MySqlException exept)
            {
                MessageBox.Show("Erreur de connection à la base de données ou à une table en particulier.\nERREUR: " + exept);
            }


        }
        public void ChargerProgrammesDepuisBaseDeDonnees()
        {
            // Utilisez votre logique existante pour charger les programmes depuis la base de données
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
                    string nomProgramme = reader["Nom"].ToString();
                    AjouterNomProgramme(nomProgramme);
                    _listeProgrammes.Add(nomProgramme); // Ajoutez le nom du programme à la liste _listeProgrammes
                }

                reader.Close();
            }
            catch (Exception ex)
            {
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
            cmbNomProgramme.Items.Add(nomProgramme);
        }

        
        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            Keyboard.Focus(textBox); // Met le focus sur le TextBox
        }

      

    }
}
