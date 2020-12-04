using System;
using System.Collections.Generic;

namespace Deck_of_Cards
{
    
    class Player
    {
        
        public string Name;
        public List<Card> Hand;

        public Player(string name)
        {
            Name = name;
            Hand = new List<Card>{};
        }

        public Card Draw(Deck deck)
        {
            Card cardDrawn = deck.Deal();
            Hand.Add(cardDrawn);
            return cardDrawn;
        }

        public Card Discard(int index)
        {
            if (index < Hand.Count)
            {
                Card removedCard = Hand[index];
                Hand.Remove(Hand[index]);
                return removedCard;
            }
            else 
            {
                return null;
            }
        }
    }
}