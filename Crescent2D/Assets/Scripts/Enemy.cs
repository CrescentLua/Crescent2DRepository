﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* LIST OF ENEMIES, ENEMY NAMES, AND LEVEL ASSOCIATION */
/*   {                               }   */

abstract public class Enemy : MonoBehaviour
{

    public GameObject Player;

    Rigidbody2D rb;
    Animator anim; 

    float speed;
    float health;
    float distance;
    float followRange;

    bool isFacingRight;
    bool EnemyFlipped;
    bool EnemyAttacking; 

   public void StartEnemyScript()
    {
        distance = 0.0f;
        followRange = 25.0f;
        isFacingRight = true;
        EnemyFlipped = false;
        EnemyAttacking = false; 

        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        if (gameObject.tag == "Enemy19")
        {
            speed = 5.0f;
            health = 100.0f; 
        }

       else if (gameObject.tag == "Enemy5")
        {
            speed = 25.0f;
            health = 85.0f;
        }
    }

   public void UpdateEnemyScript()
    {
        distance =  gameObject.transform.position.x - Player.transform.position.x;
        Debug.Log(distance);

        if (distance > 0.0f && isFacingRight == true)
        {
            isFacingRight = false;
            FlipEnemy();
        }

        else if (distance < 0.0f && isFacingRight == false)
        {
            isFacingRight = true;
            FlipEnemy();
        }

        if (!Player)
        {
            Debug.Log("There is no player set!");
        }

        else if (Player && gameObject.tag == "Enemy19" && distance < followRange)
        {
            gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, Player.transform.position, 1.0f * speed * Time.deltaTime);
            anim.SetBool("Walk", true);
        }

        else
        {
            anim.SetBool("Walk", false);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            EnemyAttacking = true; 
            StartCoroutine(GroundAttack());
        }
    }

    void FlyingAttack()
    {

    }

    void FlipEnemy ()
    {
        // Keep a copy of 'localScale' because scale cannot be changed directly
        Vector3 scaleFactor = transform.localScale;

        // Change sign of scale in 'x'
        scaleFactor.x *= -1; // or - -scaleFactor.x

        // Assign updated value back to 'localScale'
        gameObject.transform.localScale = scaleFactor;
    }


    IEnumerator GroundAttack()
    {
        if (EnemyAttacking == true)
        {
            anim.SetBool("Attack", EnemyAttacking);
        }

        yield return new WaitForSeconds(2.0f);
        EnemyAttacking = false;
        anim.SetBool("Attack", EnemyAttacking);
    }
}


