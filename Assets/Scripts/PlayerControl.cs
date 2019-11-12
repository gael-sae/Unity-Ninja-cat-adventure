using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    [SerializeField]
    LayerMask layerMask = default;
 
    public Rigidbody2D body;
    BoxCollider2D boxCollider2d;
    PlayerHealth playerHealth;
    Health health;

    Vector2 direction;
    [SerializeField]
    Vector2 wallHopDirection;
    [SerializeField]
    Vector2 wallJumpDirection;

    [SerializeField]
    float speed = 3f;

    [SerializeField]
    float jumpVelocity = 6f;
    [SerializeField]
    float wallHopForce = 6f;
    [SerializeField]
    float wallJumpForce = 10f;

    bool facingRight;
    bool isWall = false;

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
        wallHopDirection.Normalize();
        wallJumpDirection.Normalize();
    }
    void Awake()
    { 
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
        if (IsGrounded() && Input.GetAxis("Jump") > 0.1f)
        {
                body.velocity = Vector2.up * jumpVelocity;
        }
        if (isWall && !IsGrounded())
        {
            if (facingRight)
            {
                body.velocity = Vector2.left * wallJumpDirection.x * wallHopDirection.y * wallHopForce;
            }
            if (!facingRight)
            {
                body.velocity = Vector2.right * wallHopDirection.x * wallJumpDirection.y * wallHopForce;
            }
            //Vector2 forcetoAdd = new Vector2(wallHopForce * wallJumpDirection.x, wallHopForce * wallHopDirection.y);
        }

        direction = new Vector2(Input.GetAxis("Horizontal") * speed, body.velocity.y);
    }
    bool IsGrounded()
    {
        RaycastHit2D raycastHit2d = Physics2D.BoxCast(boxCollider2d.bounds.center, boxCollider2d.bounds.size, 0f, Vector2.down, 0.1f, layerMask);
        Debug.Log(raycastHit2d.collider);
        return raycastHit2d.collider != null;
    }
        void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Win")
        {
            Debug.Log("WIN");
            Destroy(gameObject); // S'enfuit avec l'objet "win"
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "Wall")
        {
            isWall = true;
            Debug.Log("Wall");
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            body.velocity = Vector2.up * wallHopDirection.x * wallJumpDirection.y * wallJumpForce;
            isWall = false;
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
