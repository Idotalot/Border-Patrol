using UnityEngine;

public class Shooting : MonoBehaviour
{
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
        if (Input.GetKeyDown(KeyCode.Space)) // Change KeyCode.Space to the desired shoot key
        {
            if (gameInitializationSettings != null)
            {
                if (gameInitializationSettings.roundInProgress == true)
                {
                    Shoot();
                }
                else
                {
                    Debug.Log("Round NOT in progress");
                }
            }
        }
    }

    void Shoot()
    {
        AmmoCountController ammoCountController = GameObject.Find("AmmoCounterObject").GetComponent<AmmoCountController>();

        if (ammoCountController != null)
        {
            Debug.Log("ammoCountController exists. Ammo: " + ammoCountController.ammo.ToString());
            if (ammoCountController.ammo != 0)
            {
                Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
                ammoCountController.RemoveAmmo(1); // Remove 1 ammo
            }
        }
        

        // Add code to control the bullet's movement and behavior
    }
}
