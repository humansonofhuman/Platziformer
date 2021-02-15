using UnityEngine;

public class MoveBetween : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float tolerance = 0.02f;
    [SerializeField] Transform pointA;
    [SerializeField] Transform pointB;
    Transform currentPoint;

    void Start()
    {
        currentPoint = pointA;
    }

    void FixedUpdate()
    {
        if (ItReached(currentPoint.position))
            SwitchPoint();
        Move();
    }

    bool ItReached(Vector3 point)
    {
        float distance = Vector3.Distance(point, transform.position);
        return distance < (speed * tolerance);
    }

    void SwitchPoint()
    {
        if (currentPoint.Equals(pointA))
            currentPoint = pointB;
        else
            currentPoint = pointA;
    }

    void Move()
    {
        Vector2 direction = currentPoint.position - transform.position;
        transform.position += (Vector3)direction.normalized * (speed * Time.deltaTime);
    }
}
