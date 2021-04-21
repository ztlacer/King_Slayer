using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Default Equipment", menuName = "Inventory System/Items/Equipment")]
public class EquipmentObject : ItemObject
{
    public int atkBonus;
    public int defenseBonus;
    public int stealthBonus;
    public void Awake()
    {
        type = ItemType.Equipment;
    }
}