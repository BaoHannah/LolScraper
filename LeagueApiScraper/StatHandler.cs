using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace LeagueApiScraper
{
    public static class StatHandler
    {
        public static Participant GetMaxStats(List<GameInfo> games, string trackedPuuid)
        {
            PropertyInfo[] props = typeof(Participant).GetProperties();
            Participant maxStats = new Participant();
            maxStats.challenges = new Challenges();
            maxStats.puuid = trackedPuuid;

            List<Participant> gamePerformances = new List<Participant>();

            foreach(GameInfo game in games)
            {
                foreach(Participant player in game.info.participants)
                {
                    if(player.puuid == trackedPuuid)
                    {
                        gamePerformances.Add(player);
                    }
                }
            }

            foreach(Participant performance in gamePerformances)
            {
                foreach (PropertyInfo prop in props)
                {
                    if(prop.GetValue(performance) != null)
                    {
                        switch (prop.PropertyType)
                        {
                            case var type when type == typeof(int):
                            case var type1 when type1 == typeof(int?):

                                if (prop.GetValue(maxStats) == null || (int)prop.GetValue(performance) > (int)prop.GetValue(maxStats))
                                {
                                    prop.SetValue(maxStats, prop.GetValue(performance));
                                }
                                break;

                            case var type when type == typeof(double):
                            case var type1 when type1 == typeof(double?):

                                if (prop.GetValue(maxStats) == null || (double)prop.GetValue(performance) > (double)prop.GetValue(maxStats))
                                {
                                    prop.SetValue(maxStats, prop.GetValue(performance));
                                }
                                break;

                            case var type when type == typeof(Challenges):

                                PropertyInfo[] challengeProps = typeof(Challenges).GetProperties();
                                foreach (PropertyInfo challengeProp in challengeProps)
                                {
                                    switch (challengeProp.PropertyType)
                                    {
                                        case var c_type when c_type == typeof(double):
                                        case var c_type1 when c_type1 == typeof(double?):

                                            if (challengeProp.GetValue(performance.challenges) != null)
                                            {
                                                if (challengeProp.GetValue(maxStats.challenges) == null || (double)challengeProp.GetValue(performance.challenges) > (double)challengeProp.GetValue(maxStats.challenges))
                                                {
                                                    challengeProp.SetValue(maxStats.challenges, challengeProp.GetValue(performance.challenges));
                                                }
                                            }
                                            break;
                                    }
                                }
                                break;
                        }
                    }
                }
            }

            return maxStats;
        }

        public static Participant GetMinStats(List<GameInfo> games, string trackedPuuid)
        {
            PropertyInfo[] props = typeof(Participant).GetProperties();
            Participant minStats = new Participant();
            minStats.challenges = new Challenges();
            minStats.puuid = trackedPuuid;

            List<Participant> gamePerformances = new List<Participant>();

            foreach (GameInfo game in games)
            {
                if(game.info.gameDuration > 800)
                {
                    foreach (Participant player in game.info.participants)
                    {
                        if (player.puuid == trackedPuuid)
                        {
                            gamePerformances.Add(player);
                        }
                    }
                }
            }

            foreach (Participant performance in gamePerformances)
            {
                foreach (PropertyInfo prop in props)
                {
                    if (prop.GetValue(performance) != null)
                    {
                        switch (prop.PropertyType)
                        {
                            case var type1 when type1 == typeof(int):
                            case var type2 when type2 == typeof(int?):

                                if (prop.GetValue(minStats) == null || (int)prop.GetValue(minStats) == 0)
                                {
                                    prop.SetValue(minStats, prop.GetValue(performance));
                                }
                                else if ((int)prop.GetValue(performance) < (int)prop.GetValue(minStats) && (int)prop.GetValue(performance) != 0)
                                {
                                    prop.SetValue(minStats, prop.GetValue(performance));
                                }
                                break;

                            case var type3 when type3 == typeof(double):
                            case var type4 when type4 == typeof(double?):

                                if (prop.GetValue(minStats) == null ||  (double)prop.GetValue(minStats) == 0)
                                {
                                    prop.SetValue(minStats, prop.GetValue(performance));
                                }
                                else if ((double)prop.GetValue(performance) < (double)prop.GetValue(minStats) && (double)prop.GetValue(performance) != 0)
                                {
                                    prop.SetValue(minStats, prop.GetValue(performance));
                                }
                                break;

                            case var type when type == typeof(Challenges):

                                PropertyInfo[] challengeProps = typeof(Challenges).GetProperties();
                                foreach (PropertyInfo challengeProp in challengeProps)
                                {
                                    switch (challengeProp.PropertyType)
                                    {
                                        case var c_type1 when c_type1 == typeof(double):
                                        case var c_type2 when c_type2 == typeof(double?):

                                            if (challengeProp.GetValue(minStats.challenges) == null || (Double)challengeProp.GetValue(minStats.challenges) == 0.0)
                                            {
                                                challengeProp.SetValue(minStats.challenges, challengeProp.GetValue(performance.challenges));
                                            }
                                            else if (challengeProp.GetValue(performance.challenges) != null)
                                            {
                                                if((double)challengeProp.GetValue(performance.challenges) < (double)challengeProp.GetValue(minStats.challenges) && (double)challengeProp.GetValue(performance.challenges) != 0)
                                                {
                                                    challengeProp.SetValue(minStats.challenges, challengeProp.GetValue(performance.challenges));
                                                }
                                            }
                                            break;
                                    }
                                }
                                break;
                        }
                    }
                }
            }

            return minStats;
        }

        public static Participant GetTotalStats(List<GameInfo> games, string trackedPuuid)
        {
            PropertyInfo[] props = typeof(Participant).GetProperties();
            Participant totalStats = new Participant();
            totalStats.challenges = new Challenges();
            totalStats.puuid = trackedPuuid;

            List<Participant> gamePerformances = new List<Participant>();

            foreach (GameInfo game in games)
            {
                foreach (Participant player in game.info.participants)
                {
                    if (player.puuid == trackedPuuid)
                    {
                        gamePerformances.Add(player);
                    }
                }
            }

            foreach (Participant performance in gamePerformances)
            {
                foreach (PropertyInfo prop in props)
                {
                    if (prop.GetValue(performance) != null)
                    {
                        switch (prop.PropertyType)
                        {
                            case var type when type == typeof(int):
                            case var type1 when type1 == typeof(int?):

                                if(prop.GetValue(totalStats) != null)
                                {
                                    prop.SetValue(totalStats, (int)prop.GetValue(performance) + (int)prop.GetValue(totalStats));
                                }
                                else
                                {
                                    prop.SetValue(totalStats, prop.GetValue(performance));
                                }
                                
                                break;

                            case var type when type == typeof(double):
                            case var type1 when type1 == typeof(double?):

                                if (prop.GetValue(totalStats) != null)
                                {
                                    prop.SetValue(totalStats, (double)prop.GetValue(performance) + (double)prop.GetValue(totalStats));
                                }
                                else
                                {
                                    prop.SetValue(totalStats, prop.GetValue(performance));
                                }
                                break;

                            case var type when type == typeof(Challenges):

                                PropertyInfo[] challengeProps = typeof(Challenges).GetProperties();
                                foreach (PropertyInfo challengeProp in challengeProps)
                                {
                                    switch (challengeProp.PropertyType)
                                    {
                                        case var c_type when c_type == typeof(double):
                                        case var c_type1 when c_type1 == typeof(double?):

                                            if (challengeProp.GetValue(performance.challenges) != null)
                                            {
                                                if (challengeProp.GetValue(totalStats.challenges) != null)
                                                {
                                                    challengeProp.SetValue(totalStats.challenges, (double)challengeProp.GetValue(performance.challenges) + (double)challengeProp.GetValue(totalStats.challenges));
                                                }
                                                else
                                                {
                                                    challengeProp.SetValue(totalStats.challenges, challengeProp.GetValue(performance.challenges));
                                                }
                                            }
                                            break;
                                    }
                                }
                                break;
                        }
                    }
                }
            }

            return totalStats;
        }

        public static Participant GetCcScore(List<GameInfo> games, string trackedPuuid) //CC score when ignoring nocturne games
        {
            Participant maxStats = new Participant();
            maxStats.challenges = new Challenges();
            maxStats.puuid = trackedPuuid;

            List<Participant> gamePerformances = new List<Participant>();

            foreach (GameInfo game in games)
            {
                foreach (Participant player in game.info.participants)
                {
                    if (player.puuid == trackedPuuid)
                    {
                        gamePerformances.Add(player);
                    }
                }
            }

            foreach(Participant performance in gamePerformances)
            {
                if(performance.championName != "Nocturne")
                {
                    if(maxStats.timeCCingOthers == 0)
                    {
                        maxStats.timeCCingOthers = performance.timeCCingOthers;
                    }
                    else if(maxStats.timeCCingOthers < performance.timeCCingOthers)
                    {
                        maxStats.timeCCingOthers = performance.timeCCingOthers;
                    }
                }
            }

            return maxStats;
        }
    }

    public class GameStats
    {
        public int allInPings { get; set; }
        public int assistMePings { get; set; }
        public int assists { get; set; }
        public int baronKills { get; set; }
        public int basicPings { get; set; }
        public int bountyLevel { get; set; }
        public Challenges challenges { get; set; }
        public int champExperience { get; set; }
        public int champLevel { get; set; }
        public int championId { get; set; }
        public string championName { get; set; }
        public int championTransform { get; set; }
        public int commandPings { get; set; }
        public int consumablesPurchased { get; set; }
        public int damageDealtToBuildings { get; set; }
        public int damageDealtToObjectives { get; set; }
        public int damageDealtToTurrets { get; set; }
        public int damageSelfMitigated { get; set; }
        public int dangerPings { get; set; }
        public int deaths {  get; set; }
        public int detectorWardsPlaced { get; set; }
        public int doubleKills { get; set; }
        public int dragonKills { get; set; }
        public int eligibleForProgression { get; set; }
        public int enemyMissingPings { get; set; }
        public int enemyVisionPings { get; set; }
        public int firstBloodAssist { get; set; }
        public int firstBloodKill { get; set; }
        public int firstTowerAssist { get; set; }
        public int firstTowerKill { get; set; }
        public int gameEndedInEarlySurrender { get; set; }
        public int gameEndedInSurrender { get; set; }
        public int getBackPings { get; set; }
        public int goldEarned { get; set; }
        public int goldSpent { get; set; }
        public int holdPings { get; set; }
        public string individualPosition { get; set; }
        public int inhibitorKills { get; set; }
        public int inhibitorTakedowns { get; set; }
        public int inhibitorsLost { get; set; }
        public int item0 { get; set; }
        public int item1 { get; set; }
        public int item2 { get; set; }
        public int item3 { get; set; }
        public int item4 { get; set; }
        public int item5 { get; set; }
        public int item6 { get; set; }
        public int itemsPurchased { get; set; }
        public int killingSprees { get; set; }
        public int kills { get; set; }
        public string lane { get; set; }
        public int largestCriticalStrike { get; set; }
        public int largestKillingSpree { get; set; }
        public int largestMultiKill { get; set; }
        public int longestTimeSpentLiving { get; set; }
        public int magicDamageDealt { get; set; }
        public int magicDamageDealtToChampions { get; set; }
        public int magicDamageTaken { get; set; }
        public Missions missions { get; set; }
        public int needVisionPings { get; set; }
        public int neutralMinionsKilled { get; set; }
        public int nexusKills { get; set; }
        public int nexusLost { get; set; }
        public int nexusTakedowns { get; set; }
        public int objectivesStolen { get; set; }
        public int objectivesStolenAssists { get; set; }
        public int onMyWayPings { get; set; }
        public int participantId { get; set; }
        public int pentaKills { get; set; }
        public Perks perks { get; set; }
        public int physicalDamageDealt { get; set; }
        public int physicalDamageDealtToChampions { get; set; }
        public int physicalDamageTaken { get; set; }
        public int placement { get; set; }
        public int playerAugment1 { get; set; }
        public int playerAugment2 { get; set; }
        public int playerAugment3 { get; set; }
        public int playerAugment4 { get; set; }
        public int playerAugment5 { get; set; }
        public int playerAugment6 { get; set; }
        public int playerSubteamId { get; set; }
        public int profileIcon { get; set; }
        public int pushPings { get; set; }
        public string puuid { get; set; }
        public int quadraKills { get; set; }
        public int retreatPings { get; set; }
        public string riotIdGameName { get; set; }
        public string riotIdTagline { get; set; }
        public string role { get; set; }
        public int sightWardsBoughtInGame { get; set; }
        public int spell1Casts { get; set; }
        public int spell2Casts { get; set; }
        public int spell3Casts { get; set; }
        public int spell4Casts { get; set; }
        public int subteamPlacement { get; set; }
        public int summoner1Casts { get; set; }
        public int summoner1Id { get; set; }
        public int summoner2Casts { get; set; }
        public int summoner2Id { get; set; }
        public string summonerId { get; set; }
        public int summonerLevel { get; set; }
        public string summonerName { get; set; }
        public int teamEarlySurrendered { get; set; }
        public int teamId { get; set; }
        public string teamPosition { get; set; }
        public int timeCCingOthers { get; set; }
        public int timePlayed { get; set; }
        public int totalAllyJungleMinionsKilled { get; set; }
        public int totalDamageDealt { get; set; }
        public int totalDamageDealtToChampions { get; set; }
        public int totalDamageShieldedOnTeammates { get; set; }
        public int totalDamageTaken { get; set; }
        public int totalEnemyJungleMinionsKilled { get; set; }
        public int totalHeal { get; set; }
        public int totalHealsOnTeammates { get; set; }
        public int totalMinionsKilled { get; set; }
        public int totalTimeCCDealt { get; set; }
        public int totalTimeSpentDead { get; set; }
        public int totalUnitsHealed { get; set; }
        public int tripleKills { get; set; }
        public int trueDamageDealt { get; set; }
        public int trueDamageDealtToChampions { get; set; }
        public int trueDamageTaken { get; set; }
        public int turretKills { get; set; }
        public int turretTakedowns { get; set; }
        public int turretsLost { get; set; }
        public int unrealKills { get; set; }
        public int visionClearedPings { get; set; }
        public int visionScore { get; set; }
        public int visionWardsBoughtInGame { get; set; }
        public int wardsKilled { get; set; }
        public int wardsPlaced { get; set; }
        public int win { get; set; }
    }
}
