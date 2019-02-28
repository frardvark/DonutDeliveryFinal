﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowDonut : MonoBehaviour
{
    public GameObject player;
    public GameObject house;
    public GameObject arrow;
    private bool canFire;

    // Start is called before the first frame update
    void Start()
    {
        house = GetComponent<HouseSelection>().targetHouse;
        arrow = GameObject.Find("Arrow");
        

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


    //create new object just above truck and throws it at the house
    void FireDonut()
    {
        Vector3 position = player.transform.position;
        Vector3 target = house.transform.position;
        float x = position.x;
        float y = position.y;
        float z = position.z;
        GameObject donut = GameObject.CreatePrimitive(PrimitiveType.Sphere);
       // donut.AddComponent<Collide>();
        Rigidbody donut_rb = donut.AddComponent<Rigidbody>();
        donut.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        donut.transform.position = new Vector3(x, y + 2, z);
        Vector3 direction = target - position;
        donut_rb.AddForce(direction * 100);
        //canFire = false;
        //checkCD = cooldown;
    }
}
