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
     * Procedurally Generates a Maze 
     * 
     * @parameters
     * gridWidth - Divisions That Make Up The Width Of The Maze Grid (i.e. Is the grid 5x6 or 6x6?)
     * gridWidth - Divisions That Make Up The Depth Of The Maze Grid (i.e. Is the grid 5x6 or 5x7?)
     * gridStartIndexX - On The Overall Maze Grid, Which X Index Will This SubMaze Start Generating At (i.e. Will the submaze start generating at (3,2)? (4,2)?)
     * gridStartIndexZ - On The Overall Maze Grid, Which Z Index Will This SubMaze Start Generating At (i.e. Will the submaze start generating at (3,2)? (3,3)?)
     * wallsStartIndex - Which Index In The Walls Array Can This Method Start Pulling From (i.e. index 6 of Walls[])
     * wallsEndIndex - Which Index In The Walls Array Must This Method Stop Pulling From (i.e. index 12 of Walls[])
     * worldTransX - X Translation To Place This Maze In An Appropriate Location In World
     * worldTransZ - Z Translation To Place This Maze In An Appropriate Location In World
     * coordSize - Size of A Coord In Game Units
     * rotX0 - X Translation For Rotating Wall To 0 Degrees
     * rotZ0 - Z Translation For Rotating Wall To 0 Degrees
     * rotX90 - X Translation For Rotating Wall To 90 Degrees
     * rotZ90 - Z Translation For Rotating Wall To 90 Degrees
     * Walls - Array Of Walls To Use For Maze Generation
     */
    void genMaze(int gridWidth, int gridDepth, int gridStartIndexX, int gridStartIndexZ, int wallsStartIndex, int wallsEndIndex, double worldTransX, double worldTransZ, int coordSize, int rotX0, int rotZ0, double rotX90, double rotZ90, GameObject[] Walls)
    {
        int orientation = 0;

        if (gridWidth > gridDepth)
        {
            orientation = 1;
        }

        if (gridWidth == gridDepth)
        {
            orientation = Random.Range(0, 2);
        }
            

        int angle = 0;

        if (orientation == 0)
        {
            int depth = Random.Range(0, gridDepth - 1);

            int width = Random.Range(0, gridWidth);

            int transZ = rotZ0 + depth * coordSize + coordSize * gridStartIndexZ;

            int transX = rotX0 + coordSize * gridStartIndexX;

            int banX = transX + width * coordSize;


            for (int i = wallsStartIndex; i < (gridWidth - 1) + wallsStartIndex; i++)
            {
                if (transX == banX)
                {
                    transX += coordSize;
                }
                Walls[i].transform.position = new Vector3( transX + (float) worldTransX, 5, transZ + (float) worldTransZ);
                Walls[i].transform.Rotate(0, angle, 0, Space.Self);
                transX += coordSize;

            }
            
                int nextX = gridWidth;
                
                int nextZA = gridDepth - (depth + 1);
                int nextZB = depth + 1;
                
                int nextStartZA = gridStartIndexZ + nextZB;
                int nextStartZB = gridStartIndexZ;

                
                int wallsNeededA = (nextX - 1) * (nextZA - 1);
                int wallsNeededB = (nextX - 1) * (nextZB - 1);

                int nextIndexA = wallsStartIndex + gridWidth - 1;
                int maxIndexA = nextIndexA + wallsNeededA - 1;
                
                int nextIndexB = nextIndexA + wallsNeededA;
                int maxIndexB = wallsEndIndex;

                if (wallsNeededA > 0)
                {
                    genMaze(nextX, nextZA, gridStartIndexX, nextStartZA, nextIndexA, maxIndexA, worldTransX, worldTransZ, coordSize, rotX0, rotZ0, rotX90, rotZ90, Walls);
                }
                if (wallsNeededB > 0)
                {
                    genMaze(nextX, nextZB, gridStartIndexX, nextStartZB, nextIndexB, maxIndexB, worldTransX, worldTransZ, coordSize, rotX0, rotZ0, rotX90, rotZ90, Walls);
                }
            
        } else {

            angle = 90;
            print("Orientation Caught");

            int width = Random.Range(0, gridWidth - 1);

            int depth = Random.Range(0, gridDepth);

            double transX = rotX90 + width * coordSize + coordSize * gridStartIndexX;

            double transZ = rotZ90 + coordSize * gridStartIndexZ;

            double banZ = transZ + depth * coordSize;

            for (int i = wallsStartIndex; i < (gridDepth - 1) + wallsStartIndex; i++)
            {
                if (transZ == banZ)
                {
                    transZ += coordSize;
                }
                Walls[i].transform.Rotate(0, angle, 0, Space.Self);
                Walls[i].transform.position = new Vector3((float) transX + (float) worldTransX, 5, (float) transZ + (float) worldTransZ);
                transZ += coordSize;
            }

            
                int nextZ = gridDepth;

                int nextXA = gridWidth - (width + 1);
                int nextXB = width + 1;

                int nextStartXA = gridStartIndexX + nextXB;
                int nextStartXB = gridStartIndexX;


                int wallsNeededA = (nextZ - 1) * (nextXA - 1);
                int wallsNeededB = (nextZ - 1) * (nextXB - 1);

                int nextIndexA = wallsStartIndex + gridDepth - 1;
                int maxIndexA = nextIndexA + wallsNeededA - 1;

                int nextIndexB = nextIndexA + wallsNeededA;
                int maxIndexB = wallsEndIndex;

                if (wallsNeededA > 0)
                {
                    genMaze(nextXA, nextZ, nextStartXA, gridStartIndexZ, nextIndexA, maxIndexA, worldTransX, worldTransZ, coordSize, rotX0, rotZ0, rotX90, rotZ90, Walls);
                }
                if (wallsNeededB > 0)
                {
                    genMaze(nextXB, nextZ, nextStartXB, gridStartIndexZ, nextIndexB, maxIndexB, worldTransX, worldTransZ, coordSize, rotX0, rotZ0, rotX90, rotZ90, Walls);
                }

            
            
        }

    }
}
