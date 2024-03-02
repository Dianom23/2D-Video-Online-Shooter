using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float _speed;
    private Rigidbody2D _rb;
    private PhotonView _view;
    private Vector2 _moveDirection;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _view = GetComponent<PhotonView>();
    }

    void Update()
    {
        if (_view.IsMine == false)
            return;

        InputMove();
        Move();
    }

    private void InputMove()
    {
        _moveDirection.x = Input.GetAxisRaw("Horizontal");
        _moveDirection.y = Input.GetAxisRaw("Vertical");
        _moveDirection.Normalize();
    }

    private void Move()
    {
        _rb.velocity = _moveDirection * _speed;
    }
}
