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

        private Random random = new Random();
        public Contestent Winner { get; private set; }
		private int days = 1;

        public void playGame()
        {
            Console.WriteLine("Gathering contestents...");
            contestents.AddRange(generateContestens(Constants.NR_OF_CONTESTENS));
            Console.WriteLine("Now introducing the contestents:");
            contestents.ForEach(x => Console.WriteLine(x.ToString()));
            // loop through game

			while (contestents.Count > 1)
			{
				nextRound();
			}

            Winner = contestents[random.Next(contestents.Count - 1)];

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
            return new BattleItem();
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
			contestents.ForEach(x => x.resetHealth());

			// at end of day surviving contestents have chance of finding battle item
			contestents.ForEach(x => x.searchForBattleItem());
			if (days > 20)
			{
				contestents.RemoveRange(1, contestents.Count-1);
			}


		}
		private void startDuel()
		{
			int rnd1 = random.Next(0, contestents.Count);
			int rnd2 = random.Next(0, contestents.Count);
			while (rnd1 == rnd2)
			{
				rnd2 = random.Next(0, contestents.Count);
			}
			Console.WriteLine("duel with {0} and {1}", rnd1,rnd2);
			Contestent contestent1 = contestents[rnd1];
			Contestent contestent2 = contestents[rnd2];

			
		}
		

    }
}
