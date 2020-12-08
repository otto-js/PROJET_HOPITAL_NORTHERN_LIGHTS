using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace NorthenLights_LandierJeremy
{
    partial class Administrateur
    {
        //AJOUT MEDECIN
        private void Ajout_Click(object sender, RoutedEventArgs e)
        {
            Medecin medecinAAjouter = new Medecin();
            medecinAAjouter.nom = txtboxNom.Text;
            medecinAAjouter.prenom = txtboxPrenom.Text;

            if (!string.IsNullOrEmpty(txtboxNom.Text) && !string.IsNullOrEmpty(txtboxPrenom.Text))
            {
                MainWindow.myBdd.Medecins.Add(medecinAAjouter);
                if (MessageBox.Show("Êtes-vous sûr de vouloir ajouter ce médecin?", "Confirmation Ajout", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    try
                    {
                        MainWindow.myBdd.SaveChanges();
                        dataMedecin.DataContext = MainWindow.myBdd.Medecins.ToList();
                        txtboxNom.Text = string.Empty;
                        txtboxPrenom.Text = string.Empty;
                        txtboxNom.Focus();
                        MessageBox.Show("Le nouveau médecin a bien été ajouté.", "Ajout", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Tous les champs doivent être remplis", "Attention", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

    }
}
