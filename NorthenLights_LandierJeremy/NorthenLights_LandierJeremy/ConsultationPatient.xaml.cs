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
    /// Logique d'interaction pour ConsultationPatient.xaml
    /// </summary>
    public partial class ConsultationPatient : Window
    {
        public ConsultationPatient()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var requete = (from a in MainWindow.myBdd.Admissions
                           join p in MainWindow.myBdd.Patients on a.NSS equals p.NSS
                           join m in MainWindow.myBdd.Medecins on a.IDMedecin equals m.IDMedecin
                           join l in MainWindow.myBdd.Lits on a.numeroLit equals l.numeroLit
                           join t in MainWindow.myBdd.TypeLits on l.IDType equals t.IDtype
                           join d in MainWindow.myBdd.Departements on l.IDDepartement equals d.IDDepartement
                           join ass in MainWindow.myBdd.Assurances on p.IDAssurance equals ass.IDAssurance
                           select new { a.NSS, p.nom, p.prenom, p.telephone, a.dateAdmission, a.dateConge, a.dateChirurgie, a.numeroLit, t.description, d.nomDepartement, nomMedecin = "Dr " + m.nom.Trim() + " " + m.prenom.Trim(), ass.nomCompagnie });

            dataPatient.DataContext = requete.ToList();
        }
    }
}
