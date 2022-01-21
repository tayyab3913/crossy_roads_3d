using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleBehavior : MonoBehaviour
{
    private PlayerController playerControllerScript;

    // This method initializes vehicle to provide a player reference
    public void InitializeVehicle(PlayerController player)
    {
        playerControllerScript = player;
    }

    // This method checks collision with player and calls player died method
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Collided with Player");
            playerControllerScript.PlayerDied();
        }
    }
}
