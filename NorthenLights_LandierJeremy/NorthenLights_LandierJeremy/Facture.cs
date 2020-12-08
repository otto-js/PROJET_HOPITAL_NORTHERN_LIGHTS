using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace NorthenLights_LandierJeremy
{
    class Facture
    {
        const double PRIX_PHONE = 7.50;
        const double PRIX_TELE = 42.50;
        const double PRIX_LIT_SEMIPRIVE = 267;
        const double PRIX_LIT_PRIVE = 571;

        public static double CalculerNombreJours(Admission patientSortant)
        {
            return ((TimeSpan)(patientSortant.dateConge - patientSortant.dateAdmission)).TotalDays;
        }

        public static double CalculerTotalTelephone(Admission patientSortant)
        {
            if (patientSortant.telephone)
                return CalculerNombreJours(patientSortant) * PRIX_PHONE;
            else 
                return 0;
        }

        public static double CalculerTotalTelevision(Admission patientSortant)
        {
            if (patientSortant.televiseur)
                return CalculerNombreJours(patientSortant) * PRIX_TELE;
            else
                return 0;
        }
        
        public static double CalculerTotalChambre(Admission patientSortant)
        {
            double nombreJours = CalculerNombreJours(patientSortant);

            if (patientSortant.Lit.IDType == 2)
            {
                if (patientSortant.litInferieurDispo)
                {
                    return PRIX_LIT_SEMIPRIVE * nombreJours;
                }
            }
            else if (patientSortant.Lit.IDType == 3)
            {
                if (patientSortant.litInferieurDispo)
                {
                    return PRIX_LIT_PRIVE * nombreJours;
                }
            }
            return 0;
        }

        public static void AfficherFacture(Admission patientSortant)
        {
            double television = Facture.CalculerTotalTelevision(patientSortant);
            double telephone = Facture.CalculerTotalTelephone(patientSortant);
            double chambre = Facture.CalculerTotalChambre(patientSortant);

            MessageBox.Show("Le prix total du sejour est de " + (chambre + television + telephone) + "$" + " pour un sejour de " + Facture.CalculerNombreJours(patientSortant) + " jours." +
                            "\n ---------------------------------------------" +
                            "\n Détail facture : " +
                            "\n Location chambre : " + chambre + "$" +
                            "\n Location television : " + television + "$" +
                            "\n Location telephone : " + telephone + "$");
        }
    }
}
