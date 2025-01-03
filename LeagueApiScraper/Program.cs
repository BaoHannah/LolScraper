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
/*                ("skrtskrt","2433"),
                ("TheRealTrey","NA1"),
                ("Quodge","NA1"),
                ("metaknight", "8388"),
                ("ycalvez", "3302"),
                ("SperrysRLife1776", "8588"),
                ("benslowcal", "1578"),
                ("buschhh", "7715"),
                ("sluggo", "8604"),*/
                ("philmybean", "8588"),
                ("SaladeDLL", "NA1"),
                ("ThatsPr0", "NA1")

            };

            CsvWriter writer = new CsvWriter();
            Dictionary<string, int> totalGames = new Dictionary<string, int>();
            Dictionary<string, Participant> ccScores = new Dictionary<string, Participant>();

            foreach((string, string) player in players)
            {
                PlayerHandler p = new PlayerHandler(player.Item1, player.Item2, "APIKEYHERE");
                Console.WriteLine($"Player: {p.accountInfo.gameName}#{p.accountInfo.tagLine}");
                DateTime target = new DateTime(2024, 1, 1);
                List<GameInfo> allGames = p.GetAllSrGamesFromStartDate(target, p.apiKey);
                Console.WriteLine(allGames.Count);

                //Min Max Stats ---------------------------------------------------------------
                Participant maxStats = StatHandler.GetMaxStats(allGames, p.accountInfo.puuid);
                Participant minStats = StatHandler.GetMinStats(allGames, p.accountInfo.puuid);
                writer.WriteMinMaxStats(minStats, maxStats, player.Item1);

                //Total Stats -----------------------------------------------------------------
                Participant totalStats = StatHandler.GetTotalStats(allGames, p.accountInfo.puuid);
                writer.WriteTotalStats(totalStats, player.Item1);

                //CC Score --------------------------------------------------------------------
                Participant ccStats = StatHandler.GetCcScore(allGames, p.accountInfo.puuid);
                ccScores.Add(player.Item1, ccStats);
                
                totalGames.Add(player.Item1, allGames.Count);
            }

            writer.WriteCcScore(ccScores, "");

            foreach (string player in totalGames.Keys)
            {
                Console.WriteLine($"{player}:{totalGames[player]}");
            }
        }
    }
}
