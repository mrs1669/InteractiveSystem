using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSourceScript : MonoBehaviour
{
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = this.gameObject.GetComponent<AudioSource>();
        audioSource.clip = Resources.Load("Astronomia") as AudioClip;
        Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Play()
    {
        audioSource.Play();
    }
}
