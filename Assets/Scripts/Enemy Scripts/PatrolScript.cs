using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PatrolScript : MonoBehaviour
{

    [SerializeField] private Animator animator;

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

    public int numWaypointSet;




    // Start is called before the first frame update
    void Start()
    {
        waitTime = startWaitTime;

        nextSpot = Random.Range(0, patrolLocations.Length);

        prioQueue.Enqueue(0);

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


                patrolLocations.SetValue(GameObject.Find("waypoint" +  numWaypointSet).transform, 0);

                numWaypointSet++;

                patrolLocations.SetValue(GameObject.Find("waypoint" + numWaypointSet).transform, 1);

                numWaypointSet++;

                patrolLocations.SetValue(GameObject.Find("waypoint" + numWaypointSet).transform, 2);

                numWaypointSet++;

                patrolLocations.SetValue(GameObject.Find("waypoint" + numWaypointSet).transform, 3);

                numWaypointSet++;

                patrolLocations.SetValue(GameObject.Find("waypoint" + numWaypointSet).transform, 4);

                gameObject.transform.position = new Vector3(patrolLocations[nextSpot].position.x, 100, patrolLocations[nextSpot].position.z);

               // print(transform.position + " tpos");

                waypointsSet = true;

                scheduleQueue(0);

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
            agent.isStopped = false;
            animator.SetBool("isMoving", true);
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
                    animator.SetBool("isMoving", false);
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
                agent.isStopped = false;
                animator.SetBool("isMoving", true);
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
