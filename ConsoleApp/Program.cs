using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp.Helpers;

namespace ConsoleApp
{
    public class Program
    {
        private static readonly Dictionary<string, int> ColumnTitlesWithIndexes = new Dictionary<string, int>()
        {
            {"Country", 0},
            {"Organization", 0},
            {"City", 0},
            {"Team", 0},
            {"Email", 0},
            {"Participant1", 0},
            {"Participant2", 0},
            {"Participant3", 0}
        };

        private const string OutputHeader = "Team;Login;Email;Participants";

        /// <summary>
        /// http://codeforces.com/gym/100834/problem/D
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            string filePath = "input.csv";
            List<string> output = ParseCsvTable(filePath);

            foreach (var line in output)
            {
                Console.WriteLine(line);
            }

            Console.Write("Press ENTER...");
            Console.Read();
        }

        public static List<string> ParseCsvTable(string filePath)
        {
            string[] lines = File.ReadAllLines(filePath);

            if (lines.Length < 2)
                return null;

            string header = lines[0];
            DefineColumnsOrder(header);

            List<string> result = new List<string> { OutputHeader };
            for (int i = 1; i < lines.Length; i++)
            {
                string[] columns = lines[i].Split(';');
                string outputLine = columns[ColumnTitlesWithIndexes["Team"]] + ";";
                outputLine += GetLogin(columns, i) + ";";
                outputLine += columns[ColumnTitlesWithIndexes["Email"]] + ";";
                outputLine += GetParticipants(columns);
                result.Add(outputLine);
            }

            return result;
        }

        private static void DefineColumnsOrder(string header)
        {
            string[] titles = header.Split(';');
            for (int i = 0; i < titles.Length; i++)
            {
                if (ColumnTitlesWithIndexes.ContainsKey(titles[i]))
                    ColumnTitlesWithIndexes[titles[i]] = i;
            }
        }

        private static string GetLogin(string[] columns, int teamNumber)
        {
            string number;
            if (teamNumber < 10)
            {
                number = "00" + teamNumber;
            }
            else if (teamNumber < 100)
            {
                number = "0" + teamNumber;
            }
            else
                number = teamNumber.ToString();
            string result = string.Format("team{0} ({1}, {2})", number,
                columns[ColumnTitlesWithIndexes["Organization"]], columns[ColumnTitlesWithIndexes["City"]]);

            return result;
        }

        private static string GetParticipants(string[] columns)
        {
            string result = columns[ColumnTitlesWithIndexes["Participant1"]] + ",";
            result += columns[ColumnTitlesWithIndexes["Participant2"]] + ",";
            result += columns[ColumnTitlesWithIndexes["Participant3"]];

            return result;
        }
    }
}
