using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class InventorySlot : MonoBehaviour
{
    public ItemScriptableObject item;
    public int amount;
    public bool isEmpty = true;
    public GameObject iconGO;
    public TMP_Text ItemAmountText;
    
    private void Awake()
    {
        iconGO = transform.GetChild(0).GetChild(0).gameObject;
        ItemAmountText = transform.GetChild(0).GetChild(1).GetComponent<TMP_Text>();
    }

    public void SetIcon(Sprite icon)
    {
        iconGO.GetComponent<Image>().color = new Color(1, 1, 1);
        iconGO.GetComponent<Image>().sprite = icon;
    }
}

