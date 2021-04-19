using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonHandler1 : MonoBehaviour
{
    public GameObject[] items;
    public float Ydisplacement;
    public float Zdisplacement;
    public float Xdisplacement;

    public void moveRow()
    {
        print("moving row");
        for (int i = items.Length - 1; i > -1; i--)
        {
            //float thisZ = items[i].transform.position.z - Zdisplacement;
            float thisY = items[i].transform.position.y - Ydisplacement;
            float thisX = items[i].transform.position.x - Xdisplacement;

            if (thisY == 0)
            {
                if (thisX == 3)
                {
                    items[i].transform.position = new Vector3(items[i].transform.position.x - 3, items[i].transform.position.y, items[i].transform.position.z);
                }
                else
                {
                    items[i].transform.position = new Vector3(items[i].transform.position.x + 1, items[i].transform.position.y, items[i].transform.position.z);
                }
            }
        }
    }
}
