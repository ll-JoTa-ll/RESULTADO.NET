using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChangeString
{
    public class ChangeString
    {
        public char[] build(string p_texto)
        {
            char[] b = new char[p_texto.Length];

            using (StringReader sr = new StringReader(p_texto))
            {
                sr.Read(b, 0, p_texto.Length);

                for (int i = 0; i < b.Length; i++)
                {
                    string s_letra = b[i].ToString();
                    int i_ascii = Encoding.ASCII.GetBytes(s_letra)[0];
                    if (i_ascii == 63 || (i_ascii >= 97 && i_ascii <= 122))
                    {
                        if (i_ascii == 63)
                        {
                            i_ascii = Encoding.ASCII.GetBytes("o")[0];
                            b[i] = Convert.ToChar(i_ascii);
                        }
                        else if (i_ascii == 110)
                        {
                            i_ascii = 63;
                            b[i] = 'ñ';
                        }
                        else if (i_ascii == 122)
                        {
                            i_ascii = 97;
                            b[i] = Convert.ToChar(i_ascii);
                        }
                        else
                        {
                            i_ascii++;
                            b[i] = Convert.ToChar(i_ascii);
                        }
                    }
                }

                return b;
            }
        }
    }
}
