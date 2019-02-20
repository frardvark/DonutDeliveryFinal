using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float TimeLimit = 10f;
    public static float checkTime;
    public int houses;
    public int totalHouses;
    public Text timerText;
    public Text message;
    public Text counter;
    private bool stop;
    private bool lost;

    // Start is called before the first frame update
    void Start()
    {
        lost = false;
        checkTime = TimeLimit;
        stop = false;
        houses = 0;
        var deliveryTargets = GameObject.FindGameObjectsWithTag("DeliveryTarget");
        totalHouses = deliveryTargets.Length;
        counter.text = "Donuts Delivered: " + houses;
    }

    // Update is called once per frame
    void Update()
    {
        counter.text = "Donuts Delivered: " + houses;
        if (!stop)
        {
            checkTime -= Time.deltaTime;
        }
            

        if (houses == totalHouses && !lost)
        {
            stop = true;
            message.text = "All donuts delivered on time! Congratulations!";
        }

        if (checkTime > 10f)
            timerText.color = Color.green;

        //Text will change to yellow when timer < 50% and to red when timer < 20%
        if (checkTime <= 10f && checkTime > 5f)
            timerText.color = Color.yellow;
        
        if (checkTime <= 5f)
            timerText.color = Color.red;
        

        if (checkTime <= 0.00f)
        {
            stop = true;
            lost = true;
            message.text = "Time's Up! Try Again? \n       Press Space";

            //press spacebar to restart level
            if (Input.GetKey(KeyCode.Space))
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
            
        
        if (!stop)
            timerText.text = "Time Left: " + checkTime.ToString("n2") + " seconds";
        else
            timerText.text = "Time Left: 0.00";
        
    }
}
