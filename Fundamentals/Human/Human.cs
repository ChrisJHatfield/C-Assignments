using System;

namespace Human 
{
    class Human
    {
        public string Name;
        public int Strength;
        public int Intelligence;
        public int Dexterity;
        private int health;

        public int Health
        {
            get
            {
                return health;
            }
        }
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

        public int Attack(Human target)
        {
            int damage = 5 * target.Strength;
            target.health -= damage;
            Console.WriteLine($"{target.Name} takes {damage} damage!");
            return target.health;
        }

    }
}