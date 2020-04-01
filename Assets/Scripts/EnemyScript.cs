using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyScript : MonoBehaviour
{

    public float movespeed;
    //private float waitTime = 1.0f;
    //private float timer = 0.0f;



    


    private Vector3 scaleValue;

    private Vector3 userDirection = Vector3.right;
    private Vector3 oppositeDirection = Vector3.left;


    

    // Start is called before the first frame update
    void Start()
    {
        //enemyAnim = GetComponent<Animator>();

        //Get current scale value of the character
        scaleValue = transform.localScale;
        Debug.Log("Enemy scale :" + scaleValue);
         
    }



    // Update is called once per frame
    void Update()
    {

       movementEnemy();

        
    }

    private void movementEnemy()
    {
        if(scaleValue.x < 0)
        {
            transform.Translate(oppositeDirection * movespeed * Time.deltaTime);
        }
        else
        {
            transform.Translate(userDirection * movespeed * Time.deltaTime);
        }

       
            
        

    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.GetComponent<Movement>() != null)
        {
            Debug.Log("Enemy collided with the player");
            Levelloader.reloadLevel();
        }

        else if (collision.gameObject.CompareTag("FlipTrigger"))
        {
            Debug.Log("Chomper collided with wall");
            scaleValue = new Vector3(scaleValue.x * -1f, scaleValue.y, scaleValue.z);
            transform.localScale = scaleValue;
            
            
        }

    }


}
