using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AmmoCountController : MonoBehaviour
{
    public TextMeshProUGUI ammoCountText;
    public int ammo = 3;

    // Start is called before the first frame update
    void Start()
    {
        ammoCountText = GameObject.Find("Canvas/ammoCount").GetComponent<TextMeshProUGUI>(); // Defineren van ammo text object
        if (ammoCountText != null )
        {
            Debug.Log("AmmoCountController: ammoCountText is found");
            Debug.Log("Ammo currently = " + ammo.ToString());
            ammoCountText.text = ammo.ToString(); // Aanpassen van text naar daadwerkelijke data
        }
        else
        {
            Debug.Log("AmmoCountController: ammoCountText NOT found");
        }

        Debug.Log(ammoCountText.text + " ammo");
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void AddAmmo(int ammoAmount)
    {
        ammo += ammoAmount;
        ammoCountText.text = ammo.ToString();
    }

    public void RemoveAmmo(int ammoAmount)
    {
        ammo -= ammoAmount;
        ammoCountText.text = ammo.ToString();
    }
}