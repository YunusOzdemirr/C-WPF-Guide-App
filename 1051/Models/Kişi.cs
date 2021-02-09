using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace _1051.Models
{
    public class Kişi
    {
        public Grup Grup { get; set; }
        public string Adı { get; set; }
        public string Soyadı { get; set; }
        public string TelefonNo { get; set; }
        public string EPosta { get; set; }
        public DateTime DoğumTarihi { get; set; }
        public BitmapImage Resim { get; set; }
        public override string ToString()
        {
            return $"Grup Adı: {Grup} Adı: {Adı} Soyadı: {Soyadı} ";
        }
    }
}
