using System;
using System.Diagnostics.Eventing.Reader;
using System.Windows.Forms;
using static Org.BouncyCastle.Asn1.Cmp.Challenge;

namespace maikhardt_projekt
{
    public partial class Form1 : Form
    {
        private List<Kontinent> konList;
        private List<Laender> laList;
        private List<FrageLaender> frlList;
        private List<Hauptstadt> hauList;
        private List<FrageHauptstadt> frhList;
        private List<Spieler> SpList;
        private List<Punkte> PList;
        private Datenbank db = new Datenbank();

        private string spielername; // Spielername
        private bool allowTabChange = false; // TabSwitch Kontrolle
        private bool KontinentOnOff = false; // Kontinente Ja/Nein
        private int kontinent = 0; // Kontinentauswahl
        private int auswahl = 0; // Quizfilter
        private int inauswahl = 0; // Quizfilter        
        private int[] random = new int[10];
        private int[] antwort = new int[10]; // Die Richtigen Antworten
        private int[] antworten = new int[40]; // Richtige und Falsche Antworten
        private int punkte = 0; //Zwischenspeicher Punkte
        private int frlaliste = 115; // Angabe der Listen Größe in der Fragenländertabelle
        private int frhaliste = 80; // Angabe der Listen Größe in der Fragenhaupststadttabelle
        private int laliste = 189; // Angabe der Listengröße in der Ländertabelle
        private int haliste = 195; // Angabe der Listengröße in der Hauptstadttabelle

        int schummelscan1 = 0;
        int schummelscan2 = 0;

        public Form1()
        {
            InitializeComponent();
            InitializeCustomComponent();            
        }

        private void InitializeCustomComponent()
        {
            pAuswahl1.Click += (s, e) => ChangeTab(tabControl, 1);
            //pAuswahl2.Click += (s, e) => ChangeTab(tabControl, 2); Geht Nicht
            pAuswahl3.Click += (s, e) => ChangeTab(tabControl, 3);
            //pAuswahl1_1.Click += (s, e) => ChangeTab(tabControl, 3);  Geht Nicht
            pAuswahl1_2.Click += (s, e) => ChangeTab(tabControl, 3);
            //pAuswahl2_1.Click += (s, e) => ChangeTab(tabControl, 2);  Geht Nicht
            //pAuswahl2_2.Click += (s, e) => ChangeTab(tabControl, 2);  Geht Nicht
            pAuswahl3_1.Click += (s, e) => ChangeTab(tabControl, 1);
            pAuswahl3_2.Click += (s, e) => ChangeTab(tabControl, 1);            
        }
        private void tabControl1_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (!allowTabChange)
            {
                e.Cancel = true;
            }
        }
        private void ChangeTab(TabControl tabControl, int direction)
        {
            allowTabChange = true;

            int newIndex = tabControl.SelectedIndex + direction;

            if (newIndex >= 0 && newIndex < tabControl.TabCount)
            {
                tabControl.SelectedIndex = newIndex;
            }

            allowTabChange = false;
        }

        /* Initialisierung des Spiels (Auswahl des Quiz) + Start Button nach Auswahl -------------------------------------------------*/

        private void btnEingabe_Click(object sender, EventArgs e)
        {
            spielername = tBName.Text;
            SpList = db.getSpieler();
            if (tBName.Text != "")
            {
                if (SpList.Find(x => x.SpName == spielername) != null)
                {
                    db.saveSpieler(spielername, SpList.Find(x => x.SpName == spielername).SpNr);
                }
                else
                {
                    db.saveSpieler(spielername, -1);
                }
                ChangeTab(tabControl, 1);
            }
            else
            {
                MessageBox.Show("Gib einen Namen ein!");
                return;
            }
        }
        private void btn_auswahl_Click(object sender, EventArgs e)
        {
            string imagePath = Path.Combine(Application.StartupPath, "mats", "on.png");
            string imagePath2 = Path.Combine(Application.StartupPath, "mats", "off.png");
            if (!KontinentOnOff)
            {
                KontinentOnOff = true;
                btnKontinentOn.BackgroundImage = Image.FromFile(imagePath);

                konList = db.getKontinent();
                foreach (Kontinent k in konList)
                {
                    cBKontinent.Items.Add(k.KoName);
                }
            }
            else
            {
                KontinentOnOff = false;
                cBKontinent.Items.Clear();
                btnKontinentOn.BackgroundImage = Image.FromFile(imagePath2);
            }
        }
        private void cBKontinent_SelectedIndexChanged(object sender, EventArgs e)
        {
            kontinent = Convert.ToInt32(cBKontinent.SelectedIndex + 1);
        }
        private void pAuswahl1_Click(object sender, EventArgs e)
        {
            auswahl = 1;
        }
        /* --------------EIN VIEL ZU GROßES THEMA ÜBERSCHÄTZT-----------------------------------------------------
         * private void pAuswahl2_Click(object sender, EventArgs e)
        {
            auswahl = 2;
         ----------------------------------------------------------------------------------------------------------
        }*/
        private void pAuswahl3_Click(object sender, EventArgs e)
        {
            auswahl = 3;
        }
        /*
         * --------------EIN VIEL ZU GROßES THEMA ÜBERSCHÄTZT-----------------------------------------------------
        private void pAuswahl1_1_Click(object sender, EventArgs e)
        {
            inauswahl = 1;
        }
        ----------------------------------------------------------------------------------------------------------
        */
        private void pAuswahl1_2_Click(object sender, EventArgs e)
        {
            inauswahl = 2;
        }
        /*--------------EIN VIEL ZU GROßES THEMA ÜBERSCHÄTZT------------------------------------------------------
        private void pflaggenfar_Click(object sender, EventArgs e)
        {
            inauswahl = 1;
        }

        private void pflaggenzuo_Click(object sender, EventArgs e)
        {
            inauswahl = 2;
        }
        ----------------------------------------------------------------------------------------------------------
        */
        private void pAuswahl3_1_Click(object sender, EventArgs e)
        {
            inauswahl = 1;
        }
        private void pAuswahl3_2_Click(object sender, EventArgs e)
        {
            inauswahl = 2;
        }
        private void btnStart_Click(object sender, EventArgs e)
        {
            ChangeTab(tabControl, 1);
            quizfilter();
            lPunktestand1.Text = punkte.ToString();
            
        }

