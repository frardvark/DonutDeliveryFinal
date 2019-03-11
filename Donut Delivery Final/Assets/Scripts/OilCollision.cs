using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OilCollision : MonoBehaviour
{
 
    void OnTriggerEnter(Collider col)
    {
        
        if (col.gameObject.tag == "Player")
        {
            col.gameObject.SendMessage("HitObstacle", 2); //Call Method For Oil Slick Slow Down
        }
    }
}
