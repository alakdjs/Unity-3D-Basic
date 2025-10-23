using UnityEngine;

public class RightMove : MonoBehaviour
{
    public float _speed = 1.0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position += new Vector3(1.0f, 0.0f, 0.0f) * _speed * Time.deltaTime;
    }
}
