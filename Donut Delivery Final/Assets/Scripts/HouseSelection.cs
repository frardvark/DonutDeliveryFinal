using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class HouseSelection : MonoBehaviour
{
    public List<GameObject> deliveryTargets;
    public GameObject targetHouse;
    public GameObject Ring;
    public GameObject throwRangeBig;
    public GameObject throwRangeSmall;
    public GameObject range;
    public GameObject rangeRing;
    public int donutType;
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
        Destroy(rangeRing);
        Destroy(range);
        GameObject.FindGameObjectWithTag("Arrow").GetComponent<Renderer>().material.color = Color.white;
        Debug.Log("Delivery Goal " + deliveryGoal);
        if (deliveryGoal > 0)
        {
            targetHouse = selectTarget();   //Get a New Target
        }
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

                    if (dist < 50)   //House is too close together. Pick another
                    {
                        continue;
                    }
                }
               
                deliveryTargets.RemoveAt(pos);
                if (house.name.Contains("3F"))
                    range = Instantiate(throwRangeBig, house.transform);
                else
                    range = Instantiate(throwRangeSmall, house.transform);

                rangeRing = range.transform.GetChild(0).gameObject;

                int level = GameObject.FindGameObjectWithTag("Canvas").GetComponent<GameTimer>().level;
                
                if ( level == 2 || level == 3)
                {
                    donutType = Random.Range(0, level);
                    
                }
                else
                {
                    donutType = 0;
                }
                switch (donutType)
                {
                    case 0:   //Glazed Donut 
                        {
                            rangeRing.GetComponent<Renderer>().material.color = Color.yellow;
                            break;
                        }
                    case 1:   //Chocolate Donut
                        {
                            rangeRing.GetComponent<Renderer>().material.color = new Color32(102, 54, 5, 0);
                            break;
                        }
                    case 2:
                        {
                            rangeRing.GetComponent<Renderer>().material.color = new Color32(255, 51, 153, 1);
                            break;
                        }
                }

            }
                return house;
        }
    }
}