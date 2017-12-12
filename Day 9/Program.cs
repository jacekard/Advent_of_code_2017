using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_9 {
    class Program {
        static void Main(string[] args) {

            string line = "";
            line = Console.ReadLine();
            int groupSize = 0;
            int score = 0;
            int charCount = 0;

            for (int i = 0; i < line.Length; i++) {
                if (line[i].Equals('{'))
                    groupSize++;
                else if (line[i].Equals('}')) {
                    score += groupSize;
                    groupSize--;
                }
                else if (line[i].Equals('<')) {
                    while (!line[++i].Equals('>')) {
                        if (line[i].Equals('!')) {
                            i++;
                            charCount--;
                        }
                        charCount++;
                    }
                }
                else if (line[i].Equals('!'))
                    i++;
                //else if (line[i].Equals(',')) {
                //    if (groupSize == 1)
                //        groupSize = 0;
            }
            Console.WriteLine(score);
            Console.WriteLine(charCount);

        }

    }
}
