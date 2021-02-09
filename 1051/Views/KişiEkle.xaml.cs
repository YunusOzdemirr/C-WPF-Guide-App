using _1051.Models;
using Microsoft.Win32;
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
    /// Interaction logic for KişiEkle.xaml
    /// </summary>
    public partial class KişiEkle : Page
    {
        Kişi seçiliKişi;
        public KişiEkle()
        {
            InitializeComponent();
            BtnKaydet.Click += BtnKaydet_Click;
            BtnResimEkle.Click += BtnResimEkle_Click;
            CbGrup.ItemsSource = Veri.Gruplar;
        }

        private void BtnResimEkle_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == true)
            {
                ImgResim.Source = new BitmapImage(new Uri(ofd.FileName));
                ImgResim.Visibility = Visibility.Visible;
            }

        }

        private void BtnKaydet_Click(object sender, RoutedEventArgs e)
        {
            string HataMesajı = null;
            #region Validation

            if (string.IsNullOrWhiteSpace(TbAd.Text))
                {
                    HataMesajı += "Lütfen Kişi Adı Giriniz\n";
                }
                if (string.IsNullOrWhiteSpace(TbSoyad.Text))
                {
                    HataMesajı += "Lütfen Kişi Soyadı Giriniz\n";
                }
                if (string.IsNullOrWhiteSpace(TbTelefon.Text))
                {
                    HataMesajı += "Lütfen Kişinin Numarasını Giriniz\n";
                }
                if (DpDoğumTarihi.SelectedDate == null)
                {
                    HataMesajı += "Lütfen Kişinin Doğum Tarihini Giriniz\n";
                }
                if (ImgResim.Source == null)
                {
                    HataMesajı += "Lütfen Kişinin Fotoğrafını Doldurunuz\n";
                }
                if (HataMesajı!=null)
                {
                    MessageBox.Show(HataMesajı, "Hata", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
            #endregion

            if (seçiliKişi != null)
            {
                seçiliKişi.Adı = TbAd.Text;
                seçiliKişi.Soyadı = TbSoyad.Text;
                seçiliKişi.DoğumTarihi = DpDoğumTarihi.SelectedDate.Value;
                seçiliKişi.EPosta = TbEPosta.Text;
                seçiliKişi.TelefonNo = TbTelefon.Text;
                seçiliKişi.Grup = CbGrup.SelectedItem as Grup;
                seçiliKişi.Resim = ImgResim.Source as BitmapImage;

            }
            else
            {
                Veri.Kişiler.Add(new Kişi()
                {
                    Adı = TbAd.Text,
                    Soyadı = TbSoyad.Text,
                    DoğumTarihi = DpDoğumTarihi.SelectedDate.Value,
                    EPosta = TbEPosta.Text,
                    TelefonNo = TbTelefon.Text,
                    Resim = ImgResim.Source as BitmapImage,
                    Grup = CbGrup.SelectedItem as Grup
                });
                ImgResim.Visibility = Visibility.Collapsed;
                NavigationService.Content = new Kişiler();

                TbAd.Text = "";
                TbSoyad.Text = "";
                DpDoğumTarihi.SelectedDate = null;
                TbEPosta.Text = null;
                ImgResim.Source = null;
                TbTelefon.Text = "";
            }
        }

        public KişiEkle(Kişi gelenkişi) : this()
        {
            seçiliKişi = gelenkişi;

            TbAd.Text = gelenkişi.Adı;
            TbSoyad.Text = gelenkişi.Soyadı;
            TbTelefon.Text = gelenkişi.TelefonNo;
            DpDoğumTarihi.Text = gelenkişi.DoğumTarihi.ToString();
            TbEPosta.Text = gelenkişi.EPosta;
            ImgResim.Source = gelenkişi.Resim;
            ImgResim.Visibility = Visibility.Visible;
        }
    }
}
