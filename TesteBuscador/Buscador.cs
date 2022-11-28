using Newtonsoft.Json;
using System.Net.Http.Headers;
using TesteBuscador.model;
using TesteBuscador.util;
using System.Web;

namespace TesteBuscador
{
    public class Buscador
    {
        static HttpClient client = new HttpClient();

        public static async Task<string> GetHtmlAsync(string strABuscar)
        {
            client.BaseAddress = new Uri($"https://www.google.com/search?q={strABuscar}&ie=UTF-8");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            string html = "";
            HttpResponseMessage response = await client.GetAsync(client.BaseAddress);
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Conseguiu uma resposta");
                html = await response.Content.ReadAsStringAsync();

                return html;
            }
            return html;
        }

        public static async Task<string> BuscaAsync(string busca)
        {
            string html = await GetHtmlAsync(busca);

            Resultado resul = new Resultado();
            resul.Resultados = new List<ResultadoPesquisa>();

            trataString(resul, html);
            

            var json = JsonConvert.SerializeObject(resul);
            return json;
        }

        private static void trataString(Resultado resul, String html)
        {
            while (html.Contains("<a href=\"/url?q="))
            {

                var str = Utils.getBetween(html, "<a href=\"/url?q=", ">");
                var len = str.Length;
                var link = str.Contains("%") ? str.Substring(0, Utils.findNthOccur(str, '"', 1)) : str.Substring(0, Utils.findNthOccur(str, '&', 1));

                if (link.Contains("&amp"))
                {
                    link = Utils.replaceAccent(link);
                    try
                    {
                        link = link.Substring(0, link.IndexOf("&amp") - 1);

                    }
                    catch (Exception)
                    {

                    }
                }

                string str2;
                try
                {
                    str2 = Utils.getBetween(html, "<a href=\"/url?q=", "</h3>");
                    var h3 = str2.Substring(Utils.findNthOccur(str2, '>', 5) + 1);
                    var novo_h3 = h3.Substring(0, Utils.findNthOccur(h3, '<', 1));

                    if (novo_h3.Contains("&#8211"))
                    {
                        novo_h3 = novo_h3.Replace("&#8211;", "-");
                    }

                    var resultado = new ResultadoPesquisa();
                    resultado.Titulo = novo_h3;
                    resultado.Link = link;

                    if (!resul.Resultados.Contains(resultado) & novo_h3.Length > 3)
                    {
                        if (!link.Equals("https://support.google.com") & !link.Equals("https://accounts.google.com") & !novo_h3.Equals(""))
                        {
                            resul.Resultados.Add(resultado);
                        }
                    }
                }
                catch (Exception)
                {

                }
                html = html.Substring(html.IndexOf(">") + len);
            }
        }
    }
}
