using MonStagiaire.UserControls;
using MonStagiaire.Vues;
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

namespace MonStagiaire
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
       
        public MainWindow()
        {
            InitializeComponent();

           

        }
        

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if(e.ChangedButton== MouseButton.Left)
            {
                this.DragMove();
            }
        }

        private void Border_MouseLeftButton (object sender, MouseButtonEventArgs e)
        {
            if(e.ClickCount== 1) //ici c'est un click gauche de la souris qui active le bouton au lieu de 2
            {
                this.WindowState = WindowState.Normal; 
            }
            if (e.Source is DesignB designB && designB.Title == "Stagiaire")
            {
                // Créez une instance de ConsulterVue (si elle n'existe pas déjà)
                ConsulterVue consulterVue = new ConsulterVue();
                // Créez une instance de StagiaireVue en lui passant la référence de ConsulterVue
                StagiaireVue stagiaireVue = new StagiaireVue(consulterVue);
                ProgrammeVue programmeVue = new ProgrammeVue();
                programmeVue.ChargerProgrammesDepuisBaseDeDonnees();
                // Définissez la référence de ConsulterVue dans votre StagiaireVue
                stagiaireVue.ConsulterVue = consulterVue;

                // Définissez le contenu de MainFram comme StagiaireVue
                MainFram.Content = stagiaireVue;


            }
            if (e.Source is DesignB design && design.Title == "Programme")
            {
                MainFram.Content = new ProgrammeVue();
            }
            if (e.Source is DesignB designC && designC.Title == "Consulter")
            {
                MainFram.Content = new ConsulterVue();
            }
          
        }
      


    }
}
