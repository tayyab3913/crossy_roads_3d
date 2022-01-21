using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinCheckPoint : MonoBehaviour
{

    // This method is called when the player reaches the last checkpoint or trigger and wins the game
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<PlayerController>().gameOver = true;
            Debug.Log("Game Completed");
        }
    }
}
