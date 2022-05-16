using System.Windows.Forms;

namespace Space
{
    public static class GameText
    {
        public static void UpdateText(Label TxtScore, Label totalScore, Game game)
        {
            TxtScore.Text = "Score: " + game.Score;
            totalScore.Text = "Total score: " + game.TotalSum;
        }
    }
}
