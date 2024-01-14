using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine;

public class LoopPlayer : MonoBehaviour
{
    [HideInInspector]
    public AudioSource audioSource;
    
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource is null)
        {
            Debug.LogError($"Object {gameObject.name} does nt have an audio source");
            Destroy(gameObject);
        }

        audioSource.volume = 0;
    }

    public void Setup(float offset, float fadeInTime, float newVolume, Ease ease = Ease.InOutSine)
    {
        audioSource.Stop();
        audioSource.time = offset;
        audioSource.Play();
        UpdateVolume(fadeInTime, newVolume, ease);
    }
    
    public void UpdateVolume(float fadeInTime, float newVolume, Ease ease = Ease.InOutSine)
    {
        audioSource.DOKill();
        audioSource.DOFade(newVolume, fadeInTime).SetEase(ease);
    }

    public void Destroy(float fadeOutDuration, Ease ease = Ease.InOutSine)
    {
        audioSource.DOKill();
        audioSource.DOFade(0, fadeOutDuration).SetEase(ease).OnComplete(() =>
        {
            Debug.Log($"Item {gameObject.name} end destroy");
            audioSource.DOKill();
            Destroy(gameObject);
        });
    }
}
