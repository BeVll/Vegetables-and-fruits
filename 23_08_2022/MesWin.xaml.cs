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

namespace _23_08_2022
{
    /// <summary>
    /// Логика взаимодействия для MesWin.xaml
    /// </summary>
    public partial class MesWin : Window
    {
        public MesWin(string tittle, string message)
        {
            InitializeComponent();
            PageTitle.Text = tittle;
            Mes.Text = message;
            Show();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }
    }
}
