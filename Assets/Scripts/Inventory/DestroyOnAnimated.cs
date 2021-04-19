using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnAnimated : MonoBehaviour
{
    public void DestroyThis()
    {
        GameObject parent = gameObject.transform.parent.gameObject;
        Destroy(parent);
    }
}
