//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Day_10 {
//    class Program1 {
//        static void Main(string[] args) {
//            const int arraySize = 256;
//            int position = 0, skip = 0;
//            List<int> array = new List<int>();

//            for (int i = 0; i < arraySize; i++) {
//                array.Add(i);
//            }

//            List<int> subArray = new List<int>();
//            string[] line = Console.ReadLine().Split(',');

//            foreach (var len in line) {
//                int length = int.Parse(len);

//                if (position + length > array.Count) {
//                    int start = (position + length) % array.Count;
//                    subArray = array.GetRange(position, array.Count - position);
//                    subArray.AddRange(array.GetRange(0, start));
//                }
//                else {
//                    subArray = array.GetRange(position, length);
//                }
//                subArray.Reverse();
//                for (int i = 0; i < subArray.Count; i++) {
//                    array[(position + i) % array.Count] = subArray[i];
//                }
//                position += length + skip;
//                position %= arraySize;
//                skip++;
//            }

//            Console.WriteLine(array[0] * array[1]);
//        }


//    }
//}
