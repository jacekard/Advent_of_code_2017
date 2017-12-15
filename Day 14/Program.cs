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
            const int gridSize = 128;
            string hash = "oundnydw-";
            int[,] grid = new int[gridSize];
            int sum = 0;
            for (int i = 0; i < gridSize; i++) {
                string newhash = KnotHash.CalculateKnotHash(hash + i);
                StringBuilder row = new StringBuilder();
                Console.WriteLine(newhash);
                foreach (char z in newhash) {
                    row.Append(hexCharToBin[char.ToLower(z)]);
                }
                foreach(char z in row.ToString()) {
                    sum += z - '0';
                }
            }
            Console.WriteLine(sum);
        }
    }

    class Square {
        public Square() {

        }
    }
}
