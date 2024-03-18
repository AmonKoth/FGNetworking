using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

public class Ammo : NetworkBehaviour
{

    public NetworkVariable<int> currentAmmo = new NetworkVariable<int>();
    public PlayerController playerController;

    public override void OnNetworkSpawn()
    {

        playerController.onFireEvent += Fire;
        if (!IsServer) return;

        currentAmmo.Value = 10;
    }

    public void GotAmmo()
    {
        currentAmmo.Value = 10;
    }

    public bool AskForAmmo()
    {
        if (currentAmmo.Value > 0) return true;
        return false;

    }

    private void Fire(bool isShooting)
    {
        if (isShooting)
        {
            ReduceAmmoServerRPC();
        }
    }

    [ServerRpc]
    private void ReduceAmmoServerRPC()
    {
        if (!IsServer) return;
        currentAmmo.Value -= 1;
    }

    public override void OnNetworkDespawn()
    {
        playerController.onFireEvent -= Fire;
    }

}
