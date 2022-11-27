using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteBuscador.util
{
    public class Utils
    {
        public static int findNthOccur(String str,
                    char ch, int N)
        {
            int occur = 0;

            // Loop to find the Nth
            // occurrence of the character
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == ch)
                {
                    occur += 1;
                }
                if (occur == N)
                    return i;
            }
            return -1;
        }
        public static string getBetween(string strSource, string strStart, string strEnd)
        {
            if (strSource.Contains(strStart) && strSource.Contains(strEnd))
            {
                int Start, End;
                Start = strSource.IndexOf(strStart, 0) + strStart.Length;
                End = strSource.IndexOf(strEnd, Start);
                return strSource.Substring(Start, End - Start);
            }

            return "";
        }

    }
}
