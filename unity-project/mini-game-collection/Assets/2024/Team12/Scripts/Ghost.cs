using UnityEngine;

namespace MiniGameCollection.Games2024.Team12
{
    public class GhostMovement : MonoBehaviour
    {
        public float moveSpeed = 3f; // Adjust speed as needed
        public float changeDirectionInterval = 2f; // How often to change direction

        private Vector3 movementDirection;
        private float timeSinceDirectionChange;

        private void Start()
        {
            ChangeDirection();
        }

        private void Update()
        {
            // Move the duck in the current direction
            transform.Translate(movementDirection * moveSpeed * Time.deltaTime, Space.World);

            // Change direction at intervals
            timeSinceDirectionChange += Time.deltaTime;
            if (timeSinceDirectionChange >= changeDirectionInterval)
            {
                ChangeDirection();
                timeSinceDirectionChange = 0;
            }
        }

        private void ChangeDirection()
        {
            // Choose a random direction on the XZ plane
            float randomAngle = Random.Range(0f, 360f);
            movementDirection = new Vector3(Mathf.Cos(randomAngle), 0, Mathf.Sin(randomAngle));
        }
    }
}