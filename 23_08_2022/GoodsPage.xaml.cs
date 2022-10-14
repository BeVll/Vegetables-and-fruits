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
    /// Логика взаимодействия для GoodsPage.xaml
    /// </summary>
    public partial class GoodsPage : Page
    {
        DbConnector DbConnector = new DbConnector();

        public GoodsPage()
        {
            InitializeComponent();
            List<Goods> goods = DbConnector.GetGoods();
            List<NewGoods> ngoods = DbConnector.GoodsToNewGoods(goods);
            foreach(NewGoods ngood in ngoods)
            {
                lv.Items.Add(ngood);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NewGoods newGoods = lv.SelectedItem as NewGoods;
            DbConnector.DeleteGoods(newGoods.Id);
            lv.Items.Remove(lv.SelectedItem);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new AddGoods());
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            NewGoods newGoods = lv.SelectedItem as NewGoods;
            if (newGoods != null)
            {
                Goods goods = DbConnector.GetGoods().Where(s => s.Id == newGoods.Id).FirstOrDefault();
                this.NavigationService.Navigate(new EditGoods(goods));
            }
        }

        private void lv_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            NewGoods newGoods = lv.SelectedItem as NewGoods;
            if (newGoods != null)
            {
                this.NavigationService.Navigate(new ViewGoods(newGoods));
            }
        }
    }
}
