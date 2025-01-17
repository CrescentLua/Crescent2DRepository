﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider : Enemy
{
  
    // Start is called before the first frame update
    void Start()
    {
        speed = 6.0f;
        health = 125.0f;
        initialHealth = 125.0f;
        initialPos.x = gameObject.transform.position.x;
        initialPos.y = gameObject.transform.position.y;

        StartEnemyScript();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateEnemyScript();

        if (health <= 0.0f)
        {
            Destroy(gameObject);
        }
    }
}
