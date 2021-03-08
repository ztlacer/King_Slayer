using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeGen : MonoBehaviour
{

    public GameObject Wall1;
    public GameObject Wall2;
    public GameObject Wall3;
    public GameObject Wall4;
    public GameObject Wall5;
    public GameObject Wall6;
    public GameObject Wall7;
    public GameObject Wall8;
    public GameObject Wall9;
    public GameObject Wall10;
    public GameObject Wall11;
    public GameObject Wall12;
    public GameObject Wall13;
    public GameObject Wall14;
    public GameObject Wall15;
    public GameObject Wall16;

    public int startX0 = -20;
    public int startZ0 = -30;
    public int startX90 = -10;
    public int startZ90 = -40;

    public GameObject[] Walls;

    // Start is called before the first frame update
    void Start()
    {
        Walls = new GameObject[16];
        Walls[0] = Wall1;
        Walls[1] = Wall2;
        Walls[2] = Wall3;
        Walls[3] = Wall4;
        Walls[4] = Wall5;
        Walls[5] = Wall6;
        Walls[6] = Wall7;
        Walls[7] = Wall8;
        Walls[8] = Wall9;
        Walls[9] = Wall10;
        Walls[10] = Wall11;
        Walls[11] = Wall12;
        Walls[12] = Wall13;
        Walls[13] = Wall14;
        Walls[14] = Wall15;
        Walls[15] = Wall16;

        genMaze(5, 5, 0, 0, 0, 15);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /**
     * x - the width
     * y - the depth
     * 
     * startX - used to determine the coordinates to create the wall; representative of
     *  where the wall will be created on a hypothetical grid
     *  
     * startZ - used to create the coordinates of the wall; representative of where the 
     *  wall will be created on a hypothetical grid 
     *  
     * index - the index of the wall array usable to this paritcular iteration
     * 
     * round - term for debugging
     */
    void genMaze(int x, int z, int startX, int startZ, int index, int maxIndex)
    {
        int orientation = 0;

        if (x >= z)
        {
            orientation = 1;
        }

        if (x == z)
        {
            //orientation = Random.Range(0, 2);
        }
            

        int angle = 0;

        if (orientation == 0)
        {
            int depth = Random.Range(0, z - 1);

            int width = Random.Range(0, x);

            int transZ = startZ0 + depth * 20 + 20 * startZ;

            int transX = startX0 + 20 * startX;

            int banX = transX + width * 20;


            for (int i = index; i < (x - 1) + index; i++)
            {
                if (transX == banX)
                {
                    transX += 20;
                }
                Walls[i].transform.position = new Vector3(transX, 5, transZ);
                Walls[i].transform.Rotate(0, angle, 0, Space.Self);
                transX += 20;

            }
            
                int nextX = x;
                
                int nextZA = z - (depth + 1);
                int nextZB = depth + 1;
                
                int nextStartZA = startZ + nextZB;
                int nextStartZB = startZ;

                
                int wallsNeededA = (nextX - 1) * (nextZA - 1);
                int wallsNeededB = (nextX - 1) * (nextZB - 1);

                int nextIndexA = index + x - 1;
                int maxIndexA = nextIndexA + wallsNeededA - 1;
                
                int nextIndexB = nextIndexA + wallsNeededA;
                int maxIndexB = maxIndex;

                if (wallsNeededA > 0)
                {
                    genMaze(nextX, nextZA, startX, nextStartZA, nextIndexA, maxIndexA);
                }
                if (wallsNeededB > 0)
                {
                    genMaze(nextX, nextZB, startX, nextStartZB, nextIndexB, maxIndexB);
                }
            
        } else {

            angle = 90;
            print("Orientation Caught");

            int width = Random.Range(0, x - 1);

            int depth = Random.Range(0, z);

            int transX = startX90 + width * 20 + 20 * startX;

            int transZ = startZ90 + 20 * startZ;

            int banZ = transZ + depth * 20;

            for (int i = index; i < (z - 1) + index; i++)
            {
                if (transZ == banZ)
                {
                    transZ += 20;
                }
                Walls[i].transform.Rotate(0, angle, 0, Space.Self);
                Walls[i].transform.position = new Vector3(transX, 5, transZ);
                transZ += 20;
            }

            
                int nextZ = z;

                int nextXA = x - (width + 1);
                int nextXB = width + 1;

                int nextStartXA = startX + nextXB;
                int nextStartXB = startX;


                int wallsNeededA = (nextZ - 1) * (nextXA - 1);
                int wallsNeededB = (nextZ - 1) * (nextXB - 1);

                int nextIndexA = index + z - 1;
                int maxIndexA = nextIndexA + wallsNeededA - 1;

                int nextIndexB = nextIndexA + wallsNeededA;
                int maxIndexB = maxIndex;

                if (wallsNeededA > 0)
                {
                    genMaze(nextXA, nextZ, nextStartXA, startZ, nextIndexA, maxIndexA);
                }
                if (wallsNeededB > 0)
                {
                    genMaze(nextXB, nextZ, nextStartXB, startZ, nextIndexB, maxIndexB);
                }

            
            
        }

    }
}
