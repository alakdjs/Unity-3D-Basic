using UnityEngine;

public class RotateObject : MonoBehaviour
{
    private float _angle = 0.0f;
    private float _speed = 40.0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _angle += _speed + Time.deltaTime;
        this.transform.rotation = Quaternion.Euler(0.0f, _angle, 0.0f);
    }
}
