using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace warCardGameChallenge
{
    public class Battle
    {
        public List<Card> Cards { get; set; }
        private Player _player1;
        private Player _player2;


        public Battle(Player player1, Player player2)
        {
            Cards = new List<Card>();

            _player1 = new Player();
            _player1 = player1;

            _player2 = new Player();
            _player2 = player2;

        }
        public string doBattle()
        {
            string result = "";
            Card card1 = new Card();
            card1 = getCard(_player1);

            Card card2 = new Card();
            card2 = getCard(_player2);

            result += formatDisplayBattleCards(card1, card2);

            string resultBounty = "";
            Player winner = new Player();
            result += compareCards(card1, card2, out winner);
            addCardsToWinnersDeck(winner);

            return result + resultBounty + String.Format("<br/>{0} wins!", winner.Name);

        }

        public Card getCard(Player player)
        {
            if (player.PlayerDeck.ElementAt(0) != null)
            {
                Cards.Add(player.PlayerDeck.ElementAt(0));
            }
            player.PlayerDeck.Remove(player.PlayerDeck.ElementAt(0));
            return Cards.ElementAt(Cards.Count() - 1);
        }

        public string compareCards(Card card1, Card card2, out Player winner)
        {
            string result = "";
            int player1Card = convertCard(card1.Number);
            int player2Card = convertCard(card2.Number);

            if (player1Card > player2Card)
            {
                winner = _player1;
            }
            else if (player2Card > player1Card)
            {
                winner = _player2;
            }
            else
            {
                result += doWar(out winner);
            }

            
            result += formatDisplayBounty();
            return result;
        }

        public int convertCard(string card)
        {
            if (card == "J") return 11;
            else if (card == "Q") return 12;
            else if (card == "K") return 13;
            else if (card == "A") return 14;
            else return int.Parse(card);
        }

        public void addCardsToWinnersDeck(Player player)
        {
            foreach (Card card in Cards)
            {
                player.PlayerDeck.Add(card);
            }
            Cards.Clear();
        }

        public string formatDisplayBattleCards(Card card1, Card card2)
        {
            string result = "";
            result += String.Format("<br/><br/>Battle Cards: {0} of {1} vs {2} of {3}", card1.Number, card1.Suit, card2.Number, card2.Suit);
            
            return result;
        }

        public string formatDisplayBounty()
        {
            string result = "";
            result += String.Format("<br/>Bounty...");
            foreach (Card card in Cards)
            {
                result += String.Format("<br/>&nbsp{0} of {1}", card.Number, card.Suit);
            }
            return result;
        }

        public string doWar(out Player winner)
        {
            Card card1 = new Card();
            Card card2 = new Card();
            string result = "</br>***************WAR***************";
            for (int i = 0; i < 4; i++)
            {
                card1 = getCard(_player1);
                card2 = getCard(_player2);
            }
            result += formatDisplayBattleCards(card1, card2);
            compareCards(card1, card2, out winner);
            return result;
        }
    }
}