using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public GameObject UIPanel;
    public Transform InventoryPanel;
    public List<InventorySlot> slots = new List<InventorySlot>();
    private bool isOpened;
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
                UIPanel.SetActive(true);
            }
            else
            {
                UIPanel.SetActive(false);
            }
        }

        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, reachDistance))
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (hit.collider.gameObject.GetComponent<item>() != null)
                {
                    AddItem(hit.collider.gameObject.GetComponent<item>().itemScriptableObject,
                        hit.collider.gameObject.GetComponent<item>().amount);
                    Destroy(hit.collider.gameObject);
                }
            }
            Debug.DrawRay(ray.origin,ray.direction*reachDistance,Color.green);
        }
        else
        {
                Debug.DrawRay(ray.origin,ray.direction*reachDistance,Color.red);
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
                } 
                break;
            }
        }
        
        foreach (InventorySlot slot in slots)
        {
            if (slot.isEmpty == false)
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






