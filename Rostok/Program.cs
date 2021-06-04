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

            Console.ReadKey();
        }
    }
}
