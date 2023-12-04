using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class PlaceableItemSlot : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        if (transform.childCount != 0)
        {
            Destroy(transform.GetChild(0).gameObject);
        }

        GameObject dropped = eventData.pointerDrag;
        PlaceableItem item = dropped.GetComponent<PlaceableItem>();

        if (item != null)
        {
            item.ParentAfterDrag = transform;
        }
    }
}
