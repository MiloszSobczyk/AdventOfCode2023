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
                int sum = 0;
                if (sr.Peek()  > 0)
                {
                    string? linePrev = null;
                    string? line = null;
                    string? lineNext = sr.ReadLine();
                    while(sr.Peek() > 0)
                    {
                        linePrev = line;
                        line = lineNext;
                        lineNext = sr.ReadLine();
                        sum += ProcessLine(linePrev, line, lineNext);
                    }
                }
                return sum;
            }
        }
        private int ProcessLine(string? linePrev, string? line, string? lineNext)
        {
            int sum = 0;
            int number = 0;
            bool inNumber = false;
            bool include = false;
            for(int i = 0; i < line.Length; ++i)
            {
                inNumber = char.IsNumber(line[i]);
                include |= (linePrev != null && linePrev[i] != '.' && !char.IsNumber(linePrev[i])) ||
                    (lineNext != null && lineNext[i] != '.' && !char.IsNumber(lineNext[i]));
                if (inNumber)
                    Console.Write("");
                if (inNumber)
                {
                    number = number * 10 + line[i] - '0';
                }
                else
                {
                    if(include)
                    {
                        sum += number;
                    }
                    number = 0;
                    include = (linePrev != null && linePrev[i] != '.' && char.IsNumber(linePrev[i])) ||
                    (lineNext != null && lineNext[i] != '.' && char.IsNumber(lineNext[i]));
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
