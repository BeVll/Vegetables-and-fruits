using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Логика взаимодействия для AddColors.xaml
    /// </summary>
    public partial class AddColors : Page
    {
        DbConnector DbConnector = new DbConnector();
        public AddColors()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (Name.Text != string.Empty)
            {
                Colors colors = new Colors();
                colors.Name = Name.Text;

                Colors colors1 = DbConnector.GetColors().Where(s => s.Name == colors.Name).FirstOrDefault();
                if (colors1 == null)
                {
                    DbConnector.AddColors(colors);
                    this.NavigationService.Navigate(new ColorPage());
                }
                else
                {
                    MesWin w = new MesWin("Error", "The name is already in use");
                }
            }
            else
            {
                MesWin mw = new MesWin("Error", "Incorrectly filled fields");
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new ColorPage());
        }
    }
}
