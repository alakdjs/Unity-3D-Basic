using UnityEngine;

public class VectorTest : MonoBehaviour
{
    [SerializeField] private GameObject _pos1Object;
    [SerializeField] private GameObject _pos2Object;

    Vector3 _pos1 = Vector3.zero;
    Vector3 _pos2 = Vector3.zero;

    Vector3 _directVec = Vector3.zero;

    void Start()
    {
        _pos1 = _pos1Object.transform.position;
        _pos2 = _pos2Object.transform.position;

        _directVec = _pos1 - _pos2;

        this.transform.position += _directVec;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
