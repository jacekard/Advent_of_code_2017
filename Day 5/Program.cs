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
            string line="";
            while(line != null) {
                line = Console.ReadLine();
                if (line == null)
                    break;
                list.Add(int.Parse(line));
            }

            bool isDone = false;
            int i = 0;
            int v = 0;
            int size = list.Count;

            //exercise 1 & 2 are almost the same so here's just 2nd part

            while(!isDone) {
                i += list[i];
                if (list[v] >= 3)
                    list[v]--;
                else
                    list[v]++;
                v = i;
                counter++;
                if (i >= size)
                    isDone = true;
            }
            Console.WriteLine(counter);
        }
    }
}
