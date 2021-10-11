using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    class View
    {
        public void Hello()
        {
            Console.WriteLine("БИКОВЕ И КРАВИ");
        }
        public void IsNotUni(string str)
        {
            Console.WriteLine("в числото {0} има еднакви цифри", str);
        }
        public void GameOver()
        {
            Console.WriteLine("Край на играта . . . ");
        }
        public void Win()
        {
            Console.WriteLine("ПОБЕДА");
        }
        public string Read(int[] num)
        {
            Console.WriteLine("Въведете число");
            string input = Console.ReadLine();
            if (input != "")
            {
                num[0] = int.Parse(input[0].ToString());
                num[1] = int.Parse(input[1].ToString());
                num[2] = int.Parse(input[2].ToString());
                num[3] = int.Parse(input[3].ToString());
            }
            else
            {
                input = "0000";
            }
            return input;
        }
        public void Write(int bulls, int cows)
        {
            Console.WriteLine("bull(s) {0}", bulls);
            Console.WriteLine("cow(s) {0}", cows);
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
            mnum = new int[4] { 1, 2, 3, 4 };
            //mnum = new int[4] { random.Next(9), random.Next(9), random.Next(9), random.Next(9) };
            bool b;
            do
            {
                b = Uni(mnum);
            } while (!b);
        }

        public bool Uni(int[] num)
        {
            bool b = true;
            for (int i = 0; i < num.Length; i++)
            {
                for (int j = i + 1; j < num.Length; j++)
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
    class Game
    {
        BullsAndCows bullsAndCows;
        View view;
        public Game()
        {
            view = new View();
            view.Hello();
            bullsAndCows = new BullsAndCows();
            Run();
            view.GameOver();
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
                    if (input == "0000")
                    {
                        return;
                    }
                    b = bullsAndCows.Uni(bullsAndCows.fnum);
                    if(!b)
                    {
                        view.IsNotUni(input);
                    }
                } while (!b);
                bullsAndCows.Search();
                Write();
                if (bullsAndCows.bulls == 4)
                {
                    view.Win();
                    return;
                }
            }
        }
        string Read()
        {
            return view.Read(bullsAndCows.fnum);
        }
        public void Write()
        {
            view.Write(bullsAndCows.bulls, bullsAndCows.cows);
        }
    }
   

    class Program
    {
        static void Main(string[] args)
        {
            Game game;
            game = new Game();

            Console.ReadKey(true);
        }
    }
}
