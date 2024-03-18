using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class Health : NetworkBehaviour
{
    public NetworkVariable<int> currentHealth = new NetworkVariable<int>();
    public NetworkVariable<int> currentShield = new NetworkVariable<int>();
    public NetworkVariable<int> currentLives = new NetworkVariable<int>();

    public override void OnNetworkSpawn()
    {
        if (!IsServer) return;
        currentHealth.Value = 100;
        currentShield.Value = 0;
        currentLives.Value = 2;
    }


    public void TakeDamage(int damage)
    {
        damage = damage < 0 ? damage : -damage;
        if (currentShield.Value > 0)
        {
            currentShield.Value -= 1;
        }
        else
        {
            currentHealth.Value += damage;
        }

        if (currentHealth.Value <= 0)
        {
            HandleDeath();
        }
    }

    public void AddShield()
    {
        currentShield.Value = 2;
    }

    public void GainHealth(int health)
    {
        health = health > 0 ? health : -health;
        currentHealth.Value += health;
        if (currentHealth.Value > 100)
        {
            currentHealth.Value = 100;
        }

    }

    private void HandleDeath()
    {
        if (currentLives.Value > 0)
        {
            currentLives.Value -= 1;
            currentHealth.Value = 100;
            return;
        }
        NetworkManager.Singleton.DisconnectClient(OwnerClientId);
    }


}
