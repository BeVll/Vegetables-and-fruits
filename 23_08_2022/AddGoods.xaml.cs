using Microsoft.Win32;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.PortableExecutable;
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
using System.Resources;
using WinFormsApp21;


namespace _23_08_2022
{
    /// <summary>
    /// Логика взаимодействия для AddGoods.xaml
    /// </summary>
    public partial class AddGoods : Page
    {
        private List<Images> images = new List<Images>();
        DbConnector DbConnector = new DbConnector();
        public AddGoods()
        {
            InitializeComponent();
            Typs.ItemsSource = DbConnector.GetTypes();
            Typs.DisplayMemberPath = "Name";
            Colors.ItemsSource = DbConnector.GetColors();
            Colors.DisplayMemberPath = "Name";
            
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
                Goods goods = new Goods();
                goods.Name = Name.Text;
                goods.Calories = Convert.ToInt32(Calories.Text);
                Typ tp = Typs.SelectedItem as Typ;
                Colors clrs = Colors.SelectedItem as Colors;
                goods.Typ = tp.Id;
                goods.Colors = clrs.Id;
                Goods goods1 = DbConnector.GetGoods().Where(s => s.Name == goods.Name).FirstOrDefault();

                if (goods1 == null)
                {
                    DbConnector.AddGoods(goods);
                    if(images.Count == 0)
                    {
                        Images i = new Images();
                 
                        
                        i.Name = @".\\images.jpg";
                        images.Add(i);
                    }
                    foreach(Images im in images)
                    {
                        Images Imag = new Images();
                        Imag.Name = im.Name;
                        byte[] imageData;
                        using (FileStream fs = new FileStream(Imag.Name, FileMode.Open))
                        {
                            imageData = new byte[fs.Length];
                            fs.Read(imageData, 0, imageData.Length);
                        }
                        Imag.Data = imageData;
                        Imag.Goods_id = DbConnector.GetGoods().Where(s => s.Name == goods.Name).FirstOrDefault().Id;
                        DbConnector.AddImages(Imag);
                    }
                        
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

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Виберіть зображення";
            openFileDialog.Filter = "Png file|*.png|Jpg file|*.jpg";
            if (openFileDialog.ShowDialog() == true)
            {
                Images img = new Images();
                img.Name = openFileDialog.FileName;
                images.Add(img);

            }
                
        }
    }
}
