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
            for (int i = 1; i <= 10; i++)
            {
                _numbers.Add(i.ToString());
            }
            _numbers.Add("J");
            _numbers.Add("Q");
            _numbers.Add("K");
            _numbers.Add("A");
        }

        public void makeDeck()
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 1; j <= 13; j++)
                {
                    Cards.Add(new Card { Suit = _suits[i], Number = _numbers[j] });
                }
            }
        }
    }
}