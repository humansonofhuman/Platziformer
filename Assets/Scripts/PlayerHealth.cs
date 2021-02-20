using System.Collections;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private IntEventChannelSO _onHealthChange = default;
    int _health = 3;
    private int Health
    {
        get => _health;
        set
        {
            _health = value;
            if (_onHealthChange != null)
                _onHealthChange.RaiseEvent(value);
        }
    }

    bool hasCooldown = false;

    public void Kill()
    {
        SceneChanger.ChangeSceneTo("LoseScreen");
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
            if (Health > 0)
            {
                Health -= damage;
                hasCooldown = true;

                StartCoroutine(Cooldown());
            }
            if (Health <= 0)
            {
                Kill();
            }
        }
    }

    IEnumerator Cooldown()
    {
        yield return new WaitForSeconds(.5f);
        hasCooldown = false;
        StopCoroutine(Cooldown());
    }
}
