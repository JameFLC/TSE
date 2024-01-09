using UnityEngine;


[CreateAssetMenu(menuName = "AudioItemData")]
public partial class AudioItemData : ScriptableObject
{
    public Sprite ItemSprite;

    public ItemType ItemType = ItemType.None;
}
