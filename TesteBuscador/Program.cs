using Newtonsoft.Json;
using System.Collections;
using System.Text;
using System.Web;
using TesteBuscador;
using TesteBuscador.util;

Console.WriteLine("Busque aqui: ");
var busca = Console.ReadLine();


var json = Buscador.BuscaAsync(busca);
Console.WriteLine(json.Result);
//var caracteres_acentuados = new List<char>() { 'á', 'Á', 'à', 'À', 'ã', 'Ã', 'é', 'É', 'ó', 'Ó', 'ô', 'Ô', 'á', 'á', 'á', 'Í', 'ú', 'Ú', 'ç', 'Ç', ' ' };
//var rep_hexa = new Dictionary<string, char>();
//var link = "https://pt.wikipedia.org/wiki/Maring%25C3%25A1&amp;sa=U&amp;ved=2ahUKEwiAia3EhtH7AhUxqZUCHVvvBBsQFnoECAsQAg&amp;usg=AOvVaw2YTqjn51BY5lFTp3MxRtQn";
//link = HttpUtility.UrlDecode(link);

//foreach (var a in caracteres_acentuados)
//{
//	try
//	{
//		rep_hexa.Add(Uri.HexEscape(a), a);
//		Console.WriteLine(Uri.HexEscape(a) + " - " + a);
//	}
//	catch (Exception)
//	{
//	}
//}

//foreach (var key in rep_hexa.Keys)
//{
//	if (link.Contains(key))
//	{
//		if (key == "%C3")
//		{
//			link = link.Replace(key, "á");
//		}
//		link = link.Replace(key, rep_hexa[key].ToString());
//	}
//}
//Console.WriteLine(link);
//Console.WriteLine(HttpUtility.UrlDecode(link));