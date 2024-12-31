using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;

namespace LeagueApiScraper
{
    public class CsvWriter
    {
        public void WriteMinMaxStats(Participant minStats, Participant maxStats, string basePath)
        {
            string path = $"{basePath}MinMaxStats.csv";
            using (StreamWriter writer = new StreamWriter(path))
            {
                PropertyInfo[] props = typeof(Participant).GetProperties();
                writer.WriteLine(",Min,Max");
                foreach(PropertyInfo prop in props)
                {
                    //writer.WriteLine($"{prop.Name},{prop.GetValue(minStats)},{prop.GetValue(maxStats)}");
                    switch (prop.PropertyType)
                    {
                        case var type when type == typeof(int):
                        case var type1 when type1 == typeof(int?):
                        case var type2 when type2 == typeof(double):
                        case var type3 when type3 == typeof(double?):
                            writer.WriteLine($"{prop.Name},{prop.GetValue(minStats)},{prop.GetValue(maxStats)}");
                            break;

                        case var type when type == typeof(Challenges):

                            PropertyInfo[] challengeProps = typeof(Challenges).GetProperties();
                            foreach (PropertyInfo challengeProp in challengeProps)
                            {
                                switch (challengeProp.PropertyType)
                                {
                                    case var c_type when c_type == typeof(double):
                                    case var c_type1 when c_type1 == typeof(double?):

                                        writer.WriteLine($"{challengeProp.Name},{challengeProp.GetValue(minStats.challenges, null)},{challengeProp.GetValue(maxStats.challenges, null)}");
                                        break;
                                }
                            }
                            break;
                    }
                }
            }
        }

        public void WriteTotalStats(Participant total,string basePath)
        {
            string path = $"{basePath}TotalStats.csv";
            using (StreamWriter writer = new StreamWriter(path))
            {
                PropertyInfo[] props = typeof(Participant).GetProperties();
                writer.WriteLine(",Total");
                foreach (PropertyInfo prop in props)
                {
                    //writer.WriteLine($"{prop.Name},{prop.GetValue(minStats)},{prop.GetValue(maxStats)}");
                    switch (prop.PropertyType)
                    {
                        case var type when type == typeof(int):
                        case var type1 when type1 == typeof(int?):
                        case var type2 when type2 == typeof(double):
                        case var type3 when type3 == typeof(double?):
                            writer.WriteLine($"{prop.Name},{prop.GetValue(total)}");
                            break;

                        case var type when type == typeof(Challenges):

                            PropertyInfo[] challengeProps = typeof(Challenges).GetProperties();
                            foreach (PropertyInfo challengeProp in challengeProps)
                            {
                                switch (challengeProp.PropertyType)
                                {
                                    case var c_type when c_type == typeof(double):
                                    case var c_type1 when c_type1 == typeof(double?):

                                        writer.WriteLine($"{challengeProp.Name},{challengeProp.GetValue(total.challenges)}");
                                        break;
                                }
                            }
                            break;
                    }
                }
            }
        }

        public void WriteCcScore(Dictionary<string, Participant> ccStats, string basePath)
        {
            string path = $"{basePath}MaxCcScores.csv";
            using (StreamWriter writer = new StreamWriter(path))
            {
                writer.WriteLine("Name, CC Score");
                foreach(string player in ccStats.Keys)
                {
                    writer.WriteLine($"{player}, {ccStats[player].timeCCingOthers}");
                }
            }
        }
    }
}
