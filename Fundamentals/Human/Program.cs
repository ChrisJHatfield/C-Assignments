using System;

namespace Human
{
    class Program
    {
        static void Main(string[] args)
        {
            Human Dedalus = new Human("Dedalus");
            Human Natar = new Human("Natar", 14, 12, 10, 200);
            Natar.Attack(Dedalus);
            Console.WriteLine($"Dedalus has {Dedalus.Health} health remaining.");
        }
    }
}
