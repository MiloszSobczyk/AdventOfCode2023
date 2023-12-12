using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Day1
{
    internal class Solution
    {
        public String FilePath { get; private set; } //input filepath related to .exe file
        private Dictionary<string, int> stringDigits;
        public Solution(string filePath = $"../../../input.txt")
        {
            FilePath = filePath;
            stringDigits = new Dictionary<string, int>()
            {
                { "one",   1 },
                { "two",   2 },
                { "three", 3 },
                { "four",  4 },
                { "five",  5 },
                { "six",   6 },
                { "seven", 7 },
                { "eight", 8 },
                { "nine",  9 },
            };

        }
        private int SolvePart1()
        {
            if (!File.Exists(FilePath)) 
                return -1;
            using(StreamReader sr = new StreamReader(FilePath))
            {
                int sum = 0;
                while(sr.Peek() >= 0)
                {
                    string line = sr.ReadLine()!;
                    foreach (char c in line)
                        if (c >= '0' && c <= '9')
                        {
                            sum += (c - '0') * 10;
                            break;
                        }
                    foreach (char c in line.Reverse())
                        if (c >= '0' && c <= '9')
                        {
                            sum += c - '0';
                            break;
                        }
                }
                return sum;
            }
        }
        private int SolvePart2()
        {
            if (!File.Exists(FilePath))
                return -1;
            using (StreamReader sr = new StreamReader(FilePath))
            {
                int sum = 0;
                while (sr.Peek() >= 0)
                {
                    string line = sr.ReadLine()!;
                    int firstDigit = -1;
                    int lastDigit = -1;
                    int firstInd = line.Length - 1;
                    int lastInd = 0;
                    foreach(KeyValuePair<string, int> kvp in stringDigits)
                    {
                        int ind = line.IndexOf(kvp.Key);
                        if(ind != -1)
                        {
                            if(ind < firstInd)
                            {
                                firstInd = ind;
                                firstDigit = kvp.Value;
                            }
                            ind = line.LastIndexOf(kvp.Key);
                            if(ind > lastInd)
                            {
                                lastInd = ind;
                                lastDigit = kvp.Value;
                            }
                        }
                    }
                    for(int i = 0; i <= firstInd; ++i)
                    {
                        char c = line[i];
                        if (c >= '0' && c <= '9')
                        {
                            firstInd = i;
                            firstDigit = c - '0';
                            break;
                        }
                    }
                    for (int i = line.Length - 1; i >= lastInd; --i)
                    {
                        char c = line[i];
                        if (c >= '0' && c <= '9')
                        {
                            lastInd = i;
                            lastDigit = c - '0';
                            break;
                        }
                    }
                    sum += firstDigit * 10 + lastDigit;
                }
                return sum;
            }
        }
        public static void Main()
        {
            Solution solution = new Solution();
            Console.WriteLine(solution.SolvePart1());
            Console.WriteLine(solution.SolvePart2());
        }
    }
}
