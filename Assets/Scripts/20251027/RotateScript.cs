using UnityEngine;

public class RotateScript : MonoBehaviour
{
    [SerializeField] private Transform _targetTr;

    float _angle = 0.0f;
    float _rotSpeed = 30.0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //_angle += _rotSpeed * Time.deltaTime;
        // 1.
        //this.transform.rotation = Quaternion.Euler(30.0f, _angle, 0); // ������ -> ���ʹϾ�

        //this.transform.rotation = Quaternion.AngleAxis(_angle, new Vector3(0.5f, 1.0f, 0.0f));

        // 2.
        //this.transform.Rotate(new Vector3(1.0f, 1.0f, 0.0f), Space.Self);


        // 3.
        //this.transform.RotateAround(_targetTr.position, Vector3.up, _rotSpeed * Time.deltaTime);

        // 4.
        //this.transform.LookAt(_targetTr);

        // 5.
        /*
        Vector3 direction = _targetTr.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(direction);
        transform.rotation = rotation;
        */


        // 6.
        // �������ϰ� ȸ��
        /*
        Vector3 direction2 = _targetTr.position - transform.position; // Ÿ�� ���� ����
        Quaternion rotation2 = Quaternion.LookRotation(direction2); // Ÿ�Ϲ��� ȸ������ ����
        Quaternion rotateValue = Quaternion.RotateTowards(transform.rotation, rotation2, 60.0f * Time.deltaTime);

        transform.rotation = rotateValue;
        */


        // 7.
        // ���� �Լ��� ���
        Vector3 direction3 = _targetTr.position - transform.position;

        // ��������
        // this.transform.rotation = Quaternion.Lerp(this.transform.rotation, Quaternion.LookRotation(direction3), Time.deltaTime * _rotSpeed);

        // ���� ����
        this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(direction3), Time.deltaTime * _rotSpeed);
    }
}
