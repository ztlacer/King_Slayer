using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeavePuzzle : MonoBehaviour
{
    public GameObject puzzleDisplay;

    public void goBack()
    {
        puzzleDisplay.SetActive(false);
        Time.timeScale = 1;
    }
}
