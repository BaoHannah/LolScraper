using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using System.Threading;

namespace LeagueApiScraper
{
    public class ApiHandler
    {
        static int callCount = 0;
        static long lastCall = 0; //last call timestamp in unix epoch time

        public static T GetRequest<T>(string url)
        {
            long currentCall = Utility.ConvertToUnixMilliseconds(DateTime.Now);
            if (currentCall - lastCall <= 50)
            {
                Console.WriteLine("Call was too fast. Waiting for rate limit...");
                Thread.Sleep(1000);
                Console.WriteLine("Resuming...");
            }

            lastCall = Utility.ConvertToUnixMilliseconds(DateTime.Now);

            callCount++;
            if(callCount >= 99)
            {
                Console.WriteLine("Waiting for rate limit...");
                Thread.Sleep(120000);
                callCount = 0;
                Console.WriteLine("Resuming...");
            }

            var handler = new HttpClientHandler();
            handler.ClientCertificateOptions = ClientCertificateOption.Automatic;
            HttpClient client = new HttpClient(handler);

            var request = new HttpRequestMessage()
            {
                RequestUri = new Uri(url),
                Method = HttpMethod.Get,
            };
            request.Headers.Add("User-Agent", "scraper / 0.02");

            var response = client.Send(request);
            var responseString = response.Content.ReadAsStringAsync().Result;
            T result = JsonConvert.DeserializeObject<T>(responseString);

            return result;
        }

        public static GameInfo GetGame(string gameID, string apiKey)
        {
            string url = $"https://americas.api.riotgames.com/lol/match/v5/matches/{gameID}?api_key={apiKey}";
            return GetRequest<GameInfo>(url);
        }
    }
}
