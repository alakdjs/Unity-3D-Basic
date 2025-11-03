using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputTest : MonoBehaviour
{
    float _speed = 3.0f;
    private float _moveZ = 0.0f;
    private float _moveX = 0.0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // GetKey
        // GetKeyDown
        // GetKeyUp
        if (Input.GetKey(KeyCode.UpArrow)) // 傈规规氢
        {
            _moveZ += 1.0f;
        }

        if (Input.GetKey(KeyCode.DownArrow)) // 饶规规氢
        {
            _moveZ -= 1.0f;
        }

        if (Input.GetKey(KeyCode.LeftArrow)) // 谅规规氢
        {
            _moveX -= 1.0f;
        }

        if (Input.GetKey(KeyCode.RightArrow)) // 快规规氢
        {
            _moveX += 1.0f;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            this.GetComponent<MeshRenderer>().material.color = Color.red;
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            this.GetComponent<MeshRenderer>().material.color = Color.white;
        }

        this.transform.Translate(new Vector3(_moveX, 0.0f, _moveZ).normalized * _speed * Time.deltaTime);
        _moveX = 0.0f;
        _moveZ = 0.0f;
    }
}
