using System.Collections;
using System.Collections.Generic;using System.IO.Enumeration;using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "Food Item",menuName = "Inventory/Items/new Food Item")]
public class FoodItem : ItemScriptableObject
{
   public float healAmount;

   private void Start()
   {
      ItemType = ItemType.Food;
   }
}
