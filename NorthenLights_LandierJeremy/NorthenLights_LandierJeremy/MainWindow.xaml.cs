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

namespace NorthenLights_LandierJeremy
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static HopitalEntities myBdd = new HopitalEntities();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string utilisateur = txtUtilisateur.Text;
            string mdp = txtMotDePasse.Password;

            if (string.IsNullOrEmpty(utilisateur) || string.IsNullOrEmpty(mdp))
                MessageBox.Show("Les deux champs doivent être renseignés.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
            else if (utilisateur == "admin" && mdp == "admin")
            {
                resetLogin(txtUtilisateur, txtMotDePasse);
                new Administrateur().ShowDialog();
            }
            else if (utilisateur == "prep" && mdp == "prep")
            {
                resetLogin(txtUtilisateur, txtMotDePasse);
                new PreposeFenetre().ShowDialog();
            }
            else if (utilisateur == "medecin" && mdp == "medecin")
            {
                resetLogin(txtUtilisateur, txtMotDePasse);
                new MedecinFenetre().ShowDialog();
            }
            else
            {
                MessageBox.Show("Le nom d'utilisateur ou le mot de passe sont erronés", "Erreur", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void resetLogin(TextBox utilisateur, PasswordBox motDePasse)
        {
            utilisateur.Text = string.Empty;
            motDePasse.Password = string.Empty;
            utilisateur.Focus();
        }

    }
}
