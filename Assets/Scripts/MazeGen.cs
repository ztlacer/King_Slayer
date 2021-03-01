using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeGen : MonoBehaviour
{

    public GameObject Wall1;
    // Start is called before the first frame update
    void Start()
    {
        Wall1.transform.position = new Vector3(-20, (float) 0.50, 10);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
