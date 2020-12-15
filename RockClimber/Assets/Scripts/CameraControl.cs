using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    [SerializeField]
    private Player _target;
    private Vector3 _offSet, _cameraPos;
    private Vector3 velocity = Vector3.zero;

    [SerializeField]
    private float _topWindow = 5, _bottomWindow = 10;

    void Start()
    {
        _offSet = _target.transform.position - transform.position;
        _cameraPos = new Vector3(transform.position.x, _target.transform.position.y - _offSet.y, transform.position.z);
    }

    void FixedUpdate()
    {
        if (_target.transform.position.y > transform.position.y + _topWindow)
        {
            _cameraPos = new Vector3(transform.position.x, _target.transform.position.y - _topWindow, transform.position.z);
        }
        else if (_target.transform.position.y < transform.position.y - _bottomWindow)
        {
            _cameraPos = new Vector3(transform.position.x, _target.transform.position.y + _bottomWindow, transform.position.z);
        }

        transform.position = Vector3.SmoothDamp(transform.position, _cameraPos, ref velocity, 0.07f);
    }
}
