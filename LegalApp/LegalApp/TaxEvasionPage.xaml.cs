using LegalApp.Properties;
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
    /// Interaction logic for TaxEvasionPage.xaml
    /// </summary>
    public partial class TaxEvasionPage : Page
    {
        public TaxEvasionPage()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            LegalCase lc = new LegalCase();
            lc.TaxEvasionDescription(defendant_txt.Text, int.Parse(euros.Text), true);

            string currPath = AppDomain.CurrentDomain.BaseDirectory;
            int numOfParents = 5; //number of upper directories to access main project directories (PravnaInformatika)
            string folder_path = Util.ToUpperDirectory(currPath, numOfParents);
            folder_path = System.IO.Path.Combine(folder_path, "dr-device");
            Util.OpenReport(lc, folder_path);
        }
    }
}
