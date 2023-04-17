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
using System.Xml.Linq;

namespace LegalApp
{
    /// <summary>
    /// Interaction logic for Report.xaml
    /// </summary>
    public partial class Report : Window
    {
        private int fontSize = 18;
        private HorizontalAlignment aligment = HorizontalAlignment.Right;
        private int margin = 10;
        public Report(ReportsData reportsData)
        {
            InitializeComponent();
            int numberOfRows = 1 + reportsData.Statements.Count + reportsData.Penalties.Count;
            ExtendNumOfRowsInGrid(numberOfRows);
            int row_inx = 1;
            AddDefendantData(reportsData.Defendant, row_inx++);
            AddStatementsData(reportsData.Statements, row_inx);
            row_inx = row_inx + reportsData.Statements.Count;
            AddPenaltiesData(reportsData.Penalties, row_inx);

        }

        private void AddPenaltiesData(List<Penalty> penalties, int row)
        {
            foreach (Penalty p in penalties)
            {
                Label txt = new Label { Content = p.Scope + ":", FontSize = fontSize, HorizontalAlignment =  aligment};
                Label value = new Label { Content = p.Value, FontSize = fontSize , Margin = new Thickness(margin, 0, 0, 0) };
                grid.Children.Add(txt);
                grid.Children.Add(value);

                Grid.SetRow(txt, row);
                Grid.SetColumn(txt, 0);
                Grid.SetRow(value, row);
                Grid.SetColumn(value, 1);
                row++;
            }
        }
        private void AddStatementsData(List<Statement> statements, int row)
        {
            foreach(Statement s in statements)
            {
                Label txt = new Label { Content = s.Text + ":", FontSize = fontSize, HorizontalAlignment = aligment };
                string val = s.Possitive ? "possitive" : "negative";
                Label value = new Label { Content = val, FontSize = fontSize, Margin = new Thickness(margin, 0, 0, 0), Height = 40, VerticalAlignment = VerticalAlignment.Top};
                value.Background = s.Possitive ? Brushes.Red : Brushes.Green;
                grid.Children.Add(txt);
                grid.Children.Add(value);

                Grid.SetRow(txt, row);
                Grid.SetColumn(txt, 0);
                Grid.SetRow(value, row);
                Grid.SetColumn(value, 1);
                row++;
            }
        }


        private void AddDefendantData(string Defendant, int row)
        {
            Label name_lab = new Label { Content = "Defendant:", FontSize= fontSize, HorizontalAlignment = aligment };
            Label name = new Label { Content = Defendant, FontSize = fontSize, Margin = new Thickness(margin, 0, 0, 0) };

            grid.Children.Add(name_lab);
            grid.Children.Add(name);

            Grid.SetRow(name_lab, row);
            Grid.SetColumn(name_lab, 0);
            Grid.SetRow(name, row);
            Grid.SetColumn(name, 1);
        }

        private void ExtendNumOfRowsInGrid(int number)
        {
            for(int i=0; i<number; i++)
            {
                RowDefinition newRowDef = new RowDefinition();
                grid.RowDefinitions.Add(newRowDef);
            }
        }
    }
}
