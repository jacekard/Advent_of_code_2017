using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_16 {
    class Program {
        public static void swap(char[] list, int A, int B) {
            char tmp = list[A];
            list[A] = list[B];
            list[B] = tmp;
        }

        static void Main(string[] args) {
            int numOfProgs = 16;
            char[] list = new char[numOfProgs];
            string line = Console.ReadLine();
            string[] moves = line.Split(',');
            for (int i = 0; i < numOfProgs; i++) {
                list[i] = (char)('a' + i);
            }

            foreach (var move in moves) {
                switch (move[0]) {
                    case 's':
                    int num = int.Parse(move.Substring(1));
                    for (int j = 1, i = numOfProgs - num; j <= num; i++, j++) {
                        for (int k = i; k >= j; k--) {
                            swap(list, k, k - 1);
                        }
                    }
                    break;

                    case 'x':
                    string[] xchg = move.Substring(1).Split('/');
                    int[] vals = Array.ConvertAll(xchg, int.Parse);

                    swap(list, vals[0], vals[1]);


                    break;

                    case 'p':
                    string[] partner = move.Substring(1).Split('/');

                    int A = -1, B = -1;
                    bool hasFoundA = false, hasFoundB = false;
                    for (int i = 0; i < numOfProgs; i++) {
                        if (list[i] == partner[0].First()) {
                            A = i;
                            hasFoundA = true;
                        }
                        else if (list[i] == partner[1].First()) {
                            B = i;
                            hasFoundB = true;
                        }
                        if (hasFoundA && hasFoundB)
                            break;
                    }
                    swap(list, A, B);

                    break;

                    default: break;
                }
            }
            Console.WriteLine(list);
        }
    }
}
