using System;
using System.Collections.Generic;

namespace Deck_of_Cards
{
    class Deck
    {
        public List<Card> cards = new List<Card>{};
        
        public Deck()
        {
            string[] stringval = new string[]{"Ace", "2", "3","4","5","6","7","8","9","10","Jack","Queen","King"};
            string[] suits = new string[]{"Clubs", "Spades", "Hearts", "Diamonds"};
            int[] val = new int[]{1,2,3,4,5,6,7,8,9,10,11,12,13};
            foreach (string suit in suits)
            {
                for (int i = 0; i < stringval.Length; i++)
                {
                    Card card = new Card(stringval[i], suit, val[i]);
                    cards.Add(card);
                }
            }
        }
        public Card Deal()
        {
            Card topCard = cards[0];
            cards.Remove(cards[0]);
            return topCard;
        }
        public void Shuffle()
        {
            Random rand = new Random();
            Card placeHolder;
            for (int i = 0; i < cards.Count; i++)
            {
                int randomIdx = rand.Next(0, cards.Count);
                placeHolder = cards[i];
                cards[i] = cards[randomIdx];
                cards[randomIdx] = placeHolder;
            }
        }
        public void Reset()
        {
            Deck deck = new Deck();
        }
    }
}