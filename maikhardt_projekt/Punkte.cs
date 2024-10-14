using Org.BouncyCastle.Asn1.X509;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace maikhardt_projekt
{
    public class Punkte
    {
        private int puNr;
        private int puPunkte;
        private DateTime puDate;
        private int puSpNr;
        public int PuNr { get => puNr; set => puNr = value; }
        public int PuPunkte { get => puPunkte; set => puPunkte = value; }
        public DateTime PuDate { get => puDate; set => puDate = value; }
        public int PuSpNr { get => puSpNr; set => puSpNr = value; }

        public Punkte(int punr, int pupunkte, DateTime pudate, int puspnr)
        {
            puNr = punr;
            puPunkte = pupunkte;
            puDate = pudate;
            puSpNr = puspnr;
        }
    }
}
