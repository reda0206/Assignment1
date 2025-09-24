using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWalkerScript : MonoBehaviour
{
    public float speed = 3f;

    public Transform floorCheck;

    public Transform wallCheck;

    public LayerMask floorLayers;

    public LayerMask wallLayers;

    public bool isStunned = false;

    public float stunDuration = 2f;

    private float stunTimer = 0f;


    public void Update()
    {
       if (isStunned)
        {
            stunTimer -= Time.deltaTime;

            if (stunTimer <= 0f)
            {
                isStunned = false;
            }
            return;
        }

        transform.Translate(Vector2.right * speed * Time.deltaTime);

        RaycastHit2D floorhit = Physics2D.Raycast(floorCheck.position, Vector2.down, 0.1f, floorLayers);

        if (!floorhit.collider)
        {
            Flip();
        }

        RaycastHit2D wallhit = Physics2D.Raycast(wallCheck.position, Vector2.right, 0.1f, wallLayers);

        if (wallhit.collider)
        {
            Flip();
        }
    }


    void Flip()
    {
        Vector3 localScalePlaceholder = transform.localScale;

        localScalePlaceholder.x *= -1;

        transform.localScale = localScalePlaceholder;

        speed *= -1;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerMoveScript>().TakeDamage(1);
        }
    }

    public void Stun()
    {
        isStunned = true;
        stunTimer = stunDuration;
    }

    
}