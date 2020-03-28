using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyController : MonoBehaviour
{



    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<Movement>() != null)
        {

            Movement movement = collision.gameObject.GetComponent<Movement>();
            movement.PickUpKey();
            Destroy(gameObject);
          
        }
    }

   
}
