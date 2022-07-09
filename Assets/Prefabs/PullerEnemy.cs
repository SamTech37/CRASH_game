using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PullerEnemy : FollowerEnemy
{
    new private void OnCollisionEnter2D(Collision2D other)
    {
         if (other.collider.gameObject.GetComponent<PlayerMovement>())
         {
            Vector2 push = transform.position - target.position  ; //PULL the player
            other.rigidbody.AddForce(push.normalized * 5000f,ForceMode2D.Force);

            Death();
         }

    }
}
