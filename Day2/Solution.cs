using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day2
{
    internal class Solution
    {
        public String FilePath { get; private set; } //input filepath related to .exe file
        private Dictionary<string, int> colorCounts;
        public Solution(string filePath = $"../../../input.txt")
        {
            FilePath = filePath;
            colorCounts = new Dictionary<string, int>()
            {
                { "red", 12 },
                { "green", 13 },
                { "blue", 14 }
            };
        }
        private int Solve()
        {
            if (!File.Exists(FilePath))
                return -1;
            using (StreamReader sr = new StreamReader(FilePath))
            {
                int idSum = 0;
                int gameId = 0;
                while (sr.Peek() >= 0)
                {
                    ++gameId;
                    string game = sr.ReadLine()!;
                    if (ValidateGame(game))
                        idSum += gameId;
                }
                return idSum;
            }
        }
        private bool ValidateGame(string game)
        {
            game = game.Substring(game.IndexOf(':') + 1);
            foreach (string round in game.Split(';'))
            {
                foreach(KeyValuePair<string, int> kvp in colorCounts)
                {
                    int colorInd = round.IndexOf(kvp.Key);
                    if (colorInd == -1) continue;
                    int count = 0;
                    int i = colorInd - 2;
                    for (i = colorInd - 2; i >= 0 && round[i] >= '0' && round[i] <= '9'; --i) ;
                    for (i = i + 1; i <= colorInd - 2; ++i)
                        count = count * 10 + round[i] - '0';
                    if (count > kvp.Value) 
                        return false;
                }
            }
            return true;
        }
        public static void Main()
        {
            Solution solution = new Solution();
            Console.WriteLine(solution.Solve());
        }
    }
}
