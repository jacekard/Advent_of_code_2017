//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Day_18 {
//    class Program1 {
//        static void Main(string[] args) {
//            Dictionary<char, long> regs = new Dictionary<char, long>();
//            List<Instruction> list = new List<Instruction>();

//            Instruction instr;
//            long sound = 0;
//            bool isDone = false;

//            string line = Console.ReadLine();
//            while (line != null) {
//                string[] input = line.Split(' ');
//                var name = input[0];


//                if (name.Equals("snd") || name.Equals("rcv")) {
//                    instr = new Instruction() {
//                        Name = name,
//                        Reg = input[1].First()
//                    };
//                }
//                else {
//                    char reg = input[1].First();
//                    if (reg >= 'a' && reg <= 'z') {
//                        if (!regs.ContainsKey(reg))
//                            regs.Add(reg, 0);
//                    }
//                    else reg -= '0';
//                    instr = new Instruction() {
//                        Name = name,
//                        Reg = reg,
//                    };

//                    if (input[2].First() >= 'a' && input[2].First() <= 'z') {
//                        instr.RegParam = input[2].First();
//                        instr.isRegParam = true;
//                    }
//                    else {
//                        instr.Param = int.Parse(input[2]);
//                        instr.isRegParam = false;
//                    }
//                }

//                list.Add(instr);
//                line = Console.ReadLine();
//            }

//            for (int i = 0; i < list.Count && !isDone; i++) {
//                switch (list[i].Name) {
//                    case "snd":
//                    sound = regs[list[i].Reg];
//                    break;
//                    case "set":
//                    if (!list[i].isRegParam)
//                        regs[list[i].Reg] = list[i].Param;
//                    else
//                        regs[list[i].Reg] = regs[list[i].RegParam];
//                    break;
//                    case "add":
//                    if (!list[i].isRegParam)
//                        regs[list[i].Reg] += list[i].Param;
//                    else
//                        regs[list[i].Reg] += regs[list[i].RegParam];

//                    break;
//                    case "mul":
//                    if (!list[i].isRegParam)
//                        regs[list[i].Reg] *= list[i].Param;
//                    else
//                        regs[list[i].Reg] *= regs[list[i].RegParam];
//                    break;
//                    case "mod":
//                    if (list[i].isRegParam)
//                        regs[list[i].Reg] %= regs[list[i].RegParam];
//                    else
//                        regs[list[i].Reg] %= list[i].Param;
//                    break;
//                    case "rcv":
//                    if (regs[list[i].Reg] != 0) {
//                        Console.WriteLine(sound);
//                        isDone = true;
//                    }
//                    break;
//                    case "jgz":
//                    if (list[i].isRegParam) {
//                        if (regs[list[i].Reg] > 0)
//                            i += (int)regs[list[i].RegParam] - 1;
//                    }
//                    else {
//                        if (regs[list[i].Reg] > 0)
//                            i += (int)list[i].Param - 1;
//                    }
//                    break;
//                    default: break;
//                }
//            }
//        }
//    }

//    class Instruction {
//        public string Name { get; set; }
//        public char Reg { get; set; }
//        public bool isRegParam { get; set; }
//        public char RegParam { get; set; }
//        public long Param { get; set; }
//        public Instruction() { }
//    }
//}
