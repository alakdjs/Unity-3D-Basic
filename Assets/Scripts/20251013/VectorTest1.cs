using UnityEngine;

public class VectorTest1 : MonoBehaviour
{
    [SerializeField] private Transform _Point1Tr;
    [SerializeField] private Transform _Point2Tr;

    [SerializeField] private Transform _Point3Tr;
    [SerializeField] private Transform _Point4Tr;

    private Vector3 _direct1Vec = Vector3.zero;
    private Vector3 _direct2Vec = Vector3.zero;

    private Vector3 _calVec = Vector3.zero;

    private float _speed = 1.0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _direct1Vec = _Point1Tr.position - _Point2Tr.position;
        _direct2Vec = _Point3Tr.position - _Point4Tr.position;

        _calVec = _direct1Vec + _direct2Vec;

        //this.transform.position += _calVec;

        }

    // Update is called once per frame
    void Update()
    {
        this.transform.position += _calVec.normalized * _speed * Time.deltaTime;
    }
}
