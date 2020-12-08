using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace NorthenLights_LandierJeremy
{
    class Validation
    {

        public static bool IsMedecinAssigne(Medecin m, HopitalEntities myBdd)
        {
            foreach (Admission medecin in myBdd.Admissions)
            {
                if (medecin.IDMedecin == m.IDMedecin)
                    return true;
            }
            return false;
        }

        public static bool IsPatientExistant(Patient nouveauPatient, HopitalEntities myBdd)
        {
            foreach (Patient p in myBdd.Patients)
            {
                if (nouveauPatient.Equals(p))
                    return true;
            }
            return false;
        }

        public static void ChechKeyChiffre(KeyEventArgs e)
        {
            if ((e.Key < Key.D0 || e.Key > Key.D9) &&
                (e.Key < Key.NumPad0 || e.Key > Key.NumPad9) &&
                (e.Key != Key.Back) && (e.Key != Key.Tab))
            {
                e.Handled = true;
                MessageBox.Show("Seuls les chiffres sont acceptés dans ce champ", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public static void CheckKeyLetter(KeyEventArgs e)
        {
            if ((e.Key < Key.A || e.Key > Key.Z) &&
            (e.Key != Key.Back) && (e.Key != Key.Tab) && 
            (e.Key != Key.CapsLock) && (e.Key != Key.LeftShift) && 
            (e.Key != Key.RightShift) && (e.Key != Key.LeftCtrl) && (e.Key != Key.RightCtrl))
            {
               
                e.Handled = true;
                MessageBox.Show("Seules les lettres sont acceptées dans ce champ", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public static bool IsEnfant(DateTime dobPatient)
        {
            //Calcul si âge patient < 16
            Double jours = (DateTime.Today - dobPatient).TotalDays;

            if (jours < 5844)
                return true;
            else
                return false;
        }

        //Check si type lit inférieur disponible lors de l'admission pour patients sans assurance privée
        public static bool IsLitInferieurDispo(Patient admis, ComboBox cboxTypeLit, ComboBox cboxDepartement, PreposeFenetre prepose)
        {
            int lit = ((TypeLit)cboxTypeLit.SelectedItem).IDtype;
            int dept = ((Departement)cboxDepartement.SelectedItem).IDDepartement;

            if (admis.Assurance.IDAssurance == 1)
            {
                if (lit == 2)
                {
                    if (prepose.RequeteNombreLits(dept, 1) > 0)
                    {
                        return true;
                    }
                }
                else if (lit == 3)
                {
                    if (prepose.RequeteNombreLits(dept, 1) > 0 || prepose.RequeteNombreLits(dept, 2) > 0)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

    }
}
