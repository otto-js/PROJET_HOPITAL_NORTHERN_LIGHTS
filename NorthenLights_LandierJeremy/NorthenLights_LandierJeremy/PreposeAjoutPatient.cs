using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;



namespace NorthenLights_LandierJeremy
{
    partial class PreposeFenetre
    {
        //AJOUT PATIENT
        private void Ajouter_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtboxNSS.Text) &&
                !string.IsNullOrEmpty(txtboxNom.Text) &&
                !string.IsNullOrEmpty(txtboxPrenom.Text) &&
                dateDOB.SelectedDate != null &&
                !string.IsNullOrEmpty(txtboxAdresse.Text) &&
                !string.IsNullOrEmpty(txtboxVille.Text) &&
                !string.IsNullOrEmpty(cboxProvince.Text) &&
                !string.IsNullOrEmpty(txtboxCodePostal.Text) &&
                !string.IsNullOrEmpty(txtboxTelephone.Text) &&
                !string.IsNullOrEmpty(txtboxNSS.Text))
            {
                if (!(dateDOB.SelectedDate > DateTime.Today))
                {
                    if (Regex.IsMatch(txtboxCodePostal.Text, @"\D\d\D\d\D\d$"))
                    {
                        Patient nouveauPatient = new Patient();
                        nouveauPatient.NSS = txtboxNSS.Text;
                        nouveauPatient.dateNaissance = (DateTime)dateDOB.SelectedDate;
                        nouveauPatient.nom = txtboxNom.Text;
                        nouveauPatient.prenom = txtboxPrenom.Text;
                        nouveauPatient.adresse = txtboxAdresse.Text;
                        nouveauPatient.ville = txtboxVille.Text;
                        nouveauPatient.province = cboxProvince.Text;
                        nouveauPatient.codePostal = txtboxCodePostal.Text;
                        nouveauPatient.telephone = txtboxTelephone.Text;
                        nouveauPatient.IDAssurance = ((Assurance)cboxAssurance.SelectedItem).IDAssurance;

                        if (!Validation.IsPatientExistant(nouveauPatient, MainWindow.myBdd))
                        {
                            if (MessageBox.Show("Confirmez-vous l'ajout de ce patient?", "Confirmation Ajout", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                            {
                                MainWindow.myBdd.Patients.Add(nouveauPatient);
                                try
                                {
                                    MainWindow.myBdd.SaveChanges();
                                    MessageBox.Show("Le patient a bien été ajouté");
                                    cboxNSS.DataContext = RequeteNss();
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show(ex.Message, "Erreur Ajout", MessageBoxButton.OK, MessageBoxImage.Error);
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("Un patient avec le NSS " + txtboxNSS.Text + " existe déjà!", "Erreur Patient Existant", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Le code postal doit être dans le format suivant : H1H1H1", "Attention Code Postal", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                else
                {
                    MessageBox.Show("La date de naissance ne peut être ultérieure à la date actuelle", "Attention Date Naissance", MessageBoxButton.OK, MessageBoxImage.Error);

                }
            }
            else
            {
                MessageBox.Show("Tous les champs doivent être remplis", "Attention Champs Vides", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void txtboxTelephone_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            Validation.ChechKeyChiffre(e);
        }
        private void txtboxNSS_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            Validation.ChechKeyChiffre(e);
        }
    }
}
