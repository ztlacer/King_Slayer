using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackSmithInventory : MonoBehaviour
{
    public InventoryObject inventory;
    public GameObject screen;
    public int currentContainerLook;
    public ItemObject armor;
    public ItemObject sword;
    public ItemObject armor2;
    public ItemObject sword2;
    public ItemObject armor3;
    public ItemObject sword3;
    public ItemObject armor4;
    public ItemObject sword4;
    public ItemObject cloak;
    public ItemObject cloak2;
    public ItemObject cloak3;
    public ItemObject cloak4;
    public int zone;


    public void Start()
    {
        screen = GameObject.Find("ShopScreen");
        //currentContainerLook = 0;
        //screen.SetActive(false);
        inventory = new InventoryObject();
        if (zone == 1)
        {
            inventory.AddItem(armor, 1);
            inventory.AddItem(sword, 1);
            inventory.AddItem(cloak, 1);
        }
        if (zone == 2)
        {
            inventory.AddItem(armor2, 1);
            inventory.AddItem(sword2, 1);
            inventory.AddItem(cloak2, 1);
        }
        if (zone == 3)
        {
            inventory.AddItem(armor3, 1);
            inventory.AddItem(sword3, 1);
            inventory.AddItem(cloak3, 1);
        }
        if (zone == 4)
        {
            inventory.AddItem(armor4, 1);
            inventory.AddItem(sword4, 1);
            inventory.AddItem(cloak4, 1);
        }
    }

    private void OnApplicationQuit()
    {
        inventory.Container.Clear();
        
    }

}