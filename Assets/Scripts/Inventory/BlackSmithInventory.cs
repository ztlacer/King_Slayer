using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackSmithInventory : MonoBehaviour
{
    public InventoryObject inventory;
    public GameObject screen;
    //public int currentContainerLook;


    public void Start()
    {
        //screen = GameObject.Find("ShopScreen");
        //currentContainerLook = 0;
        //screen.SetActive(false);
    }

    private void OnApplicationQuit()
    {
        inventory.Container.Clear();
    }

}