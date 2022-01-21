using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRight : MonoBehaviour
{
    public float vehicleSpeed;
    public float boundry;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * Time.deltaTime * vehicleSpeed);
        DestroyOutOfBounds();
    }

    // This method destroys vehicles when they are outside the right bounds
    void DestroyOutOfBounds()
    {
        if(transform.position.x > boundry)
        {
            Destroy(gameObject);
        }
    }
}
