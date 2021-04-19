using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleGateHandler : MonoBehaviour
{
    public DisplayPuzzle puzzleDisplay;
    public int gateId;

    void OnMouseDown()
    {
        puzzleDisplay.Activate();
        puzzleDisplay.ScrambleByGate(gateId);
    }
}
