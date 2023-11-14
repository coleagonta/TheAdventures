using System.Collections;
using System.Collections.Generic;using System.IO.Enumeration;using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = " Item",menuName = "Inventory/Items/new Item")]
public class ItemCreator : ItemScriptableObject
{
   public float healAmount;

   private void Start()
   {
      ItemType = ItemType.Food;
   }
}
