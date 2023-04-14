using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
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
    /// Interaction logic for SmugglingPage.xaml
    /// </summary>
    public partial class SmugglingPage : Page
    {
        public SmugglingPage()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            LegalCase lc = new LegalCase();
            lc.SmugglingDescription(defendant_txt.Text, (bool)possession_of_cleared_customs_goods.IsChecked, (bool)transfer_of_weapon_or_ammunition.IsChecked, resource.Text);
            string currPath = AppDomain.CurrentDomain.BaseDirectory;
            int numOfParents = 5; //number of upper directories to access main project directories (PravnaInformatika)
            string folder_path = ToUpperDirectory(currPath, numOfParents);
            string facts_path = System.IO.Path.Combine(folder_path, "dr-device", "facts.rdf");
            Overwrite(facts_path, lc.GenerateRDF());
            string excecute_path = System.IO.Path.Combine(folder_path, "dr-device", "start.bat");
            Excecute(excecute_path);
        }

        private string ToUpperDirectory(string path, int num)
        {
            string result = path;
            for(int i = 0; i < num; i++)
            {
                result = System.IO.Directory.GetParent(result).FullName;
            }
            return result;
        }
        private void Overwrite(string filepath, string content)
        {
            using (StreamWriter writer = new StreamWriter(filepath, false))
            {
                writer.Write(content);
            }
        }

        private void Excecute(string filepath)
        {
            string parentFolder = System.IO.Directory.GetParent(filepath).FullName;
            ProcessStartInfo startInfo = new ProcessStartInfo
            {
                FileName = "cmd.exe",
                Arguments = $"/c cd \"{parentFolder}\" & start start.bat",
                UseShellExecute = false,
                CreateNoWindow = false
            };

            // Pokretanje .bat fajla
            Process process = new Process { StartInfo = startInfo };
            process.Start();
        }
    }
}
