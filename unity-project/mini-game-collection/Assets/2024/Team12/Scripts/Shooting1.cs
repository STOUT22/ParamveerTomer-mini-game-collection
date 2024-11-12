using UnityEngine;
using TMPro;

namespace MiniGameCollection.Games2024.Team12
{
    public class Shoot1 : MonoBehaviour
    {
        public Camera mainCamera1; // Reference to the main camera
        public GameObject crosshair1; // Reference to the crosshair
        public TextMeshProUGUI ammoText; // Reference to UI Text for ammo display
        public int maxAmmo = 5; // Max ammo count
        private int ammoCount; // Current ammo count
        private bool isReloading; // Check if reloading

        
        void Start()
        {
            ammoCount = maxAmmo; // Initialize ammo count
            UpdateAmmoUI(); // Update UI at start
        }

        void Update()
        {
            // Shooting with E key, with ammo and reloading
            if (Input.GetKeyDown(KeyCode.E) && ammoCount > 0 && !isReloading)
            {
                ShootGhost();
                ammoCount--; // Decrease ammo
                UpdateAmmoUI(); // Update ammo UI
            }

            // Reloading with R key only
            if (Input.GetKeyDown(KeyCode.R) && !isReloading)
            {
                StartCoroutine(Reload());
            }
        }

        void ShootGhost()
        {
            // Convert the crosshair's world position to screen space (in pixels)
            Vector3 crosshairScreenPosition = mainCamera1.WorldToScreenPoint(crosshair1.transform.position);

            // Create a ray from the camera through the screen point of the crosshair
            Ray ray = mainCamera1.ScreenPointToRay(crosshairScreenPosition);

            RaycastHit hit;

            // Debug the ray in the Scene view to visualize its direction
            Debug.DrawRay(ray.origin, ray.direction * 10, Color.green, 2f); // Shows the ray for 2 seconds in the scene

            // Raycast to detect if the ray hits any object
            //bool hasGhostTag = hit.transform.CompareTag("Ghost") != null;
                if (Physics.Raycast(ray, out hit))
                {
                    // hit = hit.collider.gameObject;

                    bool hasGhostTag = hit.collider.GetComponent<GhostTag>() != null;
                    // Check if the hit object is tagged as "Ghost"
                    if (hasGhostTag)
                    {
                        // Retrieve the GhostScorer component from the hit ghost
                        GhostScorer ghostScorer = hit.transform.GetComponent<GhostScorer>();
                        if (ghostScorer != null)
                        {
                            // Update the score for Crosshair1 based on the ghost's score value
                            ScoreManager.Instance.UpdateScore1(ghostScorer.scoreValue);
                        }

                        Destroy(hit.transform.gameObject); // Destroy the ghost on hit
                    }
                }
            
        }

        // Reload coroutine with a delay
        System.Collections.IEnumerator Reload()
        {
            isReloading = true; // Set reloading state to true
            ammoText.text = "Reloading..."; // Update UI with reloading message
            yield return new WaitForSeconds(2f); // Wait for 2 seconds (reload time)

            ammoCount = maxAmmo; // Refill ammo
            isReloading = false; // Set reloading state to false
            UpdateAmmoUI(); // Update ammo UI after reload
        }

        // Update ammo count UI
        void UpdateAmmoUI()
        {
            ammoText.text = "Ammo: " + ammoCount + "/" + maxAmmo;
        }
    }
}
