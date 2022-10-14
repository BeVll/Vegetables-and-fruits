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
    /// Логика взаимодействия для PageType.xaml
    /// </summary>
    public partial class PageType : Page
    {
        DbConnector DbConnector = new DbConnector();

        public PageType()
        {
            InitializeComponent();
            List<Typ> typs = DbConnector.GetTypes();
            foreach (Typ typ in typs)
            {
                lv.Items.Add(typ);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Typ typs = lv.SelectedItem as Typ;
            DbConnector.DeleteTypes(typs);
            lv.Items.Remove(lv.SelectedItem);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new AddTypes());
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Typ typs = lv.SelectedItem as Typ;
            if (typs != null)
            {

                this.NavigationService.Navigate(new EditTypes(typs));
            }
        }
    }
}
