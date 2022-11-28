using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace APITesteDevAtak.util
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

        public static string replaceAccent(string str)
        {
            var caracteres_acentuados = new List<char>() { 'á', 'Á', 'à', 'À', 'ã', 'Ã', 'é', 'É', 'ó', 'Ó', 'ô', 'Ô', 'á', 'á', 'á', 'Í', 'ú', 'Ú', 'ç', 'Ç', ' ' };
            var rep_hexa = new Dictionary<string, char>();
            str = HttpUtility.UrlDecode(str);

            foreach (var a in caracteres_acentuados)
            {
                try
                {
                    rep_hexa.Add(Uri.HexEscape(a), a);
                }
                catch (Exception)
                {
                }
            }

            foreach (var key in rep_hexa.Keys)
            {
                if (str.Contains(key))
                {
                    if (key == "%C3")
                    {
                        str = str.Replace(key, "á");
                    }
                    str = str.Replace(key, rep_hexa[key].ToString());
                }
            }
            return HttpUtility.UrlDecode(str);
        }

    }
}
