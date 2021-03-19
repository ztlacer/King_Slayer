using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolScript : MonoBehaviour
{

    public float speed;
    private float waitTime;
    public float startWaitTime;

    public Transform[] patrolLocations;

    private int nextSpot;

    private int lastSpot;

    public Vector3 lookDir;

    public bool otherMovement;

    // Start is called before the first frame update
    void Start()
    {
        waitTime = startWaitTime;

        nextSpot = Random.Range(0, patrolLocations.Length);

        lookDir = patrolLocations[nextSpot].position - transform.position;

        lastSpot = nextSpot;

        otherMovement = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!otherMovement)
        {
            transform.position = Vector3.MoveTowards(transform.position, patrolLocations[nextSpot].position, speed * Time.deltaTime);
        }
        

        if (Vector2.Distance(transform.position, patrolLocations[nextSpot].position) < 0.2f)
        {
            if (waitTime <= 0)
            {

                
                do
                {
                    nextSpot = Random.Range(0, patrolLocations.Length);
                }
                while (nextSpot != lastSpot + 1 && nextSpot != lastSpot - 1);
                lastSpot = nextSpot;
                waitTime = startWaitTime;
                lookDir = patrolLocations[nextSpot].position - transform.position;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            otherMovement = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            otherMovement = false;
        }
    }
}
