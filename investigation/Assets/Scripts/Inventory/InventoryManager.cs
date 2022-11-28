using System.Collections;
using System.Collections.Generic;
using UnityEditor.U2D;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;
    public List<InventoryItemData> Items = new List<InventoryItemData>();

    public Transform ItemContent;
    public GameObject InventoryItem;

    private void Awake()
    {
        Instance = this;
    }

    public void Add(InventoryItemData item)
    {
        if (Items.Contains(item))
        {
            return;
        }
        Items.Add(item);
        ListItems();
    }

    public void Remove(InventoryItemData item)
    {
        Items.Remove(item);
    }

    public void ListItems()
    {
        foreach (Transform item in ItemContent)
        {
            Destroy(item.gameObject);
        }
        foreach (var item in Items)
        {
            GameObject obj = Instantiate(InventoryItem, ItemContent);
            Image image = obj.GetComponent<Image>();
            image.sprite = item.icon;
        }
    }
}
