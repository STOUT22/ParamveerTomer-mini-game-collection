using UnityEngine;
using TMPro; 
namespace MiniGameCollection.Games2024.Team12
{
    public class Shoot : MonoBehaviour
    {
        public Camera mainCamera1;
        public GameObject crosshair1;
        public TextMeshProUGUI ammoText; // Assign your TextMeshPro UI Text here
        public int maxAmmo = 5;
        private int ammoCount;
        private bool isReloading;

        void Start()
        {
            ammoCount = maxAmmo;
            UpdateAmmoUI();
        }

        void Update()
        {
            // Shooting Ghosts with E key, with ammo and reloading
            if (Input.GetKeyDown(KeyCode.E) && ammoCount > 0 && !isReloading)
            {
                ShootGhost();
                ammoCount--;
                UpdateAmmoUI();
            }

            // Reloading with R key only
            if (Input.GetKeyDown(KeyCode.R) && !isReloading)
            {
                StartCoroutine(Reload());
            }
        }

        void ShootGhost()
        {
            Ray ray = mainCamera1.ScreenPointToRay(crosshair1.transform.position);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.CompareTag("Ghost")) // Tag your ghosts as "Ghost"
                {
                    Destroy(hit.transform.gameObject); // Destroy ghost on hit
                }
            }
        }

        // Reload coroutine with delay
        System.Collections.IEnumerator Reload()
        {
            isReloading = true;
            ammoText.text = "Reloading...";
            yield return new WaitForSeconds(2f); // 2-second reload time

            ammoCount = maxAmmo;
            isReloading = false;
            UpdateAmmoUI();
        }

        void UpdateAmmoUI()
        {
            ammoText.text = "Ammo: " + ammoCount + "/" + maxAmmo;
        }
    }
}
