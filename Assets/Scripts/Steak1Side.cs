﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Steak1Side : MonoBehaviour
{
    public bool isCooking = false; 

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
        isCooking = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        isCooking = false;
    }
}
