using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_7 {
    class Program {
        static void Main(string[] args) {
            Lista list = new Lista();
            Dictionary<string, int> map = new Dictionary<string, int>();
            string line = "";
            line = Console.ReadLine();
            while (line != null) {

                string[] elements = line.Split(' ');

                string progName = elements[0];
                //Prog p = new Prog(elements[0], int.Parse(progName));
                //list.Add(p);

                if (!map.ContainsKey(progName)) {
                    map[progName] = 0;
                }

                for (int j = 3; j < elements.Length; j++) {
                    if (j != elements.Length - 1) {
                        string neighborName = elements[j].Substring(0, elements[j].Length - 1);
                        //p.Neighbors.Add(neighborName);
                        if (map.ContainsKey(neighborName))
                            map[neighborName]++;
                        else
                            map[neighborName] = 1;

                    }
                    else {
                        if (map.ContainsKey(elements[j]))
                            map[elements[j]]++;
                        else
                            map[elements[j]] = 1;
                    }
                }
                line = Console.ReadLine();
            }

            var dict = map.OrderBy(x => x.Value);
            Console.WriteLine(dict.First().Key);
            

        }
    }
    class Lista : List<Prog> {
        public Lista() {

        }

    }

    class Prog {
        public string Name { get; set; }
        public Prog Parent { get; set; }
        public int Weight { get; set; }
        public List<string> Neighbors;
        public Prog(string name, int weight) {
            Name = name;
            Weight = weight;
            Neighbors = new List<string>();
        }
        //public Prog getNeighbor(string name) {
        //    foreach(var e in neighbors) {
        //        if (e.Equals(name)) {

        //            return p;
        //        }
        //    }
        //}
    }
}
