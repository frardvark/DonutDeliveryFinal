using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowDonut : MonoBehaviour
{
    public GameObject player;
    public GameObject house;
    public GameObject arrow;
    public GameObject donutModel;
    public bool canFire;

    // Start is called before the first frame update
    void Start()
    {
        house = GetComponent<HouseSelection>().targetHouse;
        player = GameObject.FindGameObjectWithTag("Player");
        //arrow = GameObject.Find("Arrow");
        canFire = false;
    }

    // Update is called once per frame
    void Update()
    {
        house = GetComponent<HouseSelection>().targetHouse;

        //Fire donut with 'E' key
        if (Input.GetKey(KeyCode.E) && canFire)
        {
            FireDonut();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == house.transform.GetChild(2).name)
        {
            canFire = true;
            GameObject.FindGameObjectWithTag("Arrow").GetComponent<Renderer>().material.color = Color.green;
            //Debug.Log("Can fire!");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == house.transform.GetChild(0).name)
        {
            canFire = false;
            GameObject.FindGameObjectWithTag("Arrow").GetComponent<Renderer>().material.color = Color.white;
        }
    }


    //create new object just above truck and throws it at the house
    void FireDonut()
    {
        Vector3 position = player.transform.position;
        Vector3 target = house.transform.position;
        float x = position.x;
        float y = position.y;
        float z = position.z;
        GameObject donut = Instantiate(donutModel);
        if (donut != null)
        {
            //Debug.Log("Donut not null");
        }
        
            if (donut.GetComponent<Rigidbody>() == null)
            {
                //Debug.Log("Rigidbody not attached, attaching");
                donut.AddComponent<Rigidbody>();
            }
            if (donut.GetComponent<DonutCollision>() == null)
                donut.AddComponent<DonutCollision>();
            if (donut.GetComponent<BoxCollider>() == null)
                donut.AddComponent<BoxCollider>();
            
            Rigidbody donut_rb = donut.GetComponent<Rigidbody>();
            donut.transform.localScale = new Vector3(1f, 1f, 1f);
            donut.transform.position = new Vector3(x, y + 2, z);
            Vector3 direction = target - position;
            donut_rb.AddForce(direction * 100);
            canFire = false;
            //Debug.Log("Reached end of fireDonut script");
        
    }
}
