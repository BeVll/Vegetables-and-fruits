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

namespace _23_08_2022
{
    /// <summary>
    /// Логика взаимодействия для ColorPage.xaml
    /// </summary>
    public partial class ColorPage : Page
    {
        DbConnector DbConnector = new DbConnector();

        public ColorPage()
        {
            InitializeComponent();
            List<Colors> colors = DbConnector.GetColors();
            foreach (Colors color in colors)
            {
                lv.Items.Add(color);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Colors colors = lv.SelectedItem as Colors;
            DbConnector.DeleteColors(colors);
            lv.Items.Remove(lv.SelectedItem);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new AddColors());
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Colors colors = lv.SelectedItem as Colors;
            if (colors != null)
            {
                
                this.NavigationService.Navigate(new EditColors(colors));
            }
        }
    }
}
