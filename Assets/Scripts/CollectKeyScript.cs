using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectKeyScript : MonoBehaviour
{
    public Transform Key;

    public AudioClip keyCollectSound;
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameManager.instance.CollectKey();
            AudioSource.PlayClipAtPoint(keyCollectSound, transform.position, 1f);
            Destroy(Key.gameObject);
            Destroy(gameObject);
        }
    }
}
