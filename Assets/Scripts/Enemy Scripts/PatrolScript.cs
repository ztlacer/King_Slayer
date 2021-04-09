using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PatrolScript : MonoBehaviour
{

    public float speed;
    private float waitTime;
    public float startWaitTime;
    public float wanderTime = 10;

    public NavMeshAgent agent;


    public Transform[] patrolLocations = new Transform[5];

    private int nextSpot;

    private int lastSpot;

    public Vector3 lookDir;

    public bool otherMovement;

    public bool waypointsSet = false;

    public Queue<int> prioQueue = new Queue<int>();

    private bool currentAction = true;

    private bool setLocation = false;

    private bool firstWander = true;




    // Start is called before the first frame update
    void Start()
    {
        waitTime = startWaitTime;

        nextSpot = Random.Range(0, patrolLocations.Length);

        //lookDir = patrolLocations[nextSpot].position - transform.position;

        lastSpot = nextSpot;

        otherMovement = false;


    }


    void scheduleQueue(int type)
    {
        if (type == 0)
        {
            for (int i = 0; i < 5; i++)
            {
                if (Random.Range(0, 2) == 0)
                {
                    prioQueue.Enqueue(0); //Adds a change waypoint location
                }
                else
                {
                    prioQueue.Enqueue(1); //Adds a look around
                }
            }

        }
        else
        {
            prioQueue.Clear(); //Clears any other actions the AI are taking
            prioQueue.Enqueue(2); //Chases the player
            prioQueue.Enqueue(1); //Looks around after losing them
        }
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

                scheduleQueue(0);

                //print(prioQueue.Peek());

                currentAction = true;
            }

        }

        if (!currentAction)
        {
            prioQueue.Dequeue();
            if (prioQueue.Count == 0)
            {
                scheduleQueue(0);
            }
            currentAction = true;
        }



        if (prioQueue.Peek() == 0)
        {
            //transform.position = Vector3.MoveTowards(transform.position,  patrolLocations[nextSpot].position, speed * Time.deltaTime);
            agent.SetDestination(patrolLocations[nextSpot].position);


            //print(Vector2.Distance(transform.position, patrolLocations[nextSpot].position));
            //print(nextSpot);
            //print(transform.position);
            if (agent.remainingDistance <= agent.stoppingDistance)
            {
                // print("here");
                if (waitTime <= 0)
                {

                    lastSpot = nextSpot;
                    do
                    {
                        nextSpot = Random.Range(0, patrolLocations.Length);
                    }
                    while (nextSpot != lastSpot + 1 && nextSpot != lastSpot - 1);
                    waitTime = startWaitTime;
                    lookDir = patrolLocations[nextSpot].position - transform.position;
                    currentAction = false;
                }
                else
                {
                    waitTime -= Time.deltaTime;
                }
            }
        }
        else if (prioQueue.Peek() == 1)
        {
            //print(waitTime);
            if (!setLocation)
            {
                if (firstWander)
                {
                    waitTime = wanderTime;  //changes time until patrol resume to custom time;
                    firstWander = false;
                }
                Vector3 newVec = new Vector3(transform.position.x + (float)Random.Range(-3, 3), transform.position.y, transform.position.z + Random.Range(-3, 3));
                agent.SetDestination(newVec);
                setLocation = true;
            }

            if (agent.remainingDistance <= agent.stoppingDistance)
            {
                setLocation = false;
            }

            if (waitTime <= 0)
            {
                waitTime = startWaitTime;
                currentAction = false;
                firstWander = true;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }

        }
        else if (prioQueue.Peek() == 2)
        {
            //chill
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            scheduleQueue(1); //Schedules player chase
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            scheduleQueue(0); //Schedules normal operations
            prioQueue.Dequeue();
        }

    }

}
