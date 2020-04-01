using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;


public class SoundManager : MonoBehaviour
{


    private static SoundManager _instance;

    public static SoundManager Instance { get { return _instance; } }

    private Scene activeScene;

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
        activeScene = SceneManager.GetActiveScene();
        switchAudio();
      
    }

    public void switchAudio()
    {
        // If level1 with build index 1 is playing Clip1 from array should play.
        if (activeScene.buildIndex == 1)
        {
            Debug.Log("Level music playing");
            audio = GetComponent<AudioSource>();
            audio.clip = clips[1];
            audio.Play();
        }

        else
        {
            Debug.Log("Main Menu music playing");
            audio = GetComponent<AudioSource>();
            audio.clip = clips[0];
            audio.Play();
        }
    }

}

   

