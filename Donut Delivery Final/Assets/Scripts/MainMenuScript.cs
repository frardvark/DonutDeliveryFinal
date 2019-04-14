using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class MainMenuScript : MonoBehaviour
{
    private enum MenuState { Main, LevelSelect, Options, Erase, SaveSelect};
    private MenuState currentState;
    private GameObject main;
    private GameObject levelSelect;
    private GameObject options;
    private GameObject erase;
    private GameObject saveSelect;
    private int levelsCleared;
    private Dropdown dropdown;
    public int total_levels = 3;
    //public int saveFile;
    private SaveData saveData;
    public Text file1;
    public Text file2;
    public Text file3;
    public Text file4;
    private Text[] files;
    
    void Awake()
    {
        currentState = MenuState.SaveSelect;
        main = transform.Find("Main").gameObject;
        levelSelect = transform.Find("LevelSelect").gameObject;
        options = transform.Find("Options").gameObject;
        erase = transform.Find("ConfirmErase").gameObject;
        saveSelect = transform.Find("FileSelect").gameObject;

        files = new Text[4];
        files[0] = file1;
        files[1] = file2;
        files[2] = file3;
        files[3] = file4;
        SetupFiles();
        
        //Debug.Log(options.transform.Find("Dropdown1").GetComponent<Dropdown>());
        dropdown = options.transform.Find("Dropdown1").GetComponent<Dropdown>();
        dropdown.onValueChanged.AddListener(delegate {
            updateResolution(dropdown);
        });
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
                saveSelect.SetActive(false);
                break;

            case MenuState.LevelSelect:
                levelSelect.SetActive(true);
                main.SetActive(false);
                options.SetActive(false);
                erase.SetActive(false);
                saveSelect.SetActive(false);
                break;

            case MenuState.Options:
                options.SetActive(true);
                main.SetActive(false);
                levelSelect.SetActive(false);
                erase.SetActive(false);
                saveSelect.SetActive(false);
                break;

            case MenuState.Erase:
                erase.SetActive(true);
                options.SetActive(false);
                main.SetActive(false);
                levelSelect.SetActive(false);
                saveSelect.SetActive(false);
                break;

            case MenuState.SaveSelect:
                saveSelect.SetActive(true);
                erase.SetActive(false);
                options.SetActive(false);
                main.SetActive(false);
                levelSelect.SetActive(false);
                break;
        }
    }

    public void onPlay()
    {
        //Debug.Log("Play button clicked");
        //levelsCleared = PlayerPrefs.GetInt("LevelsCleared", 0);

        levelsCleared = saveData.levelsCleared;

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

    //TODO: erase save files
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
        Debug.Log("SetupLevel reports " + levelsCleared + " levels cleared");
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
            else
            {
                level_buttons[i].GetComponent<Button>().interactable = true;
            }
        }
    }

    public void SetupFiles()
    {
        for (int i = 0; i < 4; i++)
        {
            SaveData data = SaveSystem.LoadState(i + 1);
            files[i].text = data.levelsCleared + " levels cleared";
        }
        

    }

    public void OnCredits()
    {
        SceneManager.LoadScene("Credits");
    }

    public void ChooseSaveFile(int number)
    {
        //Debug.Log("File " + number + " called");
        PlayerPrefs.SetInt("saveFile", number);
        saveData = SaveSystem.LoadState(number);
        levelsCleared = saveData.levelsCleared;
        Debug.Log("Loaded Save Data: Levels cleared = " + levelsCleared);
        SetupLevelSelect();
        currentState = MenuState.Main;
    }

    public void SaveFileMenu()
    {
        currentState = MenuState.SaveSelect;
    }
}
