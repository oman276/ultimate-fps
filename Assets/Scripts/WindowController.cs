using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WindowController : MonoBehaviour
{
    public GameObject errorScreen;

    public GameObject window1;
    public GameObject window2;
    public GameObject window3;

    public LevelController levelController;
    public int numOfWindows = 3;

    public float timer;
    public float startTime;
    public Text timerText;
    public float displayTime;

    public bool firstLoop = false;
    public bool gameActive = false;

    void Start()
    {
        levelController = FindObjectOfType<LevelController>(); 
    }

    void Update()
    {
        if (gameActive == true)
        {
            //print("buddy its loopin");

            if (firstLoop == false)
            {
                startTime = Time.time;
                firstLoop = true;
            }

            timer = Time.time - startTime;

            displayTime = 20 - timer;

            if (displayTime <= 0)
            {
                displayTime = 0;
            }

            string seconds = (displayTime % 60).ToString("f2");

            timerText.text = seconds;

            if (displayTime <= 0)
            {
                Error();                
            }
        }
    }

    public void Close1()
    {
        window1.SetActive(false);
        numOfWindows--;
        if(numOfWindows == 0)
        {
            gameActive = false;
            levelController.Success();
        }

    }
    public void Close2()
    {
        window2.SetActive(false);
        numOfWindows--;
        if (numOfWindows == 0)
        {
            gameActive = false;
            levelController.Success();
        }
    }
    public void Close3()
    {
        window3.SetActive(false);
        numOfWindows--;
        if (numOfWindows == 0)
        {
            gameActive = false;
            levelController.Success();
        }
    }
    public void Error()
    {
        gameActive = false;
        errorScreen.SetActive(true);
        levelController.GameOver();
    }


}
