using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;


public class InventoryManager : MonoBehaviour
{
    [FormerlySerializedAs("UIPanel")] public GameObject UIPanel;
    public Transform InventoryPanel;
    public List<InventorySlot> slots = new List<InventorySlot>();
    public bool isOpened;
    public float reachDistance = 1000;
    private Camera mainCamera;
   
   

    private void Awake()
    {
        UIPanel.SetActive(true);
    }

    void Start()
    {
        mainCamera = Camera.main;
        for (int i = 0; i < InventoryPanel.childCount; i++)
        {
            if (InventoryPanel.GetChild(i).GetComponent<InventorySlot>() != null)
            {
                slots.Add(InventoryPanel.GetChild(i).GetComponent<InventorySlot>());
            }
        }
        UIPanel.SetActive(false);
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            isOpened = !isOpened;
            if (isOpened)
            {
                Cursor.lockState = CursorLockMode.Confined;
                UIPanel.SetActive(true);
            }
            else
            {
                Cursor.lockState = CursorLockMode.Locked;
                UIPanel.SetActive(false);
            }
        }

        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Input.GetKeyDown(KeyCode.E))
        {
             if (Physics.Raycast(ray, out hit, reachDistance))
             {
         
                if (hit.collider.gameObject.GetComponent<item>() != null)
                {
                    AddItem(hit.collider.gameObject.GetComponent<item>().itemScriptableObject,
                        hit.collider.gameObject.GetComponent<item>().amount); 
                    Destroy(hit.collider.gameObject);
                }
             } 
        }
        
    }
    

    private void AddItem(ItemScriptableObject item, int amount)
    {
        
        foreach (InventorySlot slot in slots)
        {
            if (slot.item == item)
            {
                if (slot.amount + amount <= item.maximumAmout)
                {
                    slot.amount += amount;
                    slot.ItemAmountText.text = slot.amount.ToString();
                    return;
                } 
                break;
            }
        }
        
        foreach (InventorySlot slot in slots)
        {
            if (slot.isEmpty == true)
            {
                slot.item = item;
                slot.amount = amount;
                slot.isEmpty = false;
                slot.SetIcon(item.icon);
                slot.ItemAmountText.text = amount.ToString();
                break;
            }
        }
    }
}