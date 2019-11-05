using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformLeftRight : MonoBehaviour
{

    Rigidbody2D platform;

    Vector2 direction = new Vector2(-1, 0);

    [SerializeField]
    float speed = 3;
    


    // Start is called before the first frame update
    void Start()
    {
        platform = GetComponent<Rigidbody2D>();
        if (platform != null)
        {
            Debug.Log("platform founded!");
        }
        else
        {
            Debug.Log("No platform");
        }
    }

    void FixedUpdate()
    {

        platform.velocity = direction * speed;
    }
    // Update is called once per frame
    void Update()
    {
        if (transform.position.x > 1.5)
        {
            direction.x = -1;
        }
        else if (transform.position.x < -1.5)
        {
            direction.x = 1;
        }
        //direction = new Vector2 1 * speed, platform.velocity.y);
    }
}
