using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace warCardGameChallenge
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void playButton_Click(object sender, EventArgs e)
        {
            string result = "";
            Game game = new Game("Player 1", "Player 2");
            result += game.dealCards();
            result += game.playGame();

            resultLabel.Text = result;
            
        }
    }
}