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
        public void playGame()
        {
            Console.WriteLine("Gathering contestents...");
            contestents.AddRange(generateContestens(Constants.NR_OF_CONTESTENS));
            Console.WriteLine("Now introducing the contestents:");
            contestents.ForEach(x => Console.WriteLine(x.ToString()));
            // loop through game
            Winner = contestents[random.Next(contestents.Count - 1)];

        }

        private Contestent[] generateContestens(int nrOfContestents)
        {
            Contestent[] contestents = new Contestent[nrOfContestents];
            for (int i = 0; i < nrOfContestents; i++)
            {
                contestents[i] = getRandomContestent();
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
        private Contestent getRandomContestent()
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

        private Contestent getDistricsContestent(int i)
        {
            return new District(Faker.Name.First(), GetGender(i), random.Next(Constants.MIN_DEFENSE_BONUS, Constants.MAX_DEFENSE_BONUS));
        }

        private Contestent GetCareerContestent(int i)
        {
            return new Career(Faker.Name.First(), GetGender(i), random.Next(Constants.MIN_ATTACK_BONUS, Constants.MAX_ATTACK_BONUS), GetBattleItem());
        }

    }
}
