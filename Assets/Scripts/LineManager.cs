using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LineManager : MonoBehaviour
{

    public int currentNumCode;
    
    public string[] clipText = new string[81];
    public float[] clipDelay = new float[81];

    public float currentDelay = 1.5f;

    public int sceneNum;

    public float timer = 0f;
    public float startTime;

    public Text textBox;

    public bool firstLoop = false;
    public bool dialogueOn = true;

    public Doorman doorman;
    public Evilbad evilbad;
    


    // Start is called before the first frame update
    void Start()
    {
        sceneNum = SceneManager.GetActiveScene().buildIndex;
        //startTime = Time.time;

        doorman = FindObjectOfType<Doorman>();
        evilbad = FindObjectOfType<Evilbad>();

        if(sceneNum == 2) //Game 1
        {
            currentNumCode = 0;
        }
        else if (sceneNum == 4) //Cutscene 2
        {
            print("got Scene 5");
            currentNumCode = 4;
            FindObjectOfType<AudioManager>().Play("wind");
            
        }
        else if (sceneNum == 5) //Game 2
        {
            dialogueOn = false;
            currentNumCode = 13;
        }
        else if(sceneNum == 6) //Cutscene 3
        {
            currentNumCode = 18;
        }
        else if (sceneNum == 7) //Game 3
        {
            dialogueOn = false;
        }
        else if(sceneNum == 8) //Cutscene 4
        {
            currentNumCode = 46;
        }
        else if (sceneNum == 9) //Cutscene 5
        {
            currentNumCode = 53;
        }
        else if (sceneNum == 11) //Cutscene 6
        {
            currentNumCode = 55;
        }
        else if (sceneNum == 13) //Cutscene 7
        {
            currentNumCode = 66;
        }
        else if (sceneNum == 15) //Cutscene 8
        {
            currentNumCode = 70;
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (dialogueOn == true)
        {

            if (firstLoop == false)
            {
                startTime = Time.time;
                firstLoop = true;
            }

            timer = Time.time - startTime;

            if (timer >= currentDelay)
            {
                if (currentNumCode == 100)
                {
                    FindObjectOfType<AudioManager>().StopPlaying("wind");
                    FindObjectOfType<AudioManager>().StopPlaying("phone");
                    FindObjectOfType<AudioManager>().StopPlaying("alarm");
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                }
                if(currentNumCode == 150)
                {
                    textBox.text = null;
                    dialogueOn = false;
                    return;
                }
                else if(currentNumCode == 200)
                {
                    SceneManager.LoadScene(0);
                }

                PlayLine(currentNumCode);
                textBox.text = clipText[currentNumCode];
                currentDelay = clipDelay[currentNumCode];

                if (currentNumCode == 2 || currentNumCode == 12 || currentNumCode == 22 || currentNumCode == 52 || //Load Next Level Code
                    currentNumCode == 54 || currentNumCode == 65 || currentNumCode == 67)
                {
                    currentNumCode = 100;
                }
                else if(currentNumCode == 17)
                {
                    currentNumCode = 150;
                }
                else if(currentNumCode == 56)
                {
                    currentNumCode = 80;
                }
                else if(currentNumCode == 80)
                {
                    currentNumCode = 57;
                }
                else if(currentNumCode == 79)
                {
                    currentNumCode = 200;
                }
                else
                {
                    currentNumCode++;
                }




                startTime = Time.time;


            }
        }
    }

    public void PlayLine(int lineNum)
    {
        if(lineNum == 0)
        {
            FindObjectOfType<AudioManager>().Play("clip1");
        }
        else if(lineNum == 1)
        {
            FindObjectOfType<AudioManager>().Play("clip2");
        }
        else if (lineNum == 2)
        {
            FindObjectOfType<AudioManager>().Play("clip3");
        }
        else if (lineNum == 3)
        {
            FindObjectOfType<AudioManager>().Play("clip4");
        }
        else if (lineNum == 4)
        {
            FindObjectOfType<AudioManager>().Play("clip5");
        }
        else if (lineNum == 5)
        {
            FindObjectOfType<AudioManager>().Play("clip6");
        }
        else if (lineNum == 6)
        {
            FindObjectOfType<AudioManager>().Play("clip7");
        }
        else if (lineNum == 7)
        {
            doorman.currentStage = 2;
            evilbad.currentStage = 2;
            FindObjectOfType<AudioManager>().Play("clip8");
        }
        else if (lineNum == 8)
        {
            FindObjectOfType<AudioManager>().Play("clip9");
        }
        else if (lineNum == 9)
        {
            FindObjectOfType<AudioManager>().Play("clip10");
        }
        else if (lineNum == 10)
        {
            FindObjectOfType<AudioManager>().Play("clip11");
        }
        else if (lineNum == 11)
        {
            FindObjectOfType<AudioManager>().Play("clip12");
        }
        else if (lineNum == 12)
        {
            FindObjectOfType<AudioManager>().Play("clip13");
        }
        else if (lineNum == 13)
        {
            FindObjectOfType<AudioManager>().Play("clip14");
        }
        else if (lineNum == 14)
        {
            FindObjectOfType<AudioManager>().Play("clip15");
        }
        else if (lineNum == 15)
        {
            FindObjectOfType<AudioManager>().Play("clip16");
        }
        else if (lineNum == 16)
        {
            FindObjectOfType<AudioManager>().Play("clip17");
        }
        else if (lineNum == 17)
        {
            FindObjectOfType<AudioManager>().Play("clip18");
        }
        else if (lineNum == 18)
        {
            FindObjectOfType<AudioManager>().Play("clip19");
        }
        else if (lineNum == 19)
        {
            FindObjectOfType<AudioManager>().Play("clip20");
        }
        else if (lineNum == 20)
        {
            FindObjectOfType<AudioManager>().Play("clip21");
        }
        else if (lineNum == 21)
        {
            FindObjectOfType<AudioManager>().Play("phone");
            FindObjectOfType<AudioManager>().Play("clip22");
        }
        else if (lineNum == 22)
        {
            FindObjectOfType<AudioManager>().Play("clip23");
        }
        else if (lineNum == 23)
        {
            FindObjectOfType<AudioManager>().Play("clip24");
        }
        else if (lineNum == 24)
        {
            FindObjectOfType<AudioManager>().Play("clip25");
        }
        else if (lineNum == 25)
        {
            FindObjectOfType<AudioManager>().Play("clip26");
        }
        else if (lineNum == 26)
        {
            FindObjectOfType<AudioManager>().Play("clip27");
        }
        else if (lineNum == 27)
        {
            FindObjectOfType<AudioManager>().Play("clip28");
        }
        else if (lineNum == 28)
        {
            FindObjectOfType<AudioManager>().Play("clip29");
        }
        else if (lineNum == 29)
        {
            FindObjectOfType<AudioManager>().Play("clip30");
        }
        else if (lineNum == 30)
        {
            FindObjectOfType<AudioManager>().Play("clip31");
        }
        else if (lineNum == 31)
        {
            FindObjectOfType<AudioManager>().Play("clip32");
        }
        else if (lineNum == 32)
        {
            FindObjectOfType<AudioManager>().Play("clip33");
        }
        else if (lineNum == 33)
        {
            FindObjectOfType<AudioManager>().Play("clip34");
        }
        else if (lineNum == 34)
        {
            FindObjectOfType<AudioManager>().Play("clip35");
        }
        else if (lineNum == 35)
        {
            FindObjectOfType<AudioManager>().Play("clip36");
        }
        else if (lineNum == 36)
        {
            FindObjectOfType<AudioManager>().Play("clip37");
        }
        else if (lineNum == 37)
        {
            FindObjectOfType<AudioManager>().Play("clip38");
        }
        else if (lineNum == 38)
        {
            FindObjectOfType<AudioManager>().Play("clip39");
        }
        else if (lineNum == 39)
        {
            FindObjectOfType<AudioManager>().Play("clip40");
        }
        else if (lineNum == 40)
        {
            FindObjectOfType<AudioManager>().Play("clip41");
        }
        else if (lineNum == 41)
        {
            FindObjectOfType<AudioManager>().Play("clip42");
        }
        else if (lineNum == 42)
        {
            FindObjectOfType<AudioManager>().Play("clip43");
        }
        else if (lineNum == 43)
        {
            FindObjectOfType<AudioManager>().Play("clip44");
        }
        else if (lineNum == 44)
        {
            FindObjectOfType<AudioManager>().Play("clip45");
        }
        else if (lineNum == 45)
        {
            FindObjectOfType<AudioManager>().Play("clip46");
        }
        else if (lineNum == 46)
        {
            FindObjectOfType<AudioManager>().Play("clip47");
        }
        else if (lineNum == 47)
        {
            FindObjectOfType<AudioManager>().Play("clip48");
        }
        else if (lineNum == 48)
        {
            FindObjectOfType<AudioManager>().Play("clip49");
        }
        else if (lineNum == 49)
        {
            FindObjectOfType<AudioManager>().Play("clip50");
        }
        else if (lineNum == 50)
        {
            FindObjectOfType<AudioManager>().Play("clip51");
        }
        else if (lineNum == 51)
        {
            FindObjectOfType<AudioManager>().Play("clip52");
        }
        else if (lineNum == 52)
        {
            FindObjectOfType<AudioManager>().Play("clip52a");
        }
        else if (lineNum == 53)
        {
            FindObjectOfType<AudioManager>().Play("clip53");
        }
        else if (lineNum == 54)
        {
            FindObjectOfType<AudioManager>().Play("clip54");
        }
        else if (lineNum == 55)
        {
            FindObjectOfType<AudioManager>().Play("clip55");
        }
        else if (lineNum == 56)
        {
            FindObjectOfType<AudioManager>().Play("clip56");
        }
        else if (lineNum == 57)
        {
            FindObjectOfType<AudioManager>().Play("clip57");
        }
        else if (lineNum == 58)
        {
            FindObjectOfType<AudioManager>().Play("alarm");
            FindObjectOfType<AudioManager>().Play("clip58");
        }
        else if (lineNum == 59)
        {
            FindObjectOfType<AudioManager>().Play("clip59");
        }
        else if (lineNum == 60)
        {
            FindObjectOfType<AudioManager>().Play("clip60");
        }
        else if (lineNum == 61)
        {
            FindObjectOfType<AudioManager>().Play("clip61");
        }
        else if (lineNum == 62)
        {
            FindObjectOfType<AudioManager>().Play("clip62");
        }
        else if (lineNum == 63)
        {
            FindObjectOfType<AudioManager>().Play("clip63");
        }
        else if (lineNum == 64)
        {
            FindObjectOfType<AudioManager>().Play("clip64");
        }
        else if (lineNum == 65)
        {
            FindObjectOfType<AudioManager>().Play("clip65");
        }
        else if (lineNum == 66)
        {
            FindObjectOfType<AudioManager>().Play("clip66");
        }
        else if (lineNum == 67)
        {
            FindObjectOfType<AudioManager>().Play("clip67");
        }
        else if (lineNum == 68)
        {
            print("This shouldn't happen!");
        }
        else if (lineNum == 69)
        {
            FindObjectOfType<AudioManager>().Play("clip69");
        }
        else if (lineNum == 70)
        {
            FindObjectOfType<AudioManager>().Play("clip70");
        }
        else if (lineNum == 71)
        {
            FindObjectOfType<AudioManager>().Play("clip71");
        }
        else if (lineNum == 72)
        {
            FindObjectOfType<AudioManager>().Play("clip72");
        }
        else if (lineNum == 73)
        {
            FindObjectOfType<AudioManager>().Play("clip73");
        }
        else if (lineNum == 74)
        {
            FindObjectOfType<AudioManager>().Play("clip74");
        }
        else if (lineNum == 75)
        {
            FindObjectOfType<AudioManager>().Play("clip75");
        }
        else if (lineNum == 76)
        {
            FindObjectOfType<AudioManager>().Play("clip76");
        }
        else if (lineNum == 77)
        {
            FindObjectOfType<AudioManager>().Play("clip77");
        }
        else if (lineNum == 78)
        {
            FindObjectOfType<AudioManager>().Play("clip78");
        }
        else if (lineNum == 79)
        {
            FindObjectOfType<AudioManager>().Play("clip79");
        }
        else if (lineNum == 80)
        {
            FindObjectOfType<AudioManager>().Play("clip56a");
        }
    }
}
