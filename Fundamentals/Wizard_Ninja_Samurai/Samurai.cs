using System;
using System.Collections.Generic;

namespace Wizard_Ninja_Samurai
{
    class Samurai : Human
    {
        public Samurai(string name) : base(name)
        {
            Name = name;
            Strength = 3;
            Intelligence = 3;
            Dexterity = 3;
            health = 200;
        }
        public override int Attack(Human target)
        {
            int currentHealth = base.Attack(target);
            if(currentHealth < 50)
            {
                target.health -= 50;
                Console.WriteLine($"Executioner's Calling procced since target was less than 50 health and has slain the enemy!");
                return target.health;
            }
            else
            {
                return target.health;
            }
        }

        public void Meditate()
        {
            health = 200;
        }
    }
}