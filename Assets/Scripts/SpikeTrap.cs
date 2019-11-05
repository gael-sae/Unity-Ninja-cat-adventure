using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeTrap : MonoBehaviour
{
    Rigidbody2D Spike;
    PlayerControl playerControl;
    [SerializeField]
    LayerMask layerMask;
    BoxCollider2D boxCollider2d;


    Vector2 direction = new Vector2(0, 0);


    // Start is called before the first frame update
    void Start()
    {
        Spike = GetComponent<Rigidbody2D>();
        if (Spike != null)
        {
            Debug.Log("Spike founded!");
        }
        else
        {
            Debug.Log("No platform");
        }
    }
    void FixedUpdate()
    {
      
    }
    // Update is called once per frame
    void Update()
    {
        

        /* if (Spike.transform.position.y > -0.9)
         {
             Spike.velocity = direction * speed;
             direction.y = -1;
         } 
         else
         {
             direction.y = 0;
         }*/

        //direction = new Vector2 1 * speed, platform.velocity.y);
    }
   
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Spike.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        }
    }

    }
