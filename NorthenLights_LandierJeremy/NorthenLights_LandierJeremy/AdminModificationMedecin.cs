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
        //MODIFIER MEDECIN
        private void Modifier_Click(object sender, RoutedEventArgs e)
        {
            Medecin medecinAModifier = (Medecin)dataMedecin.SelectedItem;

            medecinAModifier.nom = txtboxModifieNom.Text;
            medecinAModifier.prenom = txtboxModifiePrenom.Text;

            if (!string.IsNullOrEmpty(txtboxModifieNom.Text) && !string.IsNullOrEmpty(txtboxModifiePrenom.Text))
            {
                if (MessageBox.Show("Êtes-vous sûr de vouloir modifier les informations du médecin?", "Confirmation Modification", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    try
                    {
                        MainWindow.myBdd.SaveChanges();
                        dataMedecin.DataContext = MainWindow.myBdd.Medecins.ToList();
                        MessageBox.Show("Les informations du médecin ont bien été modifiées", "Modification", MessageBoxButton.OK, MessageBoxImage.Information);
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
