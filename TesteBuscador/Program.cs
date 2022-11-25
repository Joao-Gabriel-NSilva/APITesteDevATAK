using Newtonsoft.Json;
using TesteBuscador;

Console.WriteLine("Busque aqui: ");
var busca = Console.ReadLine();


string html = await Buscador.GetHtmlAsync(busca);

static int findNthOccur(String str,
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
static string getBetween(string strSource, string strStart, string strEnd)
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

Dictionary<string, string> _lista = new Dictionary<string, string>();


while (html.Contains("<a href=\"/url?q="))
{

    var str = getBetween(html, "<a href=\"/url?q=", ">");
    var len = str.Length;
    var link = str.Contains("%") ? str.Substring(0, findNthOccur(str, '"', 1)) : str.Substring(0, findNthOccur(str, '&', 1));

    string str2;
    try
    {
        str2 = getBetween(html, "<a href=\"/url?q=", "</h3>");
        var h3 = str2.Substring(findNthOccur(str2, '>', 5) + 1);
        var novo_h3 = h3.Substring(0, findNthOccur(h3, '<', 1));

        if(novo_h3.Contains("&#8211"))
        {
            novo_h3 = novo_h3.Replace("&#8211;", "-");
        }

        if (!_lista.ContainsKey(novo_h3))
        {
            if (!link.Equals("https://support.google.com") & !link.Equals("https://accounts.google.com") & !novo_h3.Equals(""))
            {
                _lista.Add(novo_h3, link);
            }
        }
    }
    catch (Exception)
    {

    }
    html = html.Substring(html.IndexOf(">") + len);
}


//foreach (KeyValuePair<string, string> kvp in _lista)
//{
//    Console.WriteLine("Key = {0}, Value = {1}",
//        kvp.Key, kvp.Value);
//}

var c = JsonConvert.SerializeObject(_lista);
Console.WriteLine(c);
