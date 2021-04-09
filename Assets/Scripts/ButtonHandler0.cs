using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonHandler0 : MonoBehaviour
{
    public GameObject[] items;

    public void moveRow()
    {
        for (int i = items.Length - 1; i > -1; i--)
        {
            float thisX = items[i].transform.position.x;
            float thisY = items[i].transform.position.y;

            if (thisY == 0)
            {
                if (thisX == 0)
                {
                    items[i].transform.position = new Vector3(3, 0, 0);
                }
                else
                {
                    items[i].transform.position = new Vector3(thisX - 1, 0, 0);
                }
            } 
        }
    }
}
