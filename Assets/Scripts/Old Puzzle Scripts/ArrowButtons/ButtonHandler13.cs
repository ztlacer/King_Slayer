using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonHandler13 : MonoBehaviour
{
    public GameObject[] items;

    public void moveCol()
    {
        for (int i = items.Length - 1; i > -1; i--)
        {
            float thisX = items[i].transform.position.x;
            float thisY = items[i].transform.position.y;

            if (thisX == 1)
            {
                if (thisY == -1)
                {
                    items[i].transform.position = new Vector3(1, 2, 0);
                }
                else
                {
                    items[i].transform.position = new Vector3(1, thisY - 1, 0);
                }
            }

        }
    }
}
