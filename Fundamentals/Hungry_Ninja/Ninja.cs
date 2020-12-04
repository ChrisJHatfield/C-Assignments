using System;
using System.Collections.Generic;

namespace Hungry_Ninja
{
    class Ninja
    {
        private int calorieIntake;
        public List<Food> FoodHistory;

        public Ninja()
        {
            calorieIntake = 0;
            FoodHistory = new List<Food>{};
        }

        public bool IsFull
        {
            get
            {
                if(calorieIntake > 1200)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        public void Eat(Food item)
        {
            if (IsFull)
            {
                Console.WriteLine($"The ninja is full and cannot eat anymore food! They ate: {FoodHistory}");
            }
            else
            {
                calorieIntake += item.Calories;
                FoodHistory.Add(item);
                Console.WriteLine($"The ninja ate {item.Name}.");
                if (item.IsSpicy && item.IsSweet)
                {
                    Console.WriteLine("It was spicy and sweet!");
                }
                else if (item.IsSweet)
                {
                    Console.WriteLine("It was sweet!");
                }
                else if (item.IsSpicy)
                {
                    Console.WriteLine("It was spicy!");
                }
            }
        }
    }
}