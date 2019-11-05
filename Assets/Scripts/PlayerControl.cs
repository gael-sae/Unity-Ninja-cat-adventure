using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    [SerializeField]
    LayerMask layerMask = default;
 
    Rigidbody2D body;
    BoxCollider2D boxCollider2d;
    PlayerHealth playerHealth;
    Health health;

    Vector2 direction;

    [SerializeField]
    float speed = 3;

    [SerializeField]
    float jumpVelocity = 20f;

    bool facingRight;

    // Start is called before the first frame update
    void Start()
    {
        facingRight = true;
        body = GetComponent<Rigidbody2D>();
        if (body != null)
        {
            Debug.Log("Body founded!");
        }
        else
        {
            Debug.Log("No Body");
        }

        playerHealth = GetComponent<PlayerHealth>();
    }
    /* private void Awake()
     {
         body = gameObject.GetComponent<PlayerControl>();
     }*/

    void Awake()
    { 
        body = transform.GetComponent<Rigidbody2D>();
        boxCollider2d = transform.GetComponent<BoxCollider2D>();
    }
    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal"); 
         body.velocity = direction;
        Flip(horizontal);
    }
    // Update is called once per frame


    void Update()
    {
       //direction = new Vector2(Input.GetAxis("Horizontal"), 0) * speed;
        /**/
        if (IsGrounded() && Input.GetAxis("Jump") > 0.1f)
        {   

            body.velocity = Vector2.up * jumpVelocity;
        }


        bool IsGrounded()
        {
            RaycastHit2D raycastHit2d = Physics2D.BoxCast(boxCollider2d.bounds.center, boxCollider2d.bounds.size, 0f, Vector2.down, 0.1f, layerMask);
            Debug.Log(raycastHit2d.collider);
            return raycastHit2d.collider != null;
        }

        /*if (Input.GetKeyDown(KeyCode.A))
        {
            flip
        }*/

        direction = new Vector2(Input.GetAxis("Horizontal") * speed, body.velocity.y);

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            
        }

        /* if (body.position.y >= -4)
        {
            
            transform.localPosition=body;
            
        }*/
        /* bool setSpikeDynamic = false;
         if (body.position.x >= -5)
         {
             setSpikeDynamic = true;
         }*/

        /*  if (Input.GetKey(KeyCode.LeftArrow))
          {
              body.velocity = new Vector2(-speed, body.velocity.y);
          }
          else
          {
              if (Input.GetKey(KeyCode.RightArrow))
              {
                  body.velocity = new Vector2(+speed, body.velocity.y);
              }
              else
              {
                  body.velocity = new Vector2(0, body.velocity.y);
              }

          }*/
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Win")
        {
            Debug.Log("WIN");
            Destroy(gameObject);
        }
    }

    void Flip(float horizontal)
    {
        if (horizontal > 0 && !facingRight || horizontal < 0 && facingRight)
        {
            facingRight = !facingRight;
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
        }
    }
}
