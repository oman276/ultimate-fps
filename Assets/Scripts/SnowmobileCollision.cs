using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowmobileCollision : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnCollisionEnter(Collision collision)
    {
        print("hit something");

        if(collision.gameObject.tag == "Obstacle")
        {
            print("Game Reset!");
        }
    }
}
