using mostdev_hungergames.model;
using mostdev_hungergames.model.impl;
using System;
using System.Collections.Generic;
using System.Text;
using mostdev_hungergames.constants;
using mostdev_hungergames.constants.enums;

namespace mostdev_hungergames.controller
{
	class GameController
	{
		private List<Contestent> contestents = new List<Contestent>();
		public static readonly OutputController outputController = new OutputController();

		public static BattleItemController battleItemController = new BattleItemController();
		int days = 1;
		private Random random = new Random();

		public void playGame()
		{
			outputController.Log("Welcome to the");
			outputController.Log(@"
    )            )               (                       *          (     
 ( /(         ( /(  (            )\ )  (        (      (  `         )\ )  
 )\())    (   )\()) )\ )    (   (()/(  )\ )     )\     )\))(   (   (()/(  
((_)\     )\ ((_)\ (()/(    )\   /(_))(()/(  ((((_)(  ((_)()\  )\   /(_)) 
 _((_) _ ((_) _((_) /(_))_ ((_) (_))   /(_))_ )\ _ )\ (_()((_)((_) (_))   
| || || | | || \| |(_)) __|| __|| _ \ (_)) __|(_)_\(_)|  \/  || __|/ __|  
| __ || |_| || .` |  | (_ || _| |   /   | (_ | / _ \  | |\/| || _| \__ \  
|_||_| \___/ |_|\_|   \___||___||_|_\    \___|/_/ \_\ |_|  |_||___||___/ 

");
			outputController.Log("Gathering contestents...");
			contestents.AddRange(generateContestens(Constants.NR_OF_CONTESTENS));
			outputController.Log("Now introducing the contestents:");
			contestents.ForEach(contestent => outputController.Log(contestent.Introduce()));
			// loop through game

			while (contestents.Count > 1)
			{
				nextRound();
			}

			Contestent winner = contestents[0];
			Console.WriteLine("The winner is: " + winner.Name);
			Console.WriteLine(Environment.NewLine + "President Snow kills the winner: " + winner.Name);
			Console.ReadLine();
		}

		private Contestent[] generateContestens(int nrOfContestents)
		{
			Contestent[] contestents = new Contestent[nrOfContestents];
			for (int i = 0; i < nrOfContestents; i++)
			{
				contestents[i] = getContestent();
			}
			return contestents;
		}

		private Gender GetGender(int i)
		{
			return i % 2 == 0 ? Gender.Female : Gender.Male;
		}

		private BattleItem GetBattleItem()
		{
			return battleItemController.GetRandomBattleItem();
		}

		/// <summary>
		/// Get random contestent
		/// </summary>
		/// <returns>a Contestent</returns>
		private Contestent getContestent()
		{
			int randomValue = random.Next(0, 100);
			if (randomValue < 75)
			{
				return getDistricsContestent(randomValue);
			}
			else
			{
				return GetCareerContestent(randomValue);
			}
		}

		/// <summary>
		/// generate a district contestent
		/// </summary>
		/// <param name="i">if i%2==0 the gender will be female, else male</param>
		/// <returns>District contestent with a random defense bonus</returns>
		private Contestent getDistricsContestent(int i)
		{
			return new District(Faker.Name.First(), GetGender(i), random.Next(Constants.MIN_DEFENSE_BONUS, Constants.MAX_DEFENSE_BONUS));
		}

		/// <summary>
		/// generate a career contestent
		/// </summary>
		/// <param name="i">if i%2==0 the gender will be female, else male</param>
		/// <returns>Career contestent with a random attack bonus and a chance on an battle item</returns>
		private Contestent GetCareerContestent(int i)
		{
			return new Career(Faker.Name.First(), GetGender(i), random.Next(Constants.MIN_ATTACK_BONUS, Constants.MAX_ATTACK_BONUS), GetBattleItem());
		}

		private void nextRound()
		{
			Console.WriteLine("\nday {0} has started, {1} contestents are alive", days++, contestents.Count);
			// single round:
			// pick N contestents and let them fight a duel. 
			// duel based on attack defense and chance
			startDuel();
			// check if any of the contestents has died
			contestents.RemoveAll(x => x.Health < 1);

			// at end of day all health is restored
			contestents.ForEach(x => x.ResetHealth());

			// at end of day surviving contestents have chance of finding battle item
			contestents.ForEach(x => x.SearchForBattleItem());
		}
		private void startDuel()
		{
			int rnd1 = random.Next(0, contestents.Count);
			int rnd2 = random.Next(0, contestents.Count);
			while (rnd1 == rnd2)
			{
				rnd2 = random.Next(0, contestents.Count);
			}
			Console.WriteLine("duel with {0} and {1}", rnd1, rnd2);
			Contestent contestent1 = contestents[rnd1];
			Contestent contestent2 = contestents[rnd2];
			Console.WriteLine("contestent1: " + contestent1.ShowDuelStats());
			Console.WriteLine("contestent2: " + contestent2.ShowDuelStats());
			while (!contestent1.IsDead() && !contestent2.IsDead())
			{
				Console.WriteLine("----------------------------------------------------------------");
				Console.WriteLine("{0}({1}) attacks {2}({3})", contestent1.Name, contestent1.Health, contestent2.Name, contestent2.Health);
				contestent1.Attack(contestent2);
				if (!contestent1.IsDead() && !contestent2.IsDead())
				{
					Console.WriteLine("{0}({1}) attacks {2}({3})", contestent2.Name, contestent2.Health, contestent1.Name, contestent1.Health);
					contestent2.Attack(contestent1);
				}
				Console.WriteLine("----------------------------------------------------------------");
				//Console.ReadLine();
			}
			Contestent duelWinner = null;

			if (!contestent1.IsDead())
			{
				duelWinner = contestent1;

			}
			else
			{
				duelWinner = contestent2;
			}
			Console.WriteLine("{0} is the winner of the Dual ({1} vs {2})", duelWinner.Name, contestent1.Name, contestent2.Name);

		}


	}
}
