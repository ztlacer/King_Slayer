using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonHandler6 : MonoBehaviour
{
    public GameObject[] items;
    public float Ydisplacement;
    public float Zdisplacement;
    public float Xdisplacement;

    public void moveCol()
    {
        for (int i = items.Length - 1; i > -1; i--)
        {
            //float thisZ = items[i].transform.position.z - Zdisplacement;
            float thisY = items[i].transform.position.y - Ydisplacement;
            float thisX = items[i].transform.position.x - Xdisplacement;

            if (thisX == 2)
            {
                if (thisY == 2)
                {
                    items[i].transform.position = new Vector3(items[i].transform.position.x, items[i].transform.position.y - 3, items[i].transform.position.z);
                }
                else
                {
                    items[i].transform.position = new Vector3(items[i].transform.position.x, items[i].transform.position.y + 1, items[i].transform.position.z);
                }
            }

        }
    }
}
