using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] private float bounceForce;
    [SerializeField] private float maxSpeed = 10f; 

    
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Paddle"))
        {
            StartBounce();
        }
    }

    void StartBounce()
    {
        Vector2 randomDirection = new Vector2(Random.Range(-2, 2), 1);
        rb.AddForce(randomDirection * bounceForce, ForceMode2D.Impulse);
        ClampSpeed(); 
    }

    void ClampSpeed()
    {
        
        rb.velocity = rb.velocity.normalized * Mathf.Min(rb.velocity.magnitude, maxSpeed);
    }
}
