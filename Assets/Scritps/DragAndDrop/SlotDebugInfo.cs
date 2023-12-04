using UnityEngine;

public class SlotDebugInfo : MonoBehaviour, INotifiableSlot
{
    public void OnItemDraggedOut(GameObject item)
    {
    }

    public void OnItemDraggedIn(GameObject item)
    {
        string name = gameObject.name;

        string position = GetComponent<SlotCoordinate>()?.Position.ToString() ?? "Unknown";
        Debug.Log($"slot {name} at position {position} has now {item.name} as a child");
    }

}
