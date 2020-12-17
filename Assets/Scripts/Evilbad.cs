﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Evilbad : MonoBehaviour
{
    public int currentScene;
    public int currentStage = 1;

    public float speed = 0.4f;

    // Start is called before the first frame update
    void Start()
    {
        currentScene = SceneManager.GetActiveScene().buildIndex;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentScene == 4)
        {
            if (currentStage == 2)
            {
                transform.position = Vector3.MoveTowards(transform.position, new Vector3(-1.02f, 2.84f, 31.88f), speed);
            }
        }


    }
}