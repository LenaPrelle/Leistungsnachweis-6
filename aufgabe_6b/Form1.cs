using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/** Dieses Programm überprüft die Nutzereingabe in textBox1. Es dürfen Ziffern, Kommas, Punkte, Plus und Minus 
    enthalten sein.
    Plus und Minus dürfen nur an 1. Position stehen. Dahinter darf nur eine Ziffer folgen.
    Kommas und Punkte dürfen nicht doppelt vorkommen und dürfen weder an 1. noch an letzter Stelle stehen.
    Buchstaben, Leerzeichen und andere Sonderzeichen sind nicht erlaubt.
 **/

namespace aufgabe_6b
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string benutzereingabe = textBox1.Text;
            bool istGueltig = PruefeEingabe(benutzereingabe);
            if (istGueltig == true)
            {
                label1.Text = "Gültig";
            }
            else
            {
                label1.Text = "Ungültig";
            }
        }

        private bool PruefeEingabe(string eingabe)
        {
            if (string.IsNullOrEmpty(eingabe)) return false; // Leere Eingabe.
            if (ErlaubteZeichen(eingabe) == false) return false; // Buchstaben, Sonderzeichen und Leerzeichen ausschließen.
            if (PruefeZweiteStelle(eingabe) == false) return false; // Falls die 1. Stelle + oder - ist.
            if (PruefeKommasUndPunkte(eingabe) == false) return false; // Position und Anzahl der Kommas/Punkte
            if (PruefePlusMinusPosition(eingabe) == false) return false; // + und - nur an 1. Stelle
            // Alle Prüfungen bestanden
            return true;
        }

        private bool ErlaubteZeichen(string eingabe) 
        {
            foreach (char c in eingabe)

            {   // Wenn das Zeichen weder eine Ziffer, noch Plus/Minus/Punkt/Komma ist:
                if (!(char.IsDigit(c) || c == '+' || c == '-' || c == '.' || c == ','))
                {
                    return false; 
                }
            }
            return true;
        }

        private bool PruefeKommasUndPunkte(string eingabe)
        {
            eingabe = ErsetzeKommasMitPunkten(eingabe); // Ab hier müssen nur noch Punkte geprüft werden.

            // 1. und letzte Stelle darf kein Punkt sein.
            if (eingabe.StartsWith(".") || eingabe.EndsWith("."))
            {
                return false;
            }
            // Es darf höchstens ein Punkt in der Eingabe sein.
            int punktCount = 0;
            foreach (char c in eingabe)
            {
                if (c == '.')
                {
                    punktCount++;
                }
            }
            return punktCount <= 1; // Returns false, wenn mehr als ein Punkt enthalten ist.
        }

        private bool PruefeZweiteStelle(string eingabe) // Die 2. Stelle muss nur bei +/- geprüft werden.
        {
            if (eingabe[0] == '+' || eingabe[0] == '-')
            {
                if (eingabe.Length == 1)
                {
                    return false;      // Eingabe besteht nur aus + / - .
                }

                else if (eingabe.Length > 1)
                {
                    return char.IsDigit(eingabe[1]); // returns true, wenn die zweite Stelle eine Ziffer ist.
                }
            }
            return true;
        }

        private bool PruefePlusMinusPosition(string eingabe)
        {
            for (int i = 1; i < eingabe.Length; i++) // Checkt erst ab der 2. Stelle. Eingabe.Length ist immer
                                                     // 1 größer als Index, daher i < eingabe.Lenght und nicht kleiner gleich.
            {
                 if (eingabe[i] == '+' || eingabe[i] == '-')
                 {
                     return false;
                 }
            }
            return true;
        }

        private string ErsetzeKommasMitPunkten(string eingabe)
        {
            return eingabe.Replace(',', '.');
        }
    }
}
