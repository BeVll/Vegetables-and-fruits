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
    /// Логика взаимодействия для EditGoods.xaml
    /// </summary>
    public partial class EditGoods : Page
    {
        DbConnector DbConnector = new DbConnector();
        Goods goods;
        public EditGoods(Goods goods1)
        {
            InitializeComponent();
            Typs.ItemsSource = DbConnector.GetTypes();
            Typs.DisplayMemberPath = "Name";
            Colors.ItemsSource = DbConnector.GetColors();
            Colors.DisplayMemberPath = "Name";
            this.goods = goods1;
            Name.Text = goods.Name;
            Calories.Text = goods.Calories.ToString();
            Typs.SelectedItem = DbConnector.GetTypes().Where(s => s.Id == goods.Typ).FirstOrDefault();
            Colors.SelectedItem = DbConnector.GetColors().Where(s => s.Id == goods.Typ).FirstOrDefault();
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (Name.Text != string.Empty && Typs.SelectedIndex != -1 && Colors.SelectedIndex != -1 && Calories.Text != string.Empty)
            {
                goods.Name = Name.Text;
                goods.Calories = Convert.ToInt32(Calories.Text);
                Typ tp = Typs.SelectedItem as Typ;
                Colors clrs = Colors.SelectedItem as Colors;
                goods.Typ = tp.Id;
                goods.Colors = clrs.Id;
                Goods goods1 = DbConnector.GetGoods().Where(s => s.Name == goods.Name).FirstOrDefault();
                if (goods1 == null)
                {
                    DbConnector.UpdateGoods(goods);
                    this.NavigationService.Navigate(new GoodsPage());
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
            this.NavigationService.Navigate(new GoodsPage());
        }
    }
}
