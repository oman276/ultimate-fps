using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public GameObject scr1;
    public GameObject scr2;
    public GameObject scr3;
    public GameObject scr4;

    public float timer = 0f;
    public float startTime;

    public bool gameActive = false;

    public LineManager lineManager;
    public LevelController levelController;

    public int currentNumCode = 23;

    public float currentDelay;
    public string currentText;
    public Text textBox;

    public bool firstLoop = false;


    void Start()
    {
        lineManager = FindObjectOfType<LineManager>();
        levelController = FindObjectOfType<LevelController>();
        currentDelay = 0.5f;
    }


    public void DisableAll()
    {
        scr1.SetActive(false);
        scr2.SetActive(false);
        scr3.SetActive(false);
        scr4.SetActive(false);
    }

    void Update()
    {

        timer = Time.time - startTime;

        if(gameActive == true)
        {
           if(firstLoop == false)
            {
                startTime = Time.time;
                timer = Time.time - startTime;
                firstLoop = true;
            }

            if (timer >= currentDelay)
            {
                DisableAll();

                if(currentNumCode == 101) //Intro to Screen 1
                {
                    gameActive = false;
                    textBox.text = null;
                    scr1.SetActive(true);
                    return;
                }
                else if(currentNumCode == 102) //Screen 1 fail
                {
                    gameActive = false;
                    textBox.text = null;
                    levelController.GameOver();
                    return;
                }
                else if (currentNumCode == 103) //Screen 1 Success to screen 2
                {
                    gameActive = false;
                    textBox.text = null;
                    scr2.SetActive(true);
                    return;
                }
                else if (currentNumCode == 104) //Screen 2 fail
                {
                    gameActive = false;
                    textBox.text = null;
                    levelController.GameOver();
                    return;
                }
                else if (currentNumCode == 105) //Screen 2 Success to Screen 3
                {
                    gameActive = false;
                    textBox.text = null;
                    scr3.SetActive(true);
                    return;
                }
                else if (currentNumCode == 106) //Screen 3 fail
                {
                    gameActive = false;
                    textBox.text = null;
                    levelController.GameOver();
                    return;
                }
                else if (currentNumCode == 107) //Screen 3 Success to Screen 4
                {
                    gameActive = false;
                    textBox.text = null;
                    scr4.SetActive(true);
                    return;
                }
                else if (currentNumCode == 108) //Screen 4 fail
                {
                    gameActive = false;
                    textBox.text = null;
                    levelController.GameOver();
                    return;
                }
                else if (currentNumCode == 109) //Screen 4 Success to Win
                {
                    gameActive = false;
                    textBox.text = null;
                    levelController.Success();
                    return;
                }
                else
                {
                    lineManager.PlayLine(currentNumCode);
                    textBox.text = lineManager.clipText[currentNumCode];
                    currentDelay = lineManager.clipDelay[currentNumCode];

                    startTime = Time.time;
                }


                if(currentNumCode == 23) //Intro to Screen 1
                {
                    currentNumCode = 101;
                }
                else if(currentNumCode == 25) //Screen 1 failure
                {
                    currentNumCode = 102;
                }
                else if (currentNumCode == 28) //Screen 1 Success to Screen 2
                {
                    currentNumCode = 103;
                }
                else if (currentNumCode == 30) //Screen 2 failure
                {
                    currentNumCode = 104;
                }
                else if (currentNumCode == 33) //Screen 2 success to Screen 3
                {
                    currentNumCode = 105;
                }
                else if (currentNumCode == 35) //Screen 3 failure
                {
                    currentNumCode = 106;
                }
                else if (currentNumCode == 38) //Screen 3 success to Screen 4
                {
                    currentNumCode = 107;
                }
                else if (currentNumCode == 40) //Screen 4 failure
                {
                    currentNumCode = 108;
                }
                else if (currentNumCode == 45) //Screen 4 success 
                {
                    currentNumCode = 109;
                }
                else
                {
                    currentNumCode++;
                }

            }
        }
    }

    public void Scr1Fail()
    {
        currentNumCode = 24;
        gameActive = true;
    }
    public void Scr2Fail()
    {
        currentNumCode = 29;
        gameActive = true;
    }
    public void Scr3Fail()
    {
        currentNumCode = 34;
        gameActive = true;
    }
    public void Scr4Fail()
    {
        currentNumCode = 39;
        gameActive = true;
    }



    public void Scr1Win()
    {
        currentNumCode = 26;
        gameActive = true;
    }
    public void Scr2Win()
    {
        currentNumCode = 31;
        gameActive = true;
    }
    public void Scr3Win()
    {
        currentNumCode = 36;
        gameActive = true;
    }
    public void Scr4Win()
    {
        currentNumCode = 41;
        gameActive = true;
    }


}
