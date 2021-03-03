using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeGen : MonoBehaviour
{

    public GameObject Wall1;
    public GameObject Wall2;
    public GameObject Wall3;
    public GameObject Wall4;

    public int startX0 = -20;
    public int startZ0 = -30;
    public int startX90 = -10;
    public int startZ90 = -40;

    public GameObject[] Walls;

    // Start is called before the first frame update
    void Start()
    {
        Walls = new GameObject[4];
        Walls[0] = Wall1;
        Walls[1] = Wall2;
        Walls[2] = Wall3;
        Walls[3] = Wall4;

        genMaze(5, 5, 0, 0);
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
        int orientation = Random.Range(0, 2);

        int angle = 0;

        if (orientation == 0)
        {
            int depth = Random.Range(0, x - 1);

            int width = Random.Range(0, z);

            int transZ = startZ0 + depth * 20 + 20 * startZ;

            int transX = startX0 + 20 * startX;

            int banX = transX + width * 20;

            for (int i = 0; i < 4; i++)
            {
                if (transX == banX)
                {
                    transX += 20;
                }
                Walls[i].transform.position = new Vector3(transX, 5, transZ);
                Walls[i].transform.Rotate(0, angle, 0, Space.Self);
                transX += 20;

            }
        } else {

            angle = 90;

            int width = Random.Range(0, z - 1);

            int depth = Random.Range(0, x);

            int transX = startX90 + width * 20 + 20 * startX;

            int transZ = startZ90 + 20 * startZ;

            int banZ = transZ + width * 20;

            for (int i = 0; i < 4; i++)
            {
                if (transZ == banZ)
                {
                    transZ += 20;
                }
                Walls[i].transform.Rotate(0, angle, 0, Space.Self);
                Walls[i].transform.position = new Vector3(transX, 5, transZ);
                transZ += 20;
            }
        }

    }
}
