using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace LeagueApiScraper
{
    class PlayerHandler
    {
        public AccountDto accountInfo;
        public string apiKey;

        public PlayerHandler(string gameName, string tag, string apiKey)
        {
            this.apiKey = apiKey;
            string baseUrl = $"https://americas.api.riotgames.com/riot/account/v1/accounts/by-riot-id/";
            string accountUrl = $"{baseUrl}{gameName}/{tag}?api_key={apiKey}";
            accountInfo = ApiHandler.GetRequest<AccountDto>(accountUrl);
        }

        public List<GameInfo> GetAllGames(string apiKey)
        {
            List<GameInfo> allGames = new List<GameInfo>();
            long currentEndDate = -1;

            while(true)
            {
                List<GameInfo> currentGames = new List<GameInfo>();

                if (currentEndDate == -1)
                {
                    currentGames.AddRange(GetGames(400, 100, apiKey));
                    currentGames.AddRange(GetGames(420, 100, apiKey));
                    currentGames.AddRange(GetGames(440, 100, apiKey));
                }
                else
                {
                    currentGames.AddRange(GetGames(Utility.ConvertFromUnixTimestamp(currentEndDate), 400, 100, apiKey));
                    currentGames.AddRange(GetGames(Utility.ConvertFromUnixTimestamp(currentEndDate), 420, 100, apiKey));
                    currentGames.AddRange(GetGames(Utility.ConvertFromUnixTimestamp(currentEndDate), 440, 100, apiKey));
                }

                if(currentGames.Count <= 0)
                {
                    break;
                }

                List<GameInfo> sortedGames = currentGames.OrderByDescending(game => game.info.gameEndTimestamp).ToList();
                GameInfo earliestInList = sortedGames.Last();

                currentEndDate = (long)Math.Floor((double)earliestInList.info.gameEndTimestamp / 1000);
                allGames.AddRange(sortedGames);
            }

            return allGames;
        }

        public List<GameInfo> GetAllGamesFromStartDate(DateTime startDate, int queueType, string apiKey)
        {
            List<GameInfo> allGames = new List<GameInfo>();
            List<string> allGameIds = new List<string>();
            long currentEndDate = -1;
            Console.WriteLine($"Getting games of queue type {queueType}");

            while (true)
            {

                List<GameInfo> currentGames = new List<GameInfo>();

                if (currentEndDate > 0 && currentEndDate <= Utility.ConvertToUnixTimestamp(startDate))
                {
                    break;
                }

                if (currentEndDate == -1)
                {
                    currentGames.AddRange(GetGames(queueType, 100, apiKey));
                }
                else
                {
                    currentGames.AddRange(GetGames(startDate, Utility.ConvertFromUnixTimestamp(currentEndDate), queueType, 100, apiKey));
                }

                if (currentGames.Count > 1)
                {
                    List<GameInfo> sortedGames = currentGames.OrderByDescending(game => game.info.gameEndTimestamp).ToList();
                    GameInfo earliestInList = sortedGames.Last();
                    currentEndDate = (long)Math.Floor((double)earliestInList.info.gameEndTimestamp / 1000);
                    allGames.AddRange(sortedGames);
                }
                else
                {
                    allGames.AddRange(currentGames);
                    break;
                }
            }

            Console.WriteLine($"Found {allGames.Count} games for queue type {queueType}");

            return allGames;
        }
        public List<GameInfo> GetAllSrGamesFromStartDate(DateTime startDate, string apiKey)
        {
            List<GameInfo> allGames = new List<GameInfo>();
            allGames.AddRange(GetAllGamesFromStartDate(startDate, 400, apiKey));
            allGames.AddRange(GetAllGamesFromStartDate(startDate, 420, apiKey));
            allGames.AddRange(GetAllGamesFromStartDate(startDate, 440, apiKey));

            return allGames;
        }
       
        public List<GameInfo> GetRecentGames(int queueType, int numGames, string apiKey)
        {
            List<GameInfo> recentGames = new List<GameInfo>();

            int remainder;
            int quotient = Math.DivRem(numGames, 100, out remainder);
            long currentEndDate = -1;

            for (int i = 1; i <= quotient; i++)
            {
                if (currentEndDate == -1)
                {
                    recentGames.AddRange(GetGames(queueType, 100, apiKey));
                }
                else
                {
                    recentGames.AddRange(GetGames(Utility.ConvertFromUnixTimestamp(currentEndDate), queueType, 100, apiKey));
                }

                List<GameInfo> sortedGames = recentGames.OrderByDescending(game => game.info.gameEndTimestamp).ToList();
                GameInfo earliestInList = sortedGames.Last();

                currentEndDate = (long)Math.Floor((double)earliestInList.info.gameEndTimestamp / 1000);
            }

            recentGames.AddRange(GetGames(Utility.ConvertFromUnixTimestamp(currentEndDate), queueType, remainder, apiKey));

            return recentGames;
        }

        public List<GameInfo> GetSrGames(DateTime startDate, DateTime endDate, int maxGames, string apiKey)
        {
            List<GameInfo> result = new List<GameInfo>();

            result.AddRange(GetGames(startDate, endDate, 400, maxGames, apiKey));
            result.AddRange(GetGames(startDate, endDate, 420, maxGames, apiKey));
            result.AddRange(GetGames(startDate, endDate, 440, maxGames, apiKey));

            return result;
        }

        public List<GameInfo> GetGames(DateTime startDate, DateTime endDate, int queueType, int maxGames, string apiKey) //maxGames: 0-100, Start date: June 16th 2021, queueTypes: 400 - draft, 420 - soloranked, 440 - flex ranked, 450 - aram, 325 - maybe bridge of progress??
        {
            List<GameInfo> result = new List<GameInfo>();

            string baseMatchesUrl = "https://americas.api.riotgames.com/lol/match/v5/matches/by-puuid/";
            string finalMatchesUrl = $"{baseMatchesUrl}{accountInfo.puuid}/ids?" +
                $"startTime={Utility.ConvertToUnixTimestamp(startDate)}" +
                $"&endTime={Utility.ConvertToUnixTimestamp(endDate)}" +
                $"&queue={queueType}" +
                $"&count={maxGames}" +
                $"&api_key={apiKey}";

            List<string> gameIds = (List<string>)ApiHandler.GetRequest<IList<string>>(finalMatchesUrl);

            foreach(string gameId in gameIds)
            {
                bool retry = true;
                Retry:
                string baseGameUrl = "https://americas.api.riotgames.com/lol/match/v5/matches/";
                string finalGameUrl = $"{baseGameUrl}{gameId}?api_key={apiKey}";

                GameInfo info = ApiHandler.GetRequest<GameInfo>(finalGameUrl);

                if(info.info != null)
                {
                    result.Add(info);
                }
                else
                {
                    Console.WriteLine(gameId);
                    if(retry)
                    {
                        retry = false;
                        Console.WriteLine($"Retrying:{gameId}");
                        goto Retry;
                    }
                }
                
            }
            
            return result;
        }

        public List<GameInfo> GetGames(DateTime endDate, int queueType, int maxGames, string apiKey) //maxGames: 0-100, Start date: June 16th 2021, queueTypes: 400 - draft, 420 - soloranked, 440 - flex ranked, 450 - aram, 325 - maybe bridge of progress??
        {
            List<GameInfo> result = new List<GameInfo>();

            string baseMatchesUrl = "https://americas.api.riotgames.com/lol/match/v5/matches/by-puuid/";
            string finalMatchesUrl = $"{baseMatchesUrl}{accountInfo.puuid}/ids?" +
                $"&endTime={Utility.ConvertToUnixTimestamp(endDate)}" +
                $"&queue={queueType}" +
                $"&count={maxGames}" +
                $"&api_key={apiKey}";

            List<string> gameIds = (List<string>)ApiHandler.GetRequest<IList<string>>(finalMatchesUrl);

            foreach (string gameId in gameIds)
            {
                bool retry = true;
                Retry:
                string baseGameUrl = "https://americas.api.riotgames.com/lol/match/v5/matches/";
                string finalGameUrl = $"{baseGameUrl}{gameId}?api_key={apiKey}";

                GameInfo info = ApiHandler.GetRequest<GameInfo>(finalGameUrl);
                if (info.info != null)
                {
                    result.Add(info);
                }
                else
                {
                    Console.WriteLine(gameId);
                    if (retry)
                    {
                        retry = false;
                        Console.WriteLine($"Retrying:{gameId}");
                        goto Retry;
                    }
                }
            }

            return result;
        }

        public List<GameInfo> GetGames(int queueType, int maxGames, string apiKey) //maxGames: 0-100, Start date: June 16th 2021, queueTypes: 400 - draft, 420 - soloranked, 440 - flex ranked, 450 - aram, 325 - maybe bridge of progress??
        {
            List<GameInfo> result = new List<GameInfo>();

            string baseMatchesUrl = "https://americas.api.riotgames.com/lol/match/v5/matches/by-puuid/";
            string finalMatchesUrl = $"{baseMatchesUrl}{accountInfo.puuid}/ids?" +
                $"&queue={queueType}" +
                $"&count={maxGames}" +
                $"&api_key={apiKey}";

            List<string> gameIds = ApiHandler.GetRequest<List<string>>(finalMatchesUrl);

            foreach (string gameId in gameIds)
            {
                bool retry = true;
                Retry:
                string baseGameUrl = "https://americas.api.riotgames.com/lol/match/v5/matches/";
                string finalGameUrl = $"{baseGameUrl}{gameId}?api_key={apiKey}";

                GameInfo info = ApiHandler.GetRequest<GameInfo>(finalGameUrl);
                if (info.info != null)
                {
                    result.Add(info);
                }
                else
                {
                    Console.WriteLine(gameId);
                    if (retry)
                    {
                        retry = false;
                        Console.WriteLine($"Retrying:{gameId}");
                        goto Retry;
                    }
                }
            }

            return result;
        }

        public List<string> GetGameIds(int queueType, int maxGames, string apiKey)
        {
            List<GameInfo> result = new List<GameInfo>();

            string baseMatchesUrl = "https://americas.api.riotgames.com/lol/match/v5/matches/by-puuid/";
            string finalMatchesUrl = $"{baseMatchesUrl}{accountInfo.puuid}/ids?" +
                $"&queue={queueType}" +
                $"&count={maxGames}" +
                $"&api_key={apiKey}";

            List<string> gameIds = ApiHandler.GetRequest<List<string>>(finalMatchesUrl);

            return gameIds;
        }
        public List<string> GetGameIds(DateTime startDate, DateTime endDate, int queueType, int maxGames, string apiKey) //maxGames: 0-100, Start date: June 16th 2021, queueTypes: 400 - draft, 420 - soloranked, 440 - flex ranked, 450 - aram, 325 - maybe bridge of progress??
        {
            List<GameInfo> result = new List<GameInfo>();

            string baseMatchesUrl = "https://americas.api.riotgames.com/lol/match/v5/matches/by-puuid/";
            string finalMatchesUrl = $"{baseMatchesUrl}{accountInfo.puuid}/ids?" +
                $"startTime={Utility.ConvertToUnixTimestamp(startDate)}" +
                $"&endTime={Utility.ConvertToUnixTimestamp(endDate)}" +
                $"&queue={queueType}" +
                $"&count={maxGames}" +
                $"&api_key={apiKey}";

            List<string> gameIds = (List<string>)ApiHandler.GetRequest<IList<string>>(finalMatchesUrl);

            return gameIds;
        }
    }
}