        /*----------------------------------------------------------------------------------------------------------------------------*/

        /* Auswertung der Auswahl zur Initialisierung der Fragen + Erstellung der Fragen und Antworten sowie der Falschen Antworten --*/

        public void quizfilter()
        {
            rTB1.Text = "";
            rTB2.Text = "";
            rTB3.Text = "";
            rTB4.Text = "";
            rTB5.Text = "";
            rTB6.Text = "";
            rTB7.Text = "";
            rTB8.Text = "";
            rTB9.Text = "";
            rTB10.Text = "";

            //if (auswahl == 1 && inauswahl == 1) { quiz1_1(kontinent); }
            if (auswahl == 1 && inauswahl == 2) { quiz1_2(kontinent); }
            //else if (auswahl == 2 && inauswahl == 1) { quiz2_1(kontinent); }
            //else if (auswahl == 2 && inauswahl == 2) { quiz2_2(kontinent); }
            else if (auswahl == 3 && inauswahl == 1) { quiz3_1(kontinent); }
            else if (auswahl == 3 && inauswahl == 2) { quiz3_2(kontinent); }
        }
        /*
        * ZU GROß GEDACHT--------------------------------------------------------------------------
       private void quiz1_1(int kontinent)
       {
           if (kontinent == 0)
           {

           } else
           {

           }
       }
       --------------------------------------------------------------------------------------------
       */
        private void quiz1_2(int kontinent)
        {
            // Erstellung 10 Fragen und Antworten abhängig davon welches Spiel gespielt wird | Antworten werden als Zahl gespeichert in antwort[] um diese weiter zu bearbeiten
            frlList = db.getFrageLaender();
            fragenantwortengenerator(frlaliste, kontinent);
            string[] frage = new string[10];
            for (int i = 0; i < random.Length; i++)
            {
                frage[i] = frlList.Find(x => x.FrLaNr == this.random[i]).FrLa;
                antwort[i] = frlList.Find(x => x.FrLaNr == this.random[i]).FrLaAntwort;
            }
            rTB1.Text = frage[0];
            rTB2.Text = frage[1];
            rTB3.Text = frage[2];
            rTB4.Text = frage[3];
            rTB5.Text = frage[4];
            rTB6.Text = frage[5];
            rTB7.Text = frage[6];
            rTB8.Text = frage[7];
            rTB9.Text = frage[8];
            rTB10.Text = frage[9];
            //-----------------------------------------------------------------------------------------------------------------------------------------------------
            // antwort[] wird bearbeitet und es kommen 40 Antworten mit falschen Antworten bei raus (Aus allen Kontinenten)               
            antworten40generator(laliste);
            string[] antworten = new string[40];

            for (int i = 0; i < antworten.Length; i++)
            {
                antworten[i] = laList.Find(x => x.LaNr == this.antworten[i]).LaName;
            }
            btn1_1.Text = antworten[0];
            btn1_2.Text = antworten[1];
            btn1_3.Text = antworten[2];
            btn1_4.Text = antworten[3];

            btn2_1.Text = antworten[4];
            btn2_2.Text = antworten[5];
            btn2_3.Text = antworten[6];
            btn2_4.Text = antworten[7];

            btn3_1.Text = antworten[8];
            btn3_2.Text = antworten[9];
            btn3_3.Text = antworten[10];
            btn3_4.Text = antworten[11];

            btn4_1.Text = antworten[12];
            btn4_2.Text = antworten[13];
            btn4_3.Text = antworten[14];
            btn4_4.Text = antworten[15];

            btn5_1.Text = antworten[16];
            btn5_2.Text = antworten[17];
            btn5_3.Text = antworten[18];
            btn5_4.Text = antworten[19];

            btn6_1.Text = antworten[20];
            btn6_2.Text = antworten[21];
            btn6_3.Text = antworten[22];
            btn6_4.Text = antworten[23];

            btn7_1.Text = antworten[24];
            btn7_2.Text = antworten[25];
            btn7_3.Text = antworten[26];
            btn7_4.Text = antworten[27];

            btn8_1.Text = antworten[28];
            btn8_2.Text = antworten[29];
            btn8_3.Text = antworten[30];
            btn8_4.Text = antworten[31];

            btn9_1.Text = antworten[32];
            btn9_2.Text = antworten[33];
            btn9_3.Text = antworten[34];
            btn9_4.Text = antworten[35];

            btn10_1.Text = antworten[36];
            btn10_2.Text = antworten[37];
            btn10_3.Text = antworten[38];
            btn10_4.Text = antworten[39];
        }
        /*
         * EIN VIEL ZU GROßES THEMA ÜBERSCHÄTZT------------------------------------------------------
         * private void quiz2_1(int kontinent)
        {
            if (kontinent == 0)
            {
                
            }
            else
            {
                
            }
        }
        private void quiz2_2(int kontinent)
        {
            if (kontinent == 0)
            {
                
            }
            else
            {

            }        
        }        
        ----------------------------------------------------------------------------------------------
        */
        private void quiz3_1(int kontinent)
        {
            // Erstellung 10 Fragen und Antworten abhängig davon welches Spiel gespielt wird | Antworten werden als Zahl gespeichert in antwort[] um diese weiter zu bearbeiten
            frhList = db.getFrageHauptstadt();
            fragenantwortengenerator(frhaliste, kontinent);
            string[] frage = new string[10];
            for (int i = 0; i < random.Length; i++)
            {
                frage[i] = frhList.Find(x => x.FrHaNr == this.random[i]).FrHa;
                antwort[i] = frhList.Find(x => x.FrHaNr == this.random[i]).FrHauptstadt;
            }
            rTB1.Text = frage[0];
            rTB2.Text = frage[1];
            rTB3.Text = frage[2];
            rTB4.Text = frage[3];
            rTB5.Text = frage[4];
            rTB6.Text = frage[5];
            rTB7.Text = frage[6];
            rTB8.Text = frage[7];
            rTB9.Text = frage[8];
            rTB10.Text = frage[9];
            //-----------------------------------------------------------------------------------------------------------------------------------------------------
            // antwort[] wird bearbeitet und es kommen 40 Antworten mit falschen Antworten bei raus  (Aus allen Kontinenten)               
            antworten40generator(haliste);
            string[] antworten = new string[40];

            for (int i = 0; i < antworten.Length; i++)
            {
                antworten[i] = hauList.Find(x => x.HaNr == this.antworten[i]).HaName;
            }
            btn1_1.Text = antworten[0];
            btn1_2.Text = antworten[1];
            btn1_3.Text = antworten[2];
            btn1_4.Text = antworten[3];

            btn2_1.Text = antworten[4];
            btn2_2.Text = antworten[5];
            btn2_3.Text = antworten[6];
            btn2_4.Text = antworten[7];

            btn3_1.Text = antworten[8];
            btn3_2.Text = antworten[9];
            btn3_3.Text = antworten[10];
            btn3_4.Text = antworten[11];

            btn4_1.Text = antworten[12];
            btn4_2.Text = antworten[13];
            btn4_3.Text = antworten[14];
            btn4_4.Text = antworten[15];

            btn5_1.Text = antworten[16];
            btn5_2.Text = antworten[17];
            btn5_3.Text = antworten[18];
            btn5_4.Text = antworten[19];

            btn6_1.Text = antworten[20];
            btn6_2.Text = antworten[21];
            btn6_3.Text = antworten[22];
            btn6_4.Text = antworten[23];

            btn7_1.Text = antworten[24];
            btn7_2.Text = antworten[25];
            btn7_3.Text = antworten[26];
            btn7_4.Text = antworten[27];

            btn8_1.Text = antworten[28];
            btn8_2.Text = antworten[29];
            btn8_3.Text = antworten[30];
            btn8_4.Text = antworten[31];

            btn9_1.Text = antworten[32];
            btn9_2.Text = antworten[33];
            btn9_3.Text = antworten[34];
            btn9_4.Text = antworten[35];

            btn10_1.Text = antworten[36];
            btn10_2.Text = antworten[37];
            btn10_3.Text = antworten[38];
            btn10_4.Text = antworten[39];
        }
        private void quiz3_2(int kontinent)
        {
            frhList = db.getFrageHauptstadt();
            frlList = db.getFrageLaender();
            fragenantwortengenerator(frhaliste, kontinent);
            string[] frage = new string[10];
            for (int i = 0; i < random.Length; i++)
            {
                frage[i] = frhList.Find(x => x.FrHaNr == this.random[i]).FrHa;
                antwort[i] = frhList.Find(x => x.FrHaNr == this.random[i]).FrHaLand;
            }
            rTB1.Text = frage[0];
            rTB2.Text = frage[1];
            rTB3.Text = frage[2];
            rTB4.Text = frage[3];
            rTB5.Text = frage[4];
            rTB6.Text = frage[5];
            rTB7.Text = frage[6];
            rTB8.Text = frage[7];
            rTB9.Text = frage[8];
            rTB10.Text = frage[9];
            //-----------------------------------------------------------------------------------------------------------------------------------------------------
            // antwort[] wird bearbeitet und es kommen 40 Antworten mit falschen Antworten(Aus allen Kontinenten) bei raus           
            antworten40generator(laliste);
            string[] antworten = new string[40];

            for (int i = 0; i < antworten.Length; i++)
            {
                antworten[i] = laList.Find(x => x.LaNr == this.antworten[i]).LaName;
            }
            btn1_1.Text = antworten[0];
            btn1_2.Text = antworten[1];
            btn1_3.Text = antworten[2];
            btn1_4.Text = antworten[3];

            btn2_1.Text = antworten[4];
            btn2_2.Text = antworten[5];
            btn2_3.Text = antworten[6];
            btn2_4.Text = antworten[7];

            btn3_1.Text = antworten[8];
            btn3_2.Text = antworten[9];
            btn3_3.Text = antworten[10];
            btn3_4.Text = antworten[11];

            btn4_1.Text = antworten[12];
            btn4_2.Text = antworten[13];
            btn4_3.Text = antworten[14];
            btn4_4.Text = antworten[15];

            btn5_1.Text = antworten[16];
            btn5_2.Text = antworten[17];
            btn5_3.Text = antworten[18];
            btn5_4.Text = antworten[19];

            btn6_1.Text = antworten[20];
            btn6_2.Text = antworten[21];
            btn6_3.Text = antworten[22];
            btn6_4.Text = antworten[23];

            btn7_1.Text = antworten[24];
            btn7_2.Text = antworten[25];
            btn7_3.Text = antworten[26];
            btn7_4.Text = antworten[27];

            btn8_1.Text = antworten[28];
            btn8_2.Text = antworten[29];
            btn8_3.Text = antworten[30];
            btn8_4.Text = antworten[31];

            btn9_1.Text = antworten[32];
            btn9_2.Text = antworten[33];
            btn9_3.Text = antworten[34];
            btn9_4.Text = antworten[35];

            btn10_1.Text = antworten[36];
            btn10_2.Text = antworten[37];
            btn10_3.Text = antworten[38];
            btn10_4.Text = antworten[39];
        }
        private void fragenantwortengenerator(int zahl, int kontinent)
        {
            int[] random = new int[10]; // 10 Random Zahlen für die Fragen und Antworten
            if (kontinent == 0)
            {
                if (zahl == frlaliste)
                {

                    int index = 0; // Hilfe für Random Zahlen
                    Random rnd = new Random();  // Zahlengenerator     
                    while (index != 10)
                    {
                        int next = rnd.Next(1, zahl);
                        if (!random.Contains(next))
                        {
                            random[index] = next;
                            index++;
                        }
                    }

                }
                else if (zahl == frhaliste)
                {
                    int index = 0; // Hilfe für Random Zahlen
                    Random rnd = new Random();  // Zahlengenerator     
                    while (index != 10)
                    {
                        int next = rnd.Next(1, zahl);
                        if (!random.Contains(next))
                        {
                            random[index] = next;
                            index++;
                        }
                    }
                }
            }
            else
            {
                frlList = db.getFrageLaender();
                frhList = db.getFrageHauptstadt();
                if (zahl == frlaliste)
                {

                    int index = 0; // Hilfe für Random Zahlen
                    Random rnd = new Random();  // Zahlengenerator     
                    while (index != 10)
                    {
                        int next = rnd.Next(1, zahl);
                        if (!random.Contains(next) && kontinent == frlList.Find(x => x.FrLaNr == next).FrLaKoNr)
                        {
                            random[index] = next;
                            index++;
                        }
                    }

                }
                else if (zahl == frhaliste)
                {
                    int index = 0; // Hilfe für Random Zahlen
                    Random rnd = new Random();  // Zahlengenerator     
                    while (index != 10)
                    {
                        int next = rnd.Next(1, zahl);
                        if (!random.Contains(next) && kontinent == frhList.Find(x => x.FrHaNr == next).FrHaKoNr)
                        {
                            random[index] = next;
                            index++;
                        }
                    }
                }
            }
            for (int i = 0; i < random.Length; i++)
            {
                this.random[i] = random[i];
            }
        }
        private void antworten40generator(int zahl)
        {
            // ÜBERGABE RANDOM UM DARAUS DIE ANTWORTEN ZU HOLEN random
            int[] random = new int[3];
            int[] antwort4er = new int[4];
            int a = 3; // Für das 4er Paar um die Reihenfolge zu halten fängt immer bei 0 an
            int b = 0; // Für das 40er Paar damit die 4er Paare richtig hinzugefügt werden

            if (zahl == laliste)
            {
                for (int i = 0; i < 10; i++) // Antworten als Nummern holen und Sortieren/Vermischen 4er Paar 
                {
                    antwort4er = new int[4];
                    for (int j = 0; j < 3; j++)
                    {
                        laList = db.getLaender();
                        Random rdm = new Random();
                        int help1 = rdm.Next(1, laliste);
                        antwort4er[j] = laList.Find(x => x.LaNr == help1).LaNr;
                    }
                    if (!antwort4er.Contains(antwort[i]))
                    {
                        antwort4er[a] = antwort[i];
                        Array.Sort(antwort4er);
                        for (int k = 0; k < 4; k++)
                        {
                            antworten[b] = antwort4er[k];
                            b++;
                        }
                    }
                    else
                        i--;
                    antwort4er = [];

                }
            }
            else if (zahl == haliste)
            {
                for (int i = 0; i < 10; i++) // Antworten als Nummern holen und Sortieren/Vermischen 4er Paar
                {

                    antwort4er[a] = antwort[i];
                    for (int j = 1; j < 4; j++)
                    {
                        laList = db.getLaender();
                        Random rdm = new Random();
                        int help1 = rdm.Next(1, 189);
                        antwort4er[j] = hauList.Find(x => x.HaNr == help1).HaNr;
                    }
                    Array.Sort(antwort4er);
                    for (int j = 0; j < 4; j++)
                    {
                        antworten[b] = antwort4er[j]; //leider können hier Doppelte Richtige Antworten auftauchen
                        b++;
                    }
                    antwort4er = [];
                }
            }
        }

