using System;
using System.Collections.Generic;

namespace Day_12 {
    class Program {
        static void Main(string[] args) {
            //How many programs (Progs) belong to 0 Program?
            Dictionary<string, Prog> dict = new Dictionary<string, Prog>();
            string line = Console.ReadLine();
            while (line != null) {
                string[] elements = line.Split(new Char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
                string parent = elements[0];
                if (!dict.ContainsKey(elements[0])) {
                    dict.Add(parent, new Prog(elements[0]));
                }
                for (int i = 2; i < elements.Length; i++) {
                    if (!dict.ContainsKey(elements[i]))
                        dict.Add(elements[i], new Prog(elements[i]));
                    dict[parent].Neighbors.Add(dict[elements[i]]);
                }

                line = Console.ReadLine();
            }

            Console.WriteLine(dict["0"].getHeight());

            int numOfGroups = 1;
            foreach (var prog in dict.Values) {
                if(!prog.Visited) {
                    prog.getHeight();
                    numOfGroups++;
                }
            }
            Console.WriteLine(numOfGroups);
        }
    }

    class Prog {
        public bool Visited;
        public string Id { get; set; }
        public int height { get; set; }
        public List<Prog> Neighbors;

        public Prog(string id) {
            Id = id;
            Visited = false;
            Neighbors = new List<Prog>();
            height = 0;
        }

        public int getHeight() {

            Visited = true;

            height++;
            foreach (var n in Neighbors) {
                if (n.Visited == false)
                    height += n.getHeight();
            }
            return height;
        }


    }
}

