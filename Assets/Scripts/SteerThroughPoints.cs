using UnityEngine;

public class SteerThroughPoints : MonoBehaviour
{
    [SerializeField] float tolerance;
    [SerializeField] Transform pointA;
    [SerializeField] Transform pointB;
    Transform currentPoint;
    Directable directable;

    void Start()
    {
        directable = GetComponent<Directable>();
        currentPoint = pointA;
    }

    void Update()
    {
        if (ItReached(currentPoint.position))
            SwitchPoint();
        UpdateDirection();
    }

    bool ItReached(Vector3 point)
    {
        float distance = Vector3.Distance(point, transform.position);
        return distance < tolerance;
    }

    void SwitchPoint()
    {
        if (currentPoint.Equals(pointA))
            currentPoint = pointB;
        else
            currentPoint = pointA;
    }

    void UpdateDirection()
    {
        Vector2 direction = currentPoint.position - transform.position;
        direction.Normalize();
        directable.Direction = direction;
    }
}
