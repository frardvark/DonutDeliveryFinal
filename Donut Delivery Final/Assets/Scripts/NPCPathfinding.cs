using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCPathfinding : MonoBehaviour
{

    /*HOW TO USE THIS SCRIPT:
     1. Attach this script to any NPC gameObject to which you want to give a 3 point circular path to follow
     2. Additionally attach a NavMeshAgent to the NPC gameObject and tweak its values to whatever you want them to be
     3. Create 3 additional game objects (I use empties but they can be whatever) that will represent waypoints for the NPC to sequentially path towards. Protip: Don't make the waypoints children of NPC
     4. Drag and drop your waypoints into the respective public waypoint objects of the script in Editor. */ 
    //Waypoints must be set manually in Unity Editor for EVERY INDIVIDUAL NPC
    public GameObject waypoint1;
    public GameObject waypoint2;
    public GameObject waypoint3;

    Transform[] destinations;
    Transform currentDestination;
    int i;

    NavMeshAgent navMeshAgent;
    // Start is called before the first frame update
    void Start()
    {
        destinations = new Transform[]{ waypoint1.transform, waypoint2.transform, waypoint3.transform};
        i = 0;
        currentDestination = destinations[i];
        navMeshAgent = GetComponent<NavMeshAgent>();
        navMeshAgent.SetDestination(currentDestination.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        if (Mathf.Abs(transform.position.x - currentDestination.transform.position.x) < 3 && Mathf.Abs(transform.position.z - currentDestination.transform.position.z) < 3)
        {
            currentDestination = destinations[(++i)%3];
            navMeshAgent.SetDestination(currentDestination.transform.position);
        }
    }
}
