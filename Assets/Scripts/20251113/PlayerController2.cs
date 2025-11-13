using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2 : MonoBehaviour
{
    private float _vertical = 0.0f;
    private float _horizontal = 0.0f;
    private float _rot = 0.0f;
    private float _moveSpeed = 3.0f;

    private Animator _animator;

    private Transform _cameraTransform;
    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        _cameraTransform = Camera.main.transform;

    }

    // Update is called once per frame
    void Update()
    {
        _vertical = Input.GetAxis("Vertical");
        _horizontal = Input.GetAxis("Horizontal");
        _rot = Input.GetAxis("Mouse X");

        Vector3 forward = _cameraTransform.forward;

        Vector3 moveDir = (forward * _vertical + Vector3.right * _horizontal).normalized;

        if (moveDir.magnitude > 0.01f)
        {
            _animator.SetBool("Run", true);
            this.transform.position += moveDir.normalized * _moveSpeed * Time.deltaTime;
            Quaternion rotation = Quaternion.LookRotation(moveDir);
            this.transform.rotation = rotation;
        }
        else
        {
            _animator.SetBool("Run", false);
        }


        //this.transform.LookAt(moveDir);
        //this.transform.Rotate(Vector3.up * _rot * 5.0f);


    }
}
