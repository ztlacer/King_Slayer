using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemySight : MonoBehaviour
{

    [SerializeField] private Animator animator;
    [SerializeField] public AudioClip clip;
    public float speed;

    public bool passedThrough;

    public bool exited;

    public Vector3 lastKnownLoc;

    public NavMeshAgent agent;

    // Elapsed time to control animations when the enemy attacks
    float elapsedTime = 0;


    // Start is called before the first frame update
    void Start()
    {
        passedThrough = false;

        exited = false;

    }

    private void Update()
    {
        // check elapsed time and stuff.
        if (elapsedTime > 0 && elapsedTime < 1.667) // length of attack anim
        {
            elapsedTime += Time.deltaTime;
        }
        else if (elapsedTime > 1.667)
        {
            print("reset animation");
            elapsedTime = 0;
            animator.SetBool("isAttacking", false);
        }
    }


    void OnTriggerStay(Collider other)
    {
        
        if (other.gameObject.tag == "Player")
        {
            passedThrough = true;
            lastKnownLoc = other.transform.position;
            agent.isStopped = false;
            animator.SetBool("isMoving", true);
            agent.SetDestination(lastKnownLoc);
            //lastKnownLoc.x -= 2;
            //lastKnownLoc.z -= 2;
            if (agent.remainingDistance <= agent.stoppingDistance)
            {
                agent.isStopped = true;
                animator.SetBool("isMoving", false);
                agent.velocity = Vector3.zero;
                if (elapsedTime == 0)
                {
                    animator.SetBool("isAttacking", true);
                    elapsedTime += Time.deltaTime;
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {

            MusicTransition.instance.SwapTrack(clip);
        }

    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            exited = true;
            MusicTransition.instance.returnToDefault();
        }
        
    }
}