        /*----------------------------------------------------------------------------------------------------------------------------*/

        /* Prüft ob Antwort gegeben wurde Wenn Ja Eins Weiter ------------------------------------------------------------------------*/

        private void btnW1_Click(object sender, EventArgs e)
        {
            if (btn1_1.BackColor == Color.Red || btn1_1.BackColor == Color.Green)
            {
                ChangeTab(tabControl, 1);
                lPunktestand2.Text = punkte.ToString();
            }
            else
                MessageBox.Show("Bitte Wähle eine Antwortmöglichkeit aus!");
        }
        private void btnW2_Click(object sender, EventArgs e)
        {
            if (btn2_1.BackColor == Color.Red || btn2_1.BackColor == Color.Green)
            {
                ChangeTab(tabControl, 1);
                lPunktestand3.Text = punkte.ToString();
            }
            else
                MessageBox.Show("Bitte Wähle eine Antwortmöglichkeit aus!");
        }
        private void btnW3_Click(object sender, EventArgs e)
        {
            if (btn3_1.BackColor == Color.Red || btn3_1.BackColor == Color.Green)
            {
                ChangeTab(tabControl, 1);
                lPunktestand4.Text = punkte.ToString();
            }
            else
                MessageBox.Show("Bitte Wähle eine Antwortmöglichkeit aus!");
        }
        private void btnW4_Click(object sender, EventArgs e)
        {
            if (btn4_1.BackColor == Color.Red || btn4_1.BackColor == Color.Green)
            {
                ChangeTab(tabControl, 1);
                lPunktestand5.Text = punkte.ToString();
            }
            else
                MessageBox.Show("Bitte Wähle eine Antwortmöglichkeit aus!");
        }
        private void btnW5_Click(object sender, EventArgs e)
        {
            if (btn5_1.BackColor == Color.Red || btn5_1.BackColor == Color.Green)
            {
                ChangeTab(tabControl, 1);
                lPunktestand6.Text = punkte.ToString();
            }
            else
                MessageBox.Show("Bitte Wähle eine Antwortmöglichkeit aus!");
        }
        private void btnW6_Click(object sender, EventArgs e)
        {
            if (btn6_1.BackColor == Color.Red || btn6_1.BackColor == Color.Green)
            {
                ChangeTab(tabControl, 1);
                lPunktestand7.Text = punkte.ToString();
            }
            else
                MessageBox.Show("Bitte Wähle eine Antwortmöglichkeit aus!");
        }
        private void btnW7_Click(object sender, EventArgs e)
        {
            if (btn7_1.BackColor == Color.Red || btn7_1.BackColor == Color.Green)
            {
                ChangeTab(tabControl, 1);
                lPunktestand8.Text = punkte.ToString();
            }
            else
                MessageBox.Show("Bitte Wähle eine Antwortmöglichkeit aus!");
        }
        private void btnW8_Click(object sender, EventArgs e)
        {
            if (btn8_1.BackColor == Color.Red || btn8_1.BackColor == Color.Green)
            {
                ChangeTab(tabControl, 1);
                lPunktestand9.Text = punkte.ToString();
            }
            else
                MessageBox.Show("Bitte Wähle eine Antwortmöglichkeit aus!");
        }
        private void btnW9_Click(object sender, EventArgs e)
        {
            if (btn9_1.BackColor == Color.Red || btn9_1.BackColor == Color.Green)
            {
                ChangeTab(tabControl, 1);
                lPunktestand10.Text = punkte.ToString();
            }
            else
                MessageBox.Show("Bitte Wähle eine Antwortmöglichkeit aus!");
        }
        private void btnW10_Click(object sender, EventArgs e)
        {
            if (btn10_1.BackColor == Color.Red || btn10_1.BackColor == Color.Green)
            {
                ChangeTab(tabControl, 1);
                SpList = db.getSpieler();
                PList = db.getPunkte();
                DateTime datum = DateTime.Now.Date;
                int spnr = SpList.Find(x => x.SpName == spielername).SpNr;
                int p = punkte;
                if (SpList.Find(x => x.SpName == spielername) != null && PList.Find(x => x.PuSpNr == spnr) != null)
                {
                    p = PList.Find(x => x.PuSpNr == spnr).PuPunkte;
                    if (punkte > p)
                    {
                        Punkte punkt = new Punkte(
                        PList.Find(x => x.PuSpNr == spnr).PuNr,
                        punkte,
                        datum,
                        spnr
                        );
                        db.savePunkte(punkt);
                    }
                }
                else
                {
                    Punkte punkt = new Punkte(
                    -1,
                    p,
                    datum,
                    spnr
                    );
                    db.savePunkte(punkt);
                }


                RanglisteAnzeigen();
            }
            else
            {
                MessageBox.Show("Bitte Wähle eine Antwortmöglichkeit aus!");
            }
        }

