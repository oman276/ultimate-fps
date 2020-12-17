using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Steak : MonoBehaviour
{
    public Rigidbody rb;
    public float jumpSpeed = 5f;

    public int flipSide = 1;
    public bool isCooking = false;

    public float currentRotation = 0f;
    public float targetRotation = 0f;

    public Steak1Side side1;
    public int side1CookTime = 0;

    public Steak2Side side2;
    public int side2CookTime = 0;

    public Slider slider1;
    public Slider slider2;

    public float timer = 0f;
    public float startTime;
    public float countdownTimer = 0f;
    public float countdownStartTime;
    public float displayTime;

    public Text timerText;

    public float force = 10f;

    public float time1;
    public float time2;
    public Text time1Text;
    public Text time2Text;

    public bool gameEnded;

    public bool gameActive = false;
    public bool firstRun = true;

    public bool sizzlePlaying = false;

    public LevelController levelController;
    public LineManager lineManager;

    public Animator panAnim;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        levelController = FindObjectOfType<LevelController>();
        startTime = Time.time;
        countdownStartTime = Time.time;
        gameEnded = false;
        lineManager = FindObjectOfType<LineManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameActive == true)
        {

            if(firstRun == true)
            {
                startTime = Time.time;
                countdownStartTime = Time.time;
                firstRun = false;
                lineManager.dialogueOn = true;

                this.transform.position = new Vector3(0.045f, 2.117f, -9.759f);
            }

            timer = Time.time - startTime;
            countdownTimer = Time.time - countdownStartTime;

            displayTime = 45 - countdownTimer;

            if (displayTime <= 0)
            {
                displayTime = 0;
            }

            string seconds = (displayTime % 60).ToString("f2");

            timerText.text = seconds;


            if (timer >= 0.1f)
            {
                if (isCooking == true)
                {
                    if (flipSide == 1)
                    {
                        side1CookTime = side1CookTime + 1;
                    }
                    else
                    {
                        side2CookTime = side2CookTime + 1;
                    }

                    if(sizzlePlaying == false)
                    {
                        FindObjectOfType<AudioManager>().Play("sizzle");
                        sizzlePlaying = true;
                    }

                }
                else
                {
                    if(sizzlePlaying == true)
                    {
                        FindObjectOfType<AudioManager>().StopPlaying("sizzle");
                        sizzlePlaying = false;
                    }

                }

                //print("side 1: " + side1CookTime);
                //print("side 2: " + side2CookTime);

                startTime = Time.time;
            }

            if (currentRotation != targetRotation)
            {
                currentRotation = currentRotation + 5;
            }

            transform.localRotation = Quaternion.Euler(0, 0, currentRotation);

            if (Input.GetButtonDown("Jump"))
            {
                if (isCooking == true)
                {

                    rb.AddForce(new Vector3(0, 5, 0), ForceMode.Impulse);
                    panAnim.SetTrigger("isFlipped");

                    targetRotation = targetRotation + 180;

                    if (flipSide == 1)
                    {
                        flipSide = 2;
                    }
                    else
                    {
                        flipSide = 1;
                    }
                }
            }

            slider1.value = side1CookTime;
            slider2.value = side2CookTime;

            if (displayTime == 0 && gameEnded == false)
            {
                gameEnded = true;

                if (Mathf.Abs(side1CookTime - side2CookTime) >= 30)
                {
                    time1 = (float)side1CookTime / 10;
                    time2 = (float)side2CookTime / 10;

                    time1Text.text = ("Side 1: " + time1 + " seconds");
                    time2Text.text = ("Side 2: " + time2 + " seconds");

                    levelController.GameOver();
                }
                else
                {
                    levelController.Success();
                }

                if(sizzlePlaying == true)
                {
                    FindObjectOfType<AudioManager>().StopPlaying("sizzle");
                }
                gameActive = false;

            }

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        isCooking = true;
    }

    private void OnTriggerExit(Collider other)
    {
        isCooking = false;
    }

}
