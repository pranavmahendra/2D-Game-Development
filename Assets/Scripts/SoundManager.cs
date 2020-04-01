using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio; 


public class SoundManager : MonoBehaviour
{


    private static SoundManager _instance;

    public static SoundManager Instance { get { return _instance; } }

    public  AudioSource audio;

    public  AudioClip[] clips;

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        audio = GetComponent<AudioSource>();
        audio.clip = clips[0];
        audio.Play();
        
        
    }

    

}

