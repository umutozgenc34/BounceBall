using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    Rigidbody2D rb;
    SpriteRenderer spriteRenderer;

    [SerializeField] private float bounceForce;
    [SerializeField] private float maxSpeed = 10f;
    [SerializeField] private PanelController panelController;
    [SerializeField] private GameObject paddle;

    [SerializeField] private AudioSource source1;
    [SerializeField] private AudioSource source2;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        EndGameManager.endManager.gameOver = false;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Paddle"))
        {
            StartBounce();
            source1.Play();
            ChangeColorRandomly();
        }
        if (collision.gameObject.CompareTag("LoseCheck"))
        {
            gameObject.SetActive(false);
            panelController.HideTimerText();
            EndGameManager.endManager.gameOver = true;
            EndGameManager.endManager.StartResolveSequence();
            paddle.gameObject.SetActive(false);
        }
        if (collision.gameObject.CompareTag("Box"))
        {
            source2.Play();
            ChangeColorRandomly();
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

    void ChangeColorRandomly()
    {
        Color randomColor = new Color(Random.value, Random.value, Random.value);
        spriteRenderer.color = randomColor;
    }
}
