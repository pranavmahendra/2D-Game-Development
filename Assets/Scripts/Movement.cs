using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour
{
    public Animator animator;
    public ScoreController scoreController;

    public Levelloader reference;

    public Levelcomplete levelcomplete;

    public float speed;
    public float jump;

    private Rigidbody2D rb2d;

    private void Awake()
    {
        reference = new Levelloader();

        Debug.Log("Player controller awake.");
        rb2d = gameObject.GetComponent<Rigidbody2D>();
    }


    public void PickUpKey()
    {
        scoreController.incrementScore(10);
    }


    public void KillPlayer()
    {


        reference.reloadLevel();

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<EnemyScript>() == true)
        {
            Debug.Log("Player died chump");
            reference.reloadLevel();
        }
    }



    private void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Jump");
     

        characterMovement(horizontal, vertical);

        //Move to run transition animation.
        moveToRun(horizontal);

        //Melle animation when pressing the mouse fire1 button.
        attackAnimation();

        //Crouch animation.
        crouchAnimation();

        //Jump animation.
        jumpAnimation();



    }

    private void characterMovement(float horizontal, float vertical)
    {
        Vector3 position = transform.position;
        position.x = position.x + horizontal * speed * Time.deltaTime;
        transform.position = position;

        if (vertical > 0)
        {
                rb2d.AddForce(new Vector2(0f, jump), ForceMode2D.Force );
        }

    }



    private void moveToRun(float horizontal)
    {
        animator.SetFloat("speed", Mathf.Abs(horizontal));

        //Mathf.abs will always return positive value.

        Vector3 scale = transform.localScale;
        if (horizontal > 0)
        {
            scale.x = Mathf.Abs(scale.x);
        }
        else if (horizontal < 0)
        {
            scale.x = -1f * Mathf.Abs(scale.x);

        }
        transform.localScale = scale;
    }

    private void attackAnimation()
    {
        bool attack = Input.GetButton("Fire1");
        animator.SetBool("attack", attack);


    }

    private void crouchAnimation()
    {
        bool crouch = Input.GetKey(KeyCode.C);
        animator.SetBool("crouch", crouch);
    }

    private void jumpAnimation()
    {
       float vertical = Input.GetAxisRaw("Jump");
       if (vertical>0)
        {
            animator.SetBool("Jump", true);
            
        }
       else 
        {
            animator.SetBool("Jump", false);
      
        }
    }

}
