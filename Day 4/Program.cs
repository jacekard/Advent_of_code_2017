using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_4 {
    class Program {
        static void Main(string[] args) {

            List<Word> list = new List<Word>();
            string line = "";
            int countValidLines1 = 0;
            bool isValid1;
            int countValidLines2 = 0;
            bool isValid2;

            while (line != null) {
                isValid1 = true;
                isValid2 = true;
                line = Console.ReadLine();
                if (line == null)
                    break;

                string[] lines = line.Split(' ');

                //exercise 1
                for (int i = 0; i < lines.Length; i++) {
                    for (int j = 0; j < lines.Length; j++) {
                        if (i == j) continue;
                        if (lines[i].Equals(lines[j]) == true) {
                            isValid1 = false;
                            break;
                        }
                    }
                    if (!isValid1)
                        break;
                }
                if (isValid1)
                    countValidLines1++;

                //exercise 2
                foreach (var name in lines) {
                    Word w = new Word(name);
                    list.Add(w);
                }

                for (int i = 0; i < list.Count; i++) {
                    for (int j = 0; j < list.Count; j++) {
                        if (i == j) continue;

                        if (list[i].Value.Equals(list[j].Value) == true) {
                            isValid2 = false;
                            break;
                        }
                    }
                    if (!isValid2)
                        break;
                }
                if (isValid2)
                    countValidLines2++;

                list.Clear();
            }

            Console.WriteLine(countValidLines1);

            Console.WriteLine(countValidLines2);

        }
    }

    class Word {
        public int Size { get; set; }
        public string Value { get; set; }
        public Word(string value) {
            Value = value;
            Size = 0;
            Sort();
        }
        public void Sort() {
           Value = new string(Value.OrderBy(c => c).ToArray());
        }
    }
}
