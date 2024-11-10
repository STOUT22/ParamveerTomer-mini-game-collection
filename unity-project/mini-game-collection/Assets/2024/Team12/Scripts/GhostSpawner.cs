using UnityEngine;
namespace MiniGameCollection.Games2024.Team12
{
    public class DuckSpawner : MonoBehaviour
    {
        public GameObject positiveDuckPrefab;
        public GameObject negativeDuckPrefab;
        public Transform[] spawnPoints; // Add spawn points in the Inspector
        public float spawnInterval = 3f;

        private void Start()
        {
            InvokeRepeating(nameof(SpawnDuck), 0f, spawnInterval);
        }

        private void SpawnDuck()
        {
            // Choose a random spawn point
            Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];

            // Randomly select positive or negative duck
            GameObject duckPrefab = Random.Range(0, 2) == 0 ? positiveDuckPrefab : negativeDuckPrefab;

            // Instantiate the selected duck at the chosen spawn point
            Instantiate(duckPrefab, spawnPoint.position, Quaternion.identity);
        }
    }
}