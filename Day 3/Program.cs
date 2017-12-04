using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_3 {
    class Program {
        static void Main(string[] args) {
            int n;
            n = int.Parse(Console.ReadLine());

            Point p = new Point();

            int distance;
            int i = 1;
            int step = 1;
            while(i != n) {
                for(int j = 0; j < step; j++) {
                    if (i == n)
                        break;
                    p.x += 1;
                    i += 1;
                }

                for (int j = 0; j < step; j++) {
                    if (i == n)
                        break;
                    p.y += 1;
                    i += 1;
                }

                for (int j = 0; j < step+1; j++) {
                    if (i == n)
                        break;
                    p.x -= 1;
                    i += 1;
                }

                for (int j = 0; j < step + 1; j++) {
                    if (i == n)
                        break;
                    p.y -= 1;
                    i += 1;
                }

                step += 2;
            }
            //the taxicab distance between (p1, p2) and (q1, q2) is
            // |p1-q1| + |p2-q2| where point p(p1,p2)
            distance = Math.Abs(p.x) + Math.Abs(p.y);

            Console.WriteLine(distance + " " + i);
        }
    }

    class Point {

        public int x { get; set; }
        public int y { get; set; }
        
        public Point() {
            x = 0;
            y = 0;
        }

        public override string ToString() {
            return x + "/" + y;
        }


    }
}
