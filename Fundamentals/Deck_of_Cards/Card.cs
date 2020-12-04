using System;

namespace Deck_of_Cards
{
    class Card
    {
        public string StringVal;
        public string Suit;
        public int Val;
        public Card(string stringval, string suit, int val)
        {
            StringVal = stringval;
            Suit = suit;
            Val = val;
        }
    }
}