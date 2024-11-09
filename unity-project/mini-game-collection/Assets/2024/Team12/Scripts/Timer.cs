using UnityEngine;
using TMPro; // Add the TextMeshPro namespace
using UnityEngine.SceneManagement; // For loading a new scene

namespace MiniGameCollection.Games2024.Team12
{
    public class Timer : MonoBehaviour
    {
        public TextMeshProUGUI timerText; // TextMeshPro for displaying the timer
        private float timer = 60f; // 1-minute countdown timer
        private bool gameOver = false;

        public string sceneToLoad = "MainMenu"; // Name of the scene to load (set this in the inspector)

        void Update()
        {
            if (gameOver)
            {
                return; // Stop updating the timer once the game is over
            }

            // Update the countdown timer
            timer -= Time.deltaTime;

            // Update the timer UI
            UpdateTimerUI();

            // Check if the timer has run out
            if (timer <= 0f)
            {
                EndGame();
            }
        }

        // Update the timer UI to display the remaining time
        void UpdateTimerUI()
        {
            int minutes = Mathf.FloorToInt(timer / 60);
            int seconds = Mathf.FloorToInt(timer % 60);
            timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }

        // End the game when the timer reaches zero and load the next scene
        void EndGame()
        {
            gameOver = true;
            Invoke("LoadScene", 1f); // Delay scene change by 1 second (optional)
        }

        // Method to load the scene
        void LoadScene()
        {
            SceneManager.LoadScene("2024-team12-GameOver"); // Load the scene defined in the inspector
        }

        // Optional: Reset Timer for Restart
        public void ResetTimer()
        {
            timer = 60f;
            gameOver = false;
        }
    }
}
