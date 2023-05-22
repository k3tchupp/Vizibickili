using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vizibickili_prog_ora
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Adat> list = new List<Adat>();

            using (StreamReader sr = new StreamReader("kolcsonzesek.txt"))
            {
                sr.ReadLine();
                while (!sr.EndOfStream)
                {
                    string sor = sr.ReadLine();
                    Adat s = new Adat(sor);
                    list.Add(s);
                }
            }

            List<Atlag> atlaglist = new List<Atlag>();

            foreach (var item in list)
            {
                atlaglist.Add(new Atlag(item.Atvalt(item.EOra, item.EPerc), item.Atvalt(item.VOra, item.VPerc)));
            }

            List<int> vege = new List<int>();
            foreach (var item in atlaglist)
            {
                vege.Add((item.visszavitel - item.elvitel) / 30 * 2400);
            }

            Console.WriteLine($"5. feladat: Napi kölcsönzések száma: {list.Count}");

            Console.Write($"6. feladat: Kérek egy nevet: ");
            string kolcsonzo = Console.ReadLine();
            Console.WriteLine($"\t{kolcsonzo} Kölcsönzései: ");
            if (list.Exists(x => x.nev == kolcsonzo))
            {
                foreach (var item in list.Where(x => x.nev == kolcsonzo))
                {
                    Console.WriteLine($"\t{item.EOra}:{item.EPerc} - {item.VOra}:{item.VPerc}");
                }
            }
            else
            {
                Console.WriteLine("Nem volt ilyen nevú kölcsönző");
            }

            Console.Write("7. feladat: Adjon meg egy időpontot óra:perc alakban: ");
            string oraperc = Console.ReadLine();
            int orabe = Convert.ToInt32(oraperc.Split(':')[0]);
            int percbe = Convert.ToInt32(oraperc.Split(':')[1]);
            Console.WriteLine($"\tA vizen lévő járművek:");
            foreach (var item in list.Where(x => x.EOra <= orabe))
            {
                if (item.EOra != orabe)
                {
                    Console.WriteLine($"\t{item.EOra}:{item.EPerc}-{item.VOra}:{item.VPerc} : {item.nev}");

                }
                else if (item.EPerc < percbe)
                {
                    Console.WriteLine($"\t{item.EOra}:{item.EPerc}-{item.VOra}:{item.VPerc} : {item.nev}");
                }
            }

            Console.WriteLine($"8. feladat: A napi bevétel: {vege.Sum()} Ft");

            foreach (var item in list.GroupBy(x => x.JAzon).OrderBy(x => x.Key))
            {
                Console.WriteLine($"\t{item.Key} - {item.Count()}");
            }


            Console.ReadKey();
        }
    }
}
