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
	}
}
