using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

public class Medkit : NetworkBehaviour
{
    [SerializeField]
    private int _increaseAmmount = 10;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (IsServer)
        {
            Health health = other.GetComponent<Health>();
            if (!health) return;
            health.GainHealth(_increaseAmmount);


            NetworkObject networkObject = gameObject.GetComponent<NetworkObject>();
            networkObject.Despawn();
        }
    }
}
