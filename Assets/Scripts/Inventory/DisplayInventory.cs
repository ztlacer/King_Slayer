using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayInventory : MonoBehaviour
{
    public InventoryObject inventory;

    public StatObject playerStats;

    public GameObject goldUI;

    public int X_START;
    public int Y_START;
    public int X_SPACE_BETWEEN_ITEM;
    public int NUMBER_OF_COLUMNS;
    public int Y_SPACE_BETWEEN_ITEMS;
    public int X_GOLD_START;
    public int Y_GOLD_START;
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
    public void CreateDisplay()
    {
            var gold = Instantiate(goldUI, Vector3.zero, Quaternion.identity, transform);
            gold.GetComponent<RectTransform>().localPosition = new Vector3(X_GOLD_START, Y_GOLD_START, 0f);
            gold.GetComponentInChildren<TextMeshProUGUI>().text = "Gold: " + playerStats.goldAmount.ToString();
            localGoldAmount = playerStats.goldAmount;

        for (int i = 0; i < inventory.Container.Count; i++)
        {
            var obj = Instantiate(inventory.Container[i].item.prefab, Vector3.zero, Quaternion.identity, transform);
            obj.GetComponent<RectTransform>().localPosition = GetPosition(i);
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
        for (int i = 0; i < inventory.Container.Count; i++)
        {
            if (itemsDisplayed.ContainsKey(inventory.Container[i]))
            {
                itemsDisplayed[inventory.Container[i]].GetComponentInChildren<TextMeshProUGUI>().text = inventory.Container[i].amount.ToString("n0");
                itemsDisplayed[inventory.Container[i]].GetComponentInChildren<TextMeshProUGUI>().color = Color.black;
                if (i == inventory.currentContainerLook)
                {
                    itemsDisplayed[inventory.Container[i]].GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
                    print("color change");
                }
            }
            else
            {
                var obj = Instantiate(inventory.Container[i].item.prefab, Vector3.zero, Quaternion.identity, transform);
                obj.GetComponent<RectTransform>().localPosition = GetPosition(i);
                obj.GetComponentInChildren<TextMeshProUGUI>().text = inventory.Container[i].amount.ToString("n0");
                itemsDisplayed.Add(inventory.Container[i], obj);
                if (i == inventory.currentContainerLook)
                {
                    obj.GetComponentInChildren<TextMeshProUGUI>().outlineColor = new Color32(0, 0, 0, 255);
                }
            }
        }
    }
}
