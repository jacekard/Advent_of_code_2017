using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_3 {
    class Program2 {
        static void Main(string[] args) {
            int n;
            n = int.Parse(Console.ReadLine());

            int distance;
            int i = 1;
            int step = 1;
            int x = 50, y = 50;
            for (int j = 0; j < 100; j++) {
                for (int k = 0; k < 100; k++) {
                    Square.grid[j, k] = new Square();
                }
            }
            Square.grid[x, y].value = 1;

            while (Square.grid[x,y].value < n) {
                for (int j = 0; j < step; j++) {
                    if (Square.grid[x, y].value > n)
                        break;
                    x += 1;
                    i += 1;
                    Square.grid[x, y].getNeighbors(x, y);
                }

                for (int j = 0; j < step; j++) {
                    if (Square.grid[x, y].value > n)
                        break;
                    y += 1;
                    i += 1;
                    Square.grid[x, y].getNeighbors(x, y);
                }

                for (int j = 0; j < step + 1; j++) {
                    if (Square.grid[x, y].value > n)
                        break;
                    x -= 1;
                    i += 1;
                    Square.grid[x, y].getNeighbors(x, y);
                }

                for (int j = 0; j < step + 1; j++) {
                    if (Square.grid[x, y].value > n)
                        break;
                    y -= 1;
                    i += 1;
                    Square.grid[x, y].getNeighbors(x, y);
                }

                step += 2;
            }
            Console.WriteLine(Square.grid[x, y].value);
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

    class Square {
        public static Square[,] grid = new Square[100, 100];
        public Point pos { get; set; }
        public int value { get; set; }
        public Square() {
            pos = new Point();
            value = 0;
        }
        public void getNeighbors(int x, int y) {
            value = grid[x + 1, y + 1].value + grid[x + 1, y - 1].value +
                grid[x - 1, y - 1].value + grid[x - 1, y + 1].value +
                grid[x + 1, y].value + grid[x, y - 1].value +
                grid[x, y + 1].value + grid[x - 1, y].value;
        }
    }
}