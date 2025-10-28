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
        //this.transform.rotation = Quaternion.Euler(30.0f, _angle, 0); // 각축방식 -> 쿼터니언

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
        // 스무스하게 회전
        /*
        Vector3 direction2 = _targetTr.position - transform.position; // 타겟 방향 벡터
        Quaternion rotation2 = Quaternion.LookRotation(direction2); // 타켓방향 회전값을 구함
        Quaternion rotateValue = Quaternion.RotateTowards(transform.rotation, rotation2, 60.0f * Time.deltaTime);

        transform.rotation = rotateValue;
        */


        // 7.
        // 보간 함수를 사용
        Vector3 direction3 = _targetTr.position - transform.position;

        // 선형보간
        // this.transform.rotation = Quaternion.Lerp(this.transform.rotation, Quaternion.LookRotation(direction3), Time.deltaTime * _rotSpeed);

        // 구면 보간
        this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(direction3), Time.deltaTime * _rotSpeed);
    }
}
