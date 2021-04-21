using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackSmithInventory : MonoBehaviour
{
    public InventoryObject inventory;
    public GameObject screen;
    public int currentContainerLook;
    public ItemObject potion;
    public ItemObject meat;
    public ItemObject armor;
    public ItemObject sword;


    public void Start()
    {
        screen = GameObject.Find("ShopScreen");
        //currentContainerLook = 0;
        //screen.SetActive(false);
        inventory = new InventoryObject();
        inventory.AddItem(potion, 3);
        inventory.AddItem(meat, 3);
        inventory.AddItem(armor, 1);
        inventory.AddItem(sword, 1);
    }

    private void OnApplicationQuit()
    {
        inventory.Container.Clear();
        
    }

}