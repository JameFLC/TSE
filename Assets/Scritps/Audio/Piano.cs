using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Piano : MonoBehaviour
{
    [SerializeField]
    private List<AudioClip> notes;

    [SerializeField]
    private float Delay = 1.0f;

    private AudioSource audio;

    private int index = 0;
    private void Start()
    {
        audio = GetComponent<AudioSource>();
        StartCoroutine(Tick());
    }

    IEnumerator Tick()
    {
        while (true)
        {
            yield return new WaitForSeconds(Delay);
            // Debug.Log("Tick");
            playSound();
        }
    }

    void playSound()
    {
        if (Input.GetKey("a")) index = 0; 
        if (Input.GetKey("w")) index = 1; 
        if (Input.GetKey("s")) index = 2; 
        if (Input.GetKey("e")) index = 3; 
        if (Input.GetKey("d")) index = 4; 
        if (Input.GetKey("f")) index = 5; 
        if (Input.GetKey("t")) index = 6; 
        if (Input.GetKey("g")) index = 7; 
        if (Input.GetKey("y")) index = 8; 
        if (Input.GetKey("h")) index = 9; 
        if (Input.GetKey("u")) index = 10;
        if (Input.GetKey("j")) index = 11;

        if (true)
        {
            // Debug.Log("sound");
            // if some key pressed...
            //audio.pitch = 1 + Mathf.Pow(2, (float)index/12.0f);

            audio.PlayOneShot(notes[index]);
        }
    }
}
