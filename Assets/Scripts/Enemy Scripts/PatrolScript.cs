using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolScript : MonoBehaviour
{

    public float speed;
    private float waitTime;
    public float startWaitTime;


    public Transform[] patrolLocations = new Transform[5]; 

    private int nextSpot;

    private int lastSpot;

    public Vector3 lookDir;

    public bool otherMovement;

    public bool waypointsSet = false;


    // Start is called before the first frame update
    void Start()
    {
        waitTime = startWaitTime;

        nextSpot = Random.Range(0, patrolLocations.Length);

        //lookDir = patrolLocations[nextSpot].position - transform.position;

        lastSpot = nextSpot;

        otherMovement = false;

        
    }


    void schedule()
    {

    }

    // Update is called once per frame
    void Update()
    { 
        if (!waypointsSet)
        {
            if (GameObject.FindWithTag("Waypoint") != null)
            {

                patrolLocations.SetValue(GameObject.Find("waypoint0").transform, 0);

                patrolLocations.SetValue(GameObject.Find("waypoint1").transform, 1);

                patrolLocations.SetValue(GameObject.Find("waypoint2").transform, 2);

                patrolLocations.SetValue(GameObject.Find("waypoint3").transform, 3);

                patrolLocations.SetValue(GameObject.Find("waypoint4").transform, 4);

                transform.position = new Vector3(patrolLocations[nextSpot].position.x, transform.position.y, patrolLocations[nextSpot].position.z);


                print(patrolLocations[nextSpot].position.x);

                waypointsSet = true;
            }

        }


        
        if (!otherMovement)
        {
            transform.position = Vector3.MoveTowards(transform.position,  patrolLocations[nextSpot].position, speed * Time.deltaTime);
        }

        //print(Vector2.Distance(transform.position, patrolLocations[nextSpot].position));
        print(nextSpot);
        if (Vector2.Distance(transform.position,  patrolLocations[nextSpot].position) < 0.2f)
        {
            print("here");
            if (waitTime <= 0)
            {

                
                do
                {
                    nextSpot = Random.Range(0, patrolLocations.Length);
                }
                while (nextSpot != lastSpot + 1 && nextSpot != lastSpot - 1);
                lastSpot = nextSpot;
                waitTime = startWaitTime;
                lookDir =  patrolLocations[nextSpot].position - transform.position;
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
        