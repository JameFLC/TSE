using UnityEngine;


[CreateAssetMenu(menuName = "AudioItemData")]
public partial class AudioItemData : ScriptableObject
{
    public Sprite ItemSprite;

    public AudioClip ItemSound;

    public ItemType ItemType = ItemType.None;
}
