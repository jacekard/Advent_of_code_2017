using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_11 {
    class Program {
        static void Main(string[] args) {

            string line = "";
            Point p = new Point();
            line = Console.ReadLine();
            int distance = 0, newDistance = 0;
            while (line != null) {

                string[] directions = line.Split(',');

                for (int i = 0; i < directions.Length; i++) {
                    switch (directions[i]) {
                        case "n":
                        p.y--;
                        break;

                        case "s":
                        p.y++;
                        break;

                        case "ne":
                        p.x++;
                        p.y--;
                        break;

                        case "nw":
                        p.x--;
                        break;

                        case "sw":
                        p.x--;
                        p.y++;
                        break;

                        case "se":
                        p.x++;
                        break;
                    }
                    
                    newDistance = Math.Max(Math.Abs(p.x), Math.Abs(p.y));
                    newDistance = Math.Max(newDistance, Math.Abs(p.x + p.y));
                    if (newDistance > distance)
                        distance = newDistance;
                }

                line = Console.ReadLine();
            }

            Console.WriteLine(distance);

        }
    }

    class Point {
        public int x { get; set; }
        public int y { get; set; }
        public Point() {
            x = 0;
            y = 0;
        }
    }


}
