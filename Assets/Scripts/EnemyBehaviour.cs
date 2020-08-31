using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public float speed = 1f;
    public float delay = 2f;
    public bool isWalking = true;
    float timeBeforeChange;
    Rigidbody2D enemyRb;
    SpriteRenderer spriteRenderer;
    Animator enemyAnim;
    ParticleSystem enemyParticle;
    AudioSource enemyAudio;


    void Start()
    {
        enemyRb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        enemyAnim = GetComponent<Animator>();
        enemyParticle = GameObject.Find("EnemyParticle")
            .GetComponent<ParticleSystem>();

        enemyAudio = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (isWalking)
            Walk();
    }

    void Walk()
    {
        enemyRb.velocity = Vector2.right * speed;
        if (speed < 0)
            spriteRenderer.flipX = true;
        else if (speed > 0)
            spriteRenderer.flipX = false;

        if (timeBeforeChange < Time.time)
        {
            speed *= -1;
            // spriteRenderer.flipX = !spriteRenderer.flipX;
            // spriteRenderer.flipX ^= true;
            timeBeforeChange = Time.time + delay;
        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (transform.position.y < other.transform.position.y)
            {
                enemyParticle.transform.position = transform.position;
                enemyParticle.Play();
                isWalking = !isWalking;
                enemyAnim.SetBool("isDead", true);
                enemyAudio.Play();
            }
        }
    }

    public void DisableEnemy()
    {
        gameObject.SetActive(false);
    }
}
