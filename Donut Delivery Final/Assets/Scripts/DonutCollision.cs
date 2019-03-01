using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DonutCollision : MonoBehaviour
{
    public GameObject arrow;
    public HouseSelection houseSelection;
    private GameObject player;
    public GameObject ui;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        //arrow = GameObject.Find("Arrow");
        ui = GameObject.Find("Canvas");
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    void OnCollisionEnter(Collision collisionInfo)
    {
        if (collisionInfo.collider.tag == "DeliveryTarget" && !GameTimer.playerLost)
        {
            //Debug.Log("Delivered");
            player.GetComponent<ThrowDonut>().canFire = false;
            Collider house = collisionInfo.collider;
            house.tag = "Delivered";
            ui.GetComponent<GameTimer>().housesDelivered++;
            var houseSelection = player.GetComponent<HouseSelection>();

            houseSelection.onDelivery();
            float distance = Vector3.Distance(houseSelection.targetHouse.transform.position, player.transform.position);
            //arrow.GetComponent<Renderer>().material.color = Color.white;

            //on collision: add seconds according to distance to next house and destroy the donut
            float addedTime = 0.12f * distance;
            GameTimer.AddTime(addedTime);
            Destroy(this.gameObject);
        }
    }
}
