using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    Animator enemyAnim;
    ParticleSystem enemyParticle;
    AudioSource enemyAudio;


    void Start()
    {
        enemyAnim = GetComponent<Animator>();
        enemyParticle = GameObject.Find("EnemyParticle")
            .GetComponent<ParticleSystem>();

        enemyAudio = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (transform.position.y < other.transform.position.y)
            {
                enemyParticle.transform.position = transform.position;
                enemyParticle.Play();
                enemyAnim.SetBool("isDead", true);
                enemyAudio.Play();
            }
        }
    }

    public void DisableEnemy() // Called from animation event
    {
        gameObject.SetActive(false);
    }
}
