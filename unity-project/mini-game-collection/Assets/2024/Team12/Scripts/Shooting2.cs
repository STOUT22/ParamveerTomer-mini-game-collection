using UnityEngine;
using TMPro; 
namespace MiniGameCollection.Games2024.Team12
{
    public class Shoot2 : MonoBehaviour
    {
        public Camera mainCamera2;
        public GameObject crosshair2;
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
            // Shooting Ghosts with L key, with ammo and reloading
            if (Input.GetKeyDown(KeyCode.L) && ammoCount > 0 && !isReloading)
            {
                ShootGhost();
                ammoCount--;
                UpdateAmmoUI();
            }

            // Reloading with K key only
            if (Input.GetKeyDown(KeyCode.K) && !isReloading)
            {
                StartCoroutine(Reload());
            }
        }

        void ShootGhost()
        {
            Ray ray = mainCamera2.ScreenPointToRay(crosshair2.transform.position);
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
