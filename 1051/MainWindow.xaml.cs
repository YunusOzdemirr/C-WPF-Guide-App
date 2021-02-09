using _1051.Views;
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

namespace _1051
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ImgKişiler.Click += ImgKişiler_Click;
            ImgKişiEkle.Click += ImgKişiEkle_Click;
            ImgGrupEkle.Click += ImgGrupEkle_Click;
        }

        private void ImgGrupEkle_Click(object sender, RoutedEventArgs e)
        {
            Frm.Content = new GrupEkle();
        }

        private void ImgKişiEkle_Click(object sender, RoutedEventArgs e)
        {
            Frm.Content = new KişiEkle();
        }

        private void ImgKişiler_Click(object sender, RoutedEventArgs e)
        {
            Frm.Content = new Kişiler();
        }
    }
}
