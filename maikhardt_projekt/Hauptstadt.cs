using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace maikhardt_projekt
{
    public class Hauptstadt
    {
        private int haNr;
        private string haName;
        private int hauKoNr;
        public int HaNr { get => haNr; set => haNr = value; }
        public string HaName { get => haName; set => haName = value; }
        public int HauKoNr { get => hauKoNr; set => hauKoNr = value; }
        public Hauptstadt(int hanr, string haname, int haukonr)
        {
            haNr = hanr;
            haName = haname;
            hauKoNr = haukonr;
        }
    }
}
