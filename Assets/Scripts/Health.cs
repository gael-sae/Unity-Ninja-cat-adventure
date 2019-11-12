using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{

    public int health;
    public int numOfHealths;

    public Image[] heart;
    public Sprite fullHeart;
    public Sprite emptyHealth;

    PlayerHealth playerHealth;
    PlayerControl playerControl;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (health > numOfHealths)
        {
            health = numOfHealths;
        }
       
        for (int i = 0; i < heart.Length; i++)
        {
            if (i < health)
            {
                heart[i].sprite = fullHeart;
            }
            else
            {
                heart[i].sprite = emptyHealth;
            }
            if (i < numOfHealths)
             {
                heart[i].enabled = true;
             }
             else
            {
                heart[i].enabled = false;
            }
            
        }
    }
}
