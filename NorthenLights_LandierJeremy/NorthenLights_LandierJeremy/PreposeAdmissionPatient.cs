using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace NorthenLights_LandierJeremy
{
    partial class PreposeFenetre
    {
        //ADMISSION PATIENT
        Admission admissionAAjouter = new Admission();
        private void Admettre_Click(object sender, RoutedEventArgs e)
        {
            Lit litEtat = (Lit)cboxNumeroLit.SelectedItem;

            if (chckChirurgie.IsChecked == true)
                admissionAAjouter.chirurgieProgrammee = true;
            if (chckTelephone.IsChecked == true)
                admissionAAjouter.telephone = true;
            if (chckTeleviseur.IsChecked == true)
                admissionAAjouter.televiseur = true;

            admissionAAjouter.dateAdmission = (DateTime)dateAdmission.SelectedDate;
            admissionAAjouter.dateChirurgie = dateChirurgie.SelectedDate;
            admissionAAjouter.numeroLit = cboxNumeroLit.Text;
            admissionAAjouter.IDMedecin = int.Parse(cboxMedecin.Text);
            admissionAAjouter.NSS = cboxNSS.Text;
            admissionAAjouter.litInferieurDispo = Validation.IsLitInferieurDispo(((Patient)cboxNSS.SelectedItem), cboxTypeLit, cboxDepartement, this);

            if (RequeteLitLibre().Count > 0)
            {
                litEtat.occupe = true;
      
                MainWindow.myBdd.Admissions.Add(admissionAAjouter);
                    if (admissionAAjouter.dateAdmission != null)
                    {
                        if (chckChirurgie.IsChecked == true)
                        {
                            if (admissionAAjouter.dateChirurgie != null)
                            {
                                if (admissionAAjouter.dateChirurgie > admissionAAjouter.dateAdmission)
                                {
                                    updateBdd();
                                }
                                else
                                {
                                    MessageBox.Show("La date de chirurgie doit être ultérieure à la d'admission", "Date Admission", MessageBoxButton.OK, MessageBoxImage.Error);
                                }
                            }
                            else
                            {
                                MessageBox.Show("La case 'Chirurgie' est cochée, une date de chirurgie doit être fournie ", "Date Chirurgie", MessageBoxButton.OK, MessageBoxImage.Error);
                            }
                        }
                        else
                        {
                            updateBdd();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Une date d'admission doit être fournie", "Date Admission", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
            }
            else
            {
                MessageBox.Show("Impossible d'admettre des patients, tous les lits sont occupés", "Admission Impossible", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void cboxNSS_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            txtboxAdmissionNom.Text = ((Patient)cboxNSS.SelectedItem).nom;
            txtboxAdmissionPrenom.Text = ((Patient)cboxNSS.SelectedItem).prenom;

            AssigneADepartement(admissionAAjouter);
        }

        private void SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
                cboxNumeroLit.DataContext = RequeteLitLibre();
               
                if (cboxNumeroLit.SelectedIndex == -1)
                    txtLitOccupe.Text = $"Tous les lits de type { ((TypeLit)cboxTypeLit.SelectedItem).description.Trim()} du département {((Departement)cboxDepartement.SelectedItem).nomDepartement.Trim()} sont occupés";
                else if (RequeteNumeroLit().Count <= 0)
                    txtLitOccupe.Text = "Tous les lits du Northern Lights Hospital sont occupés";
                else
                    txtLitOccupe.Text = string.Empty;
        }


        private void chckChirurgie_Click(object sender, RoutedEventArgs e)
        {
            if (chckChirurgie.IsChecked == true)
            {
                dateChirurgie.IsEnabled = true;
                dateChirurgie.ToolTip = "Choisissez la date de chirurgie";
            }
            if (chckChirurgie.IsChecked == false)
            {
                dateChirurgie.IsEnabled = false;
                dateChirurgie.ToolTip = "La case 'Chirurgie' doit être cochée pour choisir une date de chirurgie";
            }

            AssigneADepartement(admissionAAjouter);
        }

        private void chckChoixLit_Click(object sender, RoutedEventArgs e)
        {
            if (chckChoixLit.IsChecked == true)
            {
                cboxDepartement.IsEnabled = true;
            }
            else if (chckChoixLit.IsChecked == false)
            {
                cboxDepartement.IsEnabled = false;
                cboxDepartement.SelectedIndex = 10;
            }
        }

        private void updateBdd()
        {
            if (MessageBox.Show("Confirmez-vous l'admission de ce patient?", "Confirmation Admission", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    MainWindow.myBdd.SaveChanges();
                    MessageBox.Show("L'admission est ajoutée", "Admission", MessageBoxButton.OK, MessageBoxImage.Information);
                    cboxNSS.DataContext = RequeteNss();
                    cboxNumeroLit.DataContext = RequeteLitLibre();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }



        private void AssigneADepartement(Admission admission)
        {
            //Assigne Patients en Chirurgie si lits dispo, sinon autorise assignation dans autre département
            if (chckChirurgie.IsChecked == true)
            {
                cboxDepartement.SelectedIndex = 11;
                cboxDepartement.ToolTip = "Un patient avec une chirurgie programmée est automatiquement assigné en Chirurgie";
                if (RequeteLitLibreChirurgie().Count > 0)
                    cboxDepartement.IsEnabled = false;
            }
            //Assigne patients de moins de 16 ans sans chirurgie en Pediatrie
            else if (Validation.IsEnfant(((Patient)cboxNSS.SelectedItem).dateNaissance) && chckChirurgie.IsChecked == false)
            {
                cboxDepartement.SelectedIndex = 10;
                cboxDepartement.IsEnabled = false;
                cboxDepartement.ToolTip = "Un patient de moins de 16 sans chirurgie est automatiquement assigné en pédiatrie";
                chckChoixLit.IsEnabled = true;
            }
            else
            {
               cboxDepartement.IsEnabled = true;
                cboxDepartement.ToolTip = "Choisissez le département où assigner le patient";
                chckChoixLit.IsEnabled = false;
            }
        }


    }
}

