 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class ScoreController : MonoBehaviour
{


    private TextMeshProUGUI scoreCard;

    public GameObject key;

    
    private int score = 0;

    private void Awake()
    {
        scoreCard = GetComponent<TextMeshProUGUI>();
   
    }

    private void Start()
    {
        
    }

    private void Update()
    {

        refreshUI();
        
    }



    public void incrementScore(int increment)
    {
        score += increment;
        refreshUI();
    }


    private void refreshUI()
    {

        scoreCard.text = ("Score: " + score);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<Movement>() != null)
        {
            Destroy(key);
        }
    }

}


