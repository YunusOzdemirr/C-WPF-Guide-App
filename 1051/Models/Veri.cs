using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace _1051.Models
{
    public static class Veri
    {
        public static ObservableCollection<Kişi> Kişiler = new ObservableCollection<Kişi>();
        public static ObservableCollection<Grup> Gruplar = new ObservableCollection<Grup>();

        static Veri()
        {
            Gruplar.Add(new Grup()
            {
                GrupAdı = "Arkadaşlar",
            });
            Gruplar.Add(new Grup()
            {
                GrupAdı = "Yakın Arkadaşlar",
            });
            Gruplar.Add(new Grup()
            {
                GrupAdı = "Aile",
            });

            Kişiler.Add(new Kişi()
            {
                Adı = "Yunus",
                Soyadı = "Özdemir",
                TelefonNo = "05393186864",
                DoğumTarihi = new DateTime(2003, 03, 27),
                EPosta = "yunusozdemir468@gmail.com",
                Resim = new BitmapImage(new Uri("/Image/A05.png", UriKind.Relative)),
                Grup = Veri.Gruplar[2]
            });
            Kişiler.Add(new Kişi()
            {
                Adı = "Melek",
                Soyadı = "Özdemir",
                TelefonNo = "05378944651",
                DoğumTarihi = new DateTime(1998, 12, 10),
                EPosta = "Melek12031723@gmail.com",
                Resim = new BitmapImage(new Uri("/Image/FA01.png", UriKind.Relative)),
                Grup = Veri.Gruplar[2]
            });
            Kişiler.Add(new Kişi()
            {
                Adı = "Ömer",
                Soyadı = "Özdemir",
                TelefonNo = "05487845965",
                DoğumTarihi = new DateTime(1966, 03,07),
                EPosta = "Melek12031723@gmail.com",
                Resim = new BitmapImage(new Uri("/Image/B03.png", UriKind.Relative)),
                Grup = Veri.Gruplar[2]
            });
            Kişiler.Add(new Kişi()
            {
                Adı = "Furkan",
                Soyadı = "Yılmaz",
                TelefonNo = "05841545965",
                DoğumTarihi = new DateTime(2033, 07, 15),
                EPosta = "AS4LEX@gmail.com",
                Resim = new BitmapImage(new Uri("/Image/FA01.png", UriKind.Relative)),
                Grup = Veri.Gruplar[1]
            });
            Kişiler.Add(new Kişi()
            {
                Adı = "Kıvanç",
                Soyadı = "Kurban",
                TelefonNo = "05841545965",
                DoğumTarihi = new DateTime(1972, 01, 25),
                EPosta = "ThaStack@gmail.com",
                Resim = new BitmapImage(new Uri("/Image/FA01.png", UriKind.Relative)),
                Grup = Veri.Gruplar[1]
            });
            Kişiler.Add(new Kişi()
            {
                Adı = "Nesih",
                Soyadı = "Yılmaz",
                TelefonNo = "05841545965",
                DoğumTarihi = new DateTime(1981, 08, 10),
                EPosta = "Salmiye@gmail.com",
                Resim = new BitmapImage(new Uri("/Image/C01.png", UriKind.Relative)),
                Grup = Veri.Gruplar[1]
            });
            Kişiler.Add(new Kişi()
            {
                Adı = "Salim",
                Soyadı = "Yıldız",
                TelefonNo = "05841545965",
                DoğumTarihi = new DateTime(1981, 08, 10),
                EPosta = "Salime@gmail.com",
                Resim = new BitmapImage(new Uri("/Image/A04.png", UriKind.Relative)),
                Grup = Veri.Gruplar[1]
            });


        }
    }
}
