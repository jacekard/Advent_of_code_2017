using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_15 {
    class Program {
        //Generator A starts with 722
        //Generator B starts with 354
        static void Main(string[] args) {
            ulong genA = 722, genB = 354;
            ulong factA = 16807, factB = 48271;
            ulong mod = 2147483647;
            ulong conditionA = 4, conditionB = 8;

            for (int i = 0; i < 5000000; i++) {
                do {
                    genA = (genA * factA) % mod;
                } while (genA % conditionA != 0);
                do {
                    genB = (genB * factB) % mod;
                } while (genB % conditionB != 0);

                Judge.Compare(genA, genB);
            }

            Console.WriteLine(Judge.Matches);

        }
    }

    class Judge {
        public static int Matches = 0;
        public static ulong Mask = 65535;
        public static void Compare(ulong a, ulong b) {
            if ((a & Mask) == (b & Mask))
                Matches++;
        }
    }
}
