using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    float _angle = 0.0f;
    float _angleSpeed = 40.0f;
    float _speed = 1.0f;

    bool _isStart = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    public void Go()
    {
        _isStart = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (_isStart)
        {
            _angle = _angleSpeed * Time.deltaTime;

            this.transform.rotation = Quaternion.Euler(0.0f, 0.0f, _angle);
            this.transform.position += Vector3.right * _speed * Time.deltaTime;
        }
    }
}
