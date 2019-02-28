using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DonutCollision : MonoBehaviour
{
    public GameObject arrow;
    public HouseSelection houseSelection;
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {

        player = GameObject.FindGameObjectWithTag("Player");
        arrow = GameObject.Find("Arrow");


    }

// Update is called once per frame
void Update()
    {
        void OnCollisionEnter(Collision collisionInfo)
        {
            if (collisionInfo.collider.tag == "DeliveryTarget" && !GameTimer.playerLost)
            {
                Collider house = collisionInfo.collider;
                house.tag = "Delivered";
                var nav = player.GetComponent<HouseSelection>();

                //reset HouseSelection script
                nav.enabled = false;
                nav.enabled = true;
                float distance = Vector3.Distance(nav.targetHouse.transform.position, player.transform.position);
                arrow.GetComponent<Renderer>().material.color = Color.white;


                Renderer rend = house.GetComponent<Renderer>();
                if (rend != null)
                    rend.material.color = Color.black;

                //on collision: add seconds according to distance to timer and destroy the donut
                float addedTime = 0.12f * distance;
                GameTimer.AddTime(addedTime);
                Destroy(this.gameObject);
            }
        }
    }
}
