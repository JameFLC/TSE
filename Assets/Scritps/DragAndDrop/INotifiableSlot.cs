using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface INotifiableSlot 
{
    public abstract void OnItemDragedOut(GameObject item);

    public abstract void OnItemDraggedIn(GameObject item);
}
