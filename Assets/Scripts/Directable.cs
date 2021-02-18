using System;
using UnityEngine;

public class Directable : MonoBehaviour
{
    Vector2 _direction;
    public Vector2 Direction
    {
        get => _direction;
        set
        {
            if (OnDirectionChange != null)
                OnDirectionChange(value);
            _direction = value;
        }
    }
    public Action<Vector2> OnDirectionChange { get; set; }

}
