using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioItem : MonoBehaviour
{
    #region Parameters

    [SerializeField] private AudioItemData data;

    #endregion


    // Start is called before the first frame update
    void Start()
    {
        UpdateItemSprite();
    }

    private void OnValidate()
    {
        UpdateItemSprite();
    }

    private void UpdateItemSprite()
    {
        var image = GetComponent<Image>();

        if (image != null && data != null && data.ItemSprite != null)
            image.overrideSprite = data?.ItemSprite;
    }

    public AudioItemData GetData() => data;
}
