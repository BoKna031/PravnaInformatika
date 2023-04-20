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

namespace LegalApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Smuggling_btn_Click(object sender, RoutedEventArgs e)
        {
            ResetButtonsStyle();
            smuggling_btn.Background = Brushes.Green;
            contentFrame.Source = new Uri("SmugglingPage.xaml", UriKind.Relative);
        }


        private void Funds_without_coverage_btn_Click(object sender, RoutedEventArgs e)
        {
            ResetButtonsStyle();
            funds_without_coverage_btn.Background = Brushes.Green;
            contentFrame.Source = new Uri("FundsWithoutCoveragePage.xaml", UriKind.Relative);
        }

        private void Taxs_evasion_btn_Click(object sender, RoutedEventArgs e)
        {
            ResetButtonsStyle();
            taxs_evasion_btn.Background = Brushes.Green;
            contentFrame.Source = new Uri("TaxEvasionPage.xaml", UriKind.Relative);
        }

        private void ResetButtonsStyle()
        {
            smuggling_btn.Background = null;
            funds_without_coverage_btn.Background = null;
            taxs_evasion_btn.Background = null;
            documents_btn.Background = null;
        }

        private void Documents_btn_Click(object sender, RoutedEventArgs e)
        {
            contentFrame.Source = new Uri("FundsWithoutCoveragePage.xaml", UriKind.Relative);
            DocumentWindow documentWindow = new DocumentWindow("k304-2009.xml");
            documentWindow.ShowDialog();
        }
    }
}
