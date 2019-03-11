using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class HouseSelection : MonoBehaviour
{
    public List<GameObject> deliveryTargets;
    public GameObject targetHouse;
    public GameObject Ring;
    public GameObject range;
    public int deliveryGoal;    //Number of houses you have to deliver to beat level  

    void Start()
    {
        //Initialize Possible Delivery Targets
        deliveryTargets = new List<GameObject>(GameObject.FindGameObjectsWithTag("DeliveryTarget"));

        targetHouse = selectTarget();
    }
  

    public void onDelivery()
    {
        deliveryGoal--;
        Destroy(range); //Test this. Does it delete the whole variable or just the one ring object?

        if (deliveryGoal > 0)
        {
            targetHouse = selectTarget();   //Get a New Target
        }
        //Else Signify Level is over
    }

    //Make sure they are not too close together
    GameObject selectTarget()
    {
        GameObject house = new GameObject();
       

        while (true)
        {

            if (deliveryTargets != null && deliveryTargets.Count > 0)
            {
                int pos = Random.Range(0, deliveryTargets.Count - 1);
                house = deliveryTargets.ElementAt(pos);

                if (targetHouse != null)
                {
                    float dist = Vector3.Distance(targetHouse.transform.position, house.transform.position);

                    if (dist > 40)   //Mess With This Value. Possible edge case in a map is the first house selected is the middle one and nothing is far enough away. 
                    {
                        deliveryTargets.RemoveAt(pos);
                        range = Instantiate(Ring, house.transform.GetChild(2).transform);
                        range.GetComponent<Renderer>().material.color = Color.yellow;   //Could change color based on donut type
                        return house;
                    }
                }
                else //First Target
                {
                    deliveryTargets.RemoveAt(pos);
                    range = Instantiate(Ring, house.transform.GetChild(2).transform);
                    range.GetComponent<Renderer>().material.color = Color.yellow;
                    return house;
                }

            }
        }
    }
}