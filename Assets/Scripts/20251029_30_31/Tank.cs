using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank : MonoBehaviour
{
    [SerializeField] private GameObject _CannonBallPrefab;  // 포탄
    [SerializeField] private Transform _FirePosTr;  // 대포 발사 위치

    float _speed = 3.0f;

    private float _moveZ = 0.0f;
    private float _moveX = 0.0f;
    private float _rotSpeed = 120.0f;

    void Start()
    {

    }

    void KeyPress()
    {
        if (Input.GetKey(KeyCode.UpArrow))  // 전방 방향
        {
            // this.transform.position += transform.forward * _speed * Time.deltaTime;

            _moveZ += 1.0f;
        }

        if (Input.GetKey(KeyCode.DownArrow))    // 후방 방향
        {
            _moveZ -= 1.0f;
        }

        if (Input.GetKey(KeyCode.RightArrow))   // 오른쪽 방향
        {
            _moveX += 1.0f;
        }

        if (Input.GetKey(KeyCode.LeftArrow)) // 좌측방향
        {
            _moveX -= 1.0f;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            // instantiate는 오브젝트를 동적 생성해주는 메소드
            GameObject cannonBall = Instantiate(_CannonBallPrefab, _FirePosTr.position, _FirePosTr.rotation);
        }

        transform.Translate(new Vector3(_moveX, 0.0f, _moveZ).normalized * _speed * Time.deltaTime);
        _moveX = 0.0f;
        _moveZ = 0.0f;

    }

    private void AxisProcess()
    {
        float moveSpeed = _speed * Time.deltaTime;
        float rotateSpeed = _rotSpeed * Time.deltaTime;
        float front = Input.GetAxis("Vertical"); // 수직 변화량 (-1 ~ 1)
        float ang = Input.GetAxis("Horizontal"); // 수평 변화량 (-1 ~ 1)

        transform.Translate(Vector3.forward * front * moveSpeed); // 전진 후진

        transform.Rotate(Vector3.up * ang * rotateSpeed);

        // 대포발사
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //  Instantiate 메소드는 동적으로 게임오브젝트를 생성할 때 사용합니다.
            GameObject cannonBall = Instantiate(_CannonBallPrefab, _FirePosTr.position, _FirePosTr.rotation);
            cannonBall.GetComponent<Rigidbody>().AddForce(_FirePosTr.forward * 18.0f, ForceMode.Impulse);
        }
    }

    void Update()
    {
        //KeyPress();
        AxisProcess();
    }
}
