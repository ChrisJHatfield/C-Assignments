using System;
using System.Collections.Generic;

namespace Hungry_Ninja
{
    class Buffet
    {
        public List<Food> Menu;

        public Buffet()
        {
            Menu = new List<Food>()
            {
                new Food("Apple Pie", 1200, false, false),
                new Food("French Fries", 500, false, false),
                new Food("Garden Salad", 400, false, false),
                new Food("Vindaloo Curry", 800, true, false),
                new Food("Sweet and Spicy Chicken", 600, true, true),
                new Food("Vegetable Stir Fry", 350, false, false),
                new Food("Fruit Salad", 450, false, true)
            };
        }
        public Food Serve()
        {
            Random rand = new Random();
            int selectedEntre = rand.Next(0, Menu.Count);
            return Menu[selectedEntre];
        }
    }
}