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
        targetHouse.GetComponent<Renderer>().material.color = Color.green;  //Testing (Should add ring to throwrange)
    }

    // Update is called once per frame
    void Update()
    {
        //Will be replaced with throwing the donut
        if (Input.GetKey(KeyCode.E))
        {
            //onDelivery();
        }
    }

    public void onDelivery()
    {
        deliveryGoal--;
        targetHouse.GetComponent<Renderer>().material.color = Color.red; //Testing (Should remove ring from throwrange)
        Destroy(range);

        if (deliveryGoal > 0)
        {
            targetHouse = selectTarget();   //Get a New Target
            targetHouse.GetComponent<Renderer>().material.color = Color.green; //Testing (Should add ring to throwrange)
        }
        //Else Signify Level is over
    }

    //Make sure they are not too close together
    GameObject selectTarget()
    {
        GameObject house = new GameObject();
        range = Instantiate(Ring) as GameObject; 
        //range.GetComponent<Renderer>().material.color = Color.yellow;

        while (true)
        {

            if (deliveryTargets != null && deliveryTargets.Count > 0)
            {
                int pos = Random.Range(0, deliveryTargets.Count - 1);
                house = deliveryTargets.ElementAt(pos);

                if (targetHouse != null)
                {
                    float dist = Vector3.Distance(targetHouse.transform.position, house.transform.position);

                    if (dist > 40)   //Play With This Value. Possible edge case in a map is the first house selected is the middle one and nothing is far enough away. 
                    {
                        deliveryTargets.RemoveAt(pos);
                        range.transform.parent = house.transform.GetChild(2).transform;
                        Debug.Log(house.transform.GetChild(2).name);
                        return house;
                    }
                }
                else //First Target
                {
                    deliveryTargets.RemoveAt(pos);
                    range.transform.parent = house.transform.GetChild(2).transform;
                    Debug.Log(house.transform.GetChild(2).name);
                    Debug.Log(house.transform.GetChild(2).transform.GetChild(0).name);
                    return house;
                }

            }
        }
    }
}