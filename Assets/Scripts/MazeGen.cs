using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeGen : MonoBehaviour
{

    public GameObject[] Walls1;
    public GameObject[] Walls2;
    public GameObject[] Walls3;
    public GameObject[] Walls4;

    // Start is called before the first frame update
    void Start()
    {

        Walls1 = new GameObject[361];
        for (int i = 0; i < 361; i++)
        {
            Walls1[i] = GameObject.CreatePrimitive(PrimitiveType.Cube);
            Walls1[i].transform.position = new Vector3(0, -15, 0);
            Walls1[i].transform.localScale = new Vector3(50, 30, 1);
        }

        Walls2 = new GameObject[576];
        for (int i = 0; i < 576; i++)
        {
            Walls2[i] = GameObject.CreatePrimitive(PrimitiveType.Cube);
            Walls2[i].transform.position = new Vector3(0, -15, 0);
            Walls2[i].transform.localScale = new Vector3(40, 30, 1);
        }

        Walls3 = new GameObject[1521];
        for (int i = 0; i < 1521; i++)
        {
            Walls3[i] = GameObject.CreatePrimitive(PrimitiveType.Cube);
            Walls3[i].transform.position = new Vector3(0, -15, 0);
            Walls3[i].transform.localScale = new Vector3(25, 30, 1);
        }

        Walls4 = new GameObject[2401];
        for (int i = 0; i < 2401; i ++)
        {
            Walls4[i] = GameObject.CreatePrimitive(PrimitiveType.Cube);
            Walls4[i].transform.position = new Vector3(0, -15, 0);
            Walls4[i].transform.localScale = new Vector3(20, 30, 1);
        }
        

        genMaze(50, 50, 0, 0, 0, 2400, -499, 550, 20, -20, -30, -10, -40, Walls4);
        genMaze(40, 40, 0, 0, 0, 1520, -1497.5, 804.5, 25, -20, -30, -7.5, -42.5, Walls3);
        genMaze(25, 25, 0, 0, 0, 575, -1490, -180, 40, -20, -30, 0, -50, Walls2);
        genMaze(20, 20, 0, 0, 0, 360, -485, -420, 50, -20, -30, 5, -55, Walls1);

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
    void genMaze(int x, int z, int startX, int startZ, int index, int maxIndex, double xt, double zt, int size, int startX0, int startZ0, double startX90, double startZ90, GameObject[] Walls)
    {
        int orientation = 0;

        if (x > z)
        {
            orientation = 1;
        }

        if (x == z)
        {
            orientation = Random.Range(0, 2);
        }
            

        int angle = 0;

        if (orientation == 0)
        {
            int depth = Random.Range(0, z - 1);

            int width = Random.Range(0, x);

            int transZ = startZ0 + depth * size + size * startZ;

            int transX = startX0 + size * startX;

            int banX = transX + width * size;


            for (int i = index; i < (x - 1) + index; i++)
            {
                if (transX == banX)
                {
                    transX += size;
                }
                Walls[i].transform.position = new Vector3( transX + (float) xt, 5, transZ + (float) zt);
                Walls[i].transform.Rotate(0, angle, 0, Space.Self);
                transX += size;

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
                    genMaze(nextX, nextZA, startX, nextStartZA, nextIndexA, maxIndexA, xt, zt, size, startX0, startZ0, startX90, startZ90, Walls);
                }
                if (wallsNeededB > 0)
                {
                    genMaze(nextX, nextZB, startX, nextStartZB, nextIndexB, maxIndexB, xt, zt, size, startX0, startZ0, startX90, startZ90, Walls);
                }
            
        } else {

            angle = 90;
            print("Orientation Caught");

            int width = Random.Range(0, x - 1);

            int depth = Random.Range(0, z);

            double transX = startX90 + width * size + size * startX;

            double transZ = startZ90 + size * startZ;

            double banZ = transZ + depth * size;

            for (int i = index; i < (z - 1) + index; i++)
            {
                if (transZ == banZ)
                {
                    transZ += size;
                }
                Walls[i].transform.Rotate(0, angle, 0, Space.Self);
                Walls[i].transform.position = new Vector3((float) transX + (float) xt, 5, (float) transZ + (float) zt);
                transZ += size;
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
                    genMaze(nextXA, nextZ, nextStartXA, startZ, nextIndexA, maxIndexA, xt, zt, size, startX0, startZ0, startX90, startZ90, Walls);
                }
                if (wallsNeededB > 0)
                {
                    genMaze(nextXB, nextZ, nextStartXB, startZ, nextIndexB, maxIndexB, xt, zt, size, startX0, startZ0, startX90, startZ90, Walls);
                }

            
            
        }

    }
}
