using _1051.Models;
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

namespace _1051.Views
{
    /// <summary>
    /// Interaction logic for GrupEkle.xaml
    /// </summary>
    public partial class GrupEkle : Page
    {
        public GrupEkle()
        {
            InitializeComponent();
            BtnGrupKaydet.Click += BtnGrupKaydet_Click;
        }

        private void BtnGrupKaydet_Click(object sender, RoutedEventArgs e)
        {
            Veri.Gruplar.Add(new Grup()
            {
                GrupAdı = TbGrupAdı.Text,
            });
            TbGrupAdı.Text = "";
            NavigationService.Content = new Kişiler();
        }
    }
}
