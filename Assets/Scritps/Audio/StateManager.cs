using System.Collections.Generic;
using UnityEngine;

public class StateManager : MonoBehaviour
{
    public struct Item
    {
        public Item(ItemType type, Vector2Int position)
        {
            this.type = type;
            this.position = position;
        }

        public ItemType type;
        public Vector2Int position;

        public override string ToString()
        {
            return $"[{type}, {position}]";
        }
    }

    // Public Members
    [HideInInspector] public static StateManager Instance { get; private set; } = null;

    // Private Members
    private List<Item> items = new();
    private Item lastItem = new();
    
    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
    }

    public void UpdateAudioGrid(ItemType type, Vector2Int position)
    {
        //Debug.Log($"Item {type} has been placed at {position}");

        int i = items.FindIndex(i => i.position == position);

        if (i == -1)
        {
            if (type != ItemType.None)
            {
                items.Add(new Item(type, position));
                lastItem.type = ItemType.None;
            }
        }
        else
        {
            if (type != ItemType.None)
                items[i] = new Item(type, position);
            else
            {
                // Case drag out
                lastItem = items[i];
                items.RemoveAt(i);
            }
        }

        string listLog = "List :";

        foreach (var x in items)
        {
            listLog += " " + (x.ToString()) + ",";
        }

        Debug.Log(listLog);
    }

    public void AddLastItem()
    {
        if( lastItem.type != ItemType.None)
        {
            UpdateAudioGrid(lastItem.type, lastItem.position);
            lastItem.type = ItemType.None;
        }
    }

    public List<Item> GetItems() => items;
}
