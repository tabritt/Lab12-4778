using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public List<InventoryItem> items = new List<InventoryItem>();

    void Start()
    {
        items.Add(new InventoryItem(1, "Sword", 100)); // item ID, item name, item value
        items.Add(new InventoryItem(2, "Shield", 150));
        items.Add(new InventoryItem(3, "Potion", 75));
        items.Add(new InventoryItem(4, "Helmet", 200));
        items.Add(new InventoryItem(5, "Two-Handed Sword", 300));
        
        InventoryItem foundItem = FindItemByName("Sword");

        if (foundItem != null)
        {
            Debug.Log($"Found item: {foundItem.Name} worth {foundItem.Value}");
        }
    }

   
    void Update()
    {
       
    }

    public InventoryItem FindItemByName(string ItemName)
    {
        foreach (InventoryItem Item in items) // for each item in loop using string from ItemName if same name exist return item!
        {
            if (Item.Name == ItemName)
            {
                 return Item;
            }
     
        }

        Debug.LogWarning($"Item with name {ItemName} not found."); // cue spongebob fail horn audio sound
        return null;
    }
}
