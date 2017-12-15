using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_14 {
    class KnotHash {

        public static string CalculateKnotHash(string input) {
            const int arraySize = 256;
            int position = 0, skip = 0;
            List<int> array = new List<int>();
            List<int> lengths = new List<int>();
            for (int i = 0; i < arraySize; i++) {
                array.Add(i);
            }

            List<int> subArray = new List<int>();
            
            foreach (char c in input) {
                lengths.Add(c);
            }
            lengths.AddRange(new List<int> { 17, 31, 73, 47, 23 });

            for (int x = 0; x < 64; x++) {
                foreach (var length in lengths) {

                    if (position + length > array.Count) {
                        int start = (position + length) % array.Count;
                        subArray = array.GetRange(position, array.Count - position);
                        subArray.AddRange(array.GetRange(0, start));
                    }
                    else {
                        subArray = array.GetRange(position, length);
                    }
                    subArray.Reverse();
                    for (int i = 0; i < subArray.Count; i++) {
                        array[(position + i) % array.Count] = subArray[i];
                    }

                    position += length + skip;
                    position %= arraySize;
                    skip++;
                }
            }

            List<int> dense_hash = new List<int>();
            for (int i = 0; i < 16; i++) {
                int hash = array[i * 16];
                for (int j = 1; j < 16; j++) {
                    hash ^= array[i * 16 + j];
                }
                dense_hash.Add(hash);
            }

            string output ="";

            foreach (int num in dense_hash) {
                if (num < 16)
                    output += '0';                    
                output += num.ToString("X");
            }

            return output;
        }


    }
}



