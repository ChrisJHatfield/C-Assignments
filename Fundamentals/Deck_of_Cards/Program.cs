using System;

namespace Deck_of_Cards
{
    class Program
    {
        static void Main(string[] args)
        {
            Deck deck = new Deck();
            Player Chris = new Player("Chris");
            deck.Shuffle();
            Chris.Draw(deck);
            Chris.Draw(deck);
            Chris.Draw(deck);
            Chris.Draw(deck);
            Chris.Draw(deck);
            Chris.Draw(deck);
            Chris.Draw(deck);
            Console.WriteLine(Chris.Hand);
            Chris.Discard(0);
            Chris.Discard(0);
            Chris.Discard(0);
            Chris.Discard(0);
            Chris.Discard(0);
            Chris.Discard(0);
            Chris.Discard(0);
            Console.WriteLine(Chris.Discard(0));

            // deck.Reset();
        }
    }
}