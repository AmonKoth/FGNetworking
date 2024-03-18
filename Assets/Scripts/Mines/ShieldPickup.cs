using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class ShieldPickup : NetworkBehaviour
{

    void OnTriggerEnter2D(Collider2D other)
    {
        if (IsServer)
        {

            Health health = other.GetComponent<Health>();
            if (!health) return;
            health.AddShield();

            int xPosition = Random.Range(-4, 4);
            int yPosition = Random.Range(-2, 2);

            transform.position = new Vector3(xPosition, yPosition, 0);
        }
    }
}
