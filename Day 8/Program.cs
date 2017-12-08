using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_8 {
    class Program {
        static void Main(string[] args) {

            string line = "";
            line = Console.ReadLine();

            while (line != null) {
                string[] words = line.Split(' ');
                string Id = words[0];
                string instruction = words[1];
                int value = int.Parse(words[2]);

                string[] condition = new string[words.Length-4];
                for(int i = 0; i+4 < words.Length; i++) {
                    condition[i] = words[i+4];
                }

                Var var = new Var(Id);
                var = Var.List.Add(var);
                var.evaluateCondition(condition);
                var.evaluateInstruction(instruction, value);

                line = Console.ReadLine();
            }

            int result = Var.List.First().Val;
            foreach(var v in Var.List) {
                if (v.Val > result)
                    result = v.Val;
            }
            Console.WriteLine(result);
            Console.WriteLine(Var.highestValueEver);

        }
    }
    class Lista : List<Var> {
        public Var Add(Var obj) {
            Var var = Var.List.Find(x => x.Id.Equals(obj.Id));
            if(var == null) {
                base.Add(obj);
                return obj;
            }
            else {
                return var;
            }
        }

        public Lista() : base() {}
    }

    class Var {
        public string Id { get; set; }
        public int Val { get; set; }
        public bool canExecute { get; set; }
        public static Lista List = new Lista();
        public static int highestValueEver = 0;
        public Var(string id) {
            Val = 0;
            Id = id;
            canExecute = false;
        }

        public void evaluateCondition(string[] condition) {
            string id = condition[0];
            Var var = new Var(id);
            var = List.Add(var);
            string symbol = condition[1];
            int value = int.Parse(condition[2]);
            switch(symbol) {
                case "<":
                canExecute = var.Val < value ? true : false; 
                break;

                case ">":
                canExecute = var.Val > value ? true : false;
                break;

                case "<=":
                canExecute = var.Val <= value ? true : false;
                break;

                case ">=":
                canExecute = var.Val >= value ? true : false;
                break;

                case "==":
                canExecute = var.Val == value ? true : false;
                break;

                case "!=":
                canExecute = var.Val != value ? true : false;
                break;
            }

        }

        public void evaluateInstruction(string instruction, int value) { 
            if(!canExecute) return;

            //if (Val > Var.highestValueEver)
              //  Var.highestValueEver = value;

            switch (instruction) {
                case "inc":
                Val += value;
                break;
                case "dec":
                Val -= value;
                break;
            }

            if (Val > Var.highestValueEver)
                Var.highestValueEver = Val;

            canExecute = false;
        }
    }
}
