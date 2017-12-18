//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Day_17 {
//    class Program1 {
//        static void Main(string[] args) {
//            const int steps = 386;
//            const int insertions = 2017;
//            List<int> list = new List<int>() { 0 };

//            int currPosition = 0;
//            for (int i = 1; i <= insertions; i++) {
//                currPosition = (currPosition + steps) % list.Count;
//                list.Insert(++currPosition, i);
//            }

//            Console.WriteLine(list[currPosition+1]);
//            Console.WriteLine(list[1]);

//        }
//    }
//}
