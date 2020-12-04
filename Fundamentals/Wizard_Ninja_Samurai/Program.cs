using System;

namespace Wizard_Ninja_Samurai
{
    class Program
    {
        static void Main(string[] args)
        {
            Samurai Dedalus = new Samurai("Dedalus");
            Human Natar = new Human("Natar", 14, 12, 10, 200);
            Wizard Deadover = new Wizard("Deadover");
            Ninja Yodacam = new Ninja("Yodacam");
            Samurai Baktula = new Samurai("Baktula");
            Console.WriteLine(Deadover);
            Console.WriteLine(Yodacam);
            Console.WriteLine(Baktula);
            // Natar.Attack(Dedalus);
            // Console.WriteLine($"Dedalus has {Dedalus.health} health remaining.");
            // Deadover.Attack(Dedalus);
            // Console.WriteLine($"Dedalus has {Dedalus.health} health remaining.");
            // Yodacam.Attack(Dedalus);
            // Console.WriteLine($"Dedalus has {Dedalus.health} health remaining.");
            // Baktula.Attack(Dedalus);
            // Baktula.Attack(Dedalus);
            // Baktula.Attack(Dedalus);
            // Baktula.Attack(Dedalus);
            // Baktula.Attack(Dedalus);
            // Dedalus.Meditate();
            Yodacam.Steal(Dedalus);
            Yodacam.Attack(Dedalus);
            Console.WriteLine($"Dedalus has {Dedalus.health} health remaining.");
        }
    }
}
