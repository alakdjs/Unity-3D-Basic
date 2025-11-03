using UnityEngine;

public class IsFrontScript : MonoBehaviour
{
    [SerializeField] private Transform _targetObject;

    public float _viewAngle = 60.0f; // 시야각

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    bool IsFront()
    {
        if (_targetObject == null) return false;

        // 타겟의 월드좌표를 로컬좌표로 변환
        Vector3 localPosition = transform.InverseTransformPoint(_targetObject.position);

        // 로컬좌표에서 각도를 계산
        // z 축 forward 방향. x, z 평면
        float angle = Mathf.Atan2(localPosition.x, localPosition.z) * Mathf.Rad2Deg;

        angle = Mathf.Abs(angle);

        if(angle <= _viewAngle / 2.0f)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        bool isFront = IsFront();

        if (isFront)
        {
            _targetObject.GetComponent<MeshRenderer>().material.color = Color.red;
        }
        else
        {
            _targetObject.GetComponent<MeshRenderer>().material.color = Color.blue;
        }
    }
}
