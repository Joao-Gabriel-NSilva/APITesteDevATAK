using System.Net.Http.Headers;

namespace APITesteDevATAK
{
    public class Buscador
    {
        static HttpClient client = new HttpClient();

        public static async Task<string> GetJsonAsync()
        {
            client.BaseAddress = new Uri("https://www.google.com/search?q=teste");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            string json = "";
            HttpResponseMessage response = await client.GetAsync(client.BaseAddress);
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Conseguiu uma resposta");
                json = await response.Content.ReadAsStringAsync();

                return json;
            }
            return json;
        }

    }
}
