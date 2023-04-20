using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for DocumentPage.xaml
    /// </summary>
    public partial class DocumentPage : Page
    {
        public DocumentPage()
        {
            InitializeComponent();
            DataContext = new ViewModel();
        }

        private void File_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Label control = sender as Label;
            if (control != null)
            {
                string content = (string)control.Content;
                DocumentWindow dw = new DocumentWindow(content);
                dw.ShowDialog();
            }
        }
    }

    public class ViewModel
    {
        public ObservableCollection<string> MyList { get; set; }

        public ViewModel()
        {
            string currPath = AppDomain.CurrentDomain.BaseDirectory;
            int numOfParents = 5; //number of upper directories to access main project directories (PravnaInformatika)
            string path = Util.ToUpperDirectory(currPath, numOfParents);
            
            string[] files = Directory.GetFiles(System.IO.Path.Combine(path, "documents"));
            string[] filenames = new string[files.Length];
            for(int i = 0;i < files.Length; i++)
            {
                filenames[i] = System.IO.Path.GetFileName(files[i]);
            }
            MyList = new ObservableCollection<string>(filenames);
        }
    }
}
