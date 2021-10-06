using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication4
{
    class Game
    {
        BullsAndCows bullsAndCows;
        public Game()
        {
            Console.WriteLine("Bulls and Cows");
            bullsAndCows = new BullsAndCows();
            Run();
            Console.Write("Game over . . . ");
        }
        void Run()
        {
            bullsAndCows.Mem();
            while (true)
            {
                string input;
                bool b;
                do
                {
                    input = Read();
                    b = bullsAndCows.Uni(bullsAndCows.fnum);
                    //Console.WriteLine(b);
                } while (!b);
                if (input != "0000")
                {
                    bullsAndCows.Search();
                    Write();
                }
                else
                {
                    break;
                }
            }
        }
        string Read()
        {
            Console.WriteLine("enter number");
            string input = Console.ReadLine();
            if (input != "")
            {
                bullsAndCows.fnum[0] = int.Parse(input[0].ToString());
                bullsAndCows.fnum[1] = int.Parse(input[1].ToString());
                bullsAndCows.fnum[2] = int.Parse(input[2].ToString());
                bullsAndCows.fnum[3] = int.Parse(input[3].ToString());
            }
            else
            {
                input = "0000";
            }
            return input;
        }
        void Write()
        {
            Console.WriteLine("bull(s) {0}", bullsAndCows.bulls);
            Console.WriteLine("cow(s) {0}", bullsAndCows.cows);
        }
    }

    class BullsAndCows
    {
        public int[] mnum;
        public int[] fnum;
        public int bulls;
        public int cows;
        public BullsAndCows()
        {
            bulls = 0;
            cows = 0;
            mnum = new int[4];
            fnum = new int[4];
            
            mnum = new int[4] { 1, 2, 3, 4 };
            fnum = new int[4] { 1, 4, 2, 3 };
        }

        public void Mem()
        {
            Random random = new Random();
            //mnum = new int[4] { 1, 2, 3, 4 };
            mnum = new int[4] { random.Next(9), random.Next(9), random.Next(9), random.Next(9) };
            bool b;
            do
            {
                b = Uni(mnum);
                Console.WriteLine(b);
            } while(!b);
        }

        public bool Uni(int[] num)
        {
            bool b = true;
            for (int i = 0; i < num.Length; i++)
            {
                for (int j = i+1; j < num.Length; j++)
                {
                    if (num[i] == num[j])
                    {
                        b = false;
                        break;
                    }
                }
            }
            return b;
        }

        public void Search()
        {
            bulls = 0;
            for (int i = 0; i < mnum.Length; i++)
            {
                if (mnum[i] == fnum[i])
                {
                    bulls++;
                }
            }
            cows = 0;
            for (int i = 0; i < mnum.Length; i++)
            {
                for (int j = 0; j < mnum.Length; j++)
                {
                    if (i != j)
                    {
                        if (mnum[i] == fnum[j])
                        {
                            cows++;
                        }
                    }
                }
            }
        }

    }

    class Program
    {
        public static void Main(string[] args)
        {
            Game game;
            game = new Game();

            Console.ReadKey(true);
        }
    }
}
