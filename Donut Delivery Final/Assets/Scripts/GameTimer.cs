using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{

    public float initialTime;
    private static float timeLeft;
    public int housesDelivered;
    int totalHouses;
    public Text timerText;
    public Text message;
    public Text counter;
    static bool timerStopped;
    public static bool playerLost;
    GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("truck_withTexture");
        playerLost = false;
        timeLeft = initialTime;
        timerStopped = false;
        housesDelivered = 0;
        totalHouses = player.GetComponent<HouseSelection>().deliveryGoal/2;
        counter.text = "Donuts Delivered: " + housesDelivered + "/" + totalHouses;
    }

    // Update is called once per frame
    void Update()
    {
        counter.text = "Donuts Delivered: " + housesDelivered + "/" + totalHouses;
        if (!timerStopped)
        {
            timeLeft -= Time.deltaTime;
        }


        if (housesDelivered == totalHouses && !playerLost)
        {
            timerStopped = true;
            message.text = "All donuts delivered on time! Congratulations!";
        }

        if (timeLeft > 10f && !timerStopped)
            timerText.color = Color.green;

        //Text will change to yellow when player has 10 seconds left, red when 5 seconds left
        if (timeLeft <= 10f && timeLeft > 5f && !timerStopped)
            timerText.color = Color.yellow;

        if (timeLeft <= 5f && !timerStopped)
            timerText.color = Color.red;


        if (timeLeft <= 0.00f)
        {
            timerStopped = true;
            playerLost = true;
        }

        if (playerLost)
        {
            message.text = "Time's Up! Try Again? \n       Press Space";

            //press spacebar to restart level
            if (Input.GetKey(KeyCode.Space))
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }


        if (!timerStopped)
            timerText.text = "Time Left: " + timeLeft.ToString("n2");
       
    }

    public static void AddTime(float seconds)
    {
        timeLeft += seconds;
    }
}
