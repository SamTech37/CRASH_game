using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClownEnemy : FollowerEnemy
{ 
    
    private PlayerMovement player;
   
    new void Awake()
    {
        hitSound = GameObject.Find("Hit").GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.Find("Player").GetComponent<Transform>();
        player = GameObject.Find("Player").GetComponent<PlayerMovement>();
        transform.Rotate(0, 0, Random.Range(0, 180));
        speed = 5f;
    }
    new private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.gameObject.GetComponent<PlayerMovement>())
        {
            //slightly changes player's speed
            player.speed += Random.Range(-0.1f, 0.4f);
            
            Death();
        }

    }
}
