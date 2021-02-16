using UnityEngine;

public class LinearMovement : MonoBehaviour
{
    [SerializeField] float speed;
    Directable directable;
    Vector2 direction;
    void Awake()
    {
        directable = GetComponent<Directable>();
    }

    void Update()
    {
        Move();
    }

    void Move()
    {
        transform.position += (Vector3)direction * (speed * Time.deltaTime);
    }

    void OnChangeDirection(Vector2 direction)
    {
        this.direction = direction;
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
