using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{

    public float movespeed;
    private float waitTime = 1.0f;
    private float timer = 0.0f;
   

    private Animator enemyAnim;


    private Vector3 userDirection = Vector3.right;
    private Vector3 switchDirection = Vector3.left;
    

    // Start is called before the first frame update
    void Start()
    {
        enemyAnim = GetComponent<Animator>();

        

    }



    // Update is called once per frame
    void Update()
    {
        movementEnemy();
        

    }

    private void movementEnemy()
    {

            
        transform.Translate(switchDirection * movespeed * Time.deltaTime);

    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.GetComponent<Movement>() != null)
        {
            Movement movement = collision.gameObject.GetComponent<Movement>();
            movement.KillPlayer();
        }
    }


}
