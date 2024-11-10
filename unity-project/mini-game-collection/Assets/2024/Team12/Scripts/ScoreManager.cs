using UnityEngine;
using TMPro;

namespace MiniGameCollection.Games2024.Team12
{
    public class ScoreManager : MonoBehaviour
    {
        public static ScoreManager Instance { get; private set; }

        public TextMeshProUGUI scoreText1; // Text for Crosshair1's score UI
        public TextMeshProUGUI scoreText2; // Text for Crosshair2's score UI

        private int score1;
        private int score2;

        private void Awake()
        {
            // Ensure only one instance of ScoreManager exists
            if (Instance == null) Instance = this;
            else Destroy(gameObject);
        }

        private void Start()
        {
            score1 = 0;
            score2 = 0;
            UpdateScoreUI();
        }

        public void UpdateScore1(int amount)
        {
            score1 += amount; // Update the score for Crosshair1
            UpdateScoreUI();
        }

        public void UpdateScore2(int amount)
        {
            score2 += amount; // Update the score for Crosshair2
            UpdateScoreUI();
        }

        private void UpdateScoreUI()
        {
            scoreText1.text = "Score: " + score1; // Update the UI text for Crosshair1
            scoreText2.text = "Score: " + score2; // Update the UI text for Crosshair2
        }

        // Method to get the final scores
        public int GetScore1() => score1;
        public int GetScore2() => score2;
    }
}
