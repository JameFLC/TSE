using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(GridLayoutGroup))]
public class SlotCoordinateManager : MonoBehaviour
{
    [SerializeField] private int NumberOfCollumns = 8;

    // Start is called before the first frame update
    void Start()
    {
        GridLayout grid = GetComponent<GridLayout>();

        SetupSlotCoordinates();

    }

    private void SetupSlotCoordinates()
    {
        List<SlotCoordinate> slotsCoordinates = GetComponentsInChildren<SlotCoordinate>().ToList();
        
        int slotIndex = 0;
        foreach (SlotCoordinate slotCoordinate in slotsCoordinates)
        {
            slotCoordinate.Position = new(slotIndex % NumberOfCollumns, slotIndex / NumberOfCollumns);
            slotIndex++;
        }
    }

    
}