        /*----------------------------------------------------------------------------------------------------------------------------*/

        /* Prüft ob Antwort Richtig oder Falsch ist ----------------------------------------------------------------------------------*/

        private string RichtigoderFalsch(string a, string b, string c, string d)
        {
            laList = db.getLaender();
            hauList = db.getHauptstadt();
            frlList = db.getFrageLaender();
            frhList = db.getFrageHauptstadt();

            string richtigeAntwort = null;
            string[] antwort = new string[10];
            for (int i = 0; i < antwort.Length; i++)
            {
                if (auswahl == 1 && inauswahl == 2)
                {
                    antwort[i] = laList.Find(x => x.LaNr == this.antwort[i]).LaName;
                }
                else if (auswahl == 3 && inauswahl == 1)
                {
                    antwort[i] = hauList.Find(x => x.HaNr == this.antwort[i]).HaName;
                }
                else if (auswahl == 3 && inauswahl == 2)
                {
                    antwort[i] = laList.Find(x => x.LaNr == this.antwort[i]).LaName;
                }
            }
            for (int i = 0; i < 10; i++)
            {
                if (a == antwort[i])
                {
                    richtigeAntwort = laList.Find(x => x.LaName == antwort[i]).LaName;
                    break;
                }
                else if (b == antwort[i])
                {
                    richtigeAntwort = laList.Find(x => x.LaName == antwort[i]).LaName;
                    break;
                }
                else if (c == antwort[i])
                {
                    richtigeAntwort = laList.Find(x => x.LaName == antwort[i]).LaName;
                    break;
                }
                else if (d == antwort[i])
                {
                    richtigeAntwort = laList.Find(x => x.LaName == antwort[i]).LaName;
                    break;
                }
            }
            return richtigeAntwort;
        }
        private void btn1_Click(object sender, EventArgs e)
        {
            
            schummelscan1 += 1;
            if (sender is System.Windows.Forms.Button clickedButton && schummelscan1 == 1)
            {
                string richtigeAntwort = null;
                string a = btn1_1.Text;
                string b = btn1_2.Text;
                string c = btn1_3.Text;
                string d = btn1_4.Text;
                richtigeAntwort = RichtigoderFalsch(a, b, c, d);
                // Setzen der Hintergrundfarben basierend auf der richtigen Antwort
                if (richtigeAntwort != null)
                {
                    if (a == richtigeAntwort)
                    {
                        btn1_1.BackColor = Color.Green;
                    }
                    else
                    {
                        btn1_1.BackColor = Color.Red;
                    }

                    if (b == richtigeAntwort)
                    {
                        btn1_2.BackColor = Color.Green;
                    }
                    else
                    {
                        btn1_2.BackColor = Color.Red;
                    }

                    if (c == richtigeAntwort)
                    {
                        btn1_3.BackColor = Color.Green;
                    }
                    else
                    {
                        btn1_3.BackColor = Color.Red;
                    }

                    if (d == richtigeAntwort)
                    {
                        btn1_4.BackColor = Color.Green;
                    }
                    else
                    {
                        btn1_4.BackColor = Color.Red;
                    }

                    if (clickedButton.Text == richtigeAntwort)
                    {
                        punkte += 5;
                    }
                }
                lPunktestand1.Text = punkte.ToString();
            }
            else
            {
                MessageBox.Show("Nicht Schummeln");
            }
        }
        private void btn2_Click(object sender, EventArgs e)
        {     
            
            schummelscan1 = 0;
            schummelscan2 += 1;
            if (sender is System.Windows.Forms.Button clickedButton && schummelscan2 == 1)
            {                
                string richtigeAntwort = null;
                string a = btn2_1.Text;
                string b = btn2_2.Text;
                string c = btn2_3.Text;
                string d = btn2_4.Text;
                richtigeAntwort = RichtigoderFalsch(a, b, c, d);
                // Setzen der Hintergrundfarben basierend auf der richtigen Antwort
                if (richtigeAntwort != null)
                {
                    if (a == richtigeAntwort)
                    {
                        btn2_1.BackColor = Color.Green;
                    }
                    else
                    {
                        btn2_1.BackColor = Color.Red;
                    }

                    if (b == richtigeAntwort)
                    {
                        btn2_2.BackColor = Color.Green;
                    }
                    else
                    {
                        btn2_2.BackColor = Color.Red;
                    }

                    if (c == richtigeAntwort)
                    {
                        btn2_3.BackColor = Color.Green;
                    }
                    else
                    {
                        btn2_3.BackColor = Color.Red;
                    }

                    if (d == richtigeAntwort)
                    {
                        btn2_4.BackColor = Color.Green;
                    }
                    else
                    {
                        btn2_4.BackColor = Color.Red;
                    }

                    // Markieren des geklickten Buttons, wenn er falsch ist
                    if (clickedButton.Text == richtigeAntwort)
                    {
                        punkte += 5;
                    }
                }
                lPunktestand2.Text = punkte.ToString();
            }
            else
            {
                MessageBox.Show("Nicht Schummeln");
            }
        }
        private void btn3_Click(object sender, EventArgs e)
        {
            
            schummelscan2 = 0;
            schummelscan1 += 1;
            if (sender is System.Windows.Forms.Button clickedButton && schummelscan1 == 1)
            {
                string richtigeAntwort = null;
                string a = btn3_1.Text;
                string b = btn3_2.Text;
                string c = btn3_3.Text;
                string d = btn3_4.Text;
                richtigeAntwort = RichtigoderFalsch(a, b, c, d);
                // Setzen der Hintergrundfarben basierend auf der richtigen Antwort                
                if (richtigeAntwort != null)
                {
                    if (a == richtigeAntwort)
                    {
                        btn3_1.BackColor = Color.Green;
                    }
                    else
                    {
                        btn3_1.BackColor = Color.Red;
                    }

                    if (b == richtigeAntwort)
                    {
                        btn3_2.BackColor = Color.Green;
                    }
                    else
                    {
                        btn3_2.BackColor = Color.Red;
                    }

                    if (c == richtigeAntwort)
                    {
                        btn3_3.BackColor = Color.Green;
                    }
                    else
                    {
                        btn3_3.BackColor = Color.Red;
                    }

                    if (d == richtigeAntwort)
                    {
                        btn3_4.BackColor = Color.Green;
                    }
                    else
                    {
                        btn3_4.BackColor = Color.Red;
                    }

                    // Markieren des geklickten Buttons, wenn er falsch ist
                    if (clickedButton.Text == richtigeAntwort)
                    {
                        punkte += 5;
                    }
                }
                lPunktestand3.Text = punkte.ToString();
            }
            else
            {
                MessageBox.Show("Nicht Schummeln");
            }
        }
        private void btn4_Click(object sender, EventArgs e)
        {
            schummelscan1 = 0;
            schummelscan2 += 1;
            if (sender is System.Windows.Forms.Button clickedButton && schummelscan2 == 1)
            {
                string richtigeAntwort = null;
                string a = btn4_1.Text;
                string b = btn4_2.Text;
                string c = btn4_3.Text;
                string d = btn4_4.Text;
                richtigeAntwort = RichtigoderFalsch(a, b, c, d);
                // Setzen der Hintergrundfarben basierend auf der richtigen Antwort 
                if (richtigeAntwort != null)
                {
                    if (a == richtigeAntwort)
                    {
                        btn4_1.BackColor = Color.Green;
                    }
                    else
                    {
                        btn4_1.BackColor = Color.Red;
                    }

                    if (b == richtigeAntwort)
                    {
                        btn4_2.BackColor = Color.Green;
                    }
                    else
                    {
                        btn4_2.BackColor = Color.Red;
                    }

                    if (c == richtigeAntwort)
                    {
                        btn4_3.BackColor = Color.Green;
                    }
                    else
                    {
                        btn4_3.BackColor = Color.Red;
                    }

                    if (d == richtigeAntwort)
                    {
                        btn4_4.BackColor = Color.Green;
                    }
                    else
                    {
                        btn4_4.BackColor = Color.Red;
                    }

                    // Markieren des geklickten Buttons, wenn er falsch ist
                    if (clickedButton.Text == richtigeAntwort)
                    {
                        punkte += 5;
                    }
                }
                lPunktestand4.Text = punkte.ToString();
            }
            else
            {
                MessageBox.Show("Nicht Schummeln");
            }
        }
        private void btn5_Click(object sender, EventArgs e)
        {
            schummelscan2 = 0;
            schummelscan1 += 1;
            if (sender is System.Windows.Forms.Button clickedButton && schummelscan1 == 1)
            {
                string richtigeAntwort = null;
                string a = btn5_1.Text;
                string b = btn5_2.Text;
                string c = btn5_3.Text;
                string d = btn5_4.Text;
                richtigeAntwort = RichtigoderFalsch(a, b, c, d);
                // Setzen der Hintergrundfarben basierend auf der richtigen Antwort 
                if (richtigeAntwort != null)
                {
                    if (a == richtigeAntwort)
                    {
                        btn5_1.BackColor = Color.Green;
                    }
                    else
                    {
                        btn5_1.BackColor = Color.Red;
                    }

                    if (b == richtigeAntwort)
                    {
                        btn5_2.BackColor = Color.Green;
                    }
                    else
                    {
                        btn5_2.BackColor = Color.Red;
                    }

                    if (c == richtigeAntwort)
                    {
                        btn5_3.BackColor = Color.Green;
                    }
                    else
                    {
                        btn5_3.BackColor = Color.Red;
                    }

                    if (d == richtigeAntwort)
                    {
                        btn5_4.BackColor = Color.Green;
                    }
                    else
                    {
                        btn5_4.BackColor = Color.Red;
                    }

                    // Markieren des geklickten Buttons, wenn er falsch ist
                    if (clickedButton.Text == richtigeAntwort)
                    {
                        punkte += 5;
                    }
                }
                lPunktestand5.Text = punkte.ToString();
            }
            else
            {
                MessageBox.Show("Nicht Schummeln");
            }
        }
        private void btn6_Click(object sender, EventArgs e)
        {
            schummelscan1 = 0;
            schummelscan2 += 1;
            if (sender is System.Windows.Forms.Button clickedButton && schummelscan2 == 1)
            {
                string richtigeAntwort = null;
                string a = btn6_1.Text;
                string b = btn6_2.Text;
                string c = btn6_3.Text;
                string d = btn6_4.Text;
                richtigeAntwort = RichtigoderFalsch(a, b, c, d);
                // Setzen der Hintergrundfarben basierend auf der richtigen Antwort 
                if (richtigeAntwort != null)
                {
                    if (a == richtigeAntwort)
                    {
                        btn6_1.BackColor = Color.Green;
                    }
                    else
                    {
                        btn6_1.BackColor = Color.Red;
                    }

                    if (b == richtigeAntwort)
                    {
                        btn6_2.BackColor = Color.Green;
                    }
                    else
                    {
                        btn6_2.BackColor = Color.Red;
                    }

                    if (c == richtigeAntwort)
                    {
                        btn6_3.BackColor = Color.Green;
                    }
                    else
                    {
                        btn6_3.BackColor = Color.Red;
                    }

                    if (d == richtigeAntwort)
                    {
                        btn6_4.BackColor = Color.Green;
                    }
                    else
                    {
                        btn6_4.BackColor = Color.Red;
                    }

                    // Markieren des geklickten Buttons, wenn er falsch ist
                    if (clickedButton.Text == richtigeAntwort)
                    {
                        punkte += 5;
                    }
                }
                lPunktestand6.Text = punkte.ToString();
            }
            else
            {
                MessageBox.Show("Nicht Schummeln");
            }
        }
        private void btn7_Click(object sender, EventArgs e)
        {
            schummelscan2 = 0;
            schummelscan1 += 1;
            if (sender is System.Windows.Forms.Button clickedButton && schummelscan1 == 1)
            {
                string richtigeAntwort = null;
                string a = btn7_1.Text;
                string b = btn7_2.Text;
                string c = btn7_3.Text;
                string d = btn7_4.Text;
                richtigeAntwort = RichtigoderFalsch(a, b, c, d);
                // Setzen der Hintergrundfarben basierend auf der richtigen Antwort
                if (richtigeAntwort != null)
                {
                    if (a == richtigeAntwort)
                    {
                        btn7_1.BackColor = Color.Green;
                    }
                    else
                    {
                        btn7_1.BackColor = Color.Red;
                    }

                    if (b == richtigeAntwort)
                    {
                        btn7_2.BackColor = Color.Green;
                    }
                    else
                    {
                        btn7_2.BackColor = Color.Red;
                    }

                    if (c == richtigeAntwort)
                    {
                        btn7_3.BackColor = Color.Green;
                    }
                    else
                    {
                        btn7_3.BackColor = Color.Red;
                    }

                    if (d == richtigeAntwort)
                    {
                        btn7_4.BackColor = Color.Green;
                    }
                    else
                    {
                        btn7_4.BackColor = Color.Red;
                    }

                    // Markieren des geklickten Buttons, wenn er falsch ist
                    if (clickedButton.Text == richtigeAntwort)
                    {
                        punkte += 5;
                    }
                }
                lPunktestand7.Text = punkte.ToString();
            }
            else
            {
                MessageBox.Show("Nicht Schummeln");
            }
        }
        private void btn8_Click(object sender, EventArgs e)
        {
            schummelscan1 = 0;
            schummelscan2 += 1;
            if (sender is System.Windows.Forms.Button clickedButton && schummelscan2 == 1)
            {
                string richtigeAntwort = null;
                string a = btn8_1.Text;
                string b = btn8_2.Text;
                string c = btn8_3.Text;
                string d = btn8_4.Text;
                richtigeAntwort = RichtigoderFalsch(a, b, c, d);
                // Setzen der Hintergrundfarben basierend auf der richtigen Antwort
                if (richtigeAntwort != null)
                {
                    if (a == richtigeAntwort)
                    {
                        btn8_1.BackColor = Color.Green;
                    }
                    else
                    {
                        btn8_1.BackColor = Color.Red;
                    }

                    if (b == richtigeAntwort)
                    {
                        btn8_2.BackColor = Color.Green;
                    }
                    else
                    {
                        btn8_2.BackColor = Color.Red;
                    }

                    if (c == richtigeAntwort)
                    {
                        btn8_3.BackColor = Color.Green;
                    }
                    else
                    {
                        btn8_3.BackColor = Color.Red;
                    }

                    if (d == richtigeAntwort)
                    {
                        btn8_4.BackColor = Color.Green;
                    }
                    else
                    {
                        btn8_4.BackColor = Color.Red;
                    }

                    // Markieren des geklickten Buttons, wenn er falsch ist
                    if (clickedButton.Text == richtigeAntwort)
                    {
                        punkte += 5;
                    }
                }
                lPunktestand8.Text = punkte.ToString();
            }
            else
            {
                MessageBox.Show("Nicht Schummeln");
            }
        }
        private void btn9_Click(object sender, EventArgs e)
        {
            schummelscan2 = 0;
            schummelscan1 += 1;
            if (sender is System.Windows.Forms.Button clickedButton && schummelscan1 == 1)
            {
                string richtigeAntwort = null;
                string a = btn9_1.Text;
                string b = btn9_2.Text;
                string c = btn9_3.Text;
                string d = btn9_4.Text;
                richtigeAntwort = RichtigoderFalsch(a, b, c, d);
                // Setzen der Hintergrundfarben basierend auf der richtigen Antwort
                if (richtigeAntwort != null)
                {
                    if (a == richtigeAntwort)
                    {
                        btn9_1.BackColor = Color.Green;
                    }
                    else
                    {
                        btn9_1.BackColor = Color.Red;
                    }

                    if (b == richtigeAntwort)
                    {
                        btn9_2.BackColor = Color.Green;
                    }
                    else
                    {
                        btn9_2.BackColor = Color.Red;
                    }

                    if (c == richtigeAntwort)
                    {
                        btn9_3.BackColor = Color.Green;
                    }
                    else
                    {
                        btn9_3.BackColor = Color.Red;
                    }

                    if (d == richtigeAntwort)
                    {
                        btn9_4.BackColor = Color.Green;
                    }
                    else
                    {
                        btn9_4.BackColor = Color.Red;
                    }

                    // Markieren des geklickten Buttons, wenn er falsch ist
                    if (clickedButton.Text == richtigeAntwort)
                    {
                        punkte += 5;
                    }
                }
                lPunktestand9.Text = punkte.ToString();
            }
            else
            {
                MessageBox.Show("Nicht Schummeln");
            }
        }
        private void btn10_Click(object sender, EventArgs e)
        {
            schummelscan1 = 0;
            schummelscan2 += 1;
            if (sender is System.Windows.Forms.Button clickedButton && schummelscan2 == 1)
            {
                string richtigeAntwort = null;
                string a = btn10_1.Text;
                string b = btn10_2.Text;
                string c = btn10_3.Text;
                string d = btn10_4.Text;
                richtigeAntwort = RichtigoderFalsch(a, b, c, d);
                // Setzen der Hintergrundfarben basierend auf der richtigen Antwort
                if (richtigeAntwort != null)
                {
                    if (a == richtigeAntwort)
                    {
                        btn10_1.BackColor = Color.Green;
                    }
                    else
                    {
                        btn10_1.BackColor = Color.Red;
                    }

                    if (b == richtigeAntwort)
                    {
                        btn10_2.BackColor = Color.Green;
                    }
                    else
                    {
                        btn10_2.BackColor = Color.Red;
                    }

                    if (c == richtigeAntwort)
                    {
                        btn10_3.BackColor = Color.Green;
                    }
                    else
                    {
                        btn10_3.BackColor = Color.Red;
                    }

                    if (d == richtigeAntwort)
                    {
                        btn10_4.BackColor = Color.Green;
                    }
                    else
                    {
                        btn10_4.BackColor = Color.Red;
                    }
                    // Markieren des geklickten Buttons, wenn er falsch ist
                    if (clickedButton.Text == richtigeAntwort)
                    {
                        punkte += 5;
                    }
                }
            }
            else
            {
                MessageBox.Show("Nicht Schummeln");
            }
        }

