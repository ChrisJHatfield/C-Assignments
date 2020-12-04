using System;
using System.Collections.Generic;

namespace Wizard_Ninja_Samurai
{
    class Wizard : Human
    {
        public Wizard(string name) : base(name)
        {
            Name = name;
            Strength = 3;
            Intelligence = 25;
            Dexterity = 3;
            health = 50;
        }
        public override int Attack(Human target)
        {
            int damage = 5 * Intelligence;
            target.health -= damage;
            health += damage;
            return target.health;
        }
        public int Heal(Human target)
        {
            int heal = 10 * Intelligence;
            target.health += heal;
            return target.health;
        }
    }
}
