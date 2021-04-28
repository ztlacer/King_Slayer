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
        InputManager.Controls.Player.StartPuzzle.performed += ctx => startPuzzle();
    }

    private void startPuzzle()
    {
        print("hit that putton");
        if (active)
        {
            // Disable the player from pausing or doing anything relating to the UI
            InputManager.Controls.Player.Disable();
            print("P was pressed!");
            gateCollision.deActivate();
            puzzleDisplay.Activate();
            puzzleDisplay.ScrambleByGate(gateId);

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            print("triggerrred Enter");
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
        if (other.gameObject.tag == "Player")
        {
            print("OntriggerExit");
            gateCollision.deActivate();
            active = false;
        }
    }
}
