using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeavePuzzle : MonoBehaviour
{
    public DisplayPuzzle puzzleDisplay;
    public GateCollisionOptions gateCollision;

    public void goBack()
    {
        puzzleDisplay.deActivate();
        Time.timeScale = 1;
       // gateCollision.Activate();
       if (puzzleDisplay.unlocked() == false)
        {
            gateCollision.Activate();
        }
    }
}
