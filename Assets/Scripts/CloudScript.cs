using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudScript : MonoBehaviour
{


    public bool moving = false;
    public float speed;

    void Update()
    {
        if (moving)
        {
            transform.position = new Vector3(transform.position.x + (speed / 60), transform.position.y, transform.position.z);
        }
    }
}
