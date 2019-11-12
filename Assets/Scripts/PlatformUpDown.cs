using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformUpDown : MonoBehaviour
{

    Rigidbody2D platform;

    Vector2 direction = new Vector2(0, 1);

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
    private void FixedUpdate()
    {

        platform.velocity = direction * speed;
    }
    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -1.5)
        {
            direction.y = 1;
        }
        else if (transform.position.y > 1.5)
        {
            direction.y = -1;
        }
        //direction = new Vector2 1 * speed, platform.velocity.y);
    }

    // position-player += deltatime.position.platform
}
