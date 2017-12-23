using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_20 {
    class Program {
        static void Main(string[] args) {
            string line = Console.ReadLine();
            List<Particle> list = new List<Particle>();
            int id = 0;
            List<Particle> collisions = new List<Particle>();

            while (line != null) {
                string[] input = line.Split(new char[] { ' ', ',', '=', '>', '<', 'p', 'v', 'a' },
                    StringSplitOptions.RemoveEmptyEntries);
                Vector pos = new Vector(int.Parse(input[0]), int.Parse(input[1]), int.Parse(input[2]));
                Vector vel = new Vector(int.Parse(input[3]), int.Parse(input[4]), int.Parse(input[5]));
                Vector acc = new Vector(int.Parse(input[6]), int.Parse(input[7]), int.Parse(input[8]));

                list.Add(new Particle(id, pos, vel, acc));
                ++id;
                line = Console.ReadLine();
            }

            for (int i = 0; i < 1000; i++) {
                foreach (var p in list) {
                    p.updateParticle();
                }
                for (int j = 0; j < list.Count; j++)  {
                    collisions = list.FindAll(x => x.Pos.Equals(list[j].Pos));
                    if (collisions.Count > 1) {
                        for (int k = 0; k < collisions.Count; k++) {
                            list.RemoveAt(k);
                        }
                    }
                }
            }

            //part 1
            int min = list[0].countDistance();
            foreach (var p in list) {
                if (p.countDistance() <= min) {
                    min = p.distance;
                    id = p.Id;
                }
                Console.WriteLine(p.Id + " " + p.Pos + " | " + p.Vel + " | " + p.Acc);

            }

            //part 1
            //Console.WriteLine(id);
            //part 2
            Console.WriteLine(list.Count);



        }
    }

    class Vector {
        public int x;
        public int y;
        public int z;
        public Vector(int a, int b, int c) {
            x = a;
            y = b;
            z = c;
        }
        public void AddVector(Vector v) {
            x += v.x;
            y += v.y;
            z += v.z;
        }
        public override string ToString() {
            return "(" + x + "," + y + "," + z + ")";
        }
        override
        public  bool Equals(object item) {
            var obj = item as Vector;

            if (x == obj.x && y == obj.y && z == obj.z)
                return true;
            else return false;
        }

    }

    class Particle {
        public int Id;
        public Vector Pos;
        public Vector Vel;
        public Vector Acc;
        public int distance;
        public Particle(int id, Vector pos, Vector vel, Vector acc) {
            Id = id;
            Pos = pos;
            Vel = vel;
            Acc = acc;
        }
        public int countDistance() {
            distance = Math.Abs(Pos.x) + Math.Abs(Pos.y) + Math.Abs(Pos.z);
            return distance;
        }
        public void updateParticle() {
            Vel.AddVector(Acc);
            Pos.AddVector(Vel);
        }
    }
}
