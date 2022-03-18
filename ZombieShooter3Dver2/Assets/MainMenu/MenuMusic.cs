using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuMusic : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip menuMusic;

    // Start is called before the first frame update
    void Start()
    {
        audioSource.clip = menuMusic;
        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
