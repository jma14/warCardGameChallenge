using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace warCardGameChallenge
{
    public class Game
    {
        public Deck Deck { get; set; }
        private Player _player1;
        private Player _player2;
        private Random _random;

        public Game(string name1, string name2)
        {
            _player1 = new Player();
            _player1.Name = name1;

            _player2 = new Player();
            _player2.Name = name2;

            _random = new Random();

            Deck = new Deck();

        }

        public string dealCards()
        {
            string result = "";
            while (Deck.Cards.Count > 0)
            {
                result += getNextCard(_player1);
                result += getNextCard(_player2);
            }
            return result;
        }

        public string getNextCard(Player player)
        {
            string result = "";
            int nextCard = _random.Next(Deck.Cards.Count());
            player.PlayerDeck.Add(Deck.Cards.ElementAt(nextCard));
            result += String.Format("<br/> {0} is dealt the {1} of {2}",
                player.Name,
                Deck.Cards.ElementAt(nextCard).Number,
                Deck.Cards.ElementAt(nextCard).Suit);

            Deck.Cards.Remove(Deck.Cards.ElementAt(nextCard));
            return result;

        }
    }
}