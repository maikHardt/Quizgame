using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace maikhardt_projekt
{
    public class Laender
    {
        private int laNr;
        private string laName;
        private int laeKoNr;
        public int LaNr { get => laNr; set => laNr = value; }
        public string LaName { get => laName; set => laName = value; }
        public int LaeKoNr { get => laeKoNr; set => laeKoNr = value; }
        public Laender(int lanr, string laname, int laekonr)
        {
            laNr = lanr;
            laName = laname;
            laeKoNr = laekonr;
        }
    }
}
