using System;
using System.Collections.Generic;
using System.Text;

namespace mostdev_hungergames.constants
{
	/// <summary>
	/// for now an sort of config for tweaking the game settings. 
	/// future: add ui and make these values configurable from the ui
	/// </summary>
    static class Constants
    {
		public static bool EXTENDED_LOG = true;

		public static int HEALTH = 100;

        public static int NR_OF_CONTESTENS = 24;

		public static int RARE_ATTACK_BONUS_RANGE = 1000;
		public static int RARE_ATTACK_BONUS_THRESHOLD = 950;
		public static int RARE_ATTACK_BONUS_MIN = 25;
		public static int RARE_ATTACK_BONUS_MAX = 45;

		public static int FIND_BATTLE_ITEM_THRESHOLD = 20;

		// for battle items
		// for initiial starting bonus
        public static int MIN_ATTACK_BONUS = 2;
        public static int MAX_ATTACK_BONUS = 15;
        public static int MIN_DEFENSE_BONUS = 0;
        public static int MAX_DEFENSE_BONUS = 10;

		// random bonus damage during duels
		public static int MIN_DUEL_ATTACK_BONUS = 5;
		public static int MAX_DUEL_ATTACK_BONUS = 20;
		public static int MIN_DUEL_DEFENSE_BONUS = 0;
		public static int MAX_DUEL_DEFENSE_BONUS = 10;

    }
}
