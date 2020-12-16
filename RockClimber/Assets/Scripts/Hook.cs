using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hook : MonoBehaviour
{
    [SerializeField]
    private Transform _player;
    private Vector3 _startPosPlayer,_startPosHook;
    void Start()
    {
        //transform.Translate(Vector3.down * 2);
        _startPosPlayer = _player.position;
        _startPosHook = transform.position;
    }

    void FixedUpdate()
    {
        Vector3 pos = transform.position;
       pos.y = (_startPosHook+ (_startPosPlayer - _player.position)-(_startPosPlayer - _player.position)/10).y;
        transform.position = pos;
    }
}
