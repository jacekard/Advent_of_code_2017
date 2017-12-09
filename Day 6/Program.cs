using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_6 {
    class Program {
        static void Main(string[] args) {

            int redistributions = 0;
            int cycles = 0;

            string line = "";
            line = Console.ReadLine();
            string[] numbers = line.Split('\t');
            int[] membanks = Array.ConvertAll(numbers, int.Parse);
            int length = membanks.Length;
            Dictionary<string, int> patterns = new Dictionary<string, int>();

            bool isDone = false;
            int max_value;
            int max_index = 0;

            while (!isDone) {

                max_value = membanks.Max();
                for (int i = 0; i < length; i++) {
                    if (membanks[i] == max_value) {
                        max_index = i;
                        break;
                    }
                }

                redistributions++;
                foreach (var p in patterns.Keys.ToList()) {
                    patterns[p]++;
                }

                do {

                    for (int i = 1; i < length; i++) {
                        if (membanks[max_index] != 0) {
                            membanks[max_index]--;
                            membanks[(i + max_index) % length]++;
                        }
                    }


                    string result = string.Join("", membanks.Select(i => i.ToString()).ToArray());
                    if (patterns.ContainsKey(result)) {
                        isDone = true;
                        cycles = patterns[result];
                        break;
                    }
                    else {
                        patterns.Add(result, 0);
                    }


                    if (isDone)
                        break;
                } while (membanks[max_index] >= length - 1);
            }

            Console.WriteLine(redistributions);
            Console.WriteLine(cycles);
        }
    }

}
