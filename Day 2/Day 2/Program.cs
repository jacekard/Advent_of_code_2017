using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sum_of_digits {
    class Program {
        static void Main(string[] args) {

            
            int sum1 = 0;
            int sum2 = 0;

            //read input
            string line = "";
            string[] numbers;
            int min = 0, max = 0;
            while (line != null) {
                line = Console.ReadLine();
                if (line == null) break;

                numbers = line.Split('\t');
                List<int> list = new List<int>();

                for (int i = 0; i < numbers.Length; i++) {
                    int.TryParse(numbers[i].ToString(), out int num);
                    list.Add(num);
                    //exercise 1
                    if (i != 0) {
                        if (num < min)
                            min = num;
                        else if (num > max)
                            max = num;
                    }
                    else {
                        min = num;
                        max = num;
                    }
                }
                sum1 += max - min;

                //exercise 2
                for (int i = 0; i < list.Count; i++) {
                    for (int j = 0; j < list.Count; j++) {
                        if (i == j)
                            continue;
                        if (list[j] % list[i] == 0)
                            sum2 += list[j] / list[i];
                    }
                }

                
            }




            Console.WriteLine(sum2);
        }
    }
}