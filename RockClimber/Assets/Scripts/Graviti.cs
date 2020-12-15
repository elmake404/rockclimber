using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Graviti : MonoBehaviour
{
    
    [SerializeField]
    private Rigidbody _rbMain;
    [SerializeField]
    private Vector3 _directionGraviti;
    void Start()
    {
        if (_directionGraviti==Vector3.zero)
        {
            _directionGraviti = Vector3.down;
        }
        if (_rbMain==null)
        {
            Debug.Log(name+ " absent Rigidbody");
        }
    }

    void FixedUpdate()
    {

        _rbMain.AddForce(_directionGraviti*9.8f,ForceMode.Acceleration);
    }
    [ContextMenu("GetRigidbody")]
    public void GetRigidbody()
    {
        _rbMain = GetComponent<Rigidbody>();
    }
}
