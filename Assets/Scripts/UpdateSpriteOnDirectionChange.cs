using UnityEngine;

public class UpdateSpriteOnDirectionChange : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    Directable directable;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        directable = GetComponent<Directable>();
    }

    void OnChangeDirection(Vector2 direction)
    {
        spriteRenderer.flipX = direction.x < 0;
    }

    private void OnEnable()
    {
        directable.OnDirectionChange += OnChangeDirection;
    }

    private void OnDisable()
    {
        directable.OnDirectionChange -= OnChangeDirection;
    }
}
