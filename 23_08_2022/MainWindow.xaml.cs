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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool menu_check = false;
        public MainWindow()
        {
            InitializeComponent();
            PageTitle.Text = "Goods";
            pFrame.Navigate(new GoodsPage());
        }
        private void ListViewItem_MouseEnter(object sender, MouseEventArgs e)
        {
            // Set tooltip visibility

            if (menu_check == true)
            {
                goods.Visibility = Visibility.Collapsed;
                colors.Visibility = Visibility.Collapsed;
                types.Visibility = Visibility.Collapsed;
            }
            else
            {
                goods.Visibility = Visibility.Visible;
                colors.Visibility = Visibility.Visible;
                types.Visibility = Visibility.Visible;
            }
            if (LV.SelectedIndex == 0)
            {
                PageTitle.Text = "Goods";
                pFrame.Navigate(new GoodsPage());
            }
            else if (LV.SelectedIndex == 1)
            {
                PageTitle.Text = "Colors";
                pFrame.Navigate(new ColorPage());
            }
            else if (LV.SelectedIndex == 2)
            {
                PageTitle.Text = "Types";
                pFrame.Navigate(new PageType());
            }
        }

       

        

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (menu_check == false)
                menu_check = true;
            else
                menu_check = false;

            
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if(WindowState == WindowState.Maximized)
                WindowState = WindowState.Normal;
            else
                WindowState = WindowState.Maximized;
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void ListViewItem_MouseDown(object sender, MouseButtonEventArgs e)
        {
            
        }

        private void ListViewItem_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            
        }

        private void LV_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (menu_check == true)
            {
                goods.Visibility = Visibility.Collapsed;
                colors.Visibility = Visibility.Collapsed;
                types.Visibility = Visibility.Collapsed;
            }
            else
            {
                goods.Visibility = Visibility.Visible;
                colors.Visibility = Visibility.Visible;
                types.Visibility = Visibility.Visible;
            }
            if (LV.SelectedIndex == 0)
            {
                PageTitle.Text = "Goods";
                pFrame.Navigate(new GoodsPage());
            }
            else if (LV.SelectedIndex == 1)
            {
                PageTitle.Text = "Colors";
                pFrame.Navigate(new ColorPage());
            }
            else if (LV.SelectedIndex == 2)
            {
                PageTitle.Text = "Types";
                pFrame.Navigate(new PageType());
            }
        }
    }
}
