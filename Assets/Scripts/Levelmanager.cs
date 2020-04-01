using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Levelmanager : MonoBehaviour
{
    private static Levelmanager instance;

    //Property
    public static Levelmanager Instance { get { return instance;  } }

   

    public string[] levels;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);

        }
    }

    private void Start()
    {
       if (GetLevelStatus(levels[0]) == LevelStatus.Locked)
        {
            SetLevelStatus(levels[0], LevelStatus.Unlocked);
        }
    }

    public void MarkCurrentLevelCompleted()
    {
        Scene currentscene = SceneManager.GetActiveScene();
        //Set level status to complete.
        
        SetLevelStatus(currentscene.name, LevelStatus.Completed);

        //Unlock the next level.
        //int nextSceneIndex = currentscene.buildIndex + 1;
        //Scene nextScene = SceneManager.GetSceneAt(nextSceneIndex);
        //Levelmanager.instance.SetLevelStatus(nextScene.name, LevelStatus.Unlocked);


        int currentSceneIndex = Array.FindIndex(levels, level => level == currentscene.name);
        int nextSceneIndex = currentSceneIndex + 1;
        if(nextSceneIndex < levels.Length)
        {
            SetLevelStatus(levels[nextSceneIndex], LevelStatus.Unlocked);
        }



    }
    
    public LevelStatus GetLevelStatus(string level)
    {
        LevelStatus levelStatus = (LevelStatus)PlayerPrefs.GetInt(level, 0);
        return levelStatus;
    }

    public void SetLevelStatus(string level, LevelStatus levelStatus)
    {
        //Playerprefs is a function from unity to save data. We have converted
        //Level status enum into integer.
        PlayerPrefs.SetInt(level, (int)levelStatus);
        Debug.Log("Setting Level: " + level + " Status: " + levelStatus);
    }


}
