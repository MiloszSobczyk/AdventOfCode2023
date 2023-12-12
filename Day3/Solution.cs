using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Day3
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

            }
            return 0;
        }
        private int ProcessLine(string linePrev, string line, string lineNext)
        {
            int sum = 0;
            int number = 0;
            bool inNumber = false;
            bool include = false;
            for(int i = 0; i < line.Length; ++i)
            {
                inNumber = Char.IsNumber(line[i]);
                //include |= (linePrev != null && linePrev[i])
                if(inNumber)
                {
                    number = number * 10 + line[i];
                    
                }
            }
            return sum;
        }

        public static void Main()
        {
            Solution solution = new Solution();
            Console.WriteLine(solution.Solve());
        }
    }
}
