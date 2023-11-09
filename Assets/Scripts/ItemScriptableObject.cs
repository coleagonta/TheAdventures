using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType {Default,Food,Weapon,instrument}
public class ItemScriptableObject : ScriptableObject
{
   public ItemType ItemType;
   public string itemName;
   public GameObject itemPrefab;
   public Sprite icon;
   public int maximumAmout;
   public string itemDescription;

}
