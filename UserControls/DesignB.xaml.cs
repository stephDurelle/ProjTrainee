using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

namespace MonStagiaire.UserControls
{
    /// <summary>
    /// Logique d'interaction pour DesignB.xaml
    /// </summary>
    public partial class DesignB : UserControl
    {
        public DesignB()
        {
            InitializeComponent();
            this.MouseLeftButtonDown += DesignB_MouseLeftButtonDown;
        }
        public string Title
        {
            get { return (string)GetValue(TitleProperty); } 
            set { SetValue(TitleProperty, value);}
        }

        public static readonly DependencyProperty TitleProperty =
            DependencyProperty.Register("Title", typeof (string), typeof(DesignB));

        public string Number
        {
            get { return (string)GetValue(NumberProperty); }
            set { SetValue(NumberProperty, value); }
        }

        public static readonly DependencyProperty NumberProperty =
            DependencyProperty.Register("Number", typeof(string), typeof(DesignB));


        public bool IsActive
        {
            get { return (bool)GetValue(IsActiveProperty); }
            set { SetValue(IsActiveProperty, value); }
        }

        public static readonly DependencyProperty IsActiveProperty =
            DependencyProperty.Register("IsActive", typeof(bool), typeof(DesignB));

        public ImageSource Image
        {
            get { return (ImageSource)GetValue(ImageProperty); }
            set { SetValue(ImageProperty, value); }
        }

        public static readonly DependencyProperty ImageProperty =
            DependencyProperty.Register("Image", typeof(ImageSource), typeof(DesignB));


        private void DesignB_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            // Le code à exécuter lors du clic sur le contrôle DesignB
            // Vous pouvez ouvrir une nouvelle fenêtre, changer l'état, etc.
            // Par exemple, vous pouvez définir IsActive sur true.
            this.IsActive = true;
        }
    }
}
