using UnityEngine;

public class CoordinateTest1 : MonoBehaviour
{
    [SerializeField] private Transform _targetTr;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        /*
        // ���� ��ǥ�� ���� ��ǥ�� ��ȯ
        Vector3 worldPosition = transform.TransformDirection(Vector3.forward);

        Debug.Log($"LocalPosition: {transform.forward}");
        Debug.Log($"WorldPosition: {worldPosition}");
        */

        // ������ ��ġ��ǥ�� ������ ��ġ��ǥ�� ��ȯ
        Debug.Log($"_targetTr.localPosition = {_targetTr.localPosition}");
        Debug.Log($"_targetTr.position = {_targetTr.position}");
        Vector3 worldPos = transform.TransformPoint(_targetTr.localPosition);
        Debug.Log($"WorldPos = {worldPos}");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
