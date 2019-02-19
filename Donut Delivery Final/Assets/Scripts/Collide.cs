using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Collide : MonoBehaviour
{
    public GameObject arrow;
    public Navigation nav;
    private GameObject player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        arrow = GameObject.Find("Arrow");
    }

    void OnCollisionEnter(Collision collisionInfo)
    {
        //Debug.Log("Collision detected!");
        if (collisionInfo.collider.tag == "DeliveryTarget")
        {
            //Debug.Log("Delivered!");
            Collider house = collisionInfo.collider;
            house.tag = "Delivered";
            var nav = player.GetComponent<Navigation>();
            //Debug.Log(nav);

            //reset Navigation script
            nav.enabled = false;
            nav.enabled = true;
            arrow.GetComponent<Renderer>().material.color = Color.white;


            Renderer rend = house.GetComponent<Renderer>();
            if (rend != null)
                rend.material.color = Color.black;


        }
    }
}
