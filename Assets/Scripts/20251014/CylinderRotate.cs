using UnityEngine;

public class CylinderRotate : MonoBehaviour
{
    float _rotSpeed = 40.0f;
    float _angle = 0.0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _angle += Time.deltaTime * _rotSpeed;

        this.transform.rotation = Quaternion.Euler(0, 0, _angle);
    }
}
