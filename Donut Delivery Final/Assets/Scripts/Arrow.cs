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
        target = GameObject.Find("Truck").GetComponent<Navigation>().targetHouse;
        transform.LookAt(target.transform);
        // transform.position.x = GameObject.Find("Truck").transform.position.x;
        // transform.position.y = GameObject.Find("Truck").transform.position.y + 1f;
        // transform.position.z = GameObject.Find("Truck").transform.position.z + 1f;

        //transform.position = new Vector3(truck.transform.position.x, truck.transform.position.y + 1, truck.transform.position.z + 1);
    }
}
