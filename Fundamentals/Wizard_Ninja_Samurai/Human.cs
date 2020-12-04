using System;

namespace Wizard_Ninja_Samurai
{
    class Human
    {
        public string Name;
        public int Strength;
        public int Intelligence;
        public int Dexterity;
        public int health;

        // public int Health
        // {
        //     get
        //     {
        //         return health;
        //     }
        // }
        public Human(string name)
        {
            Name = name;
            Strength = 3;
            Intelligence = 3;
            Dexterity = 3;
            health = 100;
        }
        public Human(string name, int strength, int intelligence, int dexterity, int Health)
        {
            Name = name;
            Strength = strength;
            Intelligence = intelligence;
            Dexterity = dexterity;
            health = Health;
        }

        public virtual int Attack(Human target)
        {
            int damage = 3 * Strength;
            target.health -= damage;
            Console.WriteLine($"{Name} attacked {target.Name} for {damage} damage!");
            return target.health;
        }
    }
}