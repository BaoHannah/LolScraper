using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace LeagueApiScraper
{
    public class Metadata
    {
        public string dataVersion { get; set; }
        public string matchId { get; set; }
        public IList<string> participants { get; set; }
    }

    public class Challenges
    {
        [JsonProperty("12AssistStreakCounts")]
        public double AssistStreakCount12 { get; set; }
        public double HealFromMapSources { get; set; }
        public double InfernalScalePickup { get; set; }
        public double SWARM_DefeatAatrox { get; set; }
        public double SWARM_DefeatBriar { get; set; }
        public double SWARM_DefeatMiniBosses { get; set; }
        public double SWARM_EvolveWeapon { get; set; }
        public double SWARM_Have3Passives { get; set; }
        public double SWARM_KillEnemy { get; set; }
        public double SWARM_PickupGold { get; set; }
        public double SWARM_ReachLevel50 { get; set; }
        public double SWARM_Survive15Min { get; set; }
        public double SWARM_WinWith5EvolvedWeapons { get; set; }
        public double abilityUses { get; set; }
        public double acesBefore15Minutes { get; set; }
        public double alliedJungleMonsterKills { get; set; }
        public double baronTakedowns { get; set; }
        public double blastConeOppositeOpponentCount { get; set; }
        public double bountyGold { get; set; }
        public double buffsStolen { get; set; }
        public double completeSupportQuestdoubleime { get; set; }
        public double controlWardsPlaced { get; set; }
        public double damagePerMinute { get; set; }
        public double damageTakenOnTeamPercentage { get; set; }
        public double dancedWithRiftHerald { get; set; }
        public double deathsByEnemyChamps { get; set; }
        public double dodgeSkillShotsSmallWindow { get; set; }
        public double doubleAces { get; set; }
        public double dragonTakedowns { get; set; }
        public double earliestBaron { get; set; }
        public double earliestDragonTakedown { get; set; }
        public double earlyLaningPhaseGoldExpAdvantage { get; set; }
        public double effectiveHealAndShielding { get; set; }
        public double elderDragonKillsWithOpposingSoul { get; set; }
        public double elderDragonMultikills { get; set; }
        public double enemyChampionImmobilizations { get; set; }
        public double enemyJungleMonsterKills { get; set; }
        public double epicMonsterKillsNearEnemyJungler { get; set; }
        public double epicMonsterKillsWithin30SecondsOfSpawn { get; set; }
        public double epicMonsterSteals { get; set; }
        public double epicMonsterStolenWithoutSmite { get; set; }
        public double firstTurretKilled { get; set; }
        public double fistBumpParticipation { get; set; }
        public double flawlessAces { get; set; }
        public double fullTeamTakedown { get; set; }
        public double gameLength { get; set; }
        public double getTakedownsInAllLanesEarlyJungleAsLaner { get; set; }
        public double goldPerMinute { get; set; }
        public double hadOpenNexus { get; set; }
        public double immobilizeAndKillWithAlly { get; set; }
        public double initialBuffCount { get; set; }
        public double initialCrabCount { get; set; }
        public double jungleCsBefore10Minutes { get; set; }
        public double junglerTakedownsNearDamagedEpicMonster { get; set; }
        public double kTurretsDestroyedBeforePlatesFall { get; set; }
        public double kda { get; set; }
        public double killAfterHiddenWithAlly { get; set; }
        public double killParticipation { get; set; }
        public double killedChampTookFullTeamDamageSurvived { get; set; }
        public double killingSprees { get; set; }
        public double killsNearEnemyTurret { get; set; }
        public double killsOnOtherLanesEarlyJungleAsLaner { get; set; }
        public double killsOnRecentlyHealedByAramPack { get; set; }
        public double killsUnderOwnTurret { get; set; }
        public double killsWithHelpFromEpicMonster { get; set; }
        public double knockEnemyIntoTeamAndKill { get; set; }
        public double landSkillShotsEarlyGame { get; set; }
        public double laneMinionsFirst10Minutes { get; set; }
        public double laningPhaseGoldExpAdvantage { get; set; }
        public double legendaryCount { get; set; }
        public IList<double> legendaryItemUsed { get; set; }
        public double lostAnInhibitor { get; set; }
        public double maxCsAdvantageOnLaneOpponent { get; set; }
        public double maxKillDeficit { get; set; }
        public double maxLevelLeadLaneOpponent { get; set; }
        public double mejaisFullStackInTime { get; set; }
        public double moreEnemyJungleThanOpponent { get; set; }
        public double multiKillOneSpell { get; set; }
        public double multiTurretRiftHeraldCount { get; set; }
        public double multikills { get; set; }
        public double multikillsAfterAggressiveFlash { get; set; }
        public double outerTurretExecutesBefore10Minutes { get; set; }
        public double outnumberedKills { get; set; }
        public double outnumberedNexusKill { get; set; }
        public double perfectDragonSoulsTaken { get; set; }
        public double perfectGame { get; set; }
        public double pickKillWithAlly { get; set; }
        public double playedChampSelectPosition { get; set; }
        public double poroExplosions { get; set; }
        public double quickCleanse { get; set; }
        public double quickFirstTurret { get; set; }
        public double quickSoloKills { get; set; }
        public double riftHeraldTakedowns { get; set; }
        public double saveAllyFromDeath { get; set; }
        public double scuttleCrabKills { get; set; }
        public double shortestTimeToAceFromFirstTakedown { get; set; }
        public double skillshotsDodged { get; set; }
        public double skillshotsHit { get; set; }
        public double snowballsHit { get; set; }
        public double soloBaronKills { get; set; }
        public double soloKills { get; set; }
        public double soloTurretsLategame { get; set; }
        public double stealthWardsPlaced { get; set; }
        public double survivedSingleDigitHpCount { get; set; }
        public double survivedThreeImmobilizesInFight { get; set; }
        public double takedownOnFirstTurret { get; set; }
        public double takedowns { get; set; }
        public double takedownsAfterGainingLevelAdvantage { get; set; }
        public double takedownsBeforeJungleMinionSpawn { get; set; }
        public double takedownsFirstXMinutes { get; set; }
        public double takedownsInAlcove { get; set; }
        public double takedownsInEnemyFountain { get; set; }
        public double teamBaronKills { get; set; }
        public double teamDamagePercentage { get; set; }
        public double teamElderDragonKills { get; set; }
        public double teamRiftHeraldKills { get; set; }
        public double tookLargeDamageSurvived { get; set; }
        public double turretPlatesTaken { get; set; }
        public double turretTakedowns { get; set; }
        public double turretsTakenWithRiftHerald { get; set; }
        public double twentyMinionsIn3SecondsCount { get; set; }
        public double twoWardsOneSweeperCount { get; set; }
        public double unseenRecalls { get; set; }
        public double visionScoreAdvantageLaneOpponent { get; set; }
        public double visionScorePerMinute { get; set; }
        public double voidMonsterKill { get; set; }
        public double wardTakedowns { get; set; }
        public double wardTakedownsBefore20M { get; set; }
        public double wardsGuarded { get; set; }
        public double? highestChampionDamage { get; set; }
        public double? junglerKillsEarlyJungle { get; set; }
        public double? killsOnLanersEarlyJungleAsJungler { get; set; }
        public double? teleportTakedowns { get; set; }
        public double? controlWardTimeCoverageInRiverOrEnemyHalf { get; set; }
        public double? fasterSupportQuestCompletion { get; set; }
        public double? highestWardKills { get; set; }
        public double? firstTurretKilledTime { get; set; }
        public double? highestCrowdControlScore { get; set; }
    }

    public class Missions
    {
        public int playerScore0 { get; set; }
        public int playerScore1 { get; set; }
        public int playerScore2 { get; set; }
        public int playerScore3 { get; set; }
        public int playerScore4 { get; set; }
        public int playerScore5 { get; set; }
        public int playerScore6 { get; set; }
        public int playerScore7 { get; set; }
        public int playerScore8 { get; set; }
        public int playerScore9 { get; set; }
        public int playerScore10 { get; set; }
        public int playerScore11 { get; set; }
    }

    public class StatPerks
    {
        public int defense { get; set; }
        public int flex { get; set; }
        public int offense { get; set; }
    }

    public class Selection
    {
        public int perk { get; set; }
        public int var1 { get; set; }
        public int var2 { get; set; }
        public int var3 { get; set; }
    }

    public class Style
    {
        public string description { get; set; }
        public IList<Selection> selections { get; set; }
        public int style { get; set; }
    }

    public class Perks
    {
        public StatPerks statPerks { get; set; }
        public IList<Style> styles { get; set; }
    }

    public class Participant
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
        public int deaths { get; set; }
        public int detectorWardsPlaced { get; set; }
        public int doubleKills { get; set; }
        public int dragonKills { get; set; }
        public bool eligibleForProgression { get; set; }
        public int enemyMissingPings { get; set; }
        public int enemyVisionPings { get; set; }
        public bool firstBloodAssist { get; set; }
        public bool firstBloodKill { get; set; }
        public bool firstTowerAssist { get; set; }
        public bool firstTowerKill { get; set; }
        public bool gameEndedInEarlySurrender { get; set; }
        public bool gameEndedInSurrender { get; set; }
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
        public bool teamEarlySurrendered { get; set; }
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
        public bool win { get; set; }
    }

    public class Ban
    {
        public int championId { get; set; }
        public int pickTurn { get; set; }
    }

    public class Baron
    {
        public bool first { get; set; }
        public int kills { get; set; }
    }

    public class Champion
    {
        public bool first { get; set; }
        public int kills { get; set; }
    }

    public class Dragon
    {
        public bool first { get; set; }
        public int kills { get; set; }
    }

    public class Horde
    {
        public bool first { get; set; }
        public int kills { get; set; }
    }

    public class Inhibitor
    {
        public bool first { get; set; }
        public int kills { get; set; }
    }

    public class RiftHerald
    {
        public bool first { get; set; }
        public int kills { get; set; }
    }

    public class Tower
    {
        public bool first { get; set; }
        public int kills { get; set; }
    }

    public class Objectives
    {
        public Baron baron { get; set; }
        public Champion champion { get; set; }
        public Dragon dragon { get; set; }
        public Horde horde { get; set; }
        public Inhibitor inhibitor { get; set; }
        public RiftHerald riftHerald { get; set; }
        public Tower tower { get; set; }
    }

    public class Team
    {
        public IList<Ban> bans { get; set; }
        public Objectives objectives { get; set; }
        public int teamId { get; set; }
        public bool win { get; set; }
    }

    public class Info
    {
        public string endOfGameResult { get; set; }
        public long gameCreation { get; set; }
        public int gameDuration { get; set; }
        public long gameEndTimestamp { get; set; }
        public long gameId { get; set; }
        public string gameMode { get; set; }
        public string gameName { get; set; }
        public long gameStartTimestamp { get; set; }
        public string gameType { get; set; }
        public string gameVersion { get; set; }
        public int mapId { get; set; }
        public IList<Participant> participants { get; set; }
        public string platformId { get; set; }
        public int queueId { get; set; }
        public IList<Team> teams { get; set; }
        public string tournamentCode { get; set; }
    }

    public class GameInfo
    {
        public Metadata metadata { get; set; }
        public Info info { get; set; }
    }
}
