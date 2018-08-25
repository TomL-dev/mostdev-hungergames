using System;
using System.Collections.Generic;
using System.Text;
using mostdev_hungergames.constants.enums;

namespace mostdev_hungergames.model.impl
{
    class Career : Contestent
    {
        public Career(string name, Gender gender, int attackBonus, BattleItem battleItem) : base(name, gender)
        {
            this.AttackLevel += attackBonus;
        }
    }
}
