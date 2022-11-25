using System.Net.Http.Headers;

namespace TesteBuscador
{
    public class Buscador
    {
        static HttpClient client = new HttpClient();

        public static async Task<string> GetHtmlAsync(string strABuscar)
        {
            client.BaseAddress = new Uri($"https://www.google.com/search?q={strABuscar}");
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

    }
}
