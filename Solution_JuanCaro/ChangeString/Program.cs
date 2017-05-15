using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChangeString
{
    class Program
    {
        static void Main(string[] args)
        {
            string s_texto = "";

            Console.WriteLine("\n\tPROBLEMA 1");

            Console.Write("\nIngrese texto: ");
            s_texto = Console.ReadLine().ToString();

            ChangeString o_ChangeString = new ChangeString();

            var s_nuevo_texto = o_ChangeString.build(s_texto);

            Console.Write("\nResultado: ");
            Console.WriteLine(s_nuevo_texto);

            Console.ReadLine();
        }
    }
}
