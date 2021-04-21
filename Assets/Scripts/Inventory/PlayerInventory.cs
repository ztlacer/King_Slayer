using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public InventoryObject inventory;
    public bool isTriggering = false;
    public BlackSmithInventory shopInv;
    public GameObject screen;
    public GameObject shopScreen;
    public bool shopOpen = false;
    public DisplayInventory display;
    public StatObject playerStats;
    public EquipmentObject sword;
    public EquipmentObject armor;
    public EquipmentObject cloak;
    public HealthObject potion;
    public HealthObject meat;

    //public int currentContainerLook = null;


    public void Start()
    {
        screen = GameObject.Find("InventoryScreen");
        screen.SetActive(false);
    }

    public void OnTriggerEnter(Collider other)
    {
        var item = other.GetComponent<Item>();
        if (item)
        {
            inventory.AddItem(item.item, 1);
            Destroy(other.gameObject);
        }

    }
    public void Update()
    {
        if (isTriggering)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                print("e");
                if (shopInv.screen.activeSelf)
                {
                    shopInv.screen.SetActive(false);
                }
                else
                {
                    shopInv.screen.SetActive(true);
                }

            }
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                if (shopInv.inventory.currentContainerLook < shopInv.inventory.Container.Count - 1)
                {
                    shopInv.inventory.currentContainerLook += 1;
                }

            }
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                if (shopInv.inventory.currentContainerLook > 0)
                {
                    shopInv.inventory.currentContainerLook -= 1;
                }
            }
            if (shopInv != null && shopInv.screen.activeSelf && Input.GetKeyDown(KeyCode.B))
            {
                if (shopInv.inventory.Container[shopInv.inventory.currentContainerLook].amount > 0)
                {
                    if (playerStats.goldAmount >= shopInv.inventory.Container[shopInv.inventory.currentContainerLook].item.cost)
                    {
                        inventory.AddItem(shopInv.inventory.Container[shopInv.inventory.currentContainerLook].item, 1);
                        shopInv.inventory.Container[shopInv.inventory.currentContainerLook].RemoveAmount(1);
                        playerStats.changeGold(-shopInv.inventory.Container[shopInv.inventory.currentContainerLook].item.cost);
                        if (shopInv.inventory.Container[shopInv.inventory.currentContainerLook].item.type == ItemType.Equipment) 
                        {
                            if (shopInv.inventory.Container[shopInv.inventory.currentContainerLook].item.name == "Armor")
                            {
                                playerStats.Defense += armor.defenseBonus;
                            }
                            if (shopInv.inventory.Container[shopInv.inventory.currentContainerLook].item.name == "Sword")
                            {
                                playerStats.Attack += sword.atkBonus;
                            }
                            if (shopInv.inventory.Container[shopInv.inventory.currentContainerLook].item.name == "Cloak")
                            {
                                playerStats.Attack += cloak.stealthBonus;
                            }
                        }
                    }
                }
            }

        }
        if (Input.GetKeyDown(KeyCode.I))
        {
            print("i");
            if (screen.activeSelf)
            {
                screen.SetActive(false);
            }
            else
            {
                screen.SetActive(true);
            }

        }
    }

    public void OnTriggerStay(Collider other)
    {
        var shopInventory = other.GetComponent<BlackSmithInventory>();
        
        if (!isTriggering && shopInventory)
        {
            print("foundBlacksmith");
            shopInventory.screen = shopScreen;
            //print(shopInventory.screen.name);
            shopInv = shopInventory;
            isTriggering = true;
            display.inventory = shopInv.inventory;
        }
        
    }

    public void OnTriggerExit(Collider other)
    {
        var shopInventory = other.GetComponent<BlackSmithInventory>();
        
        if (isTriggering && shopInventory)
        {
            if (shopInv.screen.activeSelf)
            {
                shopInv.screen.SetActive(false);
            }
            print("exit");
            shopInv = null;
            isTriggering = false;
        }
        
    }

    private void OnApplicationQuit()
    {
        inventory.Container.Clear();
    }

}
