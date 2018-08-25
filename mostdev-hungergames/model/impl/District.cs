using System;
using System.Collections.Generic;
using System.Text;
using mostdev_hungergames.constants.enums;

namespace mostdev_hungergames.model.impl
{
    class District : Contestent
    {
        public District(string name, Gender gender, int defenseBonus) : base(name, gender)
        {
            this.DefenseLevel += defenseBonus;
        }
    }
}