        /*----------------------------------------------------------------------------------------------------------------------------*/

        /* EndScreen -----------------------------------------------------------------------------------------------------------------*/

        private void RanglisteAnzeigen()
        {
            lpunkte.Text = punkte.ToString();

            PList = db.getPunkte();
            SpList = db.getSpieler();

            int[] highscore = new int[100]; //Highscore der Spieler
            string[] spieler = new string[100]; // Spielername
            foreach (Punkte p in PList) // Auszählung + Überprüfung ob der derzeite Punktestand des Spielers(der spielt) größer ist als in der Datenbank
            {
                if (punkte > p.PuPunkte && spielername == SpList.Find(x => x.SpNr == p.PuSpNr).SpName)
                {
                    rTBHigscore.Text = "Dein Highscore: " + punkte.ToString() + " Punkte";
                    highscore[p.PuNr - 1] = punkte;
                    spieler[p.PuNr - 1] = SpList.Find(x => x.SpNr == p.PuSpNr).SpName;
                }
                else
                {
                    if (SpList.Find(x => x.SpNr == p.PuSpNr).SpName == spielername)
                    {
                        rTBHigscore.Text = "Dein Highscore: " + p.PuPunkte.ToString() + " Punkte";
                    }
                    highscore[p.PuNr - 1] = p.PuPunkte;
                    spieler[p.PuNr - 1] = SpList.Find(x => x.SpNr == p.PuSpNr).SpName;
                }
            }
            Array.Sort(highscore);
            Array.Reverse(highscore); // Sortierung von Groß nach klein       

            for (int i = 0; i < highscore.Length; i++)
            {
                if (highscore[i] > 0)
                {
                    lBRangliste.Items.Add(spieler[i] + " " + highscore[i]);
                }

            }
        }        
        private void btnNeustart_Click(object sender, EventArgs e)
        {
            tBName.Text = "";
            punkte = 0;
            lpunkte.Text = "";
            schummelscan1 = 0;
            schummelscan2 = 0;
            lBRangliste.Items.Clear();
            btn1_1.BackColor = Color.Transparent;
            btn1_2.BackColor = Color.Transparent;
            btn1_3.BackColor = Color.Transparent;
            btn1_4.BackColor = Color.Transparent;
            btn2_1.BackColor = Color.Transparent;
            btn2_2.BackColor = Color.Transparent;
            btn2_3.BackColor = Color.Transparent;
            btn2_4.BackColor = Color.Transparent;
            btn3_1.BackColor = Color.Transparent;
            btn3_2.BackColor = Color.Transparent;
            btn3_3.BackColor = Color.Transparent;
            btn3_4.BackColor = Color.Transparent;
            btn4_1.BackColor = Color.Transparent;
            btn4_2.BackColor = Color.Transparent;
            btn4_3.BackColor = Color.Transparent;
            btn4_4.BackColor = Color.Transparent;
            btn5_1.BackColor = Color.Transparent;
            btn5_2.BackColor = Color.Transparent;
            btn5_3.BackColor = Color.Transparent;
            btn5_4.BackColor = Color.Transparent;
            btn6_1.BackColor = Color.Transparent;
            btn6_2.BackColor = Color.Transparent;
            btn6_3.BackColor = Color.Transparent;
            btn6_4.BackColor = Color.Transparent;
            btn7_1.BackColor = Color.Transparent;
            btn7_2.BackColor = Color.Transparent;
            btn7_3.BackColor = Color.Transparent;
            btn7_4.BackColor = Color.Transparent;
            btn8_1.BackColor = Color.Transparent;
            btn8_2.BackColor = Color.Transparent;
            btn8_3.BackColor = Color.Transparent;
            btn8_4.BackColor = Color.Transparent;
            btn9_1.BackColor = Color.Transparent;
            btn9_2.BackColor = Color.Transparent;
            btn9_3.BackColor = Color.Transparent;
            btn9_4.BackColor = Color.Transparent;
            btn10_1.BackColor = Color.Transparent;
            btn10_2.BackColor = Color.Transparent;
            btn10_3.BackColor = Color.Transparent;
            btn10_4.BackColor = Color.Transparent;
            

            ChangeTab(tabControl, -16);
        }       

        /*----------------------------------------------------------------------------------------------------------------------------*/
    }
}
    
