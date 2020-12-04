using System;
using System.Collections.Generic;

namespace Wizard_Ninja_Samurai
{
    class Ninja : Human
    {
        public Ninja(string name) : base(name)
        {
            Name = name;
            Strength = 3;
            Intelligence = 3;
            Dexterity = 175;
            health = 100;
        }
        public override int Attack(Human target)
        {
            Random rand = new Random();
            int bonusDamage = rand.Next(1, 5);
            int damage = 5 * Dexterity;
            target.health -= damage;
            if(bonusDamage == 1)
            {
                target.health -= 10;
                Console.WriteLine($"Bonus Damage dealt! 10 bonus damage!");
                return target.health;
            }
            else
            {
                return target.health;
            }
        }

        public int Steal(Human target)
        {
            int lifeSteal = 5;
            target.health -= lifeSteal;
            health += lifeSteal;
            return target.health;
        }
    }
}