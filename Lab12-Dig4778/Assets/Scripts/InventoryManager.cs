using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{ 
    public List<InventoryItem> items = new List<InventoryItem>();
    
    public int itemIdQuery = 0;

    void Start()
    {
        items.Add(new InventoryItem(4, "Sword", 100)); // item ID, item name, item value
        items.Add(new InventoryItem(5, "Shield", 150));
        items.Add(new InventoryItem(2, "Potion", 75));
        items.Add(new InventoryItem(1, "Helmet", 200));
        items.Add(new InventoryItem(3, "Two-Handed Sword", 300));

        InventoryItem foundItem = FindItemByName("Sword");

        if (foundItem != null)
        {
            Debug.Log($"Found item by item name - ID: {foundItem.ID}, Name: {foundItem.Name}, Value: {foundItem.Value}");
        }

        InventoryItem foundById = BinarySearchById(itemIdQuery);

        if (foundById != null)
        {
            Debug.Log($"Found item by ID - ID: {foundById.ID}, Name: {foundById.Name} Value: {foundItem.Value}");
        }
        QuickSortByValue();
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

    public InventoryItem BinarySearchById (int target)
    {

        List<InventoryItem> sortedList = new List<InventoryItem>();
        int listLength = items.Count;
        for (int i = 0; i < listLength; i++)
        {
            sortedList.Add(new InventoryItem(items[i].ID, items[i].Name, items[i].Value));
            int h = i - 1;
            if (i != 0)
            {
                if (items[i].ID > items[h].ID)
                {
                    sortedList[i] = items[i];
                }
                if (items[i].ID < items[h].ID)
                {
                    sortedList[h] = items[i];
                    sortedList[i] = items[h];
                }
            }
            else
            {
                sortedList[i] = items[i];
            }
        }
        foreach (InventoryItem Item in sortedList) // for each item in loop using string from ItemName if same name exist return item!
        {
            if (target == Item.ID)
            {
                return Item;

            }

        }

        Debug.LogWarning($"Item with ID: {target} not found.");
        return null;
    }
    public int partition(int[] array, int first, int last)
    {
        int pivot = array[last];
        int smaller = (first - 1);

        for (int element = first; element < last; element++)
        {
            if (array[element] < pivot)
            {
                element++;

                int temporary = array[smaller];
                array[smaller] = array[element];
                array[element] = temporary;
            }
        }

        int temporaryNext = array[smaller + 1];
        array[smaller + 1] = array[last];
        array[last] = temporaryNext;

        return smaller + 1;

    }

    public void quickSort(int[] array, int first, int last)
    {
        if (first < last)
        {
            int pivot = partition(array, first, last);

            quickSort(array, first, pivot - 1);
            quickSort(array, pivot + 1, last);

        }
    }
    public void QuickSortByValue()
    {
        QuickSortItemsByValue(items, 0, items.Count - 1);
        Debug.Log("Items sorted by Value using QuickSort.");

        foreach (var item in items)
        {
            Debug.Log($"→ {item.Name} (Value: {item.Value})");
        }
    }

    private void QuickSortItemsByValue(List<InventoryItem> list, int low, int high) // sorts by value
    {
        if (low < high) // case for low less than high
        {
            int pivotIndex = PartitionByValue(list, low, high); 
            QuickSortItemsByValue(list, low, pivotIndex - 1);
            QuickSortItemsByValue(list, pivotIndex + 1, high);
        }
    } 

    private int PartitionByValue(List<InventoryItem> list, int low, int high) //
    {
        int pivot = list[high].Value; // the pivot is the value of the item with higher value
        int i = low - 1; // index of smaller element

        for (int j = low; j < high; j++) // a loop to go through the list
        {
            if (list[j].Value < pivot) 
            {
                i++;
                Swap(list, i, j);
            }
        }
        //almost similar to the bubble sort method

        Swap(list, i + 1, high);
        return i + 1;
    }

    private void Swap(List<InventoryItem> list, int indexA, int indexB) // swaps two items in the list
    {
        InventoryItem temp = list[indexA];
        list[indexA] = list[indexB];
        list[indexB] = temp;// swaps two items in the list
    }

}
