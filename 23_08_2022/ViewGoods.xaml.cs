using System;
using System.Collections.Generic;
using System.IO;
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
using System.Drawing;
using WinFormsApp21;

namespace _23_08_2022
{
    /// <summary>
    /// Логика взаимодействия для ViewGoods.xaml
    /// </summary>
    public partial class ViewGoods : Page
    {
        int index = 0;
        DbConnector db = new DbConnector();
        List<Images> imgs = new List<Images>();
        private NewGoods goods;
        public ViewGoods(NewGoods goods1)
        {
            InitializeComponent();
            goods = goods1;
            GoodsName.Text = goods.Name;
            cl.Text = goods.Colors;
            tup.Text = goods.Typ;
            calor.Text = goods.Calories.ToString();
            imgs = db.GetImages().Where(x => x.Goods_id == goods.Id).ToList();
            SetImage();
        }

        private void TextBlock_SizeChanged(object sender, SizeChangedEventArgs e)
        {
           
        }

        public void SetImage()
        {


            pict.Source = LoadImage(imgs[index].Data);
        }

        private static BitmapImage LoadImage(byte[] imageData)
        {
            BitmapImage image = new BitmapImage();
            using (MemoryStream mem = new MemoryStream(imageData))
            {
                mem.Position = 0;
                image.BeginInit();
                image.CreateOptions = BitmapCreateOptions.PreservePixelFormat;
                image.CacheOption = BitmapCacheOption.OnLoad;
                image.UriSource = null;
                image.StreamSource = mem;
                image.EndInit();
            }
            image.Freeze();
            return image;
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(index > 0)
            {
                index--;
                SetImage();
            }    
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (index < imgs.Count-1)
            {
                index++;
                SetImage();
            }
        }
    }
}
