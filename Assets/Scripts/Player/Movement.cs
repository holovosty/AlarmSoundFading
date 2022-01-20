using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CircleCollider2D))]

public class Movement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private UnityEvent _startMove;
    [SerializeField] private UnityEvent _stopMove;

    private Rigidbody2D _rigidBody2D;

    private bool _isJumpable;

    private void Start()
    {
        _rigidBody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        if (Input.GetKey(KeyCode.D))
        {
            _rigidBody2D.AddForce(Vector2.right * _speed);
            _startMove.Invoke();
        }
        else if (Input.GetKey(KeyCode.A))
        {
            _rigidBody2D.AddForce(Vector2.left * _speed);
            _startMove.Invoke();
        }
        else
        {
            _stopMove.Invoke();
        }

        if (_isJumpable && Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        _isJumpable = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        _isJumpable = false;
    }

    private void Jump()
    {
        _rigidBody2D.AddForce(Vector2.up * _jumpForce);
    }
}
