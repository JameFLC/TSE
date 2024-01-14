using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Serialization;

public class LoopManager : MonoBehaviour
{
    [Serializable]
    struct LoopSelector
    {
        public LoopPlayer ArrowLoop;
        public LoopPlayer CogLoop;
        public LoopPlayer DonutLoop;
        public LoopPlayer DropLoop;
        public LoopPlayer HeartLoop;
        public LoopPlayer StarLoop;
    }

    [SerializeField]
    private LoopSelector MuteLoopsSelection;
    
    [SerializeField] private Transform PlayedLoopsParent;

    [SerializeField] private float FadeInDuration = 1.0f;
    [SerializeField] private float FadeOutDuration = 1.0f;
    [SerializeField] private Ease FadeEase = Ease.InOutSine;
    
    // Private members
    
    private List<Tuple<StateManager.Item, LoopPlayer>> Items = new ();
    

    public void OnItemUpdated(StateManager.Item newItem)
    {
        Debug.Log($"New item {newItem}");
        // if (newItem.type == ItemType.None)
        // {
        //     Debug.Log("Non type");
        // }
        foreach (var item in Items)
        {
            if (item.Item1.position == newItem.position)
            {
                item.Item2.Destroy(FadeOutDuration, FadeEase);
                Items.Remove(item);
                break;
            }
        }

        if (newItem.type != ItemType.None)
        {
            switch (newItem.type)
            {
                case ItemType.Arrow:
                    CreateNewPlayer(newItem, MuteLoopsSelection.ArrowLoop);
                    break;
                case ItemType.Cog:
                    CreateNewPlayer(newItem, MuteLoopsSelection.CogLoop);
                    break;
                case ItemType.Donut:
                    CreateNewPlayer(newItem, MuteLoopsSelection.DonutLoop);
                    break;
                case ItemType.Drop:
                    CreateNewPlayer(newItem, MuteLoopsSelection.DropLoop);
                    break;
                case ItemType.Heart:
                    CreateNewPlayer(newItem, MuteLoopsSelection.HeartLoop);
                    break;
                case ItemType.Star:
                    CreateNewPlayer(newItem, MuteLoopsSelection.StarLoop);
                    break;
                case ItemType.None:
                default:
                    break;
            }
        }
    }

    private void CreateNewPlayer(StateManager.Item item,LoopPlayer player)
    {
        GameObject newPlayerObject = Instantiate(player.gameObject);
        LoopPlayer newLoop = newPlayerObject.GetComponent<LoopPlayer>();
        
        Items.Add(new(item, newLoop));
        
        newPlayerObject.transform.parent = PlayedLoopsParent;
        
        newLoop.Setup(player.audioSource.time, FadeInDuration, 1, FadeEase );
    }
}

