using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace maikhardt_projekt
{
    public class Spieler
    {
        private int spNr;
        private string spName;
        public int SpNr { get => spNr; set => spNr = value; }
        public string SpName { get => spName; set => spName = value; }
        
        public Spieler(int spnr, string spname)
        {
            spNr = spnr;
            spName = spname;
        }
    }
}
