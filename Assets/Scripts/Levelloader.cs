﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Levelloader : MonoBehaviour
{
   
    private Button button;

    //private GameoverController gameOverUI;

    public string levelName;

    public AudioSource buttonAudio;
    public AudioClip pressSound;


    public static Scene currentLevel;


    private void Awake()
        {

        currentLevel = SceneManager.GetActiveScene();

        button = GetComponent<Button>();
        button.onClick.AddListener(OnClick);
        

        //Call audio source.
        buttonAudio = gameObject.GetComponent<AudioSource>();

        }

 

    private void OnClick()
        {
        LevelStatus levelStatus = Levelmanager.Instance.GetLevelStatus(levelName);
        switch (levelStatus)
        {
            case LevelStatus.Locked:
                Debug.Log("Level is locked");
                break;
            case LevelStatus.Unlocked:
                SceneManager.LoadScene(levelName);
                break;
            case LevelStatus.Completed:
                SceneManager.LoadScene(levelName);
                break;
        }
        SceneManager.LoadScene(levelName);

       
        
        }


    public static void reloadLevel()
    {

        SceneManager.LoadScene(currentLevel.buildIndex);
    }

    //OnPress
    public void clickSound()
    {
        buttonAudio.PlayOneShot(pressSound);
    }

}
