using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStunScript : MonoBehaviour
{
    public Transform EnemyStun;

   private void OnTriggerEnter2D(Collider2D collision)
   {
       if (collision.gameObject.CompareTag("Player"))
       {
            gameObject.GetComponent<EnemyWalkerScript>().Stun();
            collision.gameObject.GetComponent<PlayerMoveScript>().Bounce();
        }
    }
}
