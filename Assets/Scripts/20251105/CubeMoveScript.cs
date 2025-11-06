using UnityEngine;

public class CubeMoveScript : MonoBehaviour
{
    private Vector3 _pos;
    private float _speed = 5.0f;
    private float _rotSpeed = 30.0f;
    private float _ypos = 0.0f;

    Vector3 direction;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _ypos = this.transform.position.y;
    }

    public void SetPosition(Vector3 pos)
    {
        _pos = pos;

        direction = _pos - transform.position;
        direction.y = 0.0f;

        _pos.y = _ypos;
        this.transform.LookAt(_pos);
    }

    // Update is called once per frame
    void Update()
    {
        direction = _pos - transform .position;
        direction.y = 0.0f;

        _pos.y = _ypos;

        transform.position += direction.normalized * _speed * Time.deltaTime;
    }
}
