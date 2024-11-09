using UnityEngine;

namespace MiniGameCollection.Games2024.Team12
{

    public class Crosshair2 : MonoBehaviour
    {
        public RectTransform crosshairImage; // Assign your crosshair UI image here
        public float moveSpeed = 200f; // Speed of crosshair movement

        void Update()
        {
            Vector3 movement = new Vector3();

            // Capture arrow key input
            if (Input.GetKey(KeyCode.UpArrow)) movement.y += 1;
            if (Input.GetKey(KeyCode.DownArrow)) movement.y -= 1;
            if (Input.GetKey(KeyCode.LeftArrow)) movement.x -= 1;
            if (Input.GetKey(KeyCode.RightArrow)) movement.x += 1;

            // Move the crosshair based on input
            crosshairImage.anchoredPosition += (Vector2)movement * moveSpeed * Time.deltaTime;
        }
    }
}