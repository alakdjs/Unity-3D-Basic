using UnityEngine;

public class CarRaceTest : MonoBehaviour
{
    private float _speed = 1.0f;
    private bool _isStart = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _speed = UnityEngine.Random.Range(0.5f, 1.5f);
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
            this.transform.position += new Vector3(1.0f, 0.0f, 0.0f) * _speed * Time.deltaTime;
        }
    }
}
