using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day1
{
    internal class Solution
    {
        public String FilePath { get; private set; } //input filepath related to .exe file
        public Solution(string filePath = $"../../../input.txt")
        {
            FilePath = filePath;
        }
        private int Solve()
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
        public static void Main()
        {
            Solution solution = new Solution();
            Console.WriteLine(solution.Solve());
        }
    }
}
