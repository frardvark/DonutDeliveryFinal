using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    GameObject player;
    Rigidbody player_rb;
    public Canvas menu;
    public GameObject main;
    public GameObject help;
    public GameObject quit;
    public enum MenuState { Pause, Help, Game, Quit};
    public MenuState currentState;

    
    void Awake()
    {
        player = GameObject.Find("truck_withTexture");
        player_rb = player.GetComponent<Rigidbody>();
        menu = gameObject.GetComponent<Canvas>();
        menu.enabled = false;
        currentState = MenuState.Game;
        main = transform.Find("Main").gameObject;
        help = transform.Find("Help Menu").gameObject;
        quit = transform.Find("Quit").gameObject;
        resumeGame();
    }

    private void Update()
    {
        //when player presses escape
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            //make menu visible and pause game
            if (!menu.enabled)
            {
                pauseGame();
                menu.enabled = true;
            }
            else
            {
                resumeGame();
            }

        }

        switch (currentState)
        {
            case MenuState.Game:
                menu.enabled = false;
                break;

            case MenuState.Help:
                menu.enabled = true;
                help.SetActive(true);
                main.SetActive(false);
                quit.SetActive(false);
                break;

            case MenuState.Pause:
                menu.enabled = true;
                main.SetActive(true);
                help.SetActive(false);
                quit.SetActive(false);
                break;

            case MenuState.Quit:
                menu.enabled = true;
                quit.SetActive(true);
                main.SetActive(false);
                help.SetActive(false);

                break;
        }

    }

    public void OnHelp()
    {
        //display help menu
        currentState = MenuState.Help;

    }

    public void pauseGame()
    {
        Time.timeScale = 0f;
        player_rb.isKinematic = true;
        currentState = MenuState.Pause;
    }

    //for use by menu buttons
    public void resumeGame()
    {
        Time.timeScale = 1f;
        player_rb.isKinematic = false;
        currentState = MenuState.Game;
        menu.enabled = false;
    }

    public void onBack()
    {
        currentState = MenuState.Pause;
    }

    public void onQuit()
    {
        currentState = MenuState.Quit;
    }

    public void quitGame()
    {
        player_rb.isKinematic = false;
        SceneManager.LoadScene("MainMenu");
    }
}
