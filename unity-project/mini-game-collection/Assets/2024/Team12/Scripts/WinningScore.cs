using UnityEngine;
using TMPro;

namespace MiniGameCollection.Games2024.Team12
{
    public class GameOverScreen : MonoBehaviour
    {
        public TextMeshProUGUI finalScoreText1;
        public TextMeshProUGUI finalScoreText2;

        void Start()
        {
            // Display final scores when the Game Over screen is shown
            DisplayFinalScores();
        }

        private void DisplayFinalScores()
        {
            // Get scores from the ScoreManager
            int score1 = ScoreManager.Instance.GetScore1();
            int score2 = ScoreManager.Instance.GetScore2();

            // Update the Game Over UI with final scores
            finalScoreText1.text = "Player 1 Score: " + score1;
            finalScoreText2.text = "Player 2 Score: " + score2;
        }
    }
}
