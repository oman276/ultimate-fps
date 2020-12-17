using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Snowmobile : MonoBehaviour
{
    public float speed = 8f;
    public float ySpeed = 5f;
    public CharacterController controller;

    public GameObject steering;
    public int targetRotation;
    public int currentRotation = 0;

    public LevelController levelController;

    public bool gameActive = false;
    public bool controlActive = true;
    float x = 0;


    // Start is called before the first frame update
    void Start()
    {
        levelController = FindObjectOfType<LevelController>();
        if(SceneManager.GetActiveScene().buildIndex == 2)
        {
            gameActive = true;
            controlActive = false;
        }

    }

    // Update is called once per frame
    void Update()
    {
        if(gameActive == true)
        {

            if(controlActive == true)
            {
                x = Input.GetAxis("Horizontal");
            }

            if (x == 0)
            {
                targetRotation = 0;
            }
            else if (x > 0)
            {
                targetRotation = 25;
            }
            else
            {
                targetRotation = -25;
            }

            if (currentRotation != targetRotation)
            {
                if (currentRotation > targetRotation)
                {
                    currentRotation--;
                }
                else
                {
                    currentRotation++;
                }
            }

            if(controlActive == true)
            {
                steering.gameObject.transform.localRotation = Quaternion.Euler(0, 0, currentRotation);
            }

            Vector3 move = transform.right * x + transform.forward * speed;
            controller.Move(move * speed * Time.deltaTime);

        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        //print("Hit an Object");

        if(collision.collider.tag == "Obstacle")
        {
            //FindObjectOfType<AudioManager>().Play("failure");
            gameActive = false;
            levelController.GameOver();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        gameActive = false;
        levelController.Success();
    }
}
