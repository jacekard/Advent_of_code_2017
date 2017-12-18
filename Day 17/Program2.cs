using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_17 {
    class Program1 {
        static void Main(string[] args) {
            const int steps = 386;
            const int insertions = 50000000;

            int currPosition = 0;
            for (int i = 1; i <= insertions; i++) {
                currPosition = (currPosition + steps) % i;
                if (currPosition == 0)
                    Console.WriteLine(i);
                currPosition++;
            }
        }
    }
}
