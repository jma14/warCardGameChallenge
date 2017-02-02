using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace warCardGameChallenge
{
    public class Deck
    {
        public List<Card> Cards;
        private List<string> _suits;
        private List<string> _numbers;

        public Deck()
        {
            Cards = new List<Card>();
            _suits = new List<string>();
            _numbers = new List<string>();
            makeSuits();
            makeNumbers();
            makeDeck();
        }


        public void makeSuits()
        {
            _suits.Add("Hearts");
            _suits.Add("Spades");
            _suits.Add("Diamonds");
            _suits.Add("Clubs");
        }

        public void makeNumbers()
        {
            for (int i = 2; i <= 10; i++)
            {
                _numbers.Add(i.ToString());
            }
            _numbers.Add("Jack");
            _numbers.Add("Queen");
            _numbers.Add("King");
            _numbers.Add("Ace");
        }

        public void makeDeck()
        {
            foreach(string suit in _suits)
            {
                foreach (string number in _numbers)
                {
                    Cards.Add(new Card { Suit = suit, Number = number });
                }
            }
        }
    }
}