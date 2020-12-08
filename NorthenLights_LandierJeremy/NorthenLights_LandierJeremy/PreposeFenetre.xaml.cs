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
    /// Logique d'interaction pour PreposeFenetre.xaml
    /// </summary>
    public partial class PreposeFenetre : Window
    {

        bool pageLoaded = true;
        public PreposeFenetre()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            cboxNSS.DataContext = RequeteNss();
            cboxMedecin.DataContext = MainWindow.myBdd.Medecins.ToList();
            cboxDepartement.DataContext = MainWindow.myBdd.Departements.ToList();
            cboxTypeLit.DataContext = MainWindow.myBdd.TypeLits.ToList();
            cboxAssurance.DataContext = MainWindow.myBdd.Assurances.ToList();
            dateAdmission.SelectedDate = DateTime.Today;
            cboxNumeroLit.DataContext = MainWindow.myBdd.Lits.ToList();
            dataRecherchePatient.DataContext = RequeteRecherchePatient();
            pageLoaded = false;
        }


        public List<Patient> RequeteNss()
        {
            return (from p in MainWindow.myBdd.Patients
                    where !(from a in MainWindow.myBdd.Admissions
                            where a.dateConge == null
                            select a.NSS).Contains(p.NSS)
                    select p).ToList();
        }

        public List<Lit> RequeteNumeroLit()
        {
            return (from lit in MainWindow.myBdd.Lits
                    where lit.occupe == false
                    select lit).ToList();
        }

        public List<Lit> RequeteLitLibre()
        {
            //Check si page chargée pour accéder aux données des combobox, sinon retourne le premier lit de la liste
            //Évite gestion exception (Liste Lits null) lors de la première mise à jour du cbox.numeroLit car deux combobox sont interdépendants
            if (!pageLoaded)
            {
                pageLoaded = true;
                return (from lit in MainWindow.myBdd.Lits where lit.numeroLit == "1" select lit).ToList();
            }
            else
            {
                return (from lit in MainWindow.myBdd.Lits
                        where lit.IDDepartement == ((Departement)cboxDepartement.SelectedItem).IDDepartement
                        && lit.IDType == ((TypeLit)cboxTypeLit.SelectedItem).IDtype
                        && lit.occupe == false
                        select lit).ToList();
            }

        }

        public List<Lit> RequeteLitLibreChirurgie()
        {
             return (from lit in MainWindow.myBdd.Lits
                     where lit.IDDepartement == 12
                     && lit.occupe == false
                     select lit).ToList();
        }

        public int RequeteNombreLits(int deptId, int typeLit)
        {
            return (from lp in MainWindow.myBdd.Lits
                    where lp.IDDepartement == deptId
                    && lp.IDType == typeLit
                    select lp).ToList().Count;
        }

        public List<Patient> RequeteRecherchePatient()
        {
            return (from p in MainWindow.myBdd.Patients select p).ToList();    
        }
    }
}
