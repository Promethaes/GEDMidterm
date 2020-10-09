using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAudio : MonoBehaviour
{
    public AudioSource source;
    public bool loop = false;
    public bool playOnAwake = true;

    // Start is called before the first frame update
    void Start()
    {
        if (playOnAwake)
            Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Play()
    {
        source.loop = loop;
        source.PlayOneShot(source.clip);
    }
}
