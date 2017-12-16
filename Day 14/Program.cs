using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_14 {
    class Program {

        private static readonly Dictionary<char, string> hexCharToBin = new Dictionary<char, string> {
            { '0', "0000" }, { '1', "0001" }, { '2', "0010" }, { '3', "0011" },{ '4', "0100" }, { '5', "0101" }, { '6', "0110" },
            { '7', "0111" },{ '8', "1000" }, { '9', "1001" }, { 'a', "1010" }, { 'b', "1011" }, { 'c', "1100" }, { 'd', "1101" },
            { 'e', "1110" }, { 'f', "1111" }
        };

        static void Main(string[] args) {
            string hash = "oundnydw-";
            Square.gridSize = 128;
            int sum = 0;
            int numOfRegions = 0;

            Square.grid = new Square[Square.gridSize, Square.gridSize];

            for (int i = 0; i < Square.gridSize; i++) {

                string newhash = KnotHash.CalculateKnotHash(hash + i);
                StringBuilder row = new StringBuilder();

                foreach (char z in newhash) {
                    row.Append(hexCharToBin[char.ToLower(z)]);
                }

                for (int j = 0; j < Square.gridSize; j++) {
                    Square.grid[j, i] = new Square(j, i);
                    Square.grid[j, i].Val = row[j] - '0';
                    sum += row[j] - '0';
                }
            }

            foreach (var square in Square.grid) {
                if (square.Visited == false && square.Val == 1) {
                    square.lookForRegions();
                    numOfRegions++;
                }
            }

            Console.WriteLine(sum);
            Console.WriteLine(numOfRegions);

        }
    }

    class Square {
        public static Square[,] grid;
        public static int gridSize;

        public int Val { get; set; }
        public bool Visited { get; set; }
        public int x { get; set; }
        public int y { get; set; }

        public Square(int j, int i) {
            Val = 0;
            Visited = false;
            x = j;
            y = i;
        }
        public bool isCoordValid(int i) {
            bool valid = true;
            if (i < 0 || i >= gridSize)
                valid = false;

            return valid;
        }
        public void lookForRegions() {
            if (Visited == true || Val==0) return;
            Visited = true;

            if (isCoordValid(x + 1))
                Square.grid[x + 1, y].lookForRegions();
            if (isCoordValid(x - 1))
                Square.grid[x - 1, y].lookForRegions();
            if (isCoordValid(y - 1))
                Square.grid[x, y - 1].lookForRegions();
            if (isCoordValid(y + 1))
                Square.grid[x, y + 1].lookForRegions();
        }
    }
}
