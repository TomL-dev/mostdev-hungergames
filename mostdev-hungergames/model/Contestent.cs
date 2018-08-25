using System;
using System.Collections.Generic;
using System.Text;
using mostdev_hungergames.constants.enums;

namespace mostdev_hungergames.model
{
    abstract class Contestent
    {
        public string Name { get; private set; }
        public Gender Gender { get; private set; }

        private const string Format = "Contestent: {0}, Type: {1}, AttackLevel: {2), DefenseLevel: {3}";
        private int health = 100;
        private int attackLevel = 100;
        private int defenseLevel = 100;

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
            this.health = 100;
        }

        public void attack()
        {

        }
        public void defend()
        {

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
