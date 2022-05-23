using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _23._05._2022
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        bool JeCislo(string vstup, ref int pocetCifer, ref int soucet)
        {
            pocetCifer = 0;
            soucet = 0;
            for(int i = 0;i < vstup.Length ;i++)
            {
                if(vstup[i] >= '0'&& vstup[i] <='9')
                {
                    pocetCifer++;
                    if(vstup[i] % 2 !=0)
                    {
                        soucet += (vstup[i] - 48);
                    }
                }    
            }
            if (pocetCifer > 0)
            {
                return true;
            }
            return false;
        }

        bool ObsahujeSlovo(string vstup, out string Nejdelsi, out string Nejkratsi)
        {
            Nejdelsi = "";
            string[] slova = vstup.Split();
            Nejkratsi = slova[0];
            while(vstup.Contains("  "))
            {
                vstup = vstup.Replace("  ", " ");
            }
            foreach(string s in slova)
            {
                if(s.Length > Nejdelsi.Length)
                {
                    Nejdelsi = s;
                }
                if(s.Length < Nejkratsi.Length)
                {
                    Nejkratsi = s;
                }
            } 
            if(slova[0] == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int pocetCifer = 0, soucet = 0;
            odpoved.Text = String.Format("Text {0}obsahuje číslo.\nPočet čísel: {1}\nSoučet lychcých čísel: {2}", JeCislo(textBox1.Text, ref pocetCifer, ref soucet) ? "" : "ne",pocetCifer,soucet);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string Nejdelsi, Nejkratsi;
            odpoved2.Text = String.Format("Text {0}obsahuje slovo.\nNejdelší slovo: {1}\nNejkratší slovo: {2}",ObsahujeSlovo(textBox1.Text, out Nejdelsi, out Nejkratsi) ? "" : "ne", Nejdelsi, Nejkratsi);
        }
    }
}
