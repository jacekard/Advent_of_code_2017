using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_5 {
    class Program {
        static void Main(string[] args) {

            List<int> list = new List<int>();

            int counter = 0;
            string line = Console.ReadLine();
            while (line != null) {
                list.Add(int.Parse(line));
                line = Console.ReadLine();
            }

            int i = 0;
            int v = 0;

            //exercise 1 & 2 are almost the same so here's just 2nd part
            while (i < list.Count) {
                i += list[i];
                if (list[v] >= 3)
                    list[v]--;
                else
                    list[v]++;
                v = i;
                counter++;
            }
            Console.WriteLine(counter);
        }
    }
}
