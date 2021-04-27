using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeGen3 : MonoBehaviour
{
    public Material Material1;
    public Material Material2;
    public Material Material3;
    public Material Material4;

    public Material Material5;
    public Material Material6;
    public Material Material7;
    public Material Material8;

    public GameObject[] Gates1;
    public GameObject[] Gates2;
    public GameObject[] Gates3;
    public GameObject[] Gates4;

    public GameObject[] Buildings1;
    public GameObject[] Buildings2;
    public GameObject[] Buildings3;
    public GameObject[] Buildings4;

    public int b1Taken = 0;
    public int b2Taken = 0;
    public int b3Taken = 0;
    public int b4Taken = 0;

    public GameObject[] Towns1;
    public GameObject[] Towns2;
    public GameObject[] Towns3;
    public GameObject[] Towns4;

    public GameObject[] Walls1;
    public GameObject[] Walls2;
    public GameObject[] Walls3;
    public GameObject[] Walls4;

    public GameObject[] SubZones1;
    public GameObject[] SubZones2;
    public GameObject[] SubZones3;
    public GameObject[] SubZones4;

    public int[][] transXTaken1;
    public int[][] transZTaken1;

    public int[][] transXTaken2;
    public int[][] transZTaken2;

    public int[][] transXTaken3;
    public int[][] transZTaken3;

    public int[][] transXTaken4;
    public int[][] transZTaken4;

    public int[][] takenX1;
    public int[][] takenX2;
    public int[][] takenX3;
    public int[][] takenX4;

    public int[][] takenZ1;
    public int[][] takenZ2;
    public int[][] takenZ3;
    public int[][] takenZ4;

    public GameObject[] wayPoints1;
    public GameObject[] wayPoints2;
    public GameObject[] wayPoints3;
    public GameObject[] wayPoints4;
    public GameObject[] wayPoints5;
    public GameObject[] wayPoints6;
    public GameObject[] wayPoints7;
    public GameObject[] wayPoints8;

    int numberOfWaypoints = 0;


    public GameObject MerchantPrefab;

    public GameObject DoctorPrefab;

    public GameObject EnemyPrefab;

    public int randSeed;

    // Start is called before the first frame update
    void Start()
    {
        Random.InitState(randSeed);
        SubZones1 = new GameObject[3];
        transXTaken1 = new int[4][];
        transZTaken1 = new int[4][];
        for (int i = 0; i < 3; i++)
        {
            transXTaken1[i] = new int[4];
            transZTaken1[i] = new int[4];

            GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            cube.AddComponent<UnityEngine.AI.NavMeshObstacle>();
            cube.GetComponent<UnityEngine.AI.NavMeshObstacle>().carving = true;
            SubZones1[i] = cube;
            SubZones1[i].transform.position = new Vector3(0, -15, 0);
            SubZones1[i].transform.localScale = new Vector3(200, (float)1.5, 200);
            SubZones1[i].GetComponent<MeshRenderer>().material = Material1;
        }

        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                transXTaken1[i][j] = j;
                transZTaken1[i][j] = j;
            }
        }

        SubZones2 = new GameObject[4];
        transXTaken2 = new int[4][];
        transZTaken2 = new int[4][];
        for (int i = 0; i < 4; i++)
        {
            transXTaken2[i] = new int[4];
            transZTaken2[i] = new int[4];

            GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            cube.AddComponent<UnityEngine.AI.NavMeshObstacle>();
            cube.GetComponent<UnityEngine.AI.NavMeshObstacle>().carving = true;
            SubZones2[i] = cube;
            SubZones2[i].transform.position = new Vector3(0, -15, 0);
            SubZones2[i].transform.localScale = new Vector3(160, 2, 160);
            SubZones2[i].GetComponent<MeshRenderer>().material = Material2;
        }

        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                transXTaken2[i][j] = j;
                transZTaken2[i][j] = j;
            }
        }

        SubZones3 = new GameObject[3];
        transXTaken3 = new int[8][];
        transZTaken3 = new int[8][];
        for (int i = 0; i < 3; i++)
        {
            transXTaken3[i] = new int[8];
            transZTaken3[i] = new int[8];

            GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            cube.AddComponent<UnityEngine.AI.NavMeshObstacle>();
            cube.GetComponent<UnityEngine.AI.NavMeshObstacle>().carving = true;
            SubZones3[i] = cube;
            SubZones3[i].transform.position = new Vector3(0, -15, 0);
            SubZones3[i].transform.localScale = new Vector3(175, 2, 175);
            SubZones3[i].GetComponent<MeshRenderer>().material = Material3;
        }

        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                transXTaken3[i][j] = j;
                transZTaken3[i][j] = j;
            }
        }

        SubZones4 = new GameObject[4];
        transXTaken4 = new int[9][];
        transZTaken4 = new int[9][];
        for (int i = 0; i < 4; i++)
        {
            transXTaken4[i] = new int[9];
            transZTaken4[i] = new int[9];

            GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            cube.AddComponent<UnityEngine.AI.NavMeshObstacle>();
            cube.GetComponent<UnityEngine.AI.NavMeshObstacle>().carving = true;
            SubZones4[i] = cube;
            SubZones4[i].transform.position = new Vector3(0, -15, 0);
            SubZones4[i].transform.localScale = new Vector3(160, 2, 160);
            SubZones4[i].GetComponent<MeshRenderer>().material = Material4;
        }

        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 9; j++)
            {
                transXTaken4[i][j] = j;
                transZTaken4[i][j] = j;
            }
        }

        Walls1 = new GameObject[361];
        for (int i = 0; i < 361; i++)
        {
            GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            cube.AddComponent<UnityEngine.AI.NavMeshObstacle>();
            cube.GetComponent<UnityEngine.AI.NavMeshObstacle>().carving = true;
            Walls1[i] = cube;
            Walls1[i].transform.position = new Vector3(0, -15, 0);
            Walls1[i].transform.localScale = new Vector3(50, 30, 1);
            Walls1[i].GetComponent<MeshRenderer>().material = Material5;
        }

        Walls2 = new GameObject[576];
        for (int i = 0; i < 576; i++)
        {
            GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            cube.AddComponent<UnityEngine.AI.NavMeshObstacle>();
            cube.GetComponent<UnityEngine.AI.NavMeshObstacle>().carving = true;
            Walls2[i] = cube;
            Walls2[i].transform.position = new Vector3(0, -15, 0);
            Walls2[i].transform.localScale = new Vector3(40, 30, 1);
            Walls2[i].GetComponent<MeshRenderer>().material = Material6;
        }

        Walls3 = new GameObject[1521];
        for (int i = 0; i < 1521; i++)
        {
            GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            cube.AddComponent<UnityEngine.AI.NavMeshObstacle>();
            cube.GetComponent<UnityEngine.AI.NavMeshObstacle>().carving = true;
            Walls3[i] = cube;
            Walls3[i].transform.position = new Vector3(0, -15, 0);
            Walls3[i].transform.localScale = new Vector3(25, 30, 1);
            Walls3[i].GetComponent<MeshRenderer>().material = Material7;
        }

        Walls4 = new GameObject[2401];
        for (int i = 0; i < 2401; i++)
        {
            GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            cube.AddComponent<UnityEngine.AI.NavMeshObstacle>();
            cube.GetComponent<UnityEngine.AI.NavMeshObstacle>().carving = true;
            Walls4[i] = cube;
            Walls4[i].transform.position = new Vector3(0, -15, 0);
            Walls4[i].transform.localScale = new Vector3(20, 30, 1);
            Walls4[i].GetComponent<MeshRenderer>().material = Material8;
        }

        wayPoints1 = new GameObject[5];
        for (int i = 0; i < 5; i++)
        {
            wayPoints1[i] = GameObject.CreatePrimitive(PrimitiveType.Cube);
            wayPoints1[i].transform.position = new Vector3(0, -500, 0);
            wayPoints1[i].transform.localScale = new Vector3(5, 500, 5);
        }

        wayPoints2 = new GameObject[5];
        for (int i = 0; i < 5; i++)
        {
            wayPoints2[i] = GameObject.CreatePrimitive(PrimitiveType.Cube);
            wayPoints2[i].transform.position = new Vector3(0, -200, 0);
            wayPoints2[i].transform.localScale = new Vector3(5, 500, 5);
        }

        wayPoints3 = new GameObject[5];
        for (int i = 0; i < 5; i++)
        {
            wayPoints3[i] = GameObject.CreatePrimitive(PrimitiveType.Cube);
            wayPoints3[i].transform.position = new Vector3(0, -200, 0);
            wayPoints3[i].transform.localScale = new Vector3(5, 500, 5);
        }

        wayPoints4 = new GameObject[5];
        for (int i = 0; i < 5; i++)
        {
            wayPoints4[i] = GameObject.CreatePrimitive(PrimitiveType.Cube);
            wayPoints4[i].transform.position = new Vector3(0, -200, 0);
            wayPoints4[i].transform.localScale = new Vector3(5, 500, 5);
        }

        wayPoints5 = new GameObject[5];
        for (int i = 0; i < 5; i++)
        {
            wayPoints5[i] = GameObject.CreatePrimitive(PrimitiveType.Cube);
            wayPoints5[i].transform.position = new Vector3(0, -200, 0);
            wayPoints5[i].transform.localScale = new Vector3(5, 500, 5);
        }

        wayPoints6 = new GameObject[5];
        for (int i = 0; i < 5; i++)
        {
            wayPoints6[i] = GameObject.CreatePrimitive(PrimitiveType.Cube);
            wayPoints6[i].transform.position = new Vector3(0, -200, 0);
            wayPoints6[i].transform.localScale = new Vector3(5, 500, 5);
        }

        wayPoints7 = new GameObject[5];
        for (int i = 0; i < 5; i++)
        {
            wayPoints7[i] = GameObject.CreatePrimitive(PrimitiveType.Cube);
            wayPoints7[i].transform.position = new Vector3(0, -200, 0);
            wayPoints7[i].transform.localScale = new Vector3(5, 500, 5);
        }

        wayPoints8 = new GameObject[5];
        for (int i = 0; i < 5; i++)
        {
            wayPoints8[i] = GameObject.CreatePrimitive(PrimitiveType.Cube);
            wayPoints8[i].transform.position = new Vector3(0, -200, 0);
            wayPoints8[i].transform.localScale = new Vector3(5, 500, 5);
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

        //Instantiate(Buildings1[0], transform.position, transform.rotation);
        for (int i = 0; i < 10; i++)
        {
            //Instantiate(Buildings1[i], transform.position, transform.rotation);
            Buildings1[i].transform.position = new Vector3(-130 + i * 10, -10, -175);
        }

        for (int i = 0; i < 15; i++)
        {
            Buildings2[i].transform.position = new Vector3(-130 + i * 10, -10, -175);
        }

        for (int i = 0; i < 20; i++)
        {
            Buildings3[i].transform.position = new Vector3(-130 + i * 10, -10, -175);
        }

        for (int i = 0; i < 25; i++)
        {
            Buildings4[i].transform.position = new Vector3(-130 + i * 10, -10, -175);
        }

        b1Taken = 0;
        b2Taken = 0;
        b3Taken = 0;
        b4Taken = 0;
        genSubZone(3, 4, 4, 20, 20, 50, -430, -400, transXTaken1, transZTaken1, SubZones1, 1);
        genSubZone(4, 4, 4, 25, 25, 40, -1450, -170, transXTaken2, transZTaken2, SubZones2, 2);
        genSubZone(3, 8, 8, 40, 40, 25, -1442.5, 861.5, transXTaken3, transZTaken3, SubZones3, 3);
        genSubZone(4, 9, 9, 50, 50, 20, -449, 600, transXTaken4, transZTaken4, SubZones4, 4);

        genMaze(takenX4, takenZ4, transXTaken4, transZTaken4, 4, 9, 9, 50, 50, 0, 0, 0, 2400, -499, 550, 20, -20, -30, -10, -40, Walls4, 4);
        genMaze(takenX3, takenZ3, transXTaken3, transZTaken3, 3, 8, 8, 40, 40, 0, 0, 0, 1520, -1497.5, 804.5, 25, -20, -30, -7.5, -42.5, Walls3, 3);
        genMaze(takenX2, takenZ2, transXTaken2, transZTaken2, 4, 4, 4, 25, 25, 0, 0, 0, 575, -1490, -180, 40, -20, -30, 0, -50, Walls2, 2);
        genMaze(takenX1, takenZ1, transXTaken1, transZTaken1, 3, 4, 4, 20, 20, 0, 0, 0, 360, -485, -420, 50, -20, -30, 5, -55, Walls1, 1);

        //generateWayPoints(5, 20, 20, -485, -420, 50, wayPoints1, takenX1, takenZ1);

        generateGates(4, 20, 20, -430, -400, 50, Gates1, false);
        generateGates(4, 25, 25, -1450, -170, 40, Gates2, false);
        generateGates(4, 40, 40, -1442.5, 861.5, 25, Gates3, true);
        generateGates(4, 50, 50, -449, 600, 20, Gates4, false);

        generateWayPoints(5, 2, 19, -485, -420, 50, wayPoints1, takenX1, takenZ1, 0, 18, 0);
        generateWayPoints(5, 19, 19, -485, -420, 50, wayPoints2, takenX1, takenZ1, 17, 17, 5);
        generateWayPoints(5, 2, 24, -1490, -190, 40, wayPoints3, takenX2, takenZ2, 0, 23, 10);
        generateWayPoints(5, 19, 19, -1490, -190, 40, wayPoints4, takenX2, takenZ2, 17, 17, 15);
        generateWayPoints(5, 4, 4, -1505, 785, 25, wayPoints5, takenX3, takenZ3, 2, 2, 20);
        generateWayPoints(5, 39, 10, -1505, 785, 25, wayPoints6, takenX3, takenZ3, 38, 9, 25);
        generateWayPoints(5, 4, 2, -390, 550, 20, wayPoints7, takenX4, takenZ4, 2, 0, 30);
        generateWayPoints(5, 33, 47, -650, 490, 20, wayPoints8, takenX4, takenZ4, 32, 46, 35);

    }

    void genSubZone(int subZoneCount, int subZoneWidth, int subZoneDepth, int gridWidth, int gridDepth, int coordSize, double worldTransX, double worldTransZ, int[][] transTakenX, int[][] transTakenZ, GameObject[] Subzone, int level)
    {

        for (int i = 0; i < subZoneCount; i++)
        {
            int startX = Random.Range(i * (gridWidth / subZoneCount), gridWidth - ((gridWidth / subZoneCount) * (subZoneCount - i)));
            // int startZ = Random.Range(i * (gridDepth/subZoneCount), gridDepth - ((gridDepth / subZoneCount) * (subZoneCount - i)) );
            int startZ = Random.Range(i * (gridDepth / subZoneCount), gridDepth - subZoneDepth);

            Subzone[i].transform.position = new Vector3(startX * coordSize + (float)worldTransX, (float)0.1, startZ * coordSize + (float)worldTransZ);

            if (level == 1)
            {
                Towns1[i].transform.position = new Vector3(startX * coordSize + (float)worldTransX + 40, -15, startZ * coordSize + (float)worldTransZ + 25);

                var black = Instantiate(MerchantPrefab, new Vector3(startX * coordSize + (float)worldTransX + 40, 1.39f, startZ * coordSize + (float)worldTransZ + 25), Quaternion.identity);

                Instantiate(DoctorPrefab, new Vector3(startX * coordSize + (float)worldTransX + 80, 1.39f, startZ * coordSize + (float)worldTransZ + 25), Quaternion.identity);

                var shopInventory = black.GetComponent<BlackSmithInventory>();

                shopInventory.zone = 1;


            }

            if (level == 2)
            {
                Towns2[i].transform.position = new Vector3(startX * coordSize + (float)worldTransX + 40, -15, startZ * coordSize + (float)worldTransZ + 25);

                var black = Instantiate(MerchantPrefab, new Vector3(startX * coordSize + (float)worldTransX + 40, 1.39f, startZ * coordSize + (float)worldTransZ + 25), Quaternion.identity);

                Instantiate(DoctorPrefab, new Vector3(startX * coordSize + (float)worldTransX + 80, 1.39f, startZ * coordSize + (float)worldTransZ + 25), Quaternion.identity);

                var shopInventory = black.GetComponent<BlackSmithInventory>();

                shopInventory.zone = 2;
            }

            if (level == 3)
            {
                Towns3[i].transform.position = new Vector3(startX * coordSize + (float)worldTransX + 40, -15, startZ * coordSize + (float)worldTransZ + 35);
                var black = Instantiate(MerchantPrefab, new Vector3(startX * coordSize + (float)worldTransX + 40, 1.39f, startZ * coordSize + (float)worldTransZ + 25), Quaternion.identity);

                Instantiate(DoctorPrefab, new Vector3(startX * coordSize + (float)worldTransX + 80, 1.39f, startZ * coordSize + (float)worldTransZ + 25), Quaternion.identity);

                var shopInventory = black.GetComponent<BlackSmithInventory>();

                shopInventory.zone = 3;
            }

            if (level == 4)
            {
                Towns4[i].transform.position = new Vector3(startX * coordSize + (float)worldTransX + 40, -15, startZ * coordSize + (float)worldTransZ + 35);
                var black = Instantiate(MerchantPrefab, new Vector3(startX * coordSize + (float)worldTransX + 40, 1.39f, startZ * coordSize + (float)worldTransZ + 25), Quaternion.identity);

                Instantiate(DoctorPrefab, new Vector3(startX * coordSize + (float)worldTransX + 80, 1.39f, startZ * coordSize + (float)worldTransZ + 25), Quaternion.identity);

                var shopInventory = black.GetComponent<BlackSmithInventory>();

                shopInventory.zone = 4;
            }

            for (int j = 0; j < subZoneDepth; j++)
            {
                transTakenX[i][j] += startX;
                transTakenZ[i][j] += startZ;
            }

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
    void genMaze(int[][] xTaken, int[][] zTaken, int[][] transXTaken, int[][] transZTaken, int subZoneCount, int subZoneWidth, int subZoneDepth, int gridWidth, int gridDepth, int gridStartIndexX, int gridStartIndexZ, int wallsStartIndex, int wallsEndIndex, double worldTransX, double worldTransZ, int coordSize, int rotX0, int rotZ0, double rotX90, double rotZ90, GameObject[] Walls, int level)
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

            //bool addedBuild = false;

            int count = 0;
            for (int i = wallsStartIndex; i < (gridWidth - 1) + wallsStartIndex; i++)
            {
                if (transX == banX)
                {
                    transX += coordSize;
                    count++;
                }

                bool canGenerate1 = true;

                for (int j = 0; j < subZoneCount; j++)
                {
                    for (int k = 0; k < subZoneWidth; k++)
                    {
                        for (int l = 0; l < subZoneDepth; l++)
                        {
                            if ((transXTaken[j][k] == (transX / coordSize)) && (transZTaken[j][l] == (transZ / coordSize)))
                            {
                                canGenerate1 = false;
                            }
                        }

                        if (transXTaken[j][k] == transX / coordSize && transZTaken[j][0] - 1 == transZ / coordSize)
                        {
                            canGenerate1 = false;
                        }

                        if (transXTaken[j][0] - 1 == transX / coordSize && transZTaken[j][k] == transZ / coordSize)
                        {
                            canGenerate1 = false;
                        }
                    }

                    if (transXTaken[j][0] - 1 == transX / coordSize && transZTaken[j][0] - 1 == transZ / coordSize)
                    {
                        canGenerate1 = false;
                    }
                }

                if (canGenerate1)
                {
                    Walls[i].transform.position = new Vector3(transX + (float)worldTransX, 5, transZ + (float)worldTransZ);
                    Walls[i].transform.Rotate(0, angle, 0, Space.Self);

                    // Generate Level 1 Buildings
                    if (level == 1)
                    {
                        if (b1Taken < 5)
                        {
                            int buildingPossibility = Random.Range(0, 30);
                            //int buildingPossibility = 0;
                            if (buildingPossibility == 0)
                            {
                                Buildings1[b1Taken].transform.Rotate(0, 90, 0, Space.Self);
                                Buildings1[b1Taken].transform.position = new Vector3((float)transX + (float)worldTransX, 8, (float)transZ + (float)worldTransZ - 9);
                                b1Taken++;
                                //addedBuild = true;
                            }

                        }
                        else if (b1Taken < 10)
                        {
                            Buildings1[b1Taken].transform.Rotate(0, 180, 0, Space.Self);
                            Buildings1[b1Taken].transform.position = new Vector3((float)transX + (float)worldTransX, 1, (float)transZ + (float)worldTransZ - 9);
                            b1Taken++;
                            //addedBuild = true;
                        }
                    } // end lv 1
                    if (level == 2)
                    {
                        if (b2Taken < 7)
                        {
                            int buildingPossibility = Random.Range(0, 30);
                            //int buildingPossibility = 0;
                            if (buildingPossibility == 0)
                            {
                                Buildings2[b2Taken].transform.Rotate(0, 180, 0, Space.Self);
                                Buildings2[b2Taken].transform.position = new Vector3((float)transX + (float)worldTransX, -1, (float)transZ + (float)worldTransZ - 9);
                                b2Taken++;
                                //addedBuild = true;
                            }

                        }
                        else if (b2Taken < 15)
                        {
                            Buildings2[b2Taken].transform.Rotate(0, 90, 0, Space.Self);
                            Buildings2[b2Taken].transform.position = new Vector3((float)transX + (float)worldTransX, 1, (float)transZ + (float)worldTransZ - 9);
                            b2Taken++;
                            //addedBuild = true;
                        }
                    } // end lv 2
                    if (level == 3)
                    {
                        if (b3Taken < 12)
                        {
                            int buildingPossibility = Random.Range(0, 60);
                            //int buildingPossibility = 0;
                            if (buildingPossibility == 0)
                            {
                                Buildings3[b3Taken].transform.Rotate(0, 90, 0, Space.Self);
                                Buildings3[b3Taken].transform.position = new Vector3((float)transX + (float)worldTransX + 4, 1, (float)transZ + (float)worldTransZ - 9);
                                b3Taken++;
                                //addedBuild = true;
                            }

                        }
                        else if (b3Taken < 20)
                        {
                            Buildings3[b3Taken].transform.Rotate(0, 90, 0, Space.Self);
                            Buildings3[b3Taken].transform.position = new Vector3((float)transX + (float)worldTransX - 4, 8, (float)transZ + (float)worldTransZ - 9);
                            b3Taken++;
                            //addedBuild = true;
                        }
                    } // end lv 3
                    if (level == 4)
                    {
                        if (b4Taken < 15)
                        {
                            int buildingPossibility = Random.Range(0, 90);
                            //int buildingPossibility = 0;
                            if (buildingPossibility == 0)
                            {
                                Buildings4[b4Taken].transform.Rotate(0, 90, 0, Space.Self);
                                Buildings4[b4Taken].transform.position = new Vector3((float)transX + (float)worldTransX, 1, (float)transZ + (float)worldTransZ - 6);
                                b4Taken++;
                                //addedBuild = true;
                            }

                        }
                        else if (b4Taken < 25)
                        {
                            Buildings4[b4Taken].transform.Rotate(0, 90, 0, Space.Self);
                            Buildings4[b4Taken].transform.position = new Vector3((float)transX + (float)worldTransX, 8, (float)transZ + (float)worldTransZ - 9);
                            b4Taken++;
                            //addedBuild = true;
                        }
                    } // end lv 4
                }
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
                genMaze(xTaken, zTaken, transXTaken, transZTaken, subZoneCount, subZoneWidth, subZoneDepth, nextX, nextZA, gridStartIndexX, nextStartZA, nextIndexA, maxIndexA, worldTransX, worldTransZ, coordSize, rotX0, rotZ0, rotX90, rotZ90, Walls, level);
            }
            if (wallsNeededB > 0)
            {
                genMaze(xTaken, zTaken, transXTaken, transZTaken, subZoneCount, subZoneWidth, subZoneDepth, nextX, nextZB, gridStartIndexX, nextStartZB, nextIndexB, maxIndexB, worldTransX, worldTransZ, coordSize, rotX0, rotZ0, rotX90, rotZ90, Walls, level);
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

            //bool addedBuild = false;

            int count = 0;
            for (int i = wallsStartIndex; i < (gridDepth - 1) + wallsStartIndex; i++)
            {
                if (transZ == banZ)
                {
                    transZ += coordSize;
                    count++;
                }

                bool canGenerate2 = true;

                for (int j = 0; j < subZoneCount; j++)
                {
                    for (int k = 0; k < subZoneWidth - 1; k++)
                    {
                        for (int l = 0; l < subZoneDepth; l++)
                        {

                            if (transXTaken[j][k] == ((transX - rotX90) / coordSize) && transZTaken[j][l] == ((transZ - rotZ90) / coordSize))
                            {
                                canGenerate2 = false;
                            }
                        }

                        if (transXTaken[j][k] == ((transX - rotX90) / coordSize) && transZTaken[j][0] - 1 == ((transZ - rotZ90) / coordSize))
                        {
                            canGenerate2 = false;
                        }

                        if (transXTaken[j][0] - 1 == ((transX - rotX90) / coordSize) && transZTaken[j][k] == ((transZ - rotZ90) / coordSize))
                        {
                            canGenerate2 = false;
                        }
                    }

                    if (transXTaken[j][0] - 1 == ((transX - rotX90) / coordSize) && transZTaken[j][0] - 1 == ((transZ - rotZ90) / coordSize))
                    {
                        canGenerate2 = false;
                    }
                }

                //canGenerate2 = true;
                if (canGenerate2)
                {
                    Walls[i].transform.Rotate(0, angle, 0, Space.Self);
                    Walls[i].transform.position = new Vector3((float)transX + (float)worldTransX, 5, (float)transZ + (float)worldTransZ);

                    if (level == 1)
                    {
                        if (b1Taken < 5)
                        {
                            int buildingPossibility = Random.Range(0, 30);
                            //int buildingPossibility = 0;
                            if (buildingPossibility == 0)
                            {
                                Buildings1[b1Taken].transform.Rotate(0, 180, 0, Space.Self);
                                Buildings1[b1Taken].transform.position = new Vector3((float)transX + (float)worldTransX - 9, 8, (float)transZ + (float)worldTransZ);
                                b1Taken++;
                                //addedBuild = true;
                            }

                        }
                        else if (b1Taken < 10)
                        {
                            Buildings1[b1Taken].transform.Rotate(0, 270, 0, Space.Self);
                            Buildings1[b1Taken].transform.position = new Vector3((float)transX + (float)worldTransX - 9, 1, (float)transZ + (float)worldTransZ);
                            b1Taken++;
                            //addedBuild = true;
                        }
                    }
                    if (level == 2)
                    {
                        if (b2Taken < 7)
                        {
                            int buildingPossibility = Random.Range(0, 30);
                            //int buildingPossibility = 0;
                            if (buildingPossibility == 0)
                            {
                                Buildings2[b2Taken].transform.Rotate(0, 90, 0, Space.Self);
                                Buildings2[b2Taken].transform.position = new Vector3((float)transX + (float)worldTransX + 9, -1, (float)transZ + (float)worldTransZ);
                                b2Taken++;
                                //addedBuild = true;
                            }

                        }
                        else if (b2Taken < 15)
                        {
                            Buildings2[b2Taken].transform.Rotate(0, 180, 0, Space.Self);
                            Buildings2[b2Taken].transform.position = new Vector3((float)transX + (float)worldTransX - 9, 1, (float)transZ + (float)worldTransZ);
                            b2Taken++;
                            //addedBuild = true;
                        }
                    } // end lv 2
                    if (level == 3)
                    {
                        if (b3Taken < 12)
                        {
                            int buildingPossibility = Random.Range(0, 60);
                            //int buildingPossibility = 0;
                            if (buildingPossibility == 0)
                            {
                                Buildings3[b3Taken].transform.Rotate(0, 180, 0, Space.Self);
                                Buildings3[b3Taken].transform.position = new Vector3((float)transX + (float)worldTransX - 9, 1, (float)transZ + (float)worldTransZ - 5);
                                b3Taken++;
                                //addedBuild = true;
                            }

                        }
                        else if (b3Taken < 20)
                        {
                            Buildings3[b3Taken].transform.Rotate(0, 180, 0, Space.Self);
                            Buildings3[b3Taken].transform.position = new Vector3((float)transX + (float)worldTransX - 9, 8, (float)transZ + (float)worldTransZ);
                            b3Taken++;
                            //addedBuild = true;
                        }
                    } // end lv 3
                    if (level == 4)
                    {
                        if (b4Taken < 15)
                        {
                            int buildingPossibility = Random.Range(0, 100);
                            //int buildingPossibility = 0;
                            if (buildingPossibility == 0)
                            {
                                Buildings4[b4Taken].transform.Rotate(0, 180, 0, Space.Self);
                                Buildings4[b4Taken].transform.position = new Vector3((float)transX + (float)worldTransX - 6, 1, (float)transZ + (float)worldTransZ);
                                b4Taken++;
                                //addedBuild = true;
                            }

                        }
                        else if (b4Taken < 25)
                        {
                            Buildings4[b4Taken].transform.Rotate(0, 180, 0, Space.Self);
                            Buildings4[b4Taken].transform.position = new Vector3((float)transX + (float)worldTransX - 9, 8, (float)transZ + (float)worldTransZ);
                            b4Taken++;
                            //addedBuild = true;
                        }
                    } // end lv 4

                }

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
                genMaze(xTaken, zTaken, transXTaken, transZTaken, subZoneCount, subZoneWidth, subZoneDepth, nextXA, nextZ, nextStartXA, gridStartIndexZ, nextIndexA, maxIndexA, worldTransX, worldTransZ, coordSize, rotX0, rotZ0, rotX90, rotZ90, Walls, level);
            }
            if (wallsNeededB > 0)
            {
                genMaze(xTaken, zTaken, transXTaken, transZTaken, subZoneCount, subZoneWidth, subZoneDepth, nextXB, nextZ, nextStartXB, gridStartIndexZ, nextIndexB, maxIndexB, worldTransX, worldTransZ, coordSize, rotX0, rotZ0, rotX90, rotZ90, Walls, level);
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
            return false;
        }

        for (int j = 0; j < foundValues; j++)
        {
            if (xValues[j] == x && zValues[j] == (z + 1))
            {
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
            return false;
        }

        for (int j = 0; j < foundValues; j++)
        {
            if (xValues[j] == x && zValues[j] == (z - 1))
            {
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
            return false;
        }

        for (int j = 0; j < foundValues; j++)
        {
            if (xValues[j] == (x + 1) && zValues[j] == z)
            {
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
            return false;
        }

        for (int j = 0; j < foundValues; j++)
        {
            if (xValues[j] == (x - 1) && zValues[j] == z)
            {
                return false;
            }
        }

        return true;
    }

    bool move(int[] xValues, int[] zValues, int lastX, int lastZ, int rendered, bool rendering, int[][] takenX, int[][] takenZ, int i)
    {
        if (moveNorth(xValues, zValues, lastX, lastZ, rendered, takenX) == true && rendering)
        {
            xValues[i] = lastX;
            zValues[i] = lastZ + 1;
            return true;

        }
        else if (moveSouth(xValues, zValues, lastX, lastZ, rendered, takenX) == true && rendering)
        {

            xValues[i] = lastX;
            zValues[i] = lastZ - 1;
            return true;

        }
        else if (moveWest(xValues, zValues, lastX, lastZ, rendered, takenZ) == true && rendering)
        {

            xValues[i] = lastX + 1;
            zValues[i] = lastZ;
            return true;

        }
        else if (moveEast(xValues, zValues, lastX, lastZ, rendered, takenZ) == true && rendering)
        {
            xValues[i] = lastX - 1;
            zValues[i] = lastZ;
            return true;

        }
        return false;
    }


    // Need to check if subzone exists & 
    void generateGates(int GateCount, int gridWidth, int gridDepth, double worldTransX, double worldTransZ, float coordSize, GameObject[] Gates, bool dec)
    {
        float[] gateXs = new float[GateCount];
        float[] gateZs = new float[GateCount];

        for (int i = 0; i < GateCount; i++)
        {
            bool valid = false;

            while (valid == false)
            {
                float startX = Random.Range(0, gridWidth - 1) * coordSize - coordSize - coordSize / 2;

                float startZ = Random.Range(0, gridDepth - 1) * coordSize - coordSize - coordSize / 2;
                if (dec)
                {
                    startX += coordSize / 2;
                    startZ += coordSize / 2;
                }

                valid = true;
                for (int j = 0; j < i; j++)
                {
                    if (gateXs[j] == startX && gateZs[j] == startZ)
                    {
                        valid = false;
                    }
                }

                if (valid == true)
                {
                    gateXs[i] = startX;
                    gateZs[i] = startZ;
                    Gates[i].transform.position = new Vector3(startX + (float)worldTransX, 5, startZ + (float)worldTransZ);
                }
            }

        }
    }
    void generateWayPoints(int wayPointCount, int gridEndX, int gridEndZ, double worldTransX, double worldTransZ, float coordSize, GameObject[] wayPoints, int[][] takenX, int[][] takenZ, int gridStartX, int gridStartZ, int waypointsSet)
    {
        int[] xValues = new int[wayPointCount];
        int[] zValues = new int[wayPointCount];
        List<int> waypointOrder = new List<int>();

        xValues[0] = Random.Range(gridStartX, gridEndX);
        zValues[0] = Random.Range(gridStartZ, gridEndZ);

        var enemy = Instantiate(EnemyPrefab);

        PatrolScript script = enemy.GetComponent<PatrolScript>();

        script.numWaypointSet = waypointsSet;

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
            }
            else
            {
                bool resultFound = false;
                while (!resultFound)
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


        int max_X = -1000000;
        int bestXIndex = -1;
        List<int> indexList = new List<int>();
        for (int i = 0; i < xValues.Length; i++)
        {
            if (max_X == xValues[i])
            {
                indexList.Add(i);
            }
            else
            {
                max_X = Mathf.Max(max_X, xValues[i]);
                if (max_X == xValues[i])
                {
                    indexList.Clear();
                    indexList.Add(i);
                    bestXIndex = i;
                }
            }
        }
        if (indexList.Count == 1)
        {
            waypointOrder.Add(bestXIndex);

        }
        else if (indexList.Count == wayPointCount)
        {
            max_X = -1000000;
            for (int i = 0; i < zValues.Length; i++)
            {
                max_X = Mathf.Max(max_X, zValues[i]);
                if (max_X == zValues[i])
                {
                    bestXIndex = i;
                }
            }
        }
        else
        {
            for (int i = 0; i < zValues.Length; i++)
            {
                max_X = 1000000;
                if (xValues[i] == xValues[bestXIndex] && bestXIndex == i)
                {
                    for (int j = 0; j < indexList.Count; j++)
                    {
                        max_X = Mathf.Min(max_X, zValues[indexList[j]]);
                        if (max_X == zValues[indexList[j]])
                        {
                            bestXIndex = j;
                        }
                    }
                }
            }
        }


        //waypointOrder = findClosest(xValues, zValues, bestXIndex, waypointOrder, -1);

        for (int i = 0; i < rendered; i++)
        {
            var x = worldTransX + coordSize * xValues[i] - coordSize / 2;
            var z = worldTransZ + coordSize * zValues[i] - coordSize;
            //wayPoints[waypointOrder[i]].transform.position = new Vector3((float)x, 5, (float)z);
            wayPoints[i].transform.position = new Vector3((float)x, 5, (float)z);


            wayPoints[i].name = "waypoint" + numberOfWaypoints.ToString();
            wayPoints[i].tag = "Waypoint";
            numberOfWaypoints++;
            //wayPoints[waypointOrder[i]].name = "waypoint" + i.ToString();
            //wayPoints[waypointOrder[i]].tag = "Waypoint";

        }

    } // end method 
}