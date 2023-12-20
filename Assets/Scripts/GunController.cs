using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    public float moveSpeed = 8f; // Speed of gun movement
    public float minX = -8f; // Minimum X position
    public float maxX = 8f; // Maximum X position
    // Start is called before the first frame update

    // Game settings defineren
    public GameObject generalScripts;
    private GameInitializationSettings gameInitializationSettings;

    void Start()
    {
        gameInitializationSettings = generalScripts.GetComponent<GameInitializationSettings>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float newPosition = transform.position.x + horizontalInput * moveSpeed * Time.deltaTime;

        if (gameInitializationSettings != null)
        {
            if (gameInitializationSettings.roundInProgress == true)
            {
                newPosition = Mathf.Clamp(newPosition, minX, maxX);
                transform.position = new Vector3(newPosition, transform.position.y, transform.position.z);
            }
        }
    }
}
