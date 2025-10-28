using UnityEngine;


public enum DirectionEnum
{
    Up,
    Down,
    Left,
    Right,
    Stop
}

public class MoveScript : MonoBehaviour
{
    [SerializeField] private GameObject _targetObj;

    [SerializeField] private DirectionEnum _currentDirect = DirectionEnum.Stop;

    Vector3 _MoveDirect = Vector3.zero;
    private float _speed = 3.0f;

    // smooth damp 용
    float smoothTime = 1.0f;
    Vector3 velocity = Vector3.zero;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    void SetDirection()
    {
        switch(_currentDirect)
        {
            case DirectionEnum.Up:
                _MoveDirect = new Vector3(0.0f, 1.0f, 0.0f);
                break;

            case DirectionEnum.Down:
                _MoveDirect = new Vector3(0.0f, -1.0f, 0.0f);
                break;

            case DirectionEnum.Left:
                _MoveDirect = new Vector3(-1.0f, 0.0f, 0.0f);
                break;

            case DirectionEnum.Right:
                _MoveDirect = new Vector3(1.0f, 0.0f, 0.0f);
                break;

            case DirectionEnum.Stop:
                _MoveDirect = Vector3.zero;
                break;

        }
    }

    void FixedUpdate()
    {
        // 보간함수를 이용
        // Vector3.Lerp(시작위치, 목표위치, 보간값(0 ~ 1.0 사이의 값) // 선형보간

        //this.transform.position = Vector3.Lerp(this.transform.position, _targetObj.transform.position, 0.08f);

        // Vector3.Slerp(시작위치, 목표위치, 보간값(0 ~ 1.0f 사이의 값)) // 구면보간
        this.transform.position = Vector3.Slerp(this.transform.position, _targetObj.transform.position, 0.08f);
    }

    // Update is called once per frame
    void Update()
    {
        // 1.
        // SetDirection();
        // transform 컴포넌트를 직접 조작
        // this.transform.position += _MoveDirect.normalized * _speed * Time.deltaTime;

        // 2.
        //this.transform.Translate(new Vector3(0.0f, 1.0f, 0.0f) * _speed * Time.deltaTime);

        // 3.
        // 좌표계를 지정하지 않으면 로컬좌표계가 기준.
        //this.transform.Translate(Vector3.forward * _speed * Time.deltaTime, Space.Self);

        // 4.
        //this.transform.Translate(Vector3.forward * _speed * Time.deltaTime, Space.World);

        // 5.
        /*
        _MoveDirect = _targetObj.transform.position - this.transform.position; // 타겟방향으로 벡터 생성
        _MoveDirect = _MoveDirect.normalized;
        this.transform.Translate(_MoveDirect * _speed * Time.deltaTime, Space.World);
        */

        // 6.
        //transform.position = Vector3.MoveTowards(transform.position, _targetObj.transform.position, _speed * Time.deltaTime);

        // 7.
        //transform.position = Vector3.SmoothDamp(transform.position, _targetObj.transform.position, ref velocity, smoothTime);
    }
}
