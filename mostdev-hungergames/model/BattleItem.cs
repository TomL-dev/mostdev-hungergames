using System;
using System.Collections.Generic;
using System.Text;

namespace mostdev_hungergames.model
{
    class BattleItem
    {
		private int defenseBonus = 0;
		private int attackBonus = 0;

		public int DefenseBonus
		{
			get { return defenseBonus; }
			protected set { defenseBonus = value; }
		}
		public int AttackBonus
		{
			get { return attackBonus; }
			protected set { attackBonus = value; }
		}

		public string Name { get; protected set; }

		public override string ToString()
		{
			string bonus = attackBonus > 0 ? "Attack bonus: " + AttackBonus : "Defense bonus: " + DefenseBonus;
			return String.Format("{0}, {1}", Name, bonus);
		}
	}
}
