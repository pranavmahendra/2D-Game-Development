using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    public LevelData levelData;

    public Button level1;
    public Button level2;


    private string loadlevel1;
    private string loadlevel2;

    private void Awake()
    {
        //Call the leveldata class.
        levelData = new LevelData();

        loadlevel1 = levelData.levels[0];
        loadlevel2 = levelData.levels[1];


    }

    private void Start()
    {
 

        level1.onClick.AddListener(loadScene1);
        level2.onClick.AddListener(loadScene2);
    }


    private void loadScene1()
    {
        Debug.Log("Loaded scene " + loadlevel1) ;
        SceneManager.LoadScene(loadlevel1);
    }

    private void loadScene2()
    {
        Debug.Log("Loaded scene " + loadlevel2);
        SceneManager.LoadScene(loadlevel2);
    }
}


