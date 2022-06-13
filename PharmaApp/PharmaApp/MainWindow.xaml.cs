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
            //DispatcherTimer timer = new DispatcherTimer(new TimeSpan(0, 0, 1), DispatcherPriority.Normal, delegate { this.timeLabel.Content = DateTime.Now.ToString("HH:mm Tongue Tieds");}, this.Dispatcher);
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
            Autorisation autorisationInsert = new Autorisation();
            autorisationInsert.LibelleMaladie = maladieSelectorCreate.Text;
            autorisationInsert.LibelleMedicament = medSelectorCreate.Text;
            autorisationInsert.DateAutorisation = dateSelectorCreate.SelectedDate.Value.Date.ToShortDateString();
            autorisationInsert.Commentaire = commentBoxCreate.Text;
            autorisationInsert.Create();
            ApplicationData.loadApplicationData();
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
