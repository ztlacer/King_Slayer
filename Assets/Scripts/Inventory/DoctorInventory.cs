using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoctorInventory : MonoBehaviour
{

    public InventoryObject inventory;
    public GameObject screen;
    public int currentContainerLook;
    public ItemObject potion;
    public ItemObject meat;


    // Start is called before the first frame update
    void Start()
    {
        screen = GameObject.Find("ShopScreen");
        //currentContainerLook = 0;
        //screen.SetActive(false);
        inventory = new InventoryObject();
        inventory.AddItem(potion, 3);
        inventory.AddItem(meat, 3);
    }

    private void OnApplicationQuit()
    {
        inventory.Container.Clear();

    }
}
