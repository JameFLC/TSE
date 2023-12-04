using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemDispenser : MonoBehaviour, IDropHandler, INotifiableSlot
{
    // Parameters 

    [SerializeField]
    private GameObject ItemToDispense;


    // Start is called before the first frame update
    void Start()
    {
        InstantiateItem();
    }

    public void OnDrop(PointerEventData eventData)
    {
        Destroy(eventData.pointerDrag);
    }

    public void OnItemDraggedOut(GameObject item)
    {
        InstantiateItem();
    }
    
    public void OnItemDraggedIn(GameObject item)
    {
        if (item.transform.parent == transform)
            Destroy(item);
    }

    private void InstantiateItem()
    {

        if (ItemToDispense != null)
        {
            Instantiate(ItemToDispense, transform);
        }
    }
}
