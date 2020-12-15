using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private Rigidbody _rbMain;
    private Camera _cam;
    [SerializeField]
    private Vector3 _startMosePos, _currentMosePos, _direcrionVector;

    [SerializeField]
    private float _forceJump;
    [SerializeField]
    private float _speedMoveDown, _speedMoveUp;
    [SerializeField]
    private bool _isMouseBottom, _isMoveDown, _isMoveUp;
    private void Start()
    {
        _cam = Camera.main;
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _isMouseBottom = true;
            _startMosePos = _cam.ScreenToViewportPoint(Input.mousePosition);
        }
        else if (Input.GetMouseButton(0))
        {
            if (_startMosePos == Vector3.zero)
            {
                _startMosePos = _cam.ScreenToViewportPoint(Input.mousePosition);
            }

            _currentMosePos = _cam.ScreenToViewportPoint(Input.mousePosition);

            if (Mathf.Abs(_startMosePos.y - _currentMosePos.y) >= 0.01f)
            {

                if (Mathf.Abs((_currentMosePos.y - _startMosePos.y) * 7) > 1)
                {

                    float yStart = ((_currentMosePos.y - _startMosePos.y) > 0 ? 0.14f : -0.14f);
                    _startMosePos.y = _currentMosePos.y - yStart;
                }

                float Y = 0;

                if (((_currentMosePos.y - _startMosePos.y) * 7) <= 0)
                {
                    Y = ((_currentMosePos.y - _startMosePos.y) * 7) * _speedMoveDown;
                }
                else
                {
                    Y = ((_currentMosePos.y - _startMosePos.y) * 7) * _speedMoveUp;
                }

                _direcrionVector = new Vector3(0, Y, 0);
            }
            else
            {
                _direcrionVector = _rbMain.velocity;
            }

        }
        else
        {
            _direcrionVector = _rbMain.velocity;

            _isMouseBottom = false;
            _isMoveUp = false;
            _isMoveDown = false;
        }
    }
    private void FixedUpdate()
    {
        transform.eulerAngles = new Vector3(0, 0, transform.eulerAngles.z);
        _direcrionVector.x = _rbMain.velocity.x;
        _rbMain.velocity = _direcrionVector;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 8)
        {
            _rbMain.velocity = (transform.up * _forceJump);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Thorns")
        {
            Destroy(gameObject);
        }
    }
}
