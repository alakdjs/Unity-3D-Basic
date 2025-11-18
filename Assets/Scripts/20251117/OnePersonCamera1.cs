using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnePersonCamera1 : MonoBehaviour
{
    public float moveSpeed = 5.0f; // 이동 속도

    public float mouseSensitivity = 2.0f; // 마우스 감도

    private float rotationX = 0f; // 시야각 제한을 위한 변수

    void Start()
    {
        // 마우스 커서를 숨기고 게임 창 중앙에 고정합니다. (1인칭 시점의 필수 설정)
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // --- 매 프레임 업데이트 ---
    void Update()
    {
        // 1. 시야 회전 (마우스 입력)
        HandleRotation();

    }

    // --- 시야 회전 처리 함수 ---
    void HandleRotation()
    {
        // 마우스의 X, Y 축 이동량을 가져옵니다.
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        // Y축 회전 (위/아래 보기): 시야각 제한
        rotationX -= mouseY;
        // 시야각 -90도(완전 아래)부터 90도(완전 위) 사이로 제한합니다.
        rotationX = Mathf.Clamp(rotationX, -90f, 90f);

        // 현재 카메라의 로컬 회전을 쿼터니언으로 설정합니다.

        transform.localRotation = Quaternion.Euler(rotationX, 0f, 0f);

        // X축 회전 (좌/우 보기): 월드 축 기준 회전
        transform.parent.Rotate(Vector3.up * mouseX);
    }
}
