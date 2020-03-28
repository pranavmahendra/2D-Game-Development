using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class GameoverController : MonoBehaviour
{

    //This script will be attached to UI.

    public Button restartButton;
    public GameObject UI;

    public Movement movement;


    private void Awake()
    {
        UI.SetActive(false);
        restartButton.onClick.AddListener(reloadLevel);
    }



    public void reloadLevel()
    {

        movement.reloadLevel();
    }



}
