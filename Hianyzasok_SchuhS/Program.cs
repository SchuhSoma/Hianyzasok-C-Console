using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Hianyzasok_SchuhS
{
    class Program
    {
        static List<Hianyzasok> HianyzasokList;
        static int Datum;
        static List<string> OsztalyokList;
        static Dictionary<string, int> Statisztika;
        static void Main(string[] args)
        {
            Console.WriteLine("\n-----------------------------------------\n");
            Feladat1Beolvasa();
            Console.WriteLine("\n-----------------------------------------\n");
            Feladat2SzumMulasztas();
            Console.WriteLine("\n-----------------------------------------\n");
            Feladat3Hianyzo();
            Console.WriteLine("\n-----------------------------------------\n");
            Feladat5AdottNap();
            Console.WriteLine("\n-----------------------------------------\n");
            Feladat6HianyzasStatisztika();
            Console.WriteLine("\n-----------------------------------------\n");
            Console.ReadKey();

        }

        private static void Feladat6HianyzasStatisztika()
        {
            Console.WriteLine("6.Feladat: Osztályok statisztikája ");
            var sw = new StreamWriter(@"osszesites.csv", false, Encoding.UTF8);
            OsztalyokList = new List<string>();
            Statisztika = new Dictionary<string, int>();
            foreach (var h in HianyzasokList)
            {
                if(!OsztalyokList.Contains(h.Osztaly))
                {
                    OsztalyokList.Add(h.Osztaly);
                }
            }
            OsztalyokList.Sort();            
            foreach (var o in OsztalyokList)
            {
                int db = 0;
                foreach (var h in HianyzasokList)
                {
                    if(o==h.Osztaly)
                    {
                        db++;
                    }
                }
                if(!Statisztika.Keys.Contains(o))
                {
                    Statisztika.Add(o, db);
                }
            }
            foreach (var s in Statisztika)
            {
                Console.WriteLine("{0}:{1}",s.Key,s.Value);
                sw.WriteLine("{0};{1}", s.Key, s.Value);
            }
            sw.Close();
        }

        private static void Feladat5AdottNap()
        {
            Console.WriteLine("5.Feldat: A korábban megadott napon volt/voltak Hiányzók?");
            int Szamlalo = 0;
            while (Szamlalo<HianyzasokList.Count && Datum==HianyzasokList[Szamlalo].ElsoNap)
            {
                Szamlalo++;
            }
            if (Szamlalo == HianyzasokList.Count)
            {
                Console.WriteLine("\tNem volt az adott napon hiányzó");
            }
            else
            {
                foreach (var h in HianyzasokList)
                {
                    if (Datum == h.ElsoNap)
                    {
                        Console.WriteLine("\tHiányzó neve: {0,-20} osztálya: {1} ", h.Nev, h.Osztaly);
                    }
                }
            }    
        }

        private static void Feladat3Hianyzo()
        {
            Console.WriteLine("3.Feladat: Adott napon hiányzó diák adatai");  
            eleje:
            Console.Write("\tKérem adjon meg egy napot 1-je és 30-a között: ");
            Datum= int.Parse(Console.ReadLine());
            if(1<=Datum && Datum<=30)
            {
                Feladat4();
            }
            else
            {
                Console.WriteLine("\tHibás dátumot adott meg");
                goto eleje;
            }            
        }

        private static void Feladat4()
        {
            Console.Write("\tKérem adja meg a diák nevét akit keres: ");
            string Hianyzo = Console.ReadLine();
            Console.WriteLine("\n-----------------------------------------\n");
            Console.WriteLine("\n4.Feladat: Az dott diák hiányzott-e?");
            int Szamlalo = 0;
            while (Szamlalo < HianyzasokList.Count && Hianyzo.ToLower() != HianyzasokList[Szamlalo].Nev.ToLower() )
            {
                Szamlalo++;
            }
            if (Szamlalo == HianyzasokList.Count)
            {
                Console.WriteLine("\tAz Ön által keresett diák nem hiányzott szeptemberben");
            }
            else
            {
                Console.WriteLine("\tAz Ön által keresett diák hiányzott szeptemberben");
            }
        }

        private static void Feladat2SzumMulasztas()
        {
            Console.WriteLine("2.Feladat: Mulasztások száma");
            int OsszesMulasztas =0;
            foreach (var h in HianyzasokList)
            {
                OsszesMulasztas += h.MulasztottOrak;
            }
            Console.WriteLine("\n\tAz összes mulasztott órák száma: {0} óra", OsszesMulasztas);
        }

        private static void Feladat1Beolvasa()
        {
            Console.WriteLine("1.Feladat: Adatok beolvasása");
            HianyzasokList = new List<Hianyzasok>();
            var sr = new StreamReader(@"szeptember.txt", Encoding.UTF8);
            int db = 0;
            while(!sr.EndOfStream)
            {
                HianyzasokList.Add(new Hianyzasok(sr.ReadLine()));
                db++;
            }
            sr.Close();
            if(db>0)
            {
                Console.WriteLine("\n\tSikeres beolvasás\n\tBeolvasott sorok száma: {0}", db);
            }
            else
            {
                Console.WriteLine("\nSikertelen beolvasás");
            }
        }
    }
}
