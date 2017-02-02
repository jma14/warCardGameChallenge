using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace warCardGameChallenge
{
    public class Game
    {
        private Deck _deck { get; set; }
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

            _deck = new Deck();


        }

        public string playGame()
        {
            string result = dealCards();
            
            while (_player1.PlayerDeck.Count() > 0 && _player2.PlayerDeck.Count() > 0)
            {
                Battle battle = new Battle(_player1, _player2);
                result += battle.doBattle();
            }
            

            return result + getWinner();
            
        }

        public string dealCards()
        {
            string result = "";
            while (_deck.Cards.Count > 0)
            {
                result += getNextCard(_player1);
                result += getNextCard(_player2);
            }
            return result;
        }

        public string getNextCard(Player player)
        {
            string result = "";
            int nextCard = _random.Next(_deck.Cards.Count());
            player.PlayerDeck.Add(_deck.Cards.ElementAt(nextCard));
            result += String.Format("<br/> {0} is dealt the {1} of {2}",
                player.Name,
                _deck.Cards.ElementAt(nextCard).Number,
                _deck.Cards.ElementAt(nextCard).Suit);

            _deck.Cards.Remove(_deck.Cards.ElementAt(nextCard));
            return result;

        }

        public string getWinner()
        {
            string result = "<br/><h4>";

            if (_player1.PlayerDeck.Count() > _player2.PlayerDeck.Count()) result += _player1.Name + " wins!";
            else result += _player2.Name + " wins!";
            return result + "</h4>";
        }
    }
}