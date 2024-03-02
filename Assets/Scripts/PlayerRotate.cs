using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotate : MonoBehaviour
{
    private Vector3 _mousePosition;
    private PhotonView _view;
    private Camera _camera;

    void Start()
    {
        _view = GetComponent<PhotonView>();
        _camera = Camera.main;
    }

    void Update()
    {
        if (_view.IsMine == false)
            return;

        InputRotate();
        Rotate();
    }

    private void InputRotate()
    {
        _mousePosition = Input.mousePosition;
        _mousePosition = _camera.ScreenToWorldPoint( _mousePosition );
    }

    private void Rotate()
    {
        Vector3 rotateDirection = _mousePosition - transform.position;
        float angle = Mathf.Atan2(rotateDirection.y, rotateDirection.x) * Mathf.Rad2Deg;
        transform.eulerAngles = Vector3.forward * angle;
    }
}
