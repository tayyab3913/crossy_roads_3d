using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject player;
    public GameObject[] leftVehiclePrefabs;
    public GameObject[] leftSpawnLocations;
    public GameObject[] rightVehiclePrefabs;
    public GameObject[] rightSpawnLocations;
    public GameObject mainCamera;
    public GameObject secondCamera;
    private float randomRightInterval = 2;
    private float startDelay = 1;
    private GameObject playerInstance;
    private PlayerController playerScript;
    // Start is called before the first frame update
    void Start()
    {
        playerInstance = Instantiate(player, new Vector3(0, 2, 0), player.transform.rotation);
        playerScript = playerInstance.GetComponent<PlayerController>();
        playerScript.InitializePlayer(mainCamera,secondCamera, 15, 800, 400, 0, 10, -12, 5, 25);
        InvokeRepeating("SpawnVehiclesFromRight", 2, randomRightInterval);
        InvokeRepeating("SpawnVehiclesFromLeft", startDelay, randomRightInterval);
    }

    // This method spawns vehicles from spawning points on right side
    void SpawnVehiclesFromRight()
    {
        if(playerScript.gameOver == false)
        {
            int randomLoopIndex = Random.Range(1, 6);
            for (int i = 0; i < randomLoopIndex; i++)
            {
                int randomVehicleIndex = Random.Range(0, rightVehiclePrefabs.Length);
                int randomSpawnIndex = Random.Range(0, rightSpawnLocations.Length);
                GameObject vehicle = Instantiate(rightVehiclePrefabs[randomVehicleIndex], rightSpawnLocations[randomSpawnIndex].transform.position, rightVehiclePrefabs[randomVehicleIndex].transform.rotation);
                vehicle.GetComponent<VehicleBehavior>().InitializeVehicle(playerScript);
            }
        }  
    }

    // This method spawns vehicles from spawning points on left side
    void SpawnVehiclesFromLeft()
    {
        if (playerScript.gameOver == false)
        {
            int randomLoopIndex = Random.Range(1, 6);
            for (int i = 0; i < randomLoopIndex; i++)
            {
                int randomVehicleIndex = Random.Range(0, leftVehiclePrefabs.Length);
                int randomSpawnIndex = Random.Range(0, leftSpawnLocations.Length);
                GameObject vehicle = Instantiate(leftVehiclePrefabs[randomVehicleIndex], leftSpawnLocations[randomSpawnIndex].transform.position, leftVehiclePrefabs[randomVehicleIndex].transform.rotation);
                vehicle.GetComponent<VehicleBehavior>().InitializeVehicle(playerScript);
            }
        }
        
    }
}
