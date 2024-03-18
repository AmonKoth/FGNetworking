using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

public class AmmoPickup : NetworkBehaviour
{

    void OnTriggerEnter2D(Collider2D other)
    {
        if (IsServer)
        {

            Ammo playerAmmo = other.GetComponent<Ammo>();
            if (!playerAmmo) return;
            playerAmmo.GotAmmo();

            int xPosition = Random.Range(-4, 4);
            int yPosition = Random.Range(-2, 2);

            transform.position = new Vector3(xPosition, yPosition, 0);
        }
    }
}
