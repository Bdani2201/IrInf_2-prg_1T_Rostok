using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Rostok
{
    class Program
    {
        static void Main(string[] args)
        {
            //2.
            List<Rost> rostok = new List<Rost>();
            foreach (var sor in File.ReadAllLines("rostok.txt").Skip(1)) rostok.Add(new Rost(sor));

            //3.
            Console.WriteLine($"3. feladat: Élelmiszerek száma: {rostok.Count}");

            //4.
            Console.WriteLine($"4. feladat: Nem 100g-os egység: {rostok.Where(x => x.Egység != "100g").Count()}");

            //5.
            double átlag = rostok
                .Where(x => x.Kategória == "Friss gyümölcsök" && x.Egység == "100g")
                .Average(x => x.RostInGr);
            Console.WriteLine($"5. feladat: Friss gyümölcsök átlagos rosttartalma: {átlag:0.0000}g");

            //6. bekérés
            string s = "";
            do
            {
                Console.Write($"6. feladat: Kérek egy karakterláncot: ");
                s = Console.ReadLine();
            } while (s.Length < 2);

            //6. szűrés
            List<Rost> szűrt = rostok.Where(x => x.Név.ToLower().Contains(s.ToLower())).ToList();
            if (szűrt.Count == 0)
                Console.WriteLine($"6. feldat: A keresés eredménytelen!");
            else
                szűrt.ForEach(x => Console.WriteLine($"\t{x.Név} @ {x.Kategória} @ {x.Egység} @ {x.RostInGr}"));

            //7.
            /* A .Select(x => x.Kategória)-ra azért van szükség, hogy egy egyszerű string-ekből álló
             * listát kajunk, mert a Distinct() csak ilyeneket tud összehasonlítani. A másik lehetőség, hogy
             * saját comparer osztályt készítünk, amivel két Rost típusú objektumot össze tudunk hasonlítani.
             * Lásd: RostComparerByCategory class. Bővebben: https://dotnettutorials.net/lesson/linq-distinct-method/
             */
            //Select-el egyszerű string enumerable, majd Distinct(), végül Count():
            Console.WriteLine($"7. feladat: Kategóriák száma: {rostok.Select(x => x.Kategória).Distinct().Count()}");

            //Comparer class használatával:
            RostComparerByCategory rc = new RostComparerByCategory();
            Console.WriteLine($"7. feladat: Kategóriák száma: {rostok.Distinct(rc).Count()}");

            //GroupBy()-al, működik, de nem túl szerencsés módszer:
            Console.WriteLine($"7. feladat: Kategóriák száma: {rostok.GroupBy(x => x.Kategória).Select(gr => gr.First()).Count()}");

            //8.
            Console.WriteLine($"8. feladat: Statisztika");
            rostok
                .GroupBy(x => x.Kategória)
                .Select(gr => new { Kategória = gr.Key, db = gr.Count() })
                //.OrderBy(x => x.db)
                .ToList()
                .ForEach(x => Console.WriteLine($"\t {x.Kategória} - {x.db}"));

            //9.
            Console.WriteLine($"9. feladat: Rostok100g.txt");
            string filename = "Rostok100g.txt";
            List<string> sorok = new List<string>();
            sorok.Add("Megnevezés;Kategória;Rost");
            rostok
                .Where(x => x.Egység == "100g")
                .ToList()
                .ForEach(x => sorok.Add($"{x.Név};{x.Kategória};{x.RostInGr}"));
            File.WriteAllLines(filename, sorok);

            Console.ReadKey();
        }
    }
}
