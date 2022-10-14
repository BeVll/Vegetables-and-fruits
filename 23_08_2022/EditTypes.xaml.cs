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
    /// Логика взаимодействия для EditTypes.xaml
    /// </summary>
    public partial class EditTypes : Page
    {
        DbConnector DbConnector = new DbConnector();
        Typ typs;
        public EditTypes(Typ typs1)
        {
            InitializeComponent();
            typs = typs1;
            Name.Text = typs.Name;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (Name.Text != string.Empty)
            {
                typs.Name = Name.Text;

                Typ typs1 = DbConnector.GetTypes().Where(s => s.Name == typs.Name).FirstOrDefault();
                if (typs1 == null)
                {
                    DbConnector.UpdateTypes(typs);
                    this.NavigationService.Navigate(new PageType());
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
            this.NavigationService.Navigate(new PageType());
        }
    }
}
