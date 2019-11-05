using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformRotation : MonoBehaviour
{
    GameObject wood;
    Rigidbody2D platform;

    //Vector2 direction = new Vector2(1, 0);

    [SerializeField]
    float speed = 100;

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

    }
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, 0, speed * Time.deltaTime));
        //transform.rotation = wood.transform.rotation;
    }
}
