using System;
using System.Collections.Generic;
using System.Text;
using mostdev_hungergames.constants;
using mostdev_hungergames.constants.enums;
using mostdev_hungergames.controller;

namespace mostdev_hungergames.model
{
    abstract class Contestent
    {
		private Random random = new Random();
		private BattleItemController battleItemController = new BattleItemController();

        public string Name { get; private set; }
        public Gender Gender { get; private set; }

        private const string Format = "Contestent: {0}, Type: {1}, AttackLevel: {2), DefenseLevel: {3}";
        private int health = Constants.HEALTH;
        private int attackLevel = 100;
        private int defenseLevel = 100;

		public BattleItem battleItem { get; set; }

		public int AttackLevel
        {
            get { return attackLevel; }
            protected set { attackLevel = value; }
        }

        public int DefenseLevel
        {
            get { return defenseLevel; }
            protected set { defenseLevel = value; }
        }


        public int Health
        {
            get { return health; }
            private set { health = value; }
        }

        protected Contestent(string name, Gender gender)
        {
            this.Name = name;
            this.Gender = gender;
        }

        public void resetHealth()
        {
            this.health = Constants.HEALTH;
        }

        public void attack(Contestent contestent)
        {

        }
        public void defend(Contestent contestent)
        {

        }

		public void searchForBattleItem()
		{
			if (this.battleItem == null)
			{
				if (random.Next(0, 100) < 25)
				{
					this.battleItem = battleItemController.getRandomBattleItem();
					Console.Write("{0} found a new BattleItem:  {1}, ", this.Name, this.battleItem.Name);
					if (this.battleItem.AttackBonus > 0)
					{
						Console.WriteLine("Attack bonus: {0}", this.battleItem.AttackBonus);
					}
					else
					{
						Console.WriteLine("Defense bonus: {0}", this.battleItem.DefenseBonus);
					}
				}
			}
		}

        public override string ToString()
        {
            string type = GetType().ToString().Substring(GetType().ToString().LastIndexOf('.') + 1);
            return String.Format("Name: {0,10}, Type: {1,10}, Attack: {2} Defense: {3}", Name, type, AttackLevel, DefenseLevel);
            //Console.WriteLine(s);
            //return string.Format(Format, Name, "", AttackLevel.ToString(), DefenseLevel.ToString());
        }
    }
}
