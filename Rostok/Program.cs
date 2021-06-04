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

            Console.ReadKey();
        }
    }
}
