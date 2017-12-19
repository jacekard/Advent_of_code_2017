using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_19 {
    class Program {
        static void Main(string[] args) {
            Maze maze = new Maze();
            string line = Console.ReadLine();

            while (line != null) {
                maze.map.Add(line);
                line = Console.ReadLine();
            }

            maze.findLetters();
            Console.WriteLine(maze.result);
            Console.WriteLine(maze.steps);

        }
    }
    enum Dir {
        UP, DOWN, LEFT, RIGHT
    }

    struct Pos {
        public int x;
        public int y;
    }

    class Maze {
        public Dir dir;
        public List<string> map;
        public string result;
        public Pos p;
        public int steps;
        public char Symbol;
        public bool hasFoundResult;
        public Maze() {
            map = new List<string>();
            dir = Dir.DOWN;
            p.y = 0;
            p.x = 0;
            steps = 0;
            hasFoundResult = false;
        }

        public bool hasFoundExit() {
            if (map[p.y][p.x].Equals(' '))
                return true;

            return false;
        }

        public void changeDirection() {
            Symbol = map[p.y][p.x];
            if (Symbol.Equals('+')) {
                if (dir == Dir.DOWN || dir == Dir.UP) {
                    if (map[p.y][p.x + 1].Equals(' '))
                        dir = Dir.LEFT;
                    else dir = Dir.RIGHT;
                }
                else if (dir == Dir.RIGHT || dir == Dir.LEFT) {
                    if (map[p.y + 1][p.x].Equals(' '))
                        dir = Dir.UP;
                    else dir = Dir.DOWN;
                }
            }
            else {
                result += Symbol;
                moveForward();
                if (hasFoundExit())
                    hasFoundResult = true;
            }
        }

        public void moveForward() {
            switch (dir) {
                case Dir.DOWN:
                Symbol = map[++p.y][p.x]; break;
                case Dir.UP:
                Symbol = map[--p.y][p.x]; break;
                case Dir.LEFT:
                Symbol = map[p.y][--p.x]; break;
                case Dir.RIGHT:
                Symbol = map[p.y][++p.x]; break;
            }
            steps++;
        }

        public void findLetters() {
            Symbol = '|';
            p.x = map[p.y].IndexOf(Symbol);

            while (!hasFoundResult) {
                moveForward();
                if (Symbol.Equals('+') || (Symbol >= 'A' && Symbol <= 'Z')) {
                    changeDirection();
                }
            }
        }

    }
}
