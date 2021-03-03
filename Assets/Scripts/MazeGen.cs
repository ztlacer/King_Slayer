using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeGen : MonoBehaviour
{

    public GameObject Wall1;
    public GameObject Wall2;
    public GameObject Wall3;
    public GameObject Wall4;

    public GameObject[] Walls;

    // Start is called before the first frame update
    void Start()
    {
        Walls = new GameObject[4];
        Walls[0] = Wall1;
        Walls[1] = Wall2;
        Walls[2] = Wall3;
        Walls[3] = Wall4;

        genMaze(5, 5, -20, -30);
        //Walls[0].transform.position = new Vector3(-20, 5, 30);
        //Walls[1].transform.position = new Vector3(0, 5, 30);
        //Walls[2].transform.position = new Vector3(40, 5, 30);
        //Walls[3].transform.position = new Vector3(60, 5, 30);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void genMaze(int x, int z, int startX, int startZ) 
    {
        int depth = Random.Range(0, x-1);
        //print("Depth: " + depth);
        int width = Random.Range(0, z);
        //print("Width: " + width);
        int transZ = startZ + depth * 20;
        //print("transZ " + transZ);
        int transX = startX;
        //print("transX " + transX);
        int banX = startX + width * 20;
        //Wall1.transform.position = new Vector3(-20, (float)0.50, 10);
        for (int i = 0; i < 4; i++)
        {
            if (transX == banX)
            {
                transX += 20;
            }
            Walls[i].transform.position = new Vector3(transX, 5, transZ);
            transX += 20;

        }

    }
}
