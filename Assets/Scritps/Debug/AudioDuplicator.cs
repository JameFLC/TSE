using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class AudioDuplicator : MonoBehaviour
{
    [SerializeField] GameObject Original;

    [SerializeField] private float Delay;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Duplicate(Delay));
    }

    private IEnumerator Duplicate(float delay)
    {
        yield return new WaitForSeconds(delay);
        AudioSource originalAudio = Original.GetComponent<AudioSource>();
        if (originalAudio is not null)
        {
            var duplicated = Instantiate(Original);
            float originalTime = originalAudio.time;
            duplicated.GetComponent<AudioSource>().time = originalTime;

            yield return new WaitForSeconds(delay/2);
            
        }
            

            originalAudio.volume = 0;
    }
}
