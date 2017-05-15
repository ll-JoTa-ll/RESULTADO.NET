using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompleteRange
{
    class Program
    {
        static void Main(string[] args)
        {
            int i_cant_array = 0;

            Console.WriteLine("\n\tPROBLEMA 2");

            Console.Write("\nIngrese la cantidad de numeros: ");
            i_cant_array = Convert.ToInt32(Console.ReadLine());

            int[] array_numeros = new int[i_cant_array];

            for (int i = 0; i < i_cant_array; i++)
            {
                int i_valor = 0;
                Console.Write("\nIngrese posicion " + (i + 1) + ": ");
                i_valor = Convert.ToInt32(Console.ReadLine());
                array_numeros[i] = i_valor;
            }

            Array.Sort(array_numeros);

            CompleteRange o_CompleteRange = new CompleteRange();

            string s_resultado = o_CompleteRange.build(array_numeros);

            Console.WriteLine("\nResultado: " + s_resultado);

            Console.Read();
        }
    }
}