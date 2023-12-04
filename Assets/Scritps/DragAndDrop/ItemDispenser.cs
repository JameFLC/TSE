using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemDispenser : MonoBehaviour, IDropHandler, INotifiableSlot
{
    #region Paremereter

    [SerializeField]
    private GameObject ItemToDispense;

    #endregion

    // Start is called before the first frame update
    void Start()
    {
        InstantiateItem();
    }

    public void OnDrop(PointerEventData eventData)
    {
        GameObject droppedItem = eventData.pointerDrag;
        Destroy(droppedItem);
    }

    void INotifiableSlot.OnItemDragedOut(GameObject item)
    {
        InstantiateItem();
    }

    private void InstantiateItem()
    {

        if (ItemToDispense != null)
        {
            Instantiate(ItemToDispense,transform);
        }
    }

    public void OnItemDraggedIn(GameObject item)
    {
        if (item.transform.parent == transform)
            Destroy(item);
    }
}
