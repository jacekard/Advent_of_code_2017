using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sum_of_digits {
    class Program {
        static void Main(string[] args) {

            List<int> list = new List<int>();
            int sum = 0;

            //read input
            string line = "";
            while (line != null) {
                line = Console.ReadLine();
                if (line == null) break;
                for (int i = 0; i < line.Length; i++) {
                    if (int.TryParse(line[i].ToString(), out int number))
                        list.Add(number);
                    else break;
                }
            }

            //exercise 1
            for (int i = 0; i < list.Count; i++) {
                if (list[i] == list[(i + 1) % list.Count])
                    sum += list[i];
            }
            Console.WriteLine(sum);

            //exercise 2
            int average = list.Count / 2;
            for (int i = 0; i < list.Count; i++) {
                if (list[i] == list[(i + average) % list.Count])
                    sum += list[i];
            }
            Console.WriteLine(sum);
        }
    }
}
