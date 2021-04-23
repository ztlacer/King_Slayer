using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerInventory : MonoBehaviour
{
    public InventoryObject inventory;
    public bool isTriggering = false;
    public InventoryObject shopInv;
    public BlackSmithInventory blacksmith;
    public DoctorInventory doctor;
    public GameObject screen;
    public GameObject shopScreen;
    [SerializeField] GameObject messagePrefab;
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
                if (shopScreen.activeSelf)
                {
                    shopScreen.SetActive(false);
                }
                else
                {
                    shopScreen.SetActive(true);
                }

            }
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                if (shopInv != null && shopInv.currentContainerLook < shopInv.Container.Count - 1)
                {
                    shopInv.currentContainerLook += 1;
                }

            }
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                if (shopInv != null && shopInv.currentContainerLook > 0)
                {
                    shopInv.currentContainerLook -= 1;
                }

            }
            if (shopInv != null && shopScreen.activeSelf && Input.GetKeyDown(KeyCode.B))
            {
                if (shopInv.Container[shopInv.currentContainerLook].amount > 0)
                {
                    if (playerStats.goldAmount >= shopInv.Container[shopInv.currentContainerLook].item.cost)
                    {
                        inventory.AddItem(shopInv.Container[shopInv.currentContainerLook].item, 1);
                        shopInv.Container[shopInv.currentContainerLook].RemoveAmount(1);
                        playerStats.changeGold(-shopInv.Container[shopInv.currentContainerLook].item.cost);
                        if (shopInv.Container[shopInv.currentContainerLook].item.type == ItemType.Equipment) 
                        {
                            if (shopInv.Container[shopInv.currentContainerLook].item.name == "Armor")
                            {
                                playerStats.Defense += armor.defenseBonus;
                            }
                            if (shopInv.Container[shopInv.currentContainerLook].item.name == "Sword")
                            {
                                playerStats.Attack += sword.atkBonus;
                            }
                            if (shopInv.Container[shopInv.currentContainerLook].item.name == "Cloak")
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
            shopInventory.screen = shopScreen;
            //print(shopInventory.screen.name);
            shopInv = shopInventory.inventory;
            isTriggering = true;
            display.inventory = shopInv;
        }

        var DocInventory = other.GetComponent<DoctorInventory>();

        if (!isTriggering && DocInventory)
        {
            DocInventory.screen = shopScreen;
            //print(shopInventory.screen.name);
            shopInv = DocInventory.inventory;
            isTriggering = true;
            display.inventory = shopInv;
        }

    }

    public void OnTriggerExit(Collider other)
    {
        var shopInventory = other.GetComponent<BlackSmithInventory>();
        
        if (isTriggering && shopInventory)
        {
            if (shopInventory.screen.activeSelf)
            {
                shopInventory.screen.SetActive(false);
            }
            print("exit");
            shopInv = null;
            isTriggering = false;

        }

        var DocInventory = other.GetComponent<DoctorInventory>();

        if (isTriggering && DocInventory)
        {
            if (DocInventory.screen.activeSelf)
            {
                DocInventory.screen.SetActive(false);
            }
            print("exit");
            shopInv = null;
            isTriggering = false;
        }

    }

    private void OnApplicationQuit()
    {
        inventory.Container.Clear();
        playerStats.goldAmount = 0;
        playerStats.Stealth = 20;
        playerStats.Defense = 20;
        playerStats.Attack = 20;
        playerStats.Health = 100;
    }

    private void spawnMessage(string message, float x, float y)
    {
        x = Mathf.Clamp(x, 0.05f, 0.95f); // clamp position to screen to ensure
        y = Mathf.Clamp(y, 0.05f, 0.9f);  // the string will be visible
        GameObject obj = Instantiate(messagePrefab, new Vector3(x, y, 0), Quaternion.identity);
        obj.GetComponent<PickUp>().text.text = message;
    }

}
