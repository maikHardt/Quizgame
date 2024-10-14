using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Org.BouncyCastle.Crypto.Engines.SM2Engine;

namespace maikhardt_projekt
{
    public class Datenbank
    {
        private MySqlConnection con;


        public Datenbank()
        {
            string conStr = "SERVER=localhost;DATABASE=quiz;UID=root;PASSWORD=''";
            con = new MySqlConnection(conStr);
        }
        public void oeffnen()
        {
            try
            {
                con.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void schliessen()
        {
            if (con != null)
            {
                con.Close();
            }
        }
        public List<Kontinent> getKontinent()
        {
            List<Kontinent> liko = new List<Kontinent>();
            oeffnen();
            MySqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "SELECT * FROM Kontinent;";
            MySqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                liko.Add(
                    new Kontinent(
                        dr.IsDBNull(0) ? -1 : dr.GetInt32(0),
                        dr.IsDBNull(1) ? "" : dr.GetString(1)
                        )
                    );
            }
            dr.Close();
            schliessen();
            return liko;
        }
        public List<Laender> getLaender()
        {
            List<Laender> lila = new List<Laender>();
            oeffnen();
            MySqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "SELECT * FROM laender;";
            MySqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                lila.Add(
                    new Laender(
                        dr.IsDBNull(0) ? -1 : dr.GetInt32(0),
                        dr.IsDBNull(1) ? "" : dr.GetString(1),
                        dr.IsDBNull(2) ? -1 : dr.GetInt32(2)
                        )
                    );
            }
            dr.Close();
            schliessen();
            return lila;
        }
        public List<FrageLaender> getFrageLaender() 
        {
            List<FrageLaender> lifrla = new List<FrageLaender>();
            oeffnen();
            MySqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "SELECT * FROM fragelaender;";
            MySqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                lifrla.Add(
                    new FrageLaender(
                        dr.IsDBNull(0) ? -1 : dr.GetInt32(0),
                        dr.IsDBNull(1) ? "" : dr.GetString(1),
                        dr.IsDBNull(2) ? "" : dr.GetString(2),
                        dr.IsDBNull(3) ? -1 : dr.GetInt32(3),
                        dr.IsDBNull(4) ? -1 : dr.GetInt32(4)                        
                        )
                    );
            }
            dr.Close();
            schliessen();
            return lifrla;
        }
        /*
         * ZU GROß GEDACHT
         * ----------------------------------------------------------------------------------------------------------
        public List<Flaggen> getFlaggen() 
        {
            List<Flaggen> lifl = new List<Flaggen>();
            oeffnen();
            MySqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "SELECT * FROM flaggen";
            MySqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                lifl.Add(
                    new Flaggen(
                        dr.IsDBNull(0) ? -1 : dr.GetInt32(0),
                        dr.IsDBNull(1) ? "" : dr.GetString(1),
                        dr.IsDBNull(2) ? "" : dr.GetString(2),
                        dr.IsDBNull(3) ? -1 : dr.GetInt32(3)
                        )
                    );
            }
            dr.Close();
            schliessen();
            return lifl;
        }
        public List<FrageFlaggen> getFrageFlaggen()
        {
            List<FrageFlaggen> lifrfl = new List<FrageFlaggen>();
            oeffnen();
            MySqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "SELECT * FROM frageflaggen";
            MySqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                lifrfl.Add(
                    new FrageFlaggen(
                        dr.IsDBNull(0) ? -1 : dr.GetInt32(0),
                        dr.IsDBNull(1) ? "" : dr.GetString(1),
                        dr.IsDBNull(2) ? "" : dr.GetString(2),
                        dr.IsDBNull(3) ? "" : dr.GetString(3),
                        dr.IsDBNull(4) ? "" : dr.GetString(4),
                        dr.IsDBNull(5) ? -1 : dr.GetInt32(5)
                        )
                    );
            }
            dr.Close();
            schliessen();
            return lifrfl;
        }
        */
        public List<Hauptstadt> getHauptstadt() 
        {
            List<Hauptstadt> liha = new List<Hauptstadt>();
            oeffnen();
            MySqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "SELECT * FROM hauptstadt;";
            MySqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                liha.Add(
                    new Hauptstadt(
                        dr.IsDBNull(0) ? -1 : dr.GetInt32(0),
                        dr.IsDBNull(1) ? "" : dr.GetString(1),                        
                        dr.IsDBNull(2) ? -1 : dr.GetInt32(2)
                        )
                    );
            }
            dr.Close();
            schliessen();
            return liha;
        }
        public List<FrageHauptstadt> getFrageHauptstadt() {
            List<FrageHauptstadt> lifrha = new List<FrageHauptstadt>();
            oeffnen();
            MySqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "SELECT * FROM fragehauptstadt;";
            MySqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                lifrha.Add(
                    new FrageHauptstadt(
                        dr.IsDBNull(0) ? -1 : dr.GetInt32(0),
                        dr.IsDBNull(1) ? "" : dr.GetString(1),
                        dr.IsDBNull(2) ? -1 : dr.GetInt32(2),
                        dr.IsDBNull(3) ? -1 : dr.GetInt32(3),
                        dr.IsDBNull(4) ? -1 : dr.GetInt32(4)
                        )
                    );
            }
            dr.Close();
            schliessen();
            return lifrha;
        }
        public List<Spieler> getSpieler() {
            List<Spieler> lisp = new List<Spieler>();
            oeffnen();
            MySqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "SELECT * FROM spieler;";
            MySqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                lisp.Add(
                    new Spieler(
                        dr.IsDBNull(0) ? -1 : dr.GetInt32(0),
                        dr.IsDBNull(1) ? "" : dr.GetString(1)                        
                        )
                    );
            }
            dr.Close();
            schliessen();
            return lisp;
        }
        public List<Punkte> getPunkte()
        {
            List<Punkte> lipu = new List<Punkte>();
            oeffnen();
            MySqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "SELECT * FROM punkte;";
            MySqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {  
                string s = dr.IsDBNull(2) ? "" : dr.GetDateTime(2).Day + "." + dr.GetDateTime(2).Month + "." + dr.GetDateTime(2).Year;
                lipu.Add(
                    new Punkte(
                        dr.IsDBNull(0) ? -1 : dr.GetInt32(0),
                        dr.IsDBNull(1) ? -1 : dr.GetInt32(1),
                        Convert.ToDateTime(s),
                        dr.IsDBNull(3) ? -1 : dr.GetInt32(3)
                    )
                );                
            }
            dr.Close();
            schliessen();
            return lipu;
        }
        public void savePunkte(Punkte punkte)
        {
            oeffnen();
            MySqlCommand cmd = con.CreateCommand();
            string s;
            string dat = punkte.PuDate.Year.ToString() // 0000
                + "-" + punkte.PuDate.Month.ToString() // 12
                + "-" + punkte.PuDate.Day.ToString();  // 31
            if (punkte.PuNr != -1)
            {               
                s = string.Format("UPDATE punkte SET PuPunkte = '{0}', PuDate = '{1}', PuSpNr = '{2}' WHERE PuNr = '{3}';", punkte.PuPunkte, dat, punkte.PuSpNr, punkte.PuNr);
            }
            else
            {                
                s = string.Format("INSERT INTO punkte VALUES(NULL, '{0}', '{1}', '{2}');", punkte.PuPunkte, dat, punkte.PuSpNr);
            }

            cmd.CommandText = s;
            cmd.ExecuteNonQuery();
            schliessen();
        }
        public void saveSpieler(string spielername, int spnr)
        {
            oeffnen();
            MySqlCommand cmd = con.CreateCommand();
            string s;
            if (spnr != -1)
            {
                s = string.Format("UPDATE Spieler SET SpName = '{0}' WHERE SpNr = '{1}';", spielername, spnr);

            }
            else
            {
                s = string.Format("INSERT INTO Spieler VALUES(NULL, '{0}');", spielername);
            }

            cmd.CommandText = s;
            cmd.ExecuteNonQuery();
            schliessen();
        }
    }
}
