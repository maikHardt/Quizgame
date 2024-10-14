using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace maikhardt_projekt
{
    public class Kontinent
    {
        private int koNr;
        private string koName;
        public int KoNr { get => koNr; set => koNr = value; }
        public string KoName { get => koName; set => koName = value; }
        public Kontinent(int konr, string koname)
        {
            KoNr = konr;
            KoName = koname;
        }
    }
}
