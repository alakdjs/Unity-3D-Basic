using UnityEngine;

public class CrossProductTest : MonoBehaviour
{
    [SerializeField] private Transform _BasePointTr;
    [SerializeField] private Transform _Point1Tr;
    [SerializeField] private Transform _Point2Tr;

    Vector3 _vec1 = Vector3.zero;
    Vector3 _vec2 = Vector3.zero;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    private void OnDrawGizmos()
    {
        // 벡터를 만든다.
        _vec1 = _Point1Tr.position - _BasePointTr.position;
        _vec2 = _Point2Tr.position - _BasePointTr.position;

        Vector3 normVec = Vector3.Cross(_vec1, _vec2); // 두 벡터를 외적한다.

        normVec = normVec.normalized * 10.0f; // normVec의 단위벡터로 만들고, 10.0f를 곱해서 벡터 크기를 10으로 고정한다.
        // 단위벡터 == 크기가 1인 벡터

        Gizmos.color = Color.red;

        Gizmos.DrawLine(_BasePointTr.position, _BasePointTr.position + normVec);

        Gizmos.color = Color.white;
        Gizmos.DrawLine(_BasePointTr.position, _Point1Tr.position);
        Gizmos.DrawLine(_BasePointTr.position, _Point2Tr.position);

        Debug.Log($"vec1 to vec2 Angle = {CalculateVectorVecAngle(_vec1, _vec2)}");
        Debug.Log($"vec1 to Norm Angle = {CalculateVectorVecAngle(_vec1, normVec)}");
        Debug.Log($"vec2 to Norm Angle = {CalculateVectorVecAngle(_vec2, normVec)}");
    }

    private float CalculateVectorVecAngle(Vector3 vec1, Vector3 vec2)
    {
        float dot = Vector3.Dot(vec1, vec2);
        float mag = vec1.magnitude * vec2.magnitude;

        float radian = Mathf.Acos(dot / mag);

        float angle = radian * Mathf.Rad2Deg;

        return angle;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
