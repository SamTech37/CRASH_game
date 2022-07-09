using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawbladeEnemy : FollowerEnemy
{  
    
    public AudioSource explosionSound;

    public PlayerMovement player;
    new private void Awake()
    {   
        speed = 30f;
        explosionSound = GameObject.Find("Explosion").GetComponent<AudioSource>();
        hitSound = GameObject.Find("Hit").GetComponent<AudioSource>();
        target = GameObject.Find("Player").GetComponent<Transform>();
        player = GameObject.Find("Player").GetComponent<PlayerMovement>();

        rb = GetComponent<Rigidbody2D>();
        Vector2 direction = target.position - transform.position;
        rb.velocity = direction.normalized * speed;

    }
    
    new private void FixedUpdate()
    {
        transform.Rotate(0, 0, 5f);//sawblade rotates
    }
    new private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.gameObject.GetComponent<PlayerMovement>())
        {
            player.hp-=50f;
            hitSound.pitch = Random.Range(1.6f, 2f);
            hitSound.Play();
        }
    }
    void OnBecameInvisible(){
        Destroy(gameObject,0.5f);
        Instantiate(effect, transform.position, Quaternion.identity);
        Instantiate(juice, transform.position, Quaternion.identity);
        explosionSound.Play();
    }
}
