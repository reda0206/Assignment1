using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerMoveScript : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 10f;
    public float health = 3f;
    public TextMeshProUGUI healthText;
    public float damageCooldown = 1.5f;
    private float lastDamageTime = -Mathf.Infinity;
    public bool isGrounded;
    public Transform floorCheck;
    public LayerMask floorLayers;

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        healthText.text = "Health: " + health + "/3";
    }

    public void Update()
    {
        isGrounded = Physics2D.OverlapCircle(floorCheck.position, 0.5f, floorLayers);
    }


    private void FixedUpdate()
    {
        float moveInput = Input.GetAxis("Horizontal");

        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

        if (Input.GetAxis("Jump") > 0 && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }

    public void TakeDamage(int damageValue)
    {
        if (Time.time - lastDamageTime >= damageCooldown)
        {
            lastDamageTime = Time.time;


            health -= damageValue;
            healthText.text = "Health: " + health + "/3";
            Debug.Log("Player Health: " + health);


            if (health <= 0)
            {
                Debug.Log("Game Over");
                SceneManager.LoadScene("GameOverScene");
            }
        }
    }
    public void Bounce()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    }
}

