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
using System.Windows.Shapes;

namespace NorthenLights_LandierJeremy
{
    /// <summary>
    /// Logique d'interaction pour Administrateur.xaml
    /// </summary>
    public partial class Administrateur : Window
    {
        
        public Administrateur()
        {
            
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            dataMedecin.DataContext = MainWindow.myBdd.Medecins.ToList();
        }

        private void DataMedecin_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Medecin medecinAAfficher = (Medecin)dataMedecin.SelectedItem;

            txtboxModifieNom.Text = medecinAAfficher.nom.Trim();
            txtboxModifiePrenom.Text = medecinAAfficher.prenom.Trim();
            txtboxSupprimeNom.Text = medecinAAfficher.nom;
            txtboxSupprimePrenom.Text = medecinAAfficher.prenom;
        }

        private void ConsultationPatients_Click(object sender, RoutedEventArgs e)
        {
            new ConsultationPatient().ShowDialog();
        }

        private void KeyDown(object sender, KeyEventArgs e)
        {
            Validation.CheckKeyLetter(e);
        }


    }
}
