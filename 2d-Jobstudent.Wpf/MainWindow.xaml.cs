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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace _2d_Jobstudent.Wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
 //Variabelen
        float uurloon=14.45F;
        Random rand = new Random();
        int uren;

//End Variabelen

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DateTime opstartTijd = DateTime.Now;
            Title = Convert.ToString(opstartTijd);
            lblUurloon.Content = uurloon;
            txtNaam.Focus();
            btnPlus.IsEnabled = false;
            btnNaarLijst.Visibility = Visibility.Hidden;      
        }

        private void txtNaam_TextChanged(object sender, TextChangedEventArgs e)
        {
            btnPlus.IsEnabled = true;
        }

        private void btnPlus_Click(object sender, RoutedEventArgs e)
        {
            string naam;
            naam = txtNaam.Text;
            lstNamen.Items.Add(naam);
            txtNaam.Text = "";
            txtNaam.Focus();
            btnPlus.IsEnabled = false;
        }

        private void lstNamen_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            btnNaarLijst.Visibility = Visibility.Visible;
            uren = rand.Next(1, 9);
            lblUren.Content = Convert.ToString(uren);

        }

        private void btnNaarLijst_Click(object sender, RoutedEventArgs e)
        {
            string naam = lstNamen.SelectedItem.ToString();
            string samenvatting;
            samenvatting = $"{naam} - {uren} - {uurloon} ";
            tbxLijst.Text += samenvatting + Environment.NewLine;
            btnNaarLijst.Visibility = Visibility.Hidden;
        }
    }
}
