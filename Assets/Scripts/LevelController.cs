using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    public GameObject gameOverScreen;
    public GameObject successScreen;
    public GameObject introScreen;

    public Snowmobile snowmobile;
    public Steak steak;
    public SnippingController snippingController;
    public FullCharacterMovement characterMovement;
    public GunScript gunScript;
    public WindowController windowController;
    public DialogueManager dialogueManager;

    public bool firstLoop = false;
    public int currentLevel;

    public int initialSceneNum;


    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        print("Reading Start Code");




        snippingController = FindObjectOfType<SnippingController>();
        characterMovement = FindObjectOfType<FullCharacterMovement>();
        gunScript = FindObjectOfType<GunScript>();
        windowController = FindObjectOfType<WindowController>();
        dialogueManager = FindObjectOfType<DialogueManager>();
    }

    void Update()
    {
        if (firstLoop == false)
        {

            currentLevel = SceneManager.GetActiveScene().buildIndex;

            if (currentLevel == 3 || currentLevel == 5 || currentLevel == 7 || currentLevel == 10 || currentLevel == 12 || currentLevel == 4)
            {
                Cursor.lockState = CursorLockMode.None;
            }
            else if(currentLevel == 2 || currentLevel == 4 || currentLevel == 6 || currentLevel == 7 ||
                currentLevel == 9 || currentLevel == 11 || currentLevel == 13 || currentLevel == 15)
            {
                Cursor.lockState = CursorLockMode.Locked;
            }

            initialSceneNum = SceneManager.GetActiveScene().buildIndex;


            if (initialSceneNum == 0 || initialSceneNum == 1 || initialSceneNum == 2 || initialSceneNum == 3 || initialSceneNum == 4)
            {
                FindObjectOfType<AudioManager>().Play("wind");
            }
            if(initialSceneNum == 4)
            {
                Cursor.lockState = CursorLockMode.Locked;
            }
            if(initialSceneNum == 12)
            {
                FindObjectOfType<AudioManager>().Play("alarm");
            }

            firstLoop = true;


        }
    }

    public void GameOver()
    {
        Cursor.lockState = CursorLockMode.None;
        gameOverScreen.SetActive(true);
        FindObjectOfType<AudioManager>().Play("failure");
    }

    public void Success()
    {
        Cursor.lockState = CursorLockMode.None;
        successScreen.SetActive(true);
        FindObjectOfType<AudioManager>().StopPlaying("alarm");
        FindObjectOfType<AudioManager>().Play("success");
    }

    public void RemoveIntro()
    {
        FindObjectOfType<AudioManager>().Play("begin");

        introScreen.SetActive(false);
        if (SceneManager.GetActiveScene().buildIndex == 3)
        {
            snowmobile.gameActive = true;
            Cursor.lockState = CursorLockMode.Locked;
        }
        else if (SceneManager.GetActiveScene().buildIndex == 5)
        {
            steak.gameActive = true;
            Cursor.lockState = CursorLockMode.Locked;
        }
        else if (snippingController != null)
        {
            snippingController.gameActive = true;
        }
        else if(characterMovement != null)
        {
            Cursor.lockState = CursorLockMode.Locked;
            characterMovement.gameActive = true;
            gunScript.gameActive = true;
        }
        else if(windowController != null)
        {
            windowController.gameActive = true;
        }
        else if(dialogueManager != null)
        {
            dialogueManager.gameActive = true;
        }

    }

    public void ResetLevel()
    {
        Cursor.lockState = CursorLockMode.None;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void NextLevel()
    {

        FindObjectOfType<AudioManager>().StopPlaying("wind");

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        print("Quit!");
        Application.Quit();
    }
}
