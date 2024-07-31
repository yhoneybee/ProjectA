using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    [SerializeField] SpriteRenderer _sr;
    [SerializeField] Animator _animator;
    [SerializeField] private Vector2 _dir;
    public Vector2 Dir
    {
        get => _dir;
        set
        {
            _dir = value;
            _animator.SetFloat("Move", Mathf.Abs(_dir.x));
            _sr.flipX = _dir.x < 0;
        }
    }
    [SerializeField] private float _speed;

    public void OnMove(InputValue inputValue)
    {
        Dir = inputValue.Get<Vector2>();
    }

    private void Update()
    {
        transform.Translate(_speed * Time.deltaTime * Dir);
    }
}
