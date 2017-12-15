using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_13 {
    class Program {
        static void Main(string[] args) {

            List<Layer> list = new List<Layer>();
            string line = Console.ReadLine();
            while (line != null) {
                string[] elements = line.Split(new char[] { ' ', ':' }, StringSplitOptions.RemoveEmptyEntries);
                int depth = int.Parse(elements[0]);
                int range = int.Parse(elements[1]);
                list.Add(new Layer(depth, range));
                line = Console.ReadLine();
            }
            int severity = 0;
            int actualSize = list[list.Count-1].Depth;
            //Part 1
            for (int i = 0; i < actualSize; i++) {
                if (i < list.Count && list[i].Scaner == 0)
                    severity += list[i].Depth * list[i].Range;
                foreach (var layer in list) {
                    layer.moveScaner();
                }
            }
            Console.WriteLine(severity);

            // part 2
            int delay = 0;
            while (true) {
            bool good = true;
                delay++;
                foreach (var layer in list) {
                    if ((layer.Depth + delay) % (2 * layer.Range - 2) == 0) {
                        good = false;
                        break;
                    }
                }
                if (good) {
                    Console.WriteLine(delay);
                    break;
                }
            }
        }

    }

}

class Layer {
    public int Depth { get; set; }
    public int Range { get; set; }
    public int Scaner { get; set; }
    public bool movingUp { get; set; }
    public Layer(int depth, int range) {
        Depth = depth;
        Range = range;
        Scaner = 0;
        movingUp = false;
    }
    public void moveScaner() {
        if (Scaner == Range-1)
            movingUp = true;
        else if (Scaner == 0)
            movingUp = false;
        if (movingUp)
            Scaner--;
        else
            Scaner++;

    }
}

