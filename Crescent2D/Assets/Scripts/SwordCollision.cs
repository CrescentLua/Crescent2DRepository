﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordCollision : Character
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject.name);

        if (collision.gameObject.tag == "Parry")
        {
            Destroy(collision.gameObject);
            PowerUpCount++;
            Debug.Log("Powerup is at " + PowerUpCount);
        }
    } 
}