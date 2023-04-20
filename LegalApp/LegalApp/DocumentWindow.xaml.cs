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
using System.Xml;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace LegalApp
{
    /// <summary>
    /// Interaction logic for DocumentWindow.xaml
    /// </summary>
    public partial class DocumentWindow : Window
    {
        private XmlDocument doc;
        private Dictionary<string, string> references = new Dictionary<string, string>();
        public DocumentWindow(string filename)
        {
            InitializeComponent();
            string path = PathToDocument(filename);
            ReadFile(path);
        }

        private static string PathToDocument(string filename)
        {
            string currPath = AppDomain.CurrentDomain.BaseDirectory;
            int numOfParents = 5; //number of upper directories to access main project directories (PravnaInformatika)
            string path = Util.ToUpperDirectory(currPath, numOfParents);
            return System.IO.Path.Combine(path, "documents", filename);
        }

        private void ReadFile(string path)
        {
            doc = new XmlDocument();
            doc.Load(path);
            TraverseXmlNode(doc.DocumentElement);
        }



        private void TraverseXmlNode(XmlNode node)
        {
            if (node.LocalName == "#text")
            {
                Run run = new Run(node.InnerText);
                paragraph.Inlines.Add(run);
            }

            if (!(node is XmlElement)) return;

            XmlElement element = (XmlElement)node;

            if (element.Name.Equals("TLCOrganization"))
            {
                AddOrganizationToDictionary(element);
            }
            else if (element.LocalName.Equals("span") && element.HasAttribute("refersTo"))
            {
                CreateHyperlink(element);
            }

            foreach (XmlNode child in node.ChildNodes)
            {
                TraverseXmlNode(child);
            }
        }

        private void CreateHyperlink(XmlElement element)
        {
            foreach (XmlAttribute atribut in element.Attributes)
            {
                string argument = atribut.Name.ToString();
                string vrednost = atribut.Value.Substring(1);
                if (argument.Equals("refersTo") && vrednost.Equals("kzcg"))
                {
                    
                    Hyperlink hyperlink = new Hyperlink
                    {
                        Foreground = Brushes.Red,
                        NavigateUri = new Uri(references[vrednost])
                    };
                    hyperlink.Inlines.Add(GetTextUntilFirtTag(element.InnerXml));
                    paragraph.Inlines.Add(hyperlink);
                    
                }
            }
        }

        private string GetTextUntilFirtTag(string XMLtxt)
        {
            int index = XMLtxt.IndexOf('<');
            if(index == -1)
            {
                return XMLtxt;
            }
            return XMLtxt.Substring(0, XMLtxt.IndexOf('<'));
        }

        private void AddOrganizationToDictionary(XmlElement element)
        {
            string id = "";
            string href = "";
            foreach (XmlAttribute atribut in element.Attributes)
            {
                string argument = atribut.Name.ToString();
                string vrednost = atribut.Value;
                if (argument.Equals("id"))
                {
                    id = vrednost;
                }
                else if (argument.Equals("href"))
                {
                    href = vrednost;
                }
            }
            references[id] = href;
        }
    }
}
