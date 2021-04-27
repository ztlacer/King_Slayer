using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayInventory : MonoBehaviour
{
    public InventoryObject inventory;

    public StatObject playerStats;

    public GameObject goldUI;

    public TextMeshProUGUI itemDescription;

    public int X_START;
    public int Y_START;
    public int X_SPACE_BETWEEN_ITEM;
    public int NUMBER_OF_COLUMNS;
    public int Y_SPACE_BETWEEN_ITEMS;
    public int X_GOLD_START;
    public int Y_GOLD_START;
    public int X_EQUIPMENT_START;
    public int Y_EQUIPMENT_START;
    int localGoldAmount;
    Dictionary<InventorySlot, GameObject> itemsDisplayed = new Dictionary<InventorySlot, GameObject>();


    // Start is called before the first frame update
    void Start()
    {
        CreateDisplay();
        localGoldAmount = playerStats.goldAmount;
    }

    // Update is called once per frame
    void Update()
    {

        UpdateDisplay();
    }
    public void clearItems()
    {
        itemsDisplayed.Clear();
        foreach (Transform child in transform)
        {
            GameObject.Destroy(child.gameObject);
        }
    }
    public void CreateDisplay()
    {
            var gold = Instantiate(goldUI, Vector3.zero, Quaternion.identity, transform);
            gold.GetComponent<RectTransform>().localPosition = new Vector3(X_GOLD_START, Y_GOLD_START, 0f);
            gold.GetComponentInChildren<TextMeshProUGUI>().text = "Gold: " + playerStats.goldAmount.ToString();
            localGoldAmount = playerStats.goldAmount;
        int numInvItems = 0;
        for (int i = 0; i < inventory.Container.Count; i++)
        {
            if (inventory.Container[i].item.name == "Armor" || inventory.Container[i].item.name == "Sword" || inventory.Container[i].item.name == "Cloak")
            {
                numInvItems++;
            }
            var obj = Instantiate(inventory.Container[i].item.prefab, Vector3.zero, Quaternion.identity, transform);
            obj.GetComponent<RectTransform>().localPosition = GetPosition(i - numInvItems);
            obj.GetComponentInChildren<TextMeshProUGUI>().text = inventory.Container[i].amount.ToString("n0");
            obj.GetComponentInChildren<TextMeshProUGUI>().color = Color.black;
            if (i == inventory.currentContainerLook)
            {
                obj.GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
                
            }
        }
    }
    public Vector3 GetPosition(int i)
    {
        return new Vector3(X_START + (X_SPACE_BETWEEN_ITEM * (i % NUMBER_OF_COLUMNS)), Y_START - (Y_SPACE_BETWEEN_ITEMS * (i / NUMBER_OF_COLUMNS)), 0f);
    }
    public void UpdateDisplay()
    {
        if (playerStats.goldAmount != localGoldAmount)
        {
            var gold = Instantiate(goldUI, Vector3.zero, Quaternion.identity, transform);
            gold.GetComponent<RectTransform>().localPosition = new Vector3(X_GOLD_START, Y_GOLD_START, 0f);
            gold.GetComponentInChildren<TextMeshProUGUI>().text = "Gold: " + playerStats.goldAmount.ToString();
            localGoldAmount = playerStats.goldAmount;
        }
        int numInvItems = 0;
        for (int i = 0; i < inventory.Container.Count; i++)
        {
            if (itemsDisplayed.ContainsKey(inventory.Container[i]))
            {
                if (inventory.Container[i].item.name == "Armor" || inventory.Container[i].item.name == "Sword" || inventory.Container[i].item.name == "Cloak")
                {
                    numInvItems++;
                }
                itemsDisplayed[inventory.Container[i]].GetComponentInChildren<TextMeshProUGUI>().text = inventory.Container[i].amount.ToString("n0");
                itemsDisplayed[inventory.Container[i]].GetComponentInChildren<TextMeshProUGUI>().color = Color.black;
                if (i == inventory.currentContainerLook)
                {
                    itemsDisplayed[inventory.Container[i]].GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
                    itemDescription.text = inventory.Container[i].item.description;
                }
            }
            else
            {
                var obj = Instantiate(inventory.Container[i].item.prefab, Vector3.zero, Quaternion.identity, transform);
                obj.GetComponentInChildren<TextMeshProUGUI>().text = inventory.Container[i].amount.ToString("n0");
                itemsDisplayed.Add(inventory.Container[i], obj);
                if (inventory.Container[i].item.name == "Armor")
                {
                    obj.GetComponent<RectTransform>().localPosition = new Vector3(X_EQUIPMENT_START, Y_EQUIPMENT_START, 0f);
                    numInvItems++;
                }
                else if (inventory.Container[i].item.name == "Sword")
                {
                    obj.GetComponent<RectTransform>().localPosition = new Vector3(X_EQUIPMENT_START + 100, Y_EQUIPMENT_START, 0f);
                    numInvItems++;
                }
                else if (inventory.Container[i].item.name == "Cloak")
                {
                    obj.GetComponent<RectTransform>().localPosition = new Vector3(X_EQUIPMENT_START + 200, Y_EQUIPMENT_START, 0f);
                    numInvItems++;
                }
                else {
                    obj.GetComponent<RectTransform>().localPosition = GetPosition(i - numInvItems);
                }
                if (i == inventory.currentContainerLook)
                {
                    obj.GetComponentInChildren<TextMeshProUGUI>().outlineColor = new Color32(0, 0, 0, 255);
                    itemDescription.text = inventory.Container[i].item.description;
                }
            }
        }
    }
}
