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
