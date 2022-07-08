using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeEnemy : MonoBehaviour
{
    public PlayerMovement player;
    void Awake()
    {
        player = GameObject.Find("Player").GetComponent<PlayerMovement>();
        transform.Rotate(0, 0, Random.Range(0, 180));
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.gameObject.GetComponent<PlayerMovement>())
        {
            player.Gameover(); //game is over when hitting spikes
        }
    }
}
