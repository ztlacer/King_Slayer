using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySight : MonoBehaviour
{
    public float speed;

    public bool passedThrough;

    public bool exited;

    public Vector3 lastKnownLoc;


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
        
        if (other.gameObject.name == "Player")
        {
           // Debug.Log("here");
            passedThrough = true;
            lastKnownLoc = other.transform.position;

            if ((Vector2.Distance(transform.position, lastKnownLoc) < .5f))
            {
                return;
            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, lastKnownLoc, speed * Time.deltaTime);
            }
        }

    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            exited = true;
        }
        
    }
}
