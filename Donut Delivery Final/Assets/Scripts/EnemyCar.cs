using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyCar : MonoBehaviour
{
    private Vector3 velocity;
    // Start is called before the first frame update
    void Start()
    {
        velocity = transform.forward;
        if (transform.rotation.y != 0)
        {
            velocity.z = transform.rotation.y;
            velocity.x = 0;
        }
        velocity *= .15f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(velocity);
        //Debug.Log(velocity);
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Bound")
        {
            //velocity *= -1;
            transform.RotateAround(transform.position, transform.up, 180.0f);
        }
    }
}
