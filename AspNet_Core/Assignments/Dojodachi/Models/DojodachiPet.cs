using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System;

namespace Dojodachi.Models
{
    public class DojodachiPet
    {
        public Int32 Happiness { get; set;}
        public Int32 Fullness { get; set; }
        public Int32 Energy { get; set; }
        public Int32 Meals { get; set; }
        public string Message { get; set; }
        public Boolean isAlive { get; set;}
        public Random rand = new Random();

        public DojodachiPet ()
        {
            Happiness = 20;
            Fullness = 20;
            Energy = 20;
            Meals = 3;
            Message = "";
            isAlive = true;
        }


        public DojodachiPet Feed()
        {
            int chanceToNot = rand.Next(1,4);
            int fullness = rand.Next(5, 10);

            if (chanceToNot == 1 && this.Meals > 0){
                this.Meals -= 1;
                this.Message = $"Dojodachi hated the food but still ate it :/ Meals -1";
            }
            else if (chanceToNot != 1 && this.Meals > 0)
            {
                this.Meals -= 1;
                this.Fullness += fullness;
                this.Message = $"Dojodachi loved the food and is pleased! :D Fullness +{fullness}, Meals -1";
            }
            else
            {
                this.Message = $"Dojodachi has no more food! :( Meals -1" ;
            }
            return this;
        }

        public DojodachiPet Play()
        {
            int chanceToNot = rand.Next(1,4);
            int happiness = rand.Next(5,10);

            if (chanceToNot == 1 && this.Energy > 0)
            {
                this.Energy -= 5;
                this.Message = $"You scared your Dojodachi while playing with it! O.o Energy -5";
                return this;
            }
            else if ( this.Energy > 0 )
            {
                this.Energy -= 5;
                this.Happiness += happiness;
                this.Message = $"Your Dojodachi grew closer to you while playing with it :) Happiness +{happiness}, Energy -5";
            }
            this.Message = $"Your Dojodachi is too low on Energy to do anything! -.- Energy: {this.Energy}";
            return this;
        }

        public DojodachiPet Working()
        {
            int earnedMeals = rand.Next(1,3);
            if (this.Energy > 0)
            {
                this.Energy -= 5;
                this.Meals += earnedMeals;
                this.Message = $"The Dojodachi is working hard for those meals! :) Meals +{earnedMeals}, Energy -5";
            }
            this.Message = $"Your Dojodachi is too low on Energy to do anything! -.- Energy: {this.Energy}";
            return this;
        }

        public DojodachiPet Sleeping()
        {
            this.Energy += 15;
            this.Fullness -= 5;
            this.Happiness -= 5;
            if( this.Fullness <= 0 || this.Happiness <= 0)
            {
                this.isAlive = false;
            }
            this.Message = $"Dojodachi falls asleep ZzzZzz. Energy +15, Fullness -5 & Happiness -5";
            return this;
        }

        public DojodachiPet GameOver()
        {
            if (this.Energy >= 100 && this.Fullness >= 100 && this.Happiness >= 100 && this.isAlive)
            {
                this.Message = "Congratulations! Your Dojodachi is unstoppable and you have won the game!";
                return this;
            }
            else if (!this.isAlive)
            {
                this.Message = "Gameover! Should you even own a Dojodachi? Poor thing... Let's go again!";
            }
            return this;
        }
    }
}