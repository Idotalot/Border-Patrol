/*
 * Jordy Perret - IO3S1AV
 * Border Patrol Alienist
 * 14-11-2023
 */

using UnityEngine;

public class Shooting : MonoBehaviour
{
    // Script properties defineren
    public GameObject bulletPrefab;
    public Transform firePoint;

    // Game settings defineren
    public GameObject generalScripts;
    private GameInitializationSettings gameInitializationSettings;

    void Start()
    {
        gameInitializationSettings = generalScripts.GetComponent<GameInitializationSettings>();
    }
    void Update()
    {       
        // Als user of spatie drukt schiet hij een kogel
        if (Input.GetKeyDown(KeyCode.Space)) // Change KeyCode.Space to the desired shoot key
        {
            // Check of game settings gedefineert is
            if (gameInitializationSettings != null)
            {
                // Als ronde bezig is wordt er geschoten
                if (gameInitializationSettings.roundInProgress == true)
                {
                    Shoot();
                }
                else
                {
                    // Anders wordt er niet geschoten
                    Debug.Log("Round NOT in progress");
                }
            }
        }
    }

    void Shoot()
    {
        // defineren van ammo controller
        AmmoCountController ammoCountController = GameObject.Find("AmmoCounterObject").GetComponent<AmmoCountController>();

        // als ammo controller defineert is
        if (ammoCountController != null)
        {
            // als speler nog ammo over heeft.
            if (ammoCountController.ammo != 0)
            {
                // Genereer kogel
                Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

                // Ammo -1
                ammoCountController.RemoveAmmo(1); // Remove 1 ammo
            }
        }
    }
}
