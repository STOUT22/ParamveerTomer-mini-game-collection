using UnityEngine;

namespace MiniGameCollection.Games2024.Team12
{
    public class Crosshair1 : MonoBehaviour
    {
        public RectTransform crosshairImage; // Assign your crosshair UI image here
        public float moveSpeed = 200f; // Speed of crosshair movement

        void Update()
        {
            Vector3 movement = new Vector3();

            // Capture WASD input
            if (Input.GetKey(KeyCode.W)) movement.y += 1;
            if (Input.GetKey(KeyCode.S)) movement.y -= 1;
            if (Input.GetKey(KeyCode.A)) movement.x -= 1;
            if (Input.GetKey(KeyCode.D)) movement.x += 1;

            // Move the crosshair based on input
            crosshairImage.anchoredPosition += (Vector2)movement * moveSpeed * Time.deltaTime;
        }
    }
}