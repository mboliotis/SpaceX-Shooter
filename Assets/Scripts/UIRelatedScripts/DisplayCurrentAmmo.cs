using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayCurrentAmmo : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI ammoIndicator;

    [SerializeField]
    GameObject player;

    private void Update()
    {
        ammoIndicator.text = ""+player.GetComponent<ShootSpaceship>().GetCurrentAmmo();
    }

}
