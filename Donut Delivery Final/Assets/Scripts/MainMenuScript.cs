using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class MainMenuScript : MonoBehaviour
{
    private enum MenuState { Main, LevelSelect, Options, Erase, SelectSave, HowToPlay};
    private MenuState currentState;
    private GameObject main;
    private GameObject levelSelect;
    private GameObject options;
    private GameObject erase;
    private GameObject selectSave;
    private GameObject howToPlay;
    private GameObject tutorial;
    private int levelsCleared;
    public Dropdown dropdown;
    public int total_levels = 3;
    public int selectedSaveFile;
    public Sprite tutorialImage1;
    public Sprite tutorialImage2;
    public Sprite tutorialImage3;
    public Sprite tutorialImage4;
    public Sprite tutorialImage5;
    Sprite[] slides;
    int currSlide;

    void Awake()
    {
        
        
        main = transform.Find("Main").gameObject;
        levelSelect = transform.Find("LevelSelect").gameObject;
        options = transform.Find("Options").gameObject;
        erase = transform.Find("ConfirmErase").gameObject;
        selectSave = transform.Find("SaveFileSelect").gameObject;
        howToPlay = transform.Find("HowToPlay").gameObject;
        tutorial = transform.Find("Tutorial").gameObject;
        //Debug.Log(selectSave);

        //Debug.Log("Loaded Save Data: Levels cleared = " + levelsCleared);
        SetupLevelSelect();
        Debug.Log(options.transform.Find("Dropdown1").GetComponent<Dropdown>());
        dropdown = options.transform.Find("Dropdown1").GetComponent<Dropdown>();
        dropdown.onValueChanged.AddListener(delegate {
            updateResolution(dropdown);
        });
        currentState = MenuState.SelectSave;

        slides = new Sprite[] { tutorialImage1, tutorialImage2, tutorialImage3, tutorialImage4, tutorialImage5 };
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
                selectSave.SetActive(false);
                howToPlay.SetActive(false);
                tutorial.SetActive(false);
                break;

            case MenuState.LevelSelect:
                levelSelect.SetActive(true);
                main.SetActive(false);
                options.SetActive(false);
                erase.SetActive(false);
                selectSave.SetActive(false);
                howToPlay.SetActive(false);
                tutorial.SetActive(false);
                break;

            case MenuState.Options:
                options.SetActive(true);
                main.SetActive(false);
                levelSelect.SetActive(false);
                erase.SetActive(false);
                selectSave.SetActive(false);
                howToPlay.SetActive(false);
                tutorial.SetActive(false);
                break;

            case MenuState.Erase:
                erase.SetActive(true);
                options.SetActive(false);
                main.SetActive(false);
                levelSelect.SetActive(false);
                selectSave.SetActive(false);
                howToPlay.SetActive(false);
                tutorial.SetActive(false);
                break;

            case MenuState.SelectSave:
                selectSave.SetActive(true);
                options.SetActive(false);
                main.SetActive(false);
                levelSelect.SetActive(false);
                erase.SetActive(false);
                howToPlay.SetActive(false);
                tutorial.SetActive(false);
                break;

            case MenuState.HowToPlay:
                selectSave.SetActive(false);
                options.SetActive(false);
                main.SetActive(false);
                levelSelect.SetActive(false);
                erase.SetActive(false);
                howToPlay.SetActive(true);
                tutorial.SetActive(true);
                break;
        }
    }

    public void onPlay()
    {
        Debug.Log("Play button clicked");
        levelsCleared = PlayerPrefs.GetInt("LevelsCleared", 0);
        int toLoad = levelsCleared + 1;
        if (toLoad > total_levels)
            toLoad = total_levels;
        Debug.Log("Loading level " + toLoad);
        SceneManager.LoadScene(toLoad);
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

    public void onHowToPlay()
    {
        currSlide = 0;
        currentState = MenuState.HowToPlay;
        tutorial.GetComponent<Image>().sprite = slides[currSlide];
        howToPlay.transform.GetChild(0).GetComponent<Text>().text = (currSlide % 5 + 1) + "/5";
    }

    public void previous()
    {
        tutorial.GetComponent<Image>().sprite = slides[(--currSlide) % 5];
        howToPlay.transform.GetChild(0).GetComponent<Text>().text = (currSlide % 5 + 1) + "/5";
    }

    public void next()
    {
        tutorial.GetComponent<Image>().sprite = slides[(++currSlide) % 5];
        howToPlay.transform.GetChild(0).GetComponent<Text>().text = (currSlide % 5 + 1) + "/5";
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
        SetupLevelSelect();
    }

    public void updateResolution(Dropdown res_dropdown)
    {
        Debug.Log("Change resolution called");
        //Dropdown dropdown = transform.Find("Options").transform.Find("Dropdown1").gameObject.GetComponent<Dropdown>();
        Debug.Log("Option #" + res_dropdown.value + " called");
        switch (res_dropdown.value)
        {
            case 0:
                Screen.SetResolution(1920, 1080, Screen.fullScreen);
                break;
            case 1:
                Screen.SetResolution(1600, 900, Screen.fullScreen);
                break;
            case 2:
                Screen.SetResolution(1280, 720, Screen.fullScreen);
                break;
            case 3:
                Screen.SetResolution(1024, 768, Screen.fullScreen);
                break;

        }

    }

    public void SetupLevelSelect()
    {
        //make array for level buttons
        Debug.Log("Total levels: " + total_levels);
        levelSelect = transform.Find("LevelSelect").gameObject;
        Transform[] level_buttons = new Transform[total_levels];
        Transform level1_button = levelSelect.transform.Find("level1_button");
        Transform level2_button = levelSelect.transform.Find("level2_button");
        Transform level3_button = levelSelect.transform.Find("level3_button");
        level_buttons[0] = level1_button;
        level_buttons[1] = level2_button;
        level_buttons[2] = level3_button;

        //disable level buttons if not cleared
        for (int i = 0; i < total_levels; i++)
        {
            if (levelsCleared < i)
            {
                level_buttons[i].GetComponent<Button>().interactable = false;
                //Debug.Log("level button disabled");
            }
        }
    }

    public void OnCredits()
    {
        SceneManager.LoadScene("Credits");
    }
    
    public void SelectSaveFile(int saveFile)
    {
        selectedSaveFile = saveFile;
        Debug.Log("Selected save file number " + saveFile);
        currentState = MenuState.Main;

        //load save file
        PlayerPrefs.SetInt("SaveFile", saveFile);
        switch (saveFile)
        {
            case 1:
                levelsCleared = PlayerPrefs.GetInt("LevelsCleared1", 0);
                break;

            case 2:
                levelsCleared = PlayerPrefs.GetInt("LevelsCleared2", 0);
                break;

            case 3:
                levelsCleared = PlayerPrefs.GetInt("LevelsCleared3", 0);
                break;

            case 4:
                levelsCleared = PlayerPrefs.GetInt("LevelsCleared4", 0);
                break;
        }
        Debug.Log("Loaded save data: levels cleared = " + levelsCleared);



    }
}
