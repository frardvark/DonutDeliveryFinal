using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    Rigidbody rb;
    Rigidbody childrb;
    public float speed;
    public float torque;
    public float maxSpeed;
    GameObject childCube;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        //GameObject childCube = this.gameObject.transform.GetChild(1).gameObject;
        //childrb = childCube.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalAxis = Input.GetAxis("Horizontal");
        float verticalAxis = Input.GetAxis("Vertical");
        if (verticalAxis != 0 && rb.velocity.magnitude <= maxSpeed){
            //rb.AddForce(transform.forward * verticalAxis * speed);
            //Debug.Log("Adding force");
            rb.AddForce(new Vector3(transform.forward.x * verticalAxis * speed, transform.forward.y * verticalAxis * speed, transform.forward.z * verticalAxis * speed));
        }
        //childrb.AddForce(new Vector3(horizontalAxis * torque, 0f, 0f));
        if (horizontalAxis != 0){
            transform.Rotate(0, horizontalAxis * rb.velocity.magnitude * torque, 0);
        }
        //Debug.Log(transform.forward.x);
    }

    IEnumerator HitObstacle()
    {
        float penalty = speed / 2;
        speed -= penalty;
        yield return new WaitForSeconds(3);
        speed += penalty;
        
    }
}
