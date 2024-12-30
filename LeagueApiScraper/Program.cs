using System;
using System.Collections.Generic;

namespace LeagueApiScraper
{
    class Program
    {
        static void Main(string[] args)
        {
            List<(string, string)> players = new List<(string, string)>
            {
                ("skrtskrt","2433"),
                ("TheRealTrey","NA1"),
                ("Quodge","NA1"),
                ("metaknight", "8388"),
                ("ycalvez", "3302"),
                ("SperrysRLife1776", "8588"),
                ("benslowcal", "1578"),
                ("buschhh", "7715"),
                ("sluggo", "8604")


            };

            Dictionary<string, int> totalGames = new Dictionary<string, int>();
            /*PlayerHandler q1 = new PlayerHandler("skrtskrt", "2433", "RGAPI-5d28caf7-6f5a-4177-94da-8d2ac1a8949d");
            Console.WriteLine($"Player: {q1.accountInfo.gameName}#{q1.accountInfo.tagLine}");
            DateTime target1 = new DateTime(2024, 1, 1);
            List<GameInfo> allGames1 = q1.GetAllSrGamesFromStartDate(target1, q1.apiKey);
            Console.WriteLine(allGames1.Count);
            Participant max1 = StatHandler.GetMaxStats(allGames1, q1.accountInfo.puuid);
            Participant min1 = StatHandler.GetMinStats(allGames1, q1.accountInfo.puuid);
            CsvWriter writer1 = new CsvWriter();
            writer1.WriteMinMaxStats(min1, max1, "skrtskrt");
            Console.WriteLine("Done");*/

            foreach((string, string) player in players)
            {
                PlayerHandler q = new PlayerHandler(player.Item1, player.Item2, "RGAPI-61cf561c-e4ae-46c2-aaa2-cd102c3c303c");
                Console.WriteLine($"Player: {q.accountInfo.gameName}#{q.accountInfo.tagLine}");
                DateTime target = new DateTime(2024, 1, 1);
                List<GameInfo> allGames = q.GetAllSrGamesFromStartDate(target, q.apiKey);
                Console.WriteLine(allGames.Count);
                Participant maxStats = StatHandler.GetMaxStats(allGames, q.accountInfo.puuid);
                Participant minStats = StatHandler.GetMinStats(allGames, q.accountInfo.puuid);
                CsvWriter writer = new CsvWriter();
                writer.WriteMinMaxStats(minStats, maxStats, player.Item1);
                totalGames.Add(player.Item1, allGames.Count);
            }

            foreach(string player in totalGames.Keys)
            {
                Console.WriteLine($"{player}:{totalGames[player]}");
            }
        }
    }
}
