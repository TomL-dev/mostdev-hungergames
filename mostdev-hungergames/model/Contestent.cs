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

		public string Name { get; private set; }
		public Gender Gender { get; private set; }

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

		public void ResetHealth()
		{
			this.health = Constants.HEALTH;
		}

		public void Attack(Contestent opponent)
		{
			int randomBonusDamage = getRandomAttackBonus();

			int damage = this.attackLevel;

			if (battleItem != null)
			{
				damage += battleItem.AttackBonus;
			}
			int rareAttackBonus = getRareAttackBonus();
			if (rareAttackBonus > 0)
			{
				OutputController.Log("Rare attack bonus: {0}", rareAttackBonus);
				randomBonusDamage += rareAttackBonus;
			}
			damage += randomBonusDamage;

			OutputController.Log("Attack: {0}({1}) ", damage, randomBonusDamage);
			opponent.Defend(damage);
		}

		public void Defend(int receivedAttack)
		{
			int randomBonusDefense = random.Next(Constants.MIN_DUEL_DEFENSE_BONUS, Constants.MAX_DUEL_DEFENSE_BONUS); // add random defense bonus
			int defense = DefenseLevel + randomBonusDefense;
			if (battleItem != null)
			{
				defense += battleItem.DefenseBonus;
			}
			OutputController.Log("Defense: {0}({1})", defense, randomBonusDefense);
			int delta = receivedAttack - defense;

			if (delta > 0)
			{
				this.health -= delta;
				OutputController.Log("Received damage: {0}, Health now: {1}", delta, health);
			}
			else
			{
				OutputController.Log("Defended the attack");
			}
			OutputController.Log("");
		}

		public bool IsDead()
		{
			return health <= 0;
		}

		public void SearchForBattleItem()
		{
			if (this.battleItem == null)
			{
				if (random.Next(0, 100) < Constants.FIND_BATTLE_ITEM_THRESHOLD)
				{
					this.battleItem = GameController.battleItemController.GetRandomBattleItem();
					OutputController.AddToSummary("{0} found a new BattleItem: {1}", this.Name, this.battleItem);
				}
			}
		}

		private int getRandomAttackBonus()
		{
			return getRandomValue(Constants.MIN_DUEL_ATTACK_BONUS, Constants.MAX_DUEL_ATTACK_BONUS);
		}

		private int getRandomDefenceBonus()
		{
			return getRandomValue(Constants.MIN_DUEL_DEFENSE_BONUS, Constants.MAX_DUEL_DEFENSE_BONUS);
		}

		private int getRareAttackBonus()
		{
			int chance = getRandomValue(0, Constants.RARE_ATTACK_BONUS_RANGE);
			if (chance > Constants.RARE_ATTACK_BONUS_THRESHOLD)
			{
				return getRandomValue(Constants.RARE_ATTACK_BONUS_MIN, Constants.RARE_ATTACK_BONUS_MAX);
			}
			else
			{
				return 0;
			}
		}
		private int getRandomValue(int minValue, int maxValue)
		{
			return random.Next(minValue, maxValue);
		}

		private string GetTypeString()
		{
			return GetType().ToString().Substring(GetType().ToString().LastIndexOf('.') + 1);
		}

		public override string ToString()
		{
			return String.Format("Name: {0}, Type: {1}", Name, GetTypeString());
		}

		public string Introduce()
		{
			string introduction = String.Format("Name: {0,10}, Type: {1,10}, Attack: {2} Defense: {3}", Name, GetTypeString(), AttackLevel, DefenseLevel);
			if (this.battleItem != null)
			{
				introduction += String.Format(", BattleItem: {0}", battleItem.ToString());
			}
			return introduction;
		}

		public string ShowDuelStats()
		{
			string s = String.Format("Name: {0}, Type: {1}, Attack: {2}, Defense: {3}", Name, GetTypeString(), AttackLevel, DefenseLevel);
			if (this.battleItem != null)
			{
				s += String.Format(", BattleItem: {0}", battleItem.ToString());
			}
			return s;
		}
	}
}
