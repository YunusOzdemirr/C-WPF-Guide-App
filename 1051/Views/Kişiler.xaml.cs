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
    /// Interaction logic for Kişiler.xaml
    /// </summary>
    public partial class Kişiler : Page
    {
        public Kişiler()
        {
            InitializeComponent();
            LbGruplar.ItemsSource = Veri.Gruplar;
            LbGruplar.SelectionChanged += LbGruplar_SelectionChanged;
            #region Cb Doldurma
            CbFiltreler.ItemsSource = new List<string>()
            {
                  "1) Tümünü Listele",
                  "2) Mail odresi olmayanlar",
                  "3) 1990-2000 arasında doğanlar",
                  "4) 5 Harfli ada sahip olanlar",
                  "5) Temmuz ve Ağustos ayında doğanlar",
                  "6) Ortalama yaş üzerinde doğanlar"
            };
            CbSıralamalar.ItemsSource = new List<string>()
            {
                "1)Ada Göre Artan, Soyada Göre Azalan",
                "2)Ada Göre Azalan, Soyada Göre Artan",
                "3)Doğum Tarihine Göre Azalan"
            };

            #endregion
            CbFiltreler.SelectionChanged += CbFiltreler_SelectionChanged;
            CbSıralamalar.SelectionChanged += CbSıralamalar_SelectionChanged;
            MiKişiDüzenle.Click += MiKişiDüzenle_Click;
            MiKişiSil.Click += MiKişiSil_Click;
            TbKişiAra.TextChanged += TbKişiAra_TextChanged;
            Filtrele();
        }
        #region Arama
        private void TbKişiAra_TextChanged(object sender, TextChangedEventArgs e)
        {
            Filtrele();
        }

        #endregion

        #region Sil
        private void MiKişiSil_Click(object sender, RoutedEventArgs e)
        {
            Kişi seçiliKişi = LbKişiler.SelectedItem as Kişi;
            if (seçiliKişi != null)
            {
                Veri.Kişiler.Remove(seçiliKişi);
                NavigationService.Content = new Kişiler();

            }
        }
        #endregion

        #region Düzenle
        private void MiKişiDüzenle_Click(object sender, RoutedEventArgs e)
        {
            Kişi seçiliKişi = LbKişiler.SelectedItem as Kişi;
            if (seçiliKişi != null)
            {
                NavigationService.Content = new KişiEkle(seçiliKişi);
            }
        }
        #endregion

        #region Sıralamalar
        private void CbSıralamalar_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Filtrele();
        }
        #endregion
        #region Filtre
        private void CbFiltreler_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Filtrele();
        }

        #endregion
        #region Listbox seçme
        private void LbGruplar_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Grup seçilenGrup = LbGruplar.SelectedItem as Grup;
            if (seçilenGrup != null)
            {
                LbKişiler.ItemsSource = seçilenGrup.Kişi;
            }
        }
        #endregion

        #region Filtrele

        private void Filtrele()
        {
            IEnumerable<Kişi> kişiler = Veri.Kişiler.AsEnumerable();
            #region TbAra
            kişiler = kişiler.Where(k => k.Adı.StartsWith(TbKişiAra.Text, StringComparison.CurrentCultureIgnoreCase));
            #endregion

            #region Raporlar
            if (kişiler.Count()>0)
            {
                // 1) Toplam Kişi Sayısı
                TbToplamKişi.Text = kişiler.Count().ToString();
                // 20-30 yaş arasındaki insanlar
                Tb2030YaşArasındakiler.Text = kişiler.Where(k => DateTime.Now.Year - k.DoğumTarihi.Year > 20 && DateTime.Now.Year - k.DoğumTarihi.Year < 30).FirstOrDefault()?.Adı;
                // en yaşlı insan
                TbEnYaşlıKişiyeAitBilgiler.Text = kişiler.OrderBy(k => k.DoğumTarihi).FirstOrDefault()?.Adı;
            }
           
            #endregion

            #region Sorgular
            switch (CbFiltreler.SelectedIndex)
            {
                case 0:
                    //"1) Tümünü Listele"
                    kişiler = kişiler.OrderBy(p => p.Adı);
                    break;

                case 1:
                    //"2) Mail odresi olmayanlar"
                    kişiler = kişiler.Where(k => k.EPosta == null || k.EPosta=="");
                    break;

                case 2:
                    // "3) 1990-2000 arasında doğanlar"
                    kişiler = kişiler.Where(k => k.DoğumTarihi.Year <= 1990 && k.DoğumTarihi.Year <= 2000);
                    break;

                case 3:
                    //"4) 5 Harfli ada sahip olanlar"
                    kişiler = kişiler.Where(k => k.Adı.Length == 5);
                    break;

                case 4:
                    //"5) Temmuz ve Ağustos ayında doğanlar
                    kişiler = kişiler.Where(k => k.DoğumTarihi.Month == 8 && k.DoğumTarihi.Month == 7);
                    break;

                case 5:
                    // Ortalama yaş üzerinde doğanlar
                    double ortyaş = kişiler.Average(k => DateTime.Now.Year - k.DoğumTarihi.Year);
                    kişiler = kişiler.Where(k => DateTime.Now.Year - k.DoğumTarihi.Year > ortyaş);
                    break;


            }
            #endregion

            #region Sıralamalar
            switch (CbSıralamalar.SelectedIndex)
            {
                case 0:
                    // "1)Ada Göre Artan, Soyada Göre Azalan",
                    kişiler = kişiler.OrderBy(k => k.Adı).ThenByDescending(k => k.Soyadı);
                    break;
                case 1:
                    // "2)Ada Göre Azalan, Soyada Göre Artan",
                    kişiler = kişiler.OrderByDescending(k => k.Adı).ThenBy(k => k.Soyadı);

                    break;
                case 2:
                    //  "3)Doğum Tarihine Göre Azalan"
                    kişiler = kişiler.OrderByDescending(k => k.DoğumTarihi);

                    break;

            }
            #endregion


            LbKişiler.ItemsSource = kişiler;
        }
        #endregion
    }
}
