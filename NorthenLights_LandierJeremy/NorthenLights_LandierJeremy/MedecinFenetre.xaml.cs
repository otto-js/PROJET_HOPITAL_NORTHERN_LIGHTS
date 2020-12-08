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
    /// Logique d'interaction pour MedecinFenetre.xaml
    /// </summary>
    public partial class MedecinFenetre : Window
    {
        public MedecinFenetre()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            
            cboxNSS.DataContext = (from p in MainWindow.myBdd.Admissions
                                   where p.dateConge == null
                                   select p).ToList();
        }

        private void cboxNSS_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Admission afficheAdmis = (Admission)cboxNSS.SelectedItem;

            txtBoxNom.Text = afficheAdmis.Patient.nom;
            txtBoxPrenom.Text = afficheAdmis.Patient.prenom;
            txtBoxDOB.Text = afficheAdmis.Patient.dateNaissance.ToShortDateString();
            txtBoxAdresse.Text = afficheAdmis.Patient.adresse;
            txtBoxVille.Text = afficheAdmis.Patient.ville;
            txtBoxProvince.Text = afficheAdmis.Patient.province;
            txtBoxCodePostal.Text = afficheAdmis.Patient.codePostal;
            txtBoxTelephone.Text = afficheAdmis.Patient.telephone;
            txtBoxAdmission.Text = afficheAdmis.dateAdmission.ToShortDateString();
        }

        private void ConfirmerSortie_Click(object sender, RoutedEventArgs e)
        {
            Admission patientSortant = cboxNSS.SelectedItem as Admission;

            patientSortant.Lit.occupe = false;

            if (datePickerSortie.SelectedDate != null)
            {
                if (!(datePickerSortie.SelectedDate < patientSortant.dateAdmission)) {
                    patientSortant.dateConge = datePickerSortie.SelectedDate;
                    if (MessageBox.Show("Confirmez-vous la sortie de ce patient?", "Confirmation Sortie", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                    {
                        try
                        {
                            MainWindow.myBdd.SaveChanges();
                            MessageBox.Show("Sortie du patient confirmée", "Sortie", MessageBoxButton.OK, MessageBoxImage.Information);
                            Facture.AfficherFacture(patientSortant);
                            cboxNSS.DataContext = (from p in MainWindow.myBdd.Admissions
                                                   where p.dateConge == null
                                                   select p).ToList();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Il ne reste plus de patient à congédier", "Sortie Patient", MessageBoxButton.OK, MessageBoxImage.Information);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("La date de sortie ne peut pas être antérieure à la date d'admission", "Date de sortie", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                }
            }
            else
                MessageBox.Show("Une date de sortie doit être fournie", "Date de sortie", MessageBoxButton.OK, MessageBoxImage.Exclamation);
        }       
    }
}
