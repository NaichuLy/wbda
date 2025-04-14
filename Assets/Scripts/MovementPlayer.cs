using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementPlayer : MonoBehaviour
{
    [Header("<color=green>Physics</color>")]
    [SerializeField] private float _moveSpeed = 3.5f;

    private Vector3 _dir = Vector3.zero;

    private void Update()
    {
        _dir.x = Input.GetAxis("Horizontal");
        _dir.z = Input.GetAxis("Vertical");

        if(_dir.sqrMagnitude != 0.0f)
        {
            Movement(_dir);
        }
    }

    private void Movement(Vector3 dir)
    {
        transform.position += dir.normalized * _moveSpeed * Time.deltaTime;
    }
}
