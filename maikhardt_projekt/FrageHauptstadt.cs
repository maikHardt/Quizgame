using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace maikhardt_projekt
{
    public class FrageHauptstadt
    {
        private int frHaNr;
        private string frHa;
        private int frHauptstadt;
        private int frHaLand;
        private int frHaKoNr;
        public int FrHaNr { get => frHaNr; set => frHaNr = value; }
        public string FrHa { get => frHa; set => frHa = value; }
        public int FrHauptstadt { get => frHauptstadt; set => frHauptstadt = value; }
        public int FrHaLand { get => frHaLand; set => frHaLand = value; }
        public int FrHaKoNr { get => frHaKoNr; set => frHaKoNr = value; }
        public FrageHauptstadt(int frhanr, string frha, int frhauptstadt, int frhaland, int frhakonr)
        {
            frHaNr = frhanr;
            frHa = frha;
            frHauptstadt = frhauptstadt;
            frHaLand = frhaland;
            frHaKoNr = frhakonr;
        }
    }
}
