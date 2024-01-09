using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;


public class PlaceableItemSlot : MonoBehaviour, IDropHandler, INotifiableSlot
{
    public void OnDrop(PointerEventData eventData)
    {
        if (transform.childCount != 0)
        {
            Destroy(transform.GetChild(0).gameObject);
        }

        GameObject dropped = eventData.pointerDrag;

        // Data checks

        PlaceableItem placeableItem = dropped.GetComponent<PlaceableItem>();
        if (placeableItem == null)
            return;

        placeableItem.NextParent = transform;

        AudioItem audioItem = dropped.GetComponent<AudioItem>();
        if (audioItem == null)
            return;

        NotifyAudioManager(audioItem.GetData().ItemType);

        //Debug.Log($"New placeableItem placed at {GetComponent<SlotCoordinate>().Position}");
    }

    private void NotifyAudioManager(ItemType itemType)
    {
        SlotCoordinate slotCoordinate = GetComponent<SlotCoordinate>();
        if (slotCoordinate == null)
            return;


        StateManager manager = StateManager.Instance;
        if (manager == null)
        {
            Debug.LogWarning("Audio manager missing in scene");
            return;
        }

        manager.UpdateAudioGrid(itemType, slotCoordinate.Position);
    }

    public void OnItemDraggedOut(GameObject item)
    {
        //Debug.Log("Item Dragged Out");

        NotifyAudioManager(ItemType.None);

    }

    public void OnItemDraggedIn(GameObject item)
    {
        //Debug.Log("Item Dragged In");
        
    }
}
