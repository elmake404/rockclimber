using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private Rigidbody _rbMain;
    private Camera _cam;
    private Vector3 _startMosePos, _currentMousePos;

    [SerializeField]
    private float _forceJump;
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

            _currentMousePos = _cam.ScreenToViewportPoint(Input.mousePosition);

            if ((_currentMousePos - _startMosePos).magnitude > 0.01f)
            {
                if (_currentMousePos.y > _startMosePos.y)
                {
                    _isMoveUp = true;
                    _isMoveDown = false;
                    _speedMoveUp = Mathf.Abs(_currentMousePos.y - _startMosePos.y) * 1.5f;
                    if (_speedMoveUp > 0.1f)
                    {
                        _speedMoveUp = 0.1f;
                    }
                }
                else
                {
                    _isMoveUp = false;
                    _isMoveDown = true;
                    _speedMoveDown = Mathf.Abs(_currentMousePos.y - _startMosePos.y) * 2f;
                    if (_speedMoveDown > 0.2f)
                    {
                        _speedMoveDown = 0.2f;
                    }

                }
            }
        }
        else
        {
            _isMouseBottom = false;
            _isMoveUp = false;
            _isMoveDown = false;
        }
        #region Old
        //if (Input.GetMouseButtonDown(0))
        //{
        //    _isMouseBottom = true;
        //    _startMosePos = _cam.ScreenToViewportPoint(Input.mousePosition);
        //}
        //else if (Input.GetMouseButton(0))
        //{
        //    if (_startMosePos == Vector3.zero)
        //    {
        //        _startMosePos = _cam.ScreenToViewportPoint(Input.mousePosition);
        //    }

        //    _currentMousePos = _cam.ScreenToViewportPoint(Input.mousePosition);

        //    if ((_currentMousePos - _startMosePos).magnitude > 0.01f)
        //    {
        //        if (_currentMousePos.y>_startMosePos.y)
        //        {
        //            _isMoveUp = true;
        //            _isMoveDown = false;
        //        }
        //        else
        //        {
        //            _isMoveUp = false;
        //            _isMoveDown = true;
        //        }
        //    }
        //}
        //else
        //{
        //    _isMouseBottom = false;
        //    _isMoveUp = false;
        //    _isMoveDown = false;
        //}
        #endregion
    }
    private void FixedUpdate()
    {
        transform.eulerAngles = new Vector3(0, 0, transform.eulerAngles.z);

        if (_isMouseBottom)
        {
            if (_isMoveUp)
            {
                transform.Translate(Vector3.left * _speedMoveUp);
            }
            else if (_isMoveDown)
            {
                transform.Translate(Vector3.right * _speedMoveDown);
            }
        }
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
