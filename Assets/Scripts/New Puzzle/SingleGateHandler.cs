using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleGateHandler : MonoBehaviour
{
    public DisplayPuzzle puzzleDisplay;
    public GateCollisionOptions gateCollision;
    public int gateId;
    public bool active;

    /*void OnMouseDown()
    {
        puzzleDisplay.Activate();
        puzzleDisplay.ScrambleByGate(gateId);
    }*/

    void Start()
    {
        active = false;
    }

    private void Update()
    {
        if (active)
        {
            if (Input.GetKeyDown(KeyCode.P))
            {
                print("E was pressed!");
                gateCollision.deActivate();
                puzzleDisplay.Activate();
                puzzleDisplay.ScrambleByGate(gateId);
            }
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "gateCollider")
        {
            gateCollision.Activate();
            active = true;
        }
    }

    /*private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "gateCollider" && active == false)
        {
            gateCollision.Activate();
            active = true;
        }
        
    }*/

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "gateCollider")
        {
            gateCollision.deActivate();
            active = false;
        }
    }
}
