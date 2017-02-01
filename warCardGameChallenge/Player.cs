using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace warCardGameChallenge
{
    public class Player
    {
        public string Name { get; set; }
        public int Score { get; set; }
        public List<Card> PlayerDeck { get; set; }

        public Player()
        {
            PlayerDeck = new List<Card>();
        }
    }
}