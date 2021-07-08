using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Levelcomplete : MonoBehaviour
{


    public GameoverController gameoverController;


    //Collision detect wiith the statue.
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Movement>() != null)
        {
            // UI display activated and restart button should be activated.

            gameoverController.UI.SetActive(true);
            //Time.timeScale = 0f;
            Levelmanager.Instance.MarkCurrentLevelCompleted();
                

        }
     }


    
}
