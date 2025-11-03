using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretTest : MonoBehaviour
{
    [SerializeField] private Transform _LeftShootPos;
    [SerializeField] private Transform _RightShootPos;
    [SerializeField] private Transform _MiddleShootPos;
    [SerializeField] private GameObject[] _CannonBalls;

    Vector3 LeftPos = Vector3.zero;
    Vector3 RightPos = Vector3.zero;
    Vector3 MiddlePos = Vector3.zero;

    Vector3 LeftPosVec = Vector3.zero;
    Vector3 RightPosVec = Vector3.zero;
    Vector3 MiddlePosVec = Vector3.zero;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // 로컬좌표를 월드 좌표로 변환
        /*
        LeftPos = transform.TransformPoint(_LeftShootPos.localPosition);
        RightPos = transform.TransformPoint(_RightShootPos.localPosition);
        MiddlePos = transform.TransformPoint(_MiddleShootPos.localPosition);
        */

        LeftPos = _LeftShootPos.transform.position;
        RightPos = _RightShootPos.transform.position;
        MiddlePos = _MiddleShootPos.transform.position;

        _CannonBalls[0].transform.position = LeftPos;
        _CannonBalls[1].transform.position = RightPos;
        _CannonBalls[2].transform.position = MiddlePos;

        // 로컬방향을 월드 방향으로 변환
        LeftPosVec = transform.TransformDirection(_LeftShootPos.localPosition);
        RightPosVec = transform.TransformDirection(_RightShootPos.localPosition);
        MiddlePosVec = transform.TransformDirection(_MiddleShootPos.localPosition);

        /*
        LeftPosVec = _LeftShootPos.localPosition;
        RightPosVec = _RightShootPos.localPosition;
        MiddlePosVec = _MiddleShootPos.localPosition;
        */

        _CannonBalls[0].GetComponent<ShootObject>().Shoot(LeftPosVec);
        _CannonBalls[1].GetComponent<ShootObject>().Shoot(RightPosVec);
        _CannonBalls[2].GetComponent<ShootObject>().Shoot(MiddlePosVec);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
