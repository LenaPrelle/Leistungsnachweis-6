using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kniffel
{
    public partial class Form1 : Form
    {
        private Random wuerfel = new Random();  //imaginärer Würfel wird erstellt

        //Variablen für die Häufigkeit der Würfe
        int eins = 0;   
        int zwei = 0;
        int drei = 0;
        int vier = 0;
        int fünf = 0;
        int sechs = 0;

        public Form1()
        {
            InitializeComponent();
        }


        private int holeZahl()  //Zufallzahl ermitteln
        {
            int wurf = wuerfel.Next(1,7);   //nur Zahlen von 1 bis 6
            return wurf;    
        }


        private string holeZahltext(int zahl)   //Zufallzahl wird in string umgewandelt
        {
            string zufallszahl_string = "";

            if (zahl == 1)
            {
                zufallszahl_string = "eins";
            }

            else if (zahl == 2)
            {
                zufallszahl_string = "zwei";
            }

            else if (zahl == 3)
            {
                zufallszahl_string = "drei";
            }

            else if (zahl == 4)
            {
                zufallszahl_string = "vier";
            }

            else if (zahl == 5)
            {
                zufallszahl_string = "fünf";
            }

            else
            {
                zufallszahl_string = "sechs";
            }

            return zufallszahl_string;
        }


        private void button_würfeln_Click(object sender, EventArgs e)   //wird beim Clicken des Buttons ausgeführt
        {
            int zufallszahl_int = holeZahl();   //Zufallszahl wird gezogen
            zeigeListe(zufallszahl_int);    //Anzeige der Häufigkeiten, der Zahlen
            anzeigeWurf(zufallszahl_int);   //Zeichnet die Punkte für die aktuelle Zahl
        }


        private void zeigeListe(int zahl)   //Häufigkeiten der Zahlen wird aktualisiert
        {
            listBox_gezogene_zahlen.Items.Clear();  //setzt listBox zurück

            //Variablen der Anzahl werden hochgezählt
            if (zahl == 1)
            {
                eins += 1;
            }

            else if (zahl == 2)
            {
                zwei += 1;
            }

            else if (zahl == 3)
            {
                drei += 1;
            }

            else if (zahl == 4)
            {
                vier += 1;
            }

            else if (zahl == 5)
            {
                fünf += 1;
            }

            else
            {
                sechs += 1;
            }

            string zufallszahl_string = holeZahltext(zahl);    //zufallszahl wird in string umgewandelt
            listBox_gezogene_zahlen.Items.Add(zufallszahl_string + " gewürfelt");   //Konsolen Ausgabe
            listBox_gezogene_zahlen.Items.Add("----------");
            listBox_gezogene_zahlen.Items.Add("Eins = " + eins + " mal");
            listBox_gezogene_zahlen.Items.Add("Zwei = " + zwei + " mal");
            listBox_gezogene_zahlen.Items.Add("Drei = " + drei + " mal");            
            listBox_gezogene_zahlen.Items.Add("Vier = " + vier + " mal");
            listBox_gezogene_zahlen.Items.Add("Fünf = " + fünf + " mal");
            listBox_gezogene_zahlen.Items.Add("Sechs = " + sechs + " mal");    
            
        }


        private void anzeigeWurf(int zahl)  //Punkte des aktuellen Würfels zeichnen
        {

            panel_wurf.Refresh();   //Zeichnung wird zurückgesetzt

            Graphics gr = panel_wurf.CreateGraphics();  //Rand des Würfels wird gezeichnet
            Pen p = new Pen(Color.Gray, 3);
            gr.DrawRectangle(p, 0, 0, panel_wurf.Width, panel_wurf.Height);

            //je nach Zufallszahl werden unterschiedliche Punkte gezeichnet
            if (zahl == 1)
            {
                mitte_Punkt();
            }

            else if (zahl == 2)
            {
                links_oben_Punkt();
                rechts_unten_Punkt(); 
            }

            else if (zahl == 3)
            {
                links_oben_Punkt();
                mitte_Punkt();
                rechts_unten_Punkt();
            }

            else if (zahl == 4)
            {
                rechts_oben_Punkt();
                links_oben_Punkt();
                rechts_unten_Punkt();
                links_unten_Punkt();
            }

            else if (zahl == 5)
            {
                rechts_oben_Punkt();
                links_oben_Punkt();
                mitte_Punkt();
                rechts_unten_Punkt();
                links_unten_Punkt();
            }

            else
            {
                rechts_oben_Punkt();
                links_oben_Punkt();
                rechts_mitte_Punkt();
                links_mitte_Punkt();
                rechts_unten_Punkt();
                links_unten_Punkt();
            }
            
        }

        private void links_oben_Punkt()
        {
            Brush farbe = Brushes.Gray;
            float durchmesser = panel_wurf.Height / 5;
            float x_position = Convert.ToSingle((panel_wurf.Width * 0.25) - (durchmesser / 2));
            float y_position =  Convert.ToSingle((panel_wurf.Height * 0.25) - (durchmesser / 2));
            Graphics gr = panel_wurf.CreateGraphics();
            gr.FillEllipse(farbe, x_position, y_position, durchmesser, durchmesser);
        }

        private void rechts_oben_Punkt()
        {
            Brush farbe = Brushes.Gray;
            float durchmesser = panel_wurf.Height / 5;
            float x_position = Convert.ToSingle((panel_wurf.Width *0.75) - (durchmesser / 2));
            float y_position = Convert.ToSingle((panel_wurf.Height * 0.25) - (durchmesser / 2));
            Graphics gr = panel_wurf.CreateGraphics();
            gr.FillEllipse(farbe, x_position, y_position, durchmesser, durchmesser);
        }

        private void rechts_mitte_Punkt()
        {
            Brush farbe = Brushes.Gray;
            float durchmesser = panel_wurf.Height / 5;
            float x_position = Convert.ToSingle((panel_wurf.Width * 0.25) - (durchmesser / 2));
            float y_position = Convert.ToSingle((panel_wurf.Height * 0.5) - (durchmesser / 2));
            Graphics gr = panel_wurf.CreateGraphics();
            gr.FillEllipse(farbe, x_position, y_position, durchmesser, durchmesser);
        }

        private void mitte_Punkt ()
        {
            Brush farbe = Brushes.Gray;
            float durchmesser = panel_wurf.Height / 5;
            float x_position = Convert.ToSingle((panel_wurf.Width * 0.5) - (durchmesser / 2));
            float y_position = Convert.ToSingle((panel_wurf.Height * 0.5) - (durchmesser / 2));
            Graphics gr = panel_wurf.CreateGraphics();
            gr.FillEllipse(farbe, x_position, y_position, durchmesser, durchmesser);
        }

        private void links_mitte_Punkt()
        {
            Brush farbe = Brushes.Gray;
            float durchmesser = panel_wurf.Height / 5;
            float x_position = Convert.ToSingle((panel_wurf.Width * 0.75) - (durchmesser / 2));
            float y_position = Convert.ToSingle((panel_wurf.Height * 0.5) - (durchmesser / 2));
            Graphics gr = panel_wurf.CreateGraphics();
            gr.FillEllipse(farbe, x_position, y_position, durchmesser, durchmesser);
        }

        private void rechts_unten_Punkt()
        {
            Brush farbe = Brushes.Gray;
            float durchmesser = panel_wurf.Height / 5;
            float x_position = Convert.ToSingle((panel_wurf.Width * 0.75) - (durchmesser / 2));
            float y_position = Convert.ToSingle((panel_wurf.Height * 0.75) - (durchmesser / 2));
            Graphics gr = panel_wurf.CreateGraphics();
            gr.FillEllipse(farbe, x_position, y_position, durchmesser, durchmesser);
        }

        private void links_unten_Punkt()
        {
            Brush farbe = Brushes.Gray;
            float durchmesser = panel_wurf.Height / 5;
            float x_position = Convert.ToSingle((panel_wurf.Width * 0.25) - (durchmesser / 2));
            float y_position = Convert.ToSingle((panel_wurf.Height * 0.75) - (durchmesser / 2));
            Graphics gr = panel_wurf.CreateGraphics();
            gr.FillEllipse(farbe, x_position, y_position, durchmesser, durchmesser);
        }
    }
}
