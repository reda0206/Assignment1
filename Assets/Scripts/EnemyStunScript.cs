using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStunScript : MonoBehaviour
{
    public Transform EnemyStun;

    public AudioClip stunSound;

    private void OnTriggerEnter2D(Collider2D collision)
   {
       if (collision.gameObject.CompareTag("Player"))
       {
            gameObject.GetComponent<EnemyWalkerScript>().Stun();
            AudioSource.PlayClipAtPoint(stunSound, transform.position, 1f);
            collision.gameObject.GetComponent<PlayerMoveScript>().Bounce();
        }
    }
}
