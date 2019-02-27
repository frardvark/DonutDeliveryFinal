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
        if (collisionInfo.collider.tag == "DeliveryTarget" && !Timer.playerLost)
        {
            Collider house = collisionInfo.collider;
            house.tag = "Delivered";
            var nav = player.GetComponent<Navigation>();

            //reset Navigation script
            nav.enabled = false;
            nav.enabled = true;
            float distance = Vector3.Distance(nav.targetHouse.transform.position, player.transform.position);
            arrow.GetComponent<Renderer>().material.color = Color.white;


            Renderer rend = house.GetComponent<Renderer>();
            if (rend != null)
                rend.material.color = Color.black;

            //on collision: add seconds according to distance to timer and destroy the donut
            float addedTime = 0.12f * distance;
            Timer.AddTime(addedTime);
            Destroy(this.gameObject);
        }
    }
}
