using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class AudioManager : MonoBehaviour
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
    [HideInInspector] public static AudioManager Instance { get; private set; } = null;

    // Private Members
    private List<Item> items = new();

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
            items.Add(new Item(type, position));
        }
        else
        {
            if (type != ItemType.None)
                items[i] = new Item(type, position);
            else
                items.RemoveAt(i);
        }

        string baba = "List :";

        foreach (var x in items)
        {
            baba += " " + (x.ToString()) + ",";
        }

        Debug.Log(baba);
    }

    IEnumerator baba()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);

        }
    }
}
