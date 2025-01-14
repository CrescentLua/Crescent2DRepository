﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingGreenSlime : Enemy
{

	public AudioClip flyingSlimeHitSnd;

    // Start is called before the first frame update
    void Start()
    {
        speed = 10.0f;
        health = 75.0f;
        initialHealth = 75.0f; 
        initialPos.x = gameObject.transform.position.x;
        initialPos.y = gameObject.transform.position.y;

        StartEnemyScript();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateProjectileEnemyScript();

        if (health <= 0.0f)
        {
			AudioManager.instance.alterPitchEffect(flyingSlimeHitSnd, flyingSlimeHitSnd);
            Destroy(gameObject);
        }
    }
}
