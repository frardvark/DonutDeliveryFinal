using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeCollision : MonoBehaviour
{
    void OnTriggerEnter(Collider col)
    {

        if (col.gameObject.tag == "Player")
        {
            col.gameObject.SendMessage("HitObstacle", 1); //Call Method For Spike Slow Down

        }
    }
}
