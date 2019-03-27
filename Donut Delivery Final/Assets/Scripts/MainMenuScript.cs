using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class MainMenuScript : MonoBehaviour
{
    public enum MenuState { Main, LevelSelect, Options, Erase};
    public MenuState currentState;
    public GameObject main;
    public GameObject levelSelect;
    public GameObject options;
    public GameObject erase;
    public int levelsCleared;
    public Dropdown dropdown;

    // Start is called before the first frame update
    void Start()
    {
        currentState = MenuState.Main;
        main = transform.Find("Main").gameObject;
        levelSelect = transform.Find("LevelSelect").gameObject;
        options = transform.Find("Options").gameObject;
        erase = transform.Find("ConfirmErase").gameObject;
        levelsCleared = PlayerPrefs.GetInt("LevelsCleared", 0);
        Debug.Log("Loaded Save Data: Levels cleared = " + levelsCleared);
    }

    // Update is called once per frame
    void Update()
    {
        switch (currentState)
        {
            case MenuState.Main:
                main.SetActive(true);
                levelSelect.SetActive(false);
                options.SetActive(false);
                erase.SetActive(false);

                break;

            case MenuState.LevelSelect:
                levelSelect.SetActive(true);
                main.SetActive(false);
                options.SetActive(false);
                erase.SetActive(false);
                break;

            case MenuState.Options:
                options.SetActive(true);
                main.SetActive(false);
                levelSelect.SetActive(false);
                erase.SetActive(false);
                break;

            case MenuState.Erase:
                erase.SetActive(true);
                options.SetActive(false);
                main.SetActive(false);
                levelSelect.SetActive(false);
                break;
        }
    }

    public void onPlay()
    {
        SceneManager.LoadScene("Level 1");
    }

    public void onBack()
    {
        currentState = MenuState.Main;
    }

    public void onLevelSelect()
    {
        currentState = MenuState.LevelSelect;
    }

    public void LoadLevel(string level)
    {
        Debug.Log("Loading " + level);
        SceneManager.LoadScene(level);
    }

    public void onOptions()
    {
        currentState = MenuState.Options;
    }

    public void onErase()
    {
        currentState = MenuState.Erase;
    }

    public void quitGame()
    {
        Application.Quit();
    }

    public void windowed()
    {
        Screen.fullScreen = false;
    }

    public void fullscreen()
    {
        Screen.fullScreen = true;
    }

    public void EraseData()
    {
        PlayerPrefs.DeleteAll();
        Debug.Log("Player data erased!");
        levelsCleared = 0;
        currentState = MenuState.Options;
    }

    //WIP
    public void updateResolution()
    {
        Debug.Log("Change resolution called");
        switch (dropdown.value)
        {
            case 0:
                Screen.SetResolution(1920, 1080, Screen.fullScreen);
                break;
            case 1:
                Screen.SetResolution(1600, 900, Screen.fullScreen);
                break;
            case 2:
                Screen.SetResolution(900, 600, Screen.fullScreen);
                break;

        }

    }
}
