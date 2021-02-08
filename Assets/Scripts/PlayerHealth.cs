using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public Image[] hearts;
    public SceneChanger sceneChanger;
    int health = 3;
    bool hasCooldown = false;

    public void Kill()
    {
        sceneChanger.ChangeSceneTo("LoseScreen");
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            if (GetComponent<PlayerMovement>().isGrounded)
            {
                SubstractHealth(1);
            }
        }
        else if (other.gameObject.CompareTag("Spikes"))
        {
            SubstractHealth(2);
        }
    }

    void SubstractHealth(int damage)
    {
        if (!hasCooldown)
        {
            if (health > 0)
            {
                health -= damage;
                hasCooldown = true;

                StartCoroutine(Cooldown());
            }
            if (health <= 0)
            {
                Kill();
            }

            EmptyHearts();
        }
    }

    void EmptyHearts()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            if (health - 1 < i)
                hearts[i].gameObject.SetActive(false);
        }
    }

    IEnumerator Cooldown()
    {
        yield return new WaitForSeconds(.5f);
        hasCooldown = false;
        StopCoroutine(Cooldown());
    }
}
