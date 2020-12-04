using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;

namespace Random_Passcode.Models
{
    public class PassCode
    {
        [Required]
        [MinLength(14)]
        [Display(Name="Random passcode (passcode #1")]
        public string RandomString { get; set; }

        public PassCode (){
            RandomString = this.RandomGenerator();
        }

        public string RandomGenerator()
        {
            string randGen = "";
            string numbersAlphabet = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            Random rand = new Random();
            int randIdx = rand.Next(0,35);

            for (int i = 0; i < 14; i++)
            {
                randIdx = rand.Next(0,35);
                randGen += numbersAlphabet[randIdx];
            }
            
            return randGen;
        }
    }
}