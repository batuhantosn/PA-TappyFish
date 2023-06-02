using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : MonoBehaviour
{
    private Rigidbody2D _rb;
    [SerializeField]private float speed = 9f;

    int angle;
    int maxangle = 20;
    int minangle = -60;
    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {

        FishSwim();
        FishRotation();
    }

    public void FishSwim()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _rb.velocity = Vector2.zero;
            _rb.velocity = new Vector2(_rb.velocity.x, speed);
        }
    }
    public void FishRotation()
    {
        if (_rb.velocity.y > 0 && maxangle > angle)
        {
            angle = angle + 4;
        }
        else if (_rb.velocity.y < 0 && minangle < angle)
        {
            angle = angle - 2;
        }
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }
}
