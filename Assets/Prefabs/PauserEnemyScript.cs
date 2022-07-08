using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauserEnemyScript : FollowerEnemy
{

    [SerializeField] private GameController pause;
    new void Awake()
    {
        hitSound = GameObject.Find("Hit").GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.Find("Player").GetComponent<Transform>();
        pause = GameObject.Find("GameController").GetComponent<GameController>();
        speed = 7.5f;
    }

    new private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.gameObject.GetComponent<PlayerMovement>())
        {
            if (Random.Range(1, 11) <= 1) pause.PauseGame(); // 10% chance of pausing the game
            Death();
        }

    }
}
