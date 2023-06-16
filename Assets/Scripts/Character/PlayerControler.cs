using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Animator _animator;
    private SpriteRenderer _renderer;
    private Vector2 _direction;
    private Rigidbody2D _rigidbody;

    void Start()
    {
        _renderer = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody2D>();

        if (_renderer == null)
        {
            Debug.LogError("Спрайт игрока не обнаружен");
        }
    }

    void Update()
    {
        _direction.x = Input.GetAxisRaw("Horizontal");
        _direction.y = Input.GetAxisRaw("Vertical");

        if (_direction != Vector2.zero)
        {
            _animator.SetFloat("XInput", _direction.x);
            _animator.SetFloat("YInput", _direction.y);
        }
        _animator.SetFloat("Speed", _direction.sqrMagnitude);

        if (_direction.x > 0)
            _renderer.flipX = false;
        else if (_direction.x < 0)
            _renderer.flipX = true;
    }

    private void FixedUpdate()
    {
        _rigidbody.MovePosition(_rigidbody.position + _direction * _speed * Time.fixedDeltaTime);
    }
}