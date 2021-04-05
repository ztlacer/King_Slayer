using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonHandler8 : MonoBehaviour
{
    public GameObject[] items;

    public void moveRow()
    {
        for (int i = items.Length - 1; i > -1; i--)
        {
            float thisX = items[i].transform.position.x;
            float thisY = items[i].transform.position.y;

            if (thisY == 2)
            {
                if (thisX == 0)
                {
                    items[i].transform.position = new Vector3(3, 2, 0);
                }
                else
                {
                    items[i].transform.position = new Vector3(thisX - 1, 2, 0);
                }
            }
        }
    }
}
