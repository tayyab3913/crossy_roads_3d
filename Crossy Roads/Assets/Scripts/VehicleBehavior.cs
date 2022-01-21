using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleBehavior : MonoBehaviour
{
    private PlayerController playerControllerScript;

    public void InitializeVehicle(PlayerController player)
    {
        playerControllerScript = player;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Collided with Player");
            playerControllerScript.PlayerDied();
        }
    }
}
