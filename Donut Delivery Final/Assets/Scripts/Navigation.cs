using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Navigation : MonoBehaviour
{
    //public GameObject respawnPrefab;
    public GameObject[] deliveryTargets;
    public GameObject targetHouse;
    public GameObject counter;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnEnable()
    {
        deliveryTargets = GameObject.FindGameObjectsWithTag("DeliveryTarget");

        if (deliveryTargets != null && deliveryTargets.Length > 0)
            targetHouse = deliveryTargets[Random.Range(0, deliveryTargets.Length - 1)];


        targetHouse.GetComponent<Renderer>().material.color = Color.green;
        counter = GameObject.Find("Timer");
        counter.GetComponent<Timer>().houses++;
    }


    // Update is called once per frame
    void Update()
    {

    }
}
