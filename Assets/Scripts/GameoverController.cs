using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class GameoverController : MonoBehaviour
{

    //This script will be attached to UI.

    public Button restartButton;
    public Button lobbyButton;
    public LevelData levelselector;

    public GameObject UI;

    private string lobbyStage;

    public Movement movement;


    private void Awake()
    {
        levelselector = new LevelData();

        UI.SetActive(false);
        

        lobbyStage = levelselector.levels[2];
    }

    private void Start()
    {
        restartButton.onClick.AddListener(reloadLevel);
        lobbyButton.onClick.AddListener(lobbyLevel);
    }

    public void reloadLevel()
    {

        movement.reloadLevel();
    }

    public void lobbyLevel()
    {
        Debug.Log("Going back to lobby");
        SceneManager.LoadScene(lobbyStage);
    }


}
