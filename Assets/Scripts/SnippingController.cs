using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SnippingController : MonoBehaviour
{
    public GameObject cameraObject;

    public Transform navpoint1;
    public Transform navpoint2;
    public Transform navpoint3;
    public Transform navpoint4;

    public int currentTarget = 1;
    public float moveSpeed = 13f;

    public WallPanel wallPanel1;
    public bool wallPanel1Triggered = false;
    public WallPanel wallPanel2;
    public bool wallPanel2Triggered = false;
    public WallPanel wallPanel3;
    public bool wallPanel3Triggered = false;
    public WallPanel wallPanel4;
    public bool wallPanel4Triggered = false;

    public bool gameActive = false;
    public bool firstLoop = false;
    public bool gameEnded = false;

    public float timer;
    public float startTime;
    public Text timerText;
    public float displayTime;

    public LevelController levelController;

    // Start is called before the first frame update
    void Start()
    {
        levelController = FindObjectOfType<LevelController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameActive == true)
        {

            print("It's loopin");

            if(firstLoop == false)
            {
                startTime = Time.time;
                firstLoop = true;
            }

            timer = Time.time - startTime;

            displayTime = 15 - timer;

            if (displayTime <= 0)
            {
                displayTime = 0;
            }

            string seconds = (displayTime % 60).ToString("f2");

            timerText.text = seconds;


            if (currentTarget == 1)
            {
                cameraObject.transform.position = Vector3.MoveTowards(cameraObject.transform.position, navpoint1.position, moveSpeed * Time.deltaTime);
            }
            else if (currentTarget == 2)
            {
                cameraObject.transform.position = Vector3.MoveTowards(cameraObject.transform.position, navpoint2.position, moveSpeed * Time.deltaTime);
            }
            else if (currentTarget == 3)
            {
                cameraObject.transform.position = Vector3.MoveTowards(cameraObject.transform.position, navpoint3.position, moveSpeed * Time.deltaTime);
            }
            else if (currentTarget == 4)
            {
                cameraObject.transform.position = Vector3.MoveTowards(cameraObject.transform.position, navpoint4.position, moveSpeed * Time.deltaTime);
            }


            if (wallPanel1Triggered == false)
            {
                if (wallPanel1.isActive == true)
                {
                    currentTarget = 2;
                    wallPanel1Triggered = true;
                }
            }
            else if (wallPanel2Triggered == false)
            {
                if (wallPanel2.isActive == true)
                {
                    currentTarget = 3;
                    wallPanel2Triggered = true;
                }
            }
            else if (wallPanel3Triggered == false)
            {
                if (wallPanel3.isActive == true)
                {
                    currentTarget = 4;
                    wallPanel3Triggered = true;
                }
            }
            else if (wallPanel4Triggered == false)
            {
                if (wallPanel4.isActive == true)
                {
                    print("Wires completed!");
                    wallPanel4Triggered = true;

                    gameActive = false;
                    levelController.Success();
                }
            }


            if(displayTime == 0)
            {
                gameActive = false;
                levelController.GameOver();

            }

        }

    }

    public void EndGame()
    {
        gameActive = false;
        levelController.GameOver();
    }
}
