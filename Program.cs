using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace ConsoleApp3
{
    public class Ljudi
    {
        private string Ime_Prezime;
        private char Pol;
        private int Visina;
        private int Telesna_masa;
        private int Obim_struka;
        private int Obim_Kuka;
        private int Obim_vrata;


        public string Ime_Prezime1 { get => Ime_Prezime; set => Ime_Prezime = value; }
        public char Pol1 { get { return Pol; } set => Pol = value; }
        public int Visina1 { get => Visina; set => Visina = value; }
        public int Telesna_masa1 { get => Telesna_masa; set => Telesna_masa = value; }
        public int Obim_struka1 { get => Obim_struka; set => Obim_struka = value; }
        public int Obim_Kuka1 { get => Obim_Kuka; set => Obim_Kuka = value; }
        public int Obim_vrata1 { get => Obim_vrata; set => Obim_vrata = value; }



        public Ljudi(string Ime_Prezime, char Pol, int Visina, int Telesna_masa, int Obim_struka, int Obim_Kuka, int Obim_vrata)
        {
            this.Ime_Prezime1 = Ime_Prezime;
            this.Pol1 = Pol;
            this.Visina1 = Visina;
            this.Telesna_masa1 = Telesna_masa;
            this.Obim_struka1 = Obim_struka;
            this.Obim_Kuka1 = Obim_Kuka;
            this.Obim_vrata1 = Obim_vrata;
        }
        public override string ToString()
        {
            return "Ljudi: " + Ime_Prezime1 + " " + Pol1 + " " + Visina1 + " " + Telesna_masa1 + " " + Obim_struka1 + " " + Obim_Kuka1 + " " + " " + Obim_vrata1;
        }
        public double Procenat_masti()
        {
            if (this.Pol1 == 'F')
            {
                return 495 / (1.29579 - 0.35004 * Math.Log10(this.Obim_struka1 + this.Obim_Kuka1 - this.Obim_vrata1) + 0.22100 * Math.Log10(this.Visina1)) - 450;
            }
            else
            {
                return 495 / (1.0324 - .19077 * Math.Log10(this.Obim_struka1 - this.Obim_vrata1) + 0.15456 * Math.Log10(this.Visina1)) - 450;
            }
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            Ljudi Osoba1 = new Ljudi("Jovana Blagojevic", 'F', 158, 50, 80, 68, 20);
            Ljudi Osoba2 = new Ljudi("Olja Nikolasev", 'F', 177, 65, 80, 66, 19);
            Ljudi Osoba3 = new Ljudi("Strahinja Devic", 'M', 198, 90, 100, 75, 40);
            Ljudi Osoba4 = new Ljudi("Filip Petric", 'M', 180, 70, 77, 65, 32);
            ArrayList lista = new ArrayList();
            lista.Add(Osoba1);
            lista.Add(Osoba2);
            lista.Add(Osoba3);
            lista.Add(Osoba4);
            foreach (Ljudi osoba in lista)
            {
                Console.WriteLine(osoba.ToString());
            }


            double sum = 0;


            int brojMuski = 0;
            int brojZenski = 0;
            
            double sumaMastiMuski = 0;
            double sumaMastiZenski = 0;
            
            Ljudi osobaSaNajviseMasti = null;
            Ljudi osobaSaNajmanjeMasti = null;



            foreach (Ljudi osoba in lista)
            {
                double procenatMasti = osoba.Procenat_masti();

                if (osoba.Pol1 == 'F')
                {
                    brojZenski++;
                    sumaMastiZenski += osoba.Procenat_masti();
                   
                }
                else
                {
                    brojMuski++;
                    sumaMastiMuski += osoba.Procenat_masti();
                }

                if (osobaSaNajviseMasti ==null)
                {
                    osobaSaNajviseMasti = osoba;
                }
                else if(osobaSaNajviseMasti.Procenat_masti() < osoba.Procenat_masti())
                {
                    osobaSaNajviseMasti = osoba;
                }

                if (osobaSaNajmanjeMasti == null)
                {
                    osobaSaNajmanjeMasti = osoba;
                }
                else if (osobaSaNajmanjeMasti.Procenat_masti() > osoba.Procenat_masti())
                {
                    osobaSaNajmanjeMasti = osoba;
      
                }
            }


            int ukupanBrojOosba = brojMuski + brojZenski;
            double ukupnaMast = sumaMastiMuski + sumaMastiZenski;

            Console.WriteLine("Ukupni prosek masti:" + ukupnaMast/ukupanBrojOosba);
            Console.WriteLine("Ukupni prosek masti zene:" + sumaMastiZenski / brojZenski);
            Console.WriteLine("Ukupni prosek masti muskarci:" + sumaMastiMuski / brojMuski);


            Console.WriteLine("Osoba sa najmanje " + osobaSaNajmanjeMasti.Ime_Prezime1 + " mast: " + osobaSaNajmanjeMasti.Procenat_masti());
            Console.WriteLine("Osoba sa najvise: " + osobaSaNajviseMasti.Ime_Prezime1 + " mast: " + osobaSaNajviseMasti.Procenat_masti());


          
        }
    }
}
