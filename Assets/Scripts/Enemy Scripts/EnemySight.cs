using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemySight : MonoBehaviour
{
    public float speed;

    public bool passedThrough;

    public bool exited;

    public Vector3 lastKnownLoc;

    public NavMeshAgent agent;


    // Start is called before the first frame update
    void Start()
    {
        passedThrough = false;

        exited = false;

    }




    void OnTriggerStay(Collider other)
    {
        // passedThrough = true;
        //  other.GetComponent<Rigidbody>().AddForce(Vector3.up * 12, ForceMode.Acceleration);
        
        if (other.gameObject.tag == "Player")
        {
            //Debug.Log("Colliding!!");
           // Debug.Log("here");
            passedThrough = true;
            lastKnownLoc = other.transform.position;

            if (agent.remainingDistance <= agent.stoppingDistance)
            {
                return;
            }
            else
            {
                //transform.position = Vector3.MoveTowards(transform.position, lastKnownLoc, speed * Time.deltaTime);
                agent.SetDestination(lastKnownLoc);
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            exited = true;
        }
        
    }
}
