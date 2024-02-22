using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private Vector3 _offset;

    public float height = 6f;
    public float distance = 7f;
    public float angle = 45;

    void LateUpdate()
    {
        if (_target == null) return;

        _offset = (Vector3.forward * -distance) + (Vector3.up * height);
        transform.position = _target.position + _offset;
        transform.LookAt(_target.position);
    }
    public void SetTarget(Transform target)
    {
        _target = target;
    }
}
