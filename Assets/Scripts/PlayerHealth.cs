using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

    [SerializeField]
    int maxHealth = 3;

    int currentHealth;
    bool Dead = false;

    public Transform spawnpoint;


    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    void FixedUpdate()
    {
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Dead)
        {
            currentHealth--;
            Debug.Log("la");
        }
        Dead = false;

       /* if (Win)
        {

        }   */
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "OutMap")
        {
            Respawn();
            Dead = true;
            Debug.Log("ici");

        }
    }
   
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Trap")
        {
            Respawn();
            Dead = true;
            Debug.Log("ici");

        }
        
    }
    public void Respawn()
    {
        this.transform.position = spawnpoint.position;
    }
}

    
        
    

