using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowerEnemy : MonoBehaviour
{
    public GameObject effect;
    public GameObject juice;
    public AudioSource hitSound;
    public Transform target;//to get the position of player
    public Rigidbody2D rb;

    protected float speed;
    protected void Awake()
    {
        hitSound = GameObject.Find("Hit").GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.Find("Player").GetComponent<Transform>();
        transform.Rotate(0, 0, Random.Range(0, 180));
        speed = Random.Range(5f, 7.5f);
    }
    protected void FixedUpdate()
    {
        //follow the player
        if(target != null)
        {
            Vector2 direction = target.position - transform.position;
            rb.velocity = direction.normalized * speed;
        }
    }

    protected void OnCollisionEnter2D(Collision2D other)
    {
         if (other.collider.gameObject.GetComponent<PlayerMovement>())
         {
            Death();
         }

    }
    protected void Death()
    {
        Instantiate(effect, transform.position, Quaternion.identity);
        Instantiate(juice, transform.position, Quaternion.identity);
        hitSound.pitch = Random.Range(0.8f, 1.6f);
        hitSound.Play();
        Destroy(gameObject);
    }
}
