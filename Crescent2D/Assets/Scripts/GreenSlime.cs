﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenSlime : Enemy
{
    Animator anim; 
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
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