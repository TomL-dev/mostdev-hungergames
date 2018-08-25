using mostdev_hungergames.model;
using mostdev_hungergames.model.impl;
using System;
using System.Collections.Generic;
using System.Text;

namespace mostdev_hungergames.controller
{
	class BattleItemController
	{
		private Random random = new Random();
		private List<BattleItem> battleItems = new List<BattleItem>();

		public BattleItemController()
		{
			// more rare items with higher impact are added once, making the chance to find one smaller
			battleItems.Add(new BattleAxe());
			battleItems.Add(new BodyArmour());
			// more basic items
			battleItems.Add(new Shield());
			battleItems.Add(new Shield());
			battleItems.Add(new Knife());
			battleItems.Add(new Knife());
			battleItems.Add(new Bat());
			battleItems.Add(new Bat());

		}

		public BattleItem getRandomBattleItem()
		{
			return battleItems[random.Next(battleItems.Count)];
		}
	}
}
