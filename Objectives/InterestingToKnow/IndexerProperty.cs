using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace InterestingToKnow
{
    class Deck
    {
        public IList<Card> Cards { get; private set; } = new Collection<Card>();

        public Card this[int index]
        {
            get { return Cards.ElementAt(index); }
            set { Cards[index] = value; }
        }
    }

    class Card
    {
        public int CardNumber { get; set; }

        public Card(int number)
        {
            CardNumber = number;
        }

        public static implicit operator int(Card card)
        {
            return card.CardNumber;
        }
    }

    public static class IndexerProperty
    {
        public static void Run()
        {
            var random = new Random();

            var deck = new Deck();
            deck.Cards.Add(new Card(random.Next(0, 999)));
            deck.Cards.Add(new Card(random.Next(0, 999)));
            deck.Cards.Add(new Card(random.Next(0, 999)));
            deck.Cards.Add(new Card(random.Next(0, 999)));
            deck.Cards.Add(new Card(random.Next(0, 999)));

            int a = deck[2];
            deck[2] = new Card(random.Next(0, 999));
            int b = deck[2];

            Console.WriteLine($"a: {a}, b: {b}");

        }
    }
}