using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeGen2 : MonoBehaviour
{

    public GameObject[] Walls1;
    public GameObject[] Walls2;
    public GameObject[] Walls3;
    public GameObject[] Walls4;

    public GameObject[] SubZones1;

    public int[][] takenX1;
    public int[][] takenX2;
    public int[][] takenX3;
    public int[][] takenX4;

    public int[][] takenZ1;
    public int[][] takenZ2;
    public int[][] takenZ3;
    public int[][] takenZ4;

    public GameObject[] wayPoints1;

    // Start is called before the first frame update
    void Start()
    {
        SubZones1 = new GameObject[1];
        for (int i = 0; i < 1; i++)
        {
            SubZones1[i].transform.position = new Vector3(0, -15, 0);
            SubZones1[i].transform.localScale = new Vector3(1000, 2, 1000);
        }

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

        wayPoints1 = new GameObject[5];
        for (int i = 0; i < 5; i++)
        {
            wayPoints1[i] = GameObject.CreatePrimitive(PrimitiveType.Cube);
            wayPoints1[i].transform.position = new Vector3(0, -200, 0);
            wayPoints1[i].transform.localScale = new Vector3(5, 500, 5);
        }

        takenX1 = new int[19][];
        takenX2 = new int[24][];
        takenX3 = new int[39][];
        takenX4 = new int[49][];

        takenZ1 = new int[19][];
        takenZ2 = new int[24][];
        takenZ3 = new int[39][];
        takenZ4 = new int[49][];

        for (int i = 0; i < 19; i++)
        {
            takenX1[i] = new int[20];
            takenZ1[i] = new int[20];
        }

        for (int i = 0; i < 19; i++)
        {
            for (int j = 0; j < 20; j++)
            {
                takenX1[i][j] = 0;
                takenZ1[i][j] = 0;

            }
        }

        for (int i = 0; i < 24; i++)
        {
            takenX2[i] = new int[25];
            takenZ2[i] = new int[25];
        }

        for (int i = 0; i < 24; i++)
        {
            for (int j = 0; j < 25; j++)
            {
                takenX2[i][j] = 0;
                takenZ2[i][j] = 0;

            }
        }

        for (int i = 0; i < 39; i++)
        {
            takenX3[i] = new int[40];
            takenZ3[i] = new int[40];
        }

        for (int i = 0; i < 39; i++)
        {
            for (int j = 0; j < 40; j++)
            {
                takenX3[i][j] = 0;
                takenZ3[i][j] = 0;

            }
        }

        for (int i = 0; i < 49; i++)
        {
            takenX4[i] = new int[50];
            takenZ4[i] = new int[50];
        }

        for (int i = 0; i < 49; i++)
        {
            for (int j = 0; j < 50; j++)
            {
                takenX4[i][j] = 0;
                takenZ4[i][j] = 0;

            }
        }

        //genSubZone(1, 2, 2, 20, 20, 50, -485, -420, SubZones1);

        genMaze(takenX4, takenZ4, 50, 50, 0, 0, 0, 2400, -499, 550, 20, -20, -30, -10, -40, Walls4);
        genMaze(takenX3, takenZ3, 40, 40, 0, 0, 0, 1520, -1497.5, 804.5, 25, -20, -30, -7.5, -42.5, Walls3);
        genMaze(takenX2, takenZ2, 25, 25, 0, 0, 0, 575, -1490, -180, 40, -20, -30, 0, -50, Walls2);
        genMaze(takenX1, takenZ1, 20, 20, 0, 0, 0, 360, -485, -420, 50, -20, -30, 5, -55, Walls1);

        generateWayPoints(5, 20, 20, -485, -420, 50, wayPoints1, takenX1, takenZ1);

    }

    void genSubZone(int subZoneCount, int subZoneWidth, int subZoneDepth, int gridWidth, int gridDepth, int coordSize, double worldTransX, double worldTransZ, GameObject[] Subzone)
    {
        //Walls[i].transform.position = new Vector3(transX + (float)worldTransX, 5, transZ + (float)worldTransZ);

        /** int transZ = rotZ0 + depth * coordSize + coordSize * gridStartIndexZ;

          int transX = rotX0 + coordSize * gridStartIndexX; */

        for (int i = 0; i < subZoneCount; i++)
        {
            int startX = Random.Range(0, gridWidth - subZoneWidth + 1);
            int startZ = Random.Range(0, gridDepth - subZoneDepth + 1);
            Subzone[i].transform.position = new Vector3(startX * coordSize + (float)worldTransX, 15, startZ * coordSize + (float)worldTransZ);
        }
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
        void genMaze(int[][] xTaken, int[][] zTaken, int gridWidth, int gridDepth, int gridStartIndexX, int gridStartIndexZ, int wallsStartIndex, int wallsEndIndex, double worldTransX, double worldTransZ, int coordSize, int rotX0, int rotZ0, double rotX90, double rotZ90, GameObject[] Walls)
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

            int count = 0;
            for (int i = wallsStartIndex; i < (gridWidth - 1) + wallsStartIndex; i++)
            {
                if (transX == banX)
                {
                    transX += coordSize;
                    count++;
                }
                Walls[i].transform.position = new Vector3(transX + (float)worldTransX, 5, transZ + (float)worldTransZ);
                Walls[i].transform.Rotate(0, angle, 0, Space.Self);
                transX += coordSize;

                xTaken[depth + gridStartIndexZ][gridStartIndexX + count] = 1;
                count++;

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
                genMaze(xTaken, zTaken, nextX, nextZA, gridStartIndexX, nextStartZA, nextIndexA, maxIndexA, worldTransX, worldTransZ, coordSize, rotX0, rotZ0, rotX90, rotZ90, Walls);
            }
            if (wallsNeededB > 0)
            {
                genMaze(xTaken, zTaken, nextX, nextZB, gridStartIndexX, nextStartZB, nextIndexB, maxIndexB, worldTransX, worldTransZ, coordSize, rotX0, rotZ0, rotX90, rotZ90, Walls);
            }

        }
        else
        {

            angle = 90;

            int width = Random.Range(0, gridWidth - 1);

            int depth = Random.Range(0, gridDepth);

            double transX = rotX90 + width * coordSize + coordSize * gridStartIndexX;

            double transZ = rotZ90 + coordSize * gridStartIndexZ;

            double banZ = transZ + depth * coordSize;

            int count = 0;
            for (int i = wallsStartIndex; i < (gridDepth - 1) + wallsStartIndex; i++)
            {
                if (transZ == banZ)
                {
                    transZ += coordSize;
                    count++;
                }
                Walls[i].transform.Rotate(0, angle, 0, Space.Self);
                Walls[i].transform.position = new Vector3((float)transX + (float)worldTransX, 5, (float)transZ + (float)worldTransZ);
                transZ += coordSize;

                zTaken[gridStartIndexX + width][count + gridStartIndexZ] = 1;
                count++;
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
                genMaze(xTaken, zTaken, nextXA, nextZ, nextStartXA, gridStartIndexZ, nextIndexA, maxIndexA, worldTransX, worldTransZ, coordSize, rotX0, rotZ0, rotX90, rotZ90, Walls);
            }
            if (wallsNeededB > 0)
            {
                genMaze(xTaken, zTaken, nextXB, nextZ, nextStartXB, gridStartIndexZ, nextIndexB, maxIndexB, worldTransX, worldTransZ, coordSize, rotX0, rotZ0, rotX90, rotZ90, Walls);
            }



        }
    }

        bool moveNorth(int[] xValues, int[] zValues, int x, int z, int foundValues, int[][] takenX)
        {
            if ((z + 1) >= 20)
            {
                return false;
            }

            if (takenX[z][x] == 1)
            {
                print("false2");
                return false;
            }

            for (int j = 0; j < foundValues; j++)
            {
                if (xValues[j] == x && zValues[j] == (z + 1))
                {
                    print("false3");
                    return false;
                } 
            }

            return true;
        }

        bool moveSouth(int[] xValues, int[] zValues, int x, int z, int foundValues, int[][] takenX)
        {
            if ((z - 1) < 0)
            {
                return false;
            }

            if (takenX[z - 1][x] == 1)
            {
                print("false2");
                return false;
            }

            for (int j = 0; j < foundValues; j++)
            {
                if (xValues[j] == x && zValues[j] == (z - 1))
                {
                    print("false3");
                    return false;
                } 
            }

            return true;
        }

        bool moveWest(int[] xValues, int[] zValues, int x, int z, int foundValues, int[][] takenZ)
        {
            if ((x + 1) >= 20)
            {
                return false;
            }

            if (takenZ[x][z] == 1)
            {
                print("false2");
                return false;
            }

            for (int j = 0; j < foundValues; j++)
            {
                if (xValues[j] == (x + 1) && zValues[j] == z)
                {
                    print("false3");
                    return false;
                } 
            }

            return true;
        }

        bool moveEast(int[] xValues, int[] zValues, int x, int z, int foundValues, int[][] takenZ)
        {
            if ((x - 1) < 0)
            {
                return false;
            }

            if (takenZ[x - 1][z] == 1)
            {
                print("false2");
                return false;
            }

            for (int j = 0; j < foundValues; j++)
            {
                if (xValues[j] == (x - 1) && zValues[j] == z)
                {
                    print("false3");
                    return false;
                } 
            }

            return true;
        }

        bool move(int[] xValues, int[] zValues, int lastX, int lastZ, int rendered, bool rendering, int[][] takenX, int[][] takenZ, int i)
        {
            if (moveNorth(xValues, zValues, lastX, lastZ, rendered, takenX) == true && rendering)
                {
                    print("move north");
                    xValues[i] = lastX;
                    zValues[i] = lastZ + 1;
                    return true;

                } else if (moveSouth(xValues, zValues, lastX, lastZ, rendered, takenX) == true && rendering)
                {

                    print("move south");
                    xValues[i] = lastX;
                    zValues[i] = lastZ - 1;
                    return true;

                } else if (moveWest(xValues, zValues, lastX, lastZ, rendered, takenZ) == true && rendering)
                {

                    print("move west");
                    xValues[i] = lastX + 1;
                    zValues[i] = lastZ;
                    return true;

                } else if (moveEast(xValues, zValues, lastX, lastZ, rendered, takenZ) == true && rendering)
                {
                    print("move east");
                    xValues[i] = lastX - 1;
                    zValues[i] = lastZ;
                    return true;

                } 
            return false;
        }
        
        void generateWayPoints(int wayPointCount, int gridWidth, int gridDepth, double worldTransX, double worldTransZ, float coordSize, GameObject[] wayPoints, int[][] takenX, int[][] takenZ)
        {
            int[] xValues = new int[wayPointCount];
            int[] zValues = new int[wayPointCount];

            xValues[0] = Random.Range(0, gridWidth - 1);
            zValues[0] = Random.Range(0, gridDepth - 1);

            int rendered = 1;
            bool rendering = true;

            for (int i = 1; i < wayPointCount; i++)
            {
                int lastIndex = i - 1;
                int lastX = xValues[lastIndex];
                int lastZ = zValues[lastIndex];

                bool moved = move(xValues, zValues, lastX, lastZ, rendered, rendering, takenX, takenZ, i);

                if (moved)
                {
                    rendered++;
                } else
                {
                    bool resultFound = false;
                    while(!resultFound)
                    {

                        if (lastIndex - 1 < 0)
                        {
                      
                            rendering = false;
                            resultFound = true;

                        }
                        else
                        {
                            lastIndex--;
                            lastX = xValues[lastIndex];
                            lastZ = zValues[lastIndex];
                            moved = move(xValues, zValues, lastX, lastZ, rendered, rendering, takenX, takenZ, i);
                            if (moved)
                            {

                                rendered++;
                                resultFound = true;
                                
                            } // end if

                         } // end if else 

                    } // end while
                    
                } // end for loop

            } // end method

            for (int i = 0; i < rendered; i++)
            {
                var x = worldTransX + coordSize * xValues[i] - coordSize / 2;
                var z = worldTransZ + coordSize * zValues[i] - coordSize;
                wayPoints[i].transform.position = new Vector3((float)x, 5, (float)z);

            }

        } // end method 

    
}
