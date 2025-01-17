/*
 * Jordy Perret - IO3S1AV
 * Border Patrol Alienist
 * 14-11-2023
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AmmoCountController : MonoBehaviour
{
    public TextMeshProUGUI ammoCountText;
    public int ammo = 10;

    // Start is called before the first frame update
    void Start()
    {
        // Defineren van ammo text object
        ammoCountText = GameObject.Find("Canvas/ammoCount").GetComponent<TextMeshProUGUI>();

        if (ammoCountText != null )
        {
            Debug.Log("AmmoCountController: ammoCountText is found");
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