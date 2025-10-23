using UnityEngine;

public class WindVector : MonoBehaviour
{
    private Vector3 _windVector;
    private Vector3 _windVector2;

    [SerializeField] private Transform _WindTr1;
    [SerializeField] private Transform _WindTr2;
    [SerializeField] private Transform _WindTr3;
    [SerializeField] private Transform _WindTr4;

    private float _speed = 0.7f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _windVector = _WindTr1.position - _WindTr2.position;
        _windVector = _WindTr3.position - _WindTr4.position;

        this.transform.position += (new Vector3(1.0f, 0.0f, 0.0f) + _windVector + _windVector2).normalized * _speed * Time.deltaTime;
        
    }
}
