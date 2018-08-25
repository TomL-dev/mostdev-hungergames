using System;
using System.Collections.Generic;
using System.Text;
using mostdev_hungergames.constants.enums;

namespace mostdev_hungergames.model
{
    abstract class Contestent
    {
        public string name { get; private set; }
        public Gender gender { get; private set; }
        public int attackLevel { get; private set; }
        public int defenseLevel { get; private set; }
        public int health { get; set; }

        protected Contestent(string name, Gender gender, int health, int attackLevel, int defenseLevel)
        {
            this.name = name;
            this.gender = gender;
            this.health = health;
            this.attackLevel = attackLevel;
            this.defenseLevel = defenseLevel;
        }

     


        
    }
}
