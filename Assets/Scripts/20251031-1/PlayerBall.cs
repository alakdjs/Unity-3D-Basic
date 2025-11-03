using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerBall : MonoBehaviour
{
    private float _movePower = 10.0f;
    private Rigidbody _myRigid;

    void Start()
    {
        _myRigid = GetComponent<Rigidbody>();
    }

    private void PhysicsMove()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            _myRigid.AddForce(Vector3.left * _movePower);

            //this.transform.rotation = Quaternion.LookRotation(Vector3.left);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            _myRigid.AddForce(Vector3.right * _movePower);

            //this.transform.rotation = Quaternion.LookRotation(Vector3.right);
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            _myRigid.AddForce(Vector3.forward * _movePower);

            //this.transform.rotation = Quaternion.LookRotation(Vector3.forward);
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            _myRigid.AddForce(Vector3.back * _movePower);

            //this.transform.rotation = Quaternion.LookRotation(Vector3.back);
        }

        void PhysicsMove2()
        {
            float moveX = Input.GetAxis("Horizontal");
            float moveY = Input.GetAxis("Vertical");

            _myRigid.AddForce(new Vector3(moveX, 0.0f, moveY).normalized * _movePower);
            //this.transform.rotation = Quaternion.LookRotation(new Vector3(moveX, 0.0f, moveY).normalized);
        }

        void FixedUpdate()
        {
            PhysicsMove2();
        }
    }

    void Update()
    {
        
    }
}
