using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace PharmaApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DispatcherTimer timer = new DispatcherTimer(new TimeSpan(0, 0, 1), DispatcherPriority.Normal, delegate { this.timeLabel.Content = DateTime.Now.ToString("HH:mm Tongue Tieds");}, this.Dispatcher);
            this.maladieSelectorCreate.ItemsSource = ApplicationData.listeMaladie;
            this.medSelectorCreate.ItemsSource = ApplicationData.listeMedicament;
        }

        private void catMedItem_Selected(object sender, RoutedEventArgs e)
        {
            this.listViewTri.ItemsSource = ApplicationData.listeCategorieMedicament;
            this.grdData.ItemsSource = null;
            this.listViewTri.DisplayMemberPath = "LibelleCategorie";
            //this.listViewCol.DisplayMemberBinding = new Binding("libelleCategorie");
            //((GridView)listViewTri.View).Columns[0].Header = "Categorie Medicament";
        }

        private void ttElementsItem_Selected(object sender, RoutedEventArgs e)
        {
            this.listViewTri.ItemsSource = null;
            this.grdData.ItemsSource = ApplicationData.listeAutorisations;
            //this.listViewCol.DisplayMemberBinding = null;
            //((GridView)listViewTri.View).Columns[0].Header = "Toutes les autorisations";
        }

        private void maladieItem_Selected(object sender, RoutedEventArgs e)
        {
            this.listViewTri.ItemsSource = ApplicationData.listeMaladie;
            this.listViewTri.DisplayMemberPath = "LibelleMaladie";
            this.grdData.ItemsSource = null;
            //this.listViewCol.DisplayMemberBinding = new Binding("libelleMaladie");
            //((GridView)listViewTri.View).Columns[0].Header = "Maladie";
        }

        private void medItem_Selected(object sender, RoutedEventArgs e)
        {
            this.listViewTri.ItemsSource = ApplicationData.listeMedicament;
            this.listViewTri.DisplayMemberPath = "LibelleMedicament";
            this.grdData.ItemsSource = null;
        }

        private void buttonCreate_Click(object sender, RoutedEventArgs e)
        {
            if (maladieSelectorCreate.SelectedIndex > -1 && medSelectorCreate.SelectedIndex > -1 && dateSelectorCreate.SelectedDate != null)
            {
                Autorisation autorisationInsert = new Autorisation();
                autorisationInsert.idmaladieSQL = ((Maladie)maladieSelectorCreate.SelectedItem).IdMaladie;
                autorisationInsert.idmedicamentSQL = ((Medicament)medSelectorCreate.SelectedItem).IdMedicament;
                autorisationInsert.DateAutorisation = dateSelectorCreate.SelectedDate.Value.Date.ToShortDateString();
                autorisationInsert.Commentaire = commentBoxCreate.Text.Replace("'", "''");
                autorisationInsert.Create();
                maladieSelectorCreate.SelectedIndex = -1;
                medSelectorCreate.SelectedIndex = -1;
                commentBoxCreate.Text = "";
                dateSelectorCreate.SelectedDate = null;
                ApplicationData.loadApplicationData();
                grdData.ItemsSource = ApplicationData.listeAutorisations;
            }
            else
                MessageBox.Show("Informations manquantes pour la création d'une autorisation.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void SupButtonAutorisation_Click(object sender, RoutedEventArgs e)
        {
            if(grdData.SelectedIndex != -1)
            {
                Autorisation supAuto = (Autorisation)grdData.SelectedItem;
                MessageBoxResult result = MessageBox.Show($"Supprimer l'autorisation {supAuto.LibelleMaladie} | {supAuto.LibelleMedicament} du {supAuto.DateAutorisation} ?", "Suppression", MessageBoxButton.YesNo, MessageBoxImage.Question);
                switch (result)
                {
                    case MessageBoxResult.Yes:
                        supAuto.Delete();
                        ApplicationData.loadApplicationData();
                        grdData.ItemsSource = ApplicationData.listeAutorisations;
                        grdData.SelectedIndex = -1;
                        break;
                    case MessageBoxResult.No:
                        break;
                }
            }
            else
                MessageBox.Show("Aucune autorisation selectionnée.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);


        }

        private void modButtonAutorisation_Click(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void listViewTri_Selected(object sender, SelectionChangedEventArgs e)
        {
            if(listViewTri.SelectedIndex > -1)
            {
                Autorisation triAutorisation = new Autorisation();
                string crit = "";
                switch (listViewTri.DisplayMemberPath.ToLower())
                {
                    case "libellemaladie":
                        crit = ((Maladie)listViewTri.SelectedItem).LibelleMaladie.ToString();
                        break;

                    case "libellemedicament":
                        crit = ((Medicament)listViewTri.SelectedItem).LibelleMedicament.ToString();
                        break;
                    case "libellecategorie":
                        crit = ((CategorieMedicament)listViewTri.SelectedItem).LibelleCategorie.ToString();
                        break;
                }
                grdData.ItemsSource = triAutorisation.FindBySelection(crit, listViewTri.DisplayMemberPath.ToLower());
            }
        }

        /*
        private void display_this(List<T> laListe, string leChamp, string txtHeader)
        {
            this.listViewTri.ItemsSource = null;
            this.grdData.ItemsSource = laListe;
            this.listViewCol.DisplayMemberBinding = new Binding(leChamp);
            ((GridView)listViewTri.View).Columns[0].Header = txtHeader;
        }
        */
    }
}
