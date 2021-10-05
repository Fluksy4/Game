using System;

namespace GameProgram
{
	class Game
	{
		BullsAndCows bullsAndCows;
		public Game()
		{
			Console.WriteLine("Bulls and Cows");
			bullsAndCows = new BullsAndCows();
			Run();
		}
		void Run()
		{
			bullsAndCows.Mem();
			int x = 1234;
			string s = x.ToString();
			while(true)
			{
				string input = Read();
				//Uni(input);
				if(input != "0000")
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
			bullsAndCows.fnum[0] = int.Parse(input[0].ToString());
			bullsAndCows.fnum[1] = int.Parse(input[1].ToString());
			bullsAndCows.fnum[2] = int.Parse(input[2].ToString());
			bullsAndCows.fnum[3] = int.Parse(input[3].ToString());
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
			mnum = new int[4]  {1, 2, 3, 4};
			fnum = new int[4]  {1, 4, 2, 3};
		}
        
		public void Mem()
		{
			mnum = new int[4]  {1, 2, 3, 4};
			Uni(mnum);
		}
		
		bool Uni(int[] num)
		{
			bool b = false;
			for(int i = 0; i < mnum.Length; i++)
			{
				for(int j = i; j < mnum.Length; j++)
				{
					
				}
			}
			return b;
		}
		
		public void Search()
		{
			bulls = 0;
			for(int i = 0; i < mnum.Length; i++)
			{
				if(mnum[i] == fnum[i])
				{
					bulls++;
				}
			}
			cows = 0;
			for(int i = 0; i < mnum.Length; i++)
			{
				for(int j = 0; j < mnum.Length; j++)
				{
					if(i != j)
					{
						if(mnum[i] == fnum[j])
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
			
			Console.Write("Game over . . . ");
			Console.ReadKey(true);
		}
	}
}
