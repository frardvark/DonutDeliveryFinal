using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class HouseSelection : MonoBehaviour
{
    public List<GameObject> deliveryTargets;
    public GameObject targetHouse;
    public int deliveryGoal;    //Number of houses you have to deliver to beat level  

    // Start is called before the first frame update
    void Start()
    {
        //Initialize Possible Delivery Targets
        deliveryTargets = new List<GameObject>(GameObject.FindGameObjectsWithTag("DeliveryTarget"));

        targetHouse = selectTarget();
        targetHouse.GetComponent<Renderer>().material.color = Color.green;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void onDelivery()
    {
        deliveryGoal--;
        if(deliveryGoal > 0)
        {
            targetHouse = selectTarget();   //Get a New Target
        }
        //Else Signify Level is over
    }

    //Make sure they are not too close together
    GameObject selectTarget()
    {
        GameObject house = new GameObject();

        if (deliveryTargets != null && deliveryTargets.Count > 0)
        {
            int pos = Random.Range(0, deliveryTargets.Count - 1);
            house = deliveryTargets.ElementAt(pos);
            deliveryTargets.RemoveAt(pos);
        }
        return house; 
    }
}