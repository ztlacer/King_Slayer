using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerInventory : MonoBehaviour
{
    public InventoryObject inventory;
    public bool isTriggering = false;
    public BlackSmithInventory shopInv;
    public GameObject screen;
    public GameObject shopScreen;
    [SerializeField] GameObject messagePrefab;
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
        //screen = GameObject.Find("InventoryScreen");
        //shopScreen = GameObject.Find("ShopScreen");
        shopScreen.SetActive(false);
        screen.SetActive(false);
        //shopScreen = GameObject.Find("ShopScreen");
        //shopScreen.SetActive(false);
    }

    public void OnTriggerEnter(Collider other)
    {
        var item = other.GetComponent<Item>();
        if (item)
        {
            // Notify that you received an item
            //Vector3 v = Camera.main.WorldToViewportPoint(item.transform.position);
            //spawnMessage("Picked up something", v.x, v.y);
            GameObject obj = Instantiate(messagePrefab, gameObject.transform);
            obj.transform.GetChild(0).GetComponent<TextMeshPro>().SetText("Picked up: " + item.name);
            //obj.GetComponent<PickUp>().text.text = message;
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
        print("foundBlacksmith");
        var shopInventory = other.GetComponent<BlackSmithInventory>();
        
        if (!isTriggering && shopInventory)
        {
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

    private void spawnMessage(string message, float x, float y)
    {
        x = Mathf.Clamp(x, 0.05f, 0.95f); // clamp position to screen to ensure
        y = Mathf.Clamp(y, 0.05f, 0.9f);  // the string will be visible
        GameObject obj = Instantiate(messagePrefab, new Vector3(x, y, 0), Quaternion.identity);
        obj.GetComponent<PickUp>().text.text = message;
    }

}
