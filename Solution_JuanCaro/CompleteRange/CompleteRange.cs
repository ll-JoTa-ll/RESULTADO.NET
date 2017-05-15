using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompleteRange
{
    public class CompleteRange
    {
        public string build(int[] p_array_numeros)
        {
            string s_resultado = "";

            int i_inicio = 0;
            foreach (var item in p_array_numeros)
            {
                if (item != 1)
                {
                    for (int i = i_inicio; i < item; i++)
                    {
                        s_resultado += (i + 1).ToString() + ", ";
                    }
                }
                else
                {
                    s_resultado += item.ToString() + ", ";
                }
                i_inicio = item;
            }

            return s_resultado;
        }
    }
}
