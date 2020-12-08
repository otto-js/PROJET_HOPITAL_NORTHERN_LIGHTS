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
        //SUPPRIMER MEDECIN
        private void Supprimer_Click(object sender, RoutedEventArgs e)
        {
            Medecin medecinASupprimer = (Medecin)dataMedecin.SelectedItem;

            if (!Validation.IsMedecinAssigne(medecinASupprimer, MainWindow.myBdd))
            {

                if (MessageBox.Show("Êtes-vous sûr de vouloir supprimer les informations du médecin?", "Confirmation Supression", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    MainWindow.myBdd.Medecins.Remove(medecinASupprimer);
                    try
                    {
                        MainWindow.myBdd.SaveChanges();
                        dataMedecin.DataContext = MainWindow.myBdd.Medecins.ToList();
                        MessageBox.Show("Le médecin a bien été supprimé", "Suppression", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Impossible de supprimer un médecin assigné à des patients", "Erreur Suppression", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
