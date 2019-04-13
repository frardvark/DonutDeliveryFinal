using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class Credits : MonoBehaviour
{
    private enum credits {Presents, Production, Game, Name, Erase }
    private credits currentState;
    public Text creditsText;

    // Start is called before the first frame update
    void Start()
    {
        currentState = credits.Presents;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ChangeTextEvent()
    {
        currentState++;
        switch (currentState)
        {
            case credits.Presents:
                creditsText.text = "Jaleno Studios Presents";
                break;

            case credits.Production:
                creditsText.text = "A Jaleno Studios Production";
                break;

            case credits.Game:
                creditsText.text = "A CAP4053 and DIG4715C Game";
                break;

            case credits.Name:
                creditsText.text = "Donut Delivery";
                break;

            case credits.Erase:
                GameObject.Destroy(creditsText);
                break;

        }
    }

    public void OnCreditsEnd()
    {
        SceneManager.LoadScene(0);
    }

}
