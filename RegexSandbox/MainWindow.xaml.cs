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

namespace RegexSandbox
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

        private void ListView_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            // Resize the last column of the grid to fill up most of the remaining space
            ListView listView = sender as ListView;
            GridView gridView = listView.View as GridView;

            double actualWidth = listView.ActualWidth - SystemParameters.VerticalScrollBarWidth;
            for (int i = 0; i < gridView.Columns.Count - 1; i++)
            {
                actualWidth -= gridView.Columns[i].ActualWidth;
            }

            int margin = 10;
            gridView.Columns[gridView.Columns.Count - 1].Width = Math.Max(actualWidth - margin, 0);
        }
    }
}
