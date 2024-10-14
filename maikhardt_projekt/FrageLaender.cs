using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace maikhardt_projekt
{
    public class FrageLaender
    {
        private int frLaNr;
        private string frLaBild;
        private string frLa;
        private int frLaAntwort;
        private int frLaKoNr;
        public int FrLaNr { get => frLaNr; set => frLaNr = value; }
        public string FrLaBild { get => frLaBild; set => frLaBild = value; }
        public string FrLa { get => frLa; set => frLa = value; }
        public int FrLaAntwort { get => frLaAntwort; set => frLaAntwort = value; }
        public int FrLaKoNr { get => frLaKoNr; set => frLaKoNr = value; }

        public FrageLaender(int frlanr, string frlabild, string frla, int frlaantwort, int frlakonr)
        {
            frLaNr = frlanr;
            frLaBild = frlabild;
            frLa = frla;
            frLaAntwort = frlaantwort;
            frLaKoNr = frlakonr;
        }
    }
}
