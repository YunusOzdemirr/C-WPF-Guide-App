using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1051.Models
{
    public class Grup
    {
        public string GrupAdı { get; set; }
        public List<Kişi> Kişi { get { return Veri.Kişiler.Where(g => g.Grup == this).ToList(); } }

        public override string ToString()
        {
            return $"{GrupAdı}";
        }
        
    }
}
