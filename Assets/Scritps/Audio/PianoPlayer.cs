using System;
using System.Collections;
using System.Collections.Generic;
using System.Security;
using UnityEngine;

[Obsolete]
public class PianoPlayer : MonoBehaviour
{
    // Parameters
    [SerializeField] private float Delay = 0.5f;

    [SerializeField]
    private List<AudioClip> notes;
    
    
    [SerializeField] private SlotCoordinateManager slotCoordinateManager;
    // Private members
    private List<StateManager.Item> items = new();

    private int numberOfColumns = 0;
    private int currentColumn = 0;
    
    private AudioSource audio;
    
    // Start is called before the first frame update
    void Start()
    {
        numberOfColumns = slotCoordinateManager.NumberOfCollumns;
        slotCoordinateManager = null;
        
        audio = GetComponent<AudioSource>();

        if (audio is null)
        {
            Debug.LogError("Missing Audio Source");
            return;
        }
        
        StartCoroutine(Loop());
    }
    

     IEnumerator Loop()
     {
         while (true)
         {
            yield return new WaitForSeconds(Delay);
            PlayColumn(currentColumn);
            currentColumn = (currentColumn + 1) % numberOfColumns;
         }
     }


     private void PlayColumn(int column)
     {
         string output = "";
         foreach (var item in items)
         {
             int note = notes.Count - 1 - item.position.y;
             
             Debug.Log($"note {note} was played");
             if (item.position.x == column && note >= 0)
             {
                 audio.PlayOneShot(notes[note]);
             }
         }
         
     }
     
    public void UpdateItems(List<StateManager.Item> newItems)
    {
        items = newItems;
        
        Debug.Log("List Updated");
    }
}
