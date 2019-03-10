using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    GameObject target;
    GameObject truck;


    // Start is called before the first frame update
    void Start()
    {

        truck = GameObject.Find("Truck");
        GetComponent<Renderer>().material.color = Color.white;

    }

    // Update is called once per frame
    void Update()
    {
        target = GameObject.Find("Truck").GetComponent<HouseSelection>().targetHouse;
        transform.LookAt(target.transform);
    }
}