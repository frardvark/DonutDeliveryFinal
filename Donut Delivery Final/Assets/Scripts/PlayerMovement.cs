using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    Rigidbody rb;
    //Control values
    //How much force is applied to the rigidbody
    float engineForce;
    //How much turning torque is applied to the rigidbody
    float torque;
    //Max speed that the car can reach
    float maxSpeed;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        engineForce = 6400f;
        torque = 0.2f;
        maxSpeed = 12f;
    }

    // Update is called once per frame
    void Update()
    {
        //Getting input
        float horizontalAxis = Input.GetAxis("Horizontal");
        float verticalAxis = Input.GetAxis("Vertical");

        //Add forward/backward force to car scaling with input, don't add force if the car is already moving faster than it's max velocity
        if (verticalAxis != 0 && rb.velocity.magnitude <= maxSpeed){
            rb.AddForce(new Vector3(transform.forward.x * verticalAxis * engineForce, transform.forward.y * verticalAxis * engineForce, transform.forward.z * verticalAxis * engineForce));
        }

        //Add rotational force scaling with horizontal input
        if (horizontalAxis != 0){
            //Scale rotation with forward velocity to simulate actual car turning
            transform.Rotate(0, horizontalAxis * rb.velocity.magnitude * torque, 0);
        }
    }

    public IEnumerator HitObstacle(int type)
    {
        switch (type)
        {
            case 0:
                {
                    //Oil Spill
                    Debug.Log("Oil Spill");
                    break;
                }
            case 1:       //Spikes
                {
                    float penalty = engineForce / 2;
                    engineForce -= penalty;
                    yield return new WaitForSeconds(1);
                    engineForce += penalty;
                    break;
                }
        }
    }
}
