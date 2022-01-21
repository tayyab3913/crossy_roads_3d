using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    public float vehicleSpeed;
    public float boundry;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * Time.deltaTime * vehicleSpeed);
        DestroyOutOfBounds();
    }

    // This method destroys the vehicle when it's outside the left bounds
    void DestroyOutOfBounds()
    {
        if(transform.position.x < -boundry)
        {
            Destroy(gameObject);
        }
    }
}
