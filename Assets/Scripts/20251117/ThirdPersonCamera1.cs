using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCamera1 : MonoBehaviour
{

    public Transform target; // 타겟 설정
    public float distance = 5.0f; // 타겟으로부터의 카메라 거리

    public float mouseSensitivity = 4.0f; // 마우스 감도

    public float smoothSpeed = 10f; // 타겟으로부터의 카메라 거리

    // --- 내부 변수 ---
    private float currentX = 0f; // 현재 수평 회전 각도 (Yaw)
    private float currentY = 0f; // 현재 수직 회전 각도 (Pitch)

    //private const float Y_ANGLE_MIN = -5f; // 수직 시야각 최소 제한
    private const float Y_ANGLE_MIN = 10f;
    private const float Y_ANGLE_MAX = 60f; // 수직 시야각 최대 제한

    void Start()
    {
        // 마우스 커서를 잠금 (선택 사항)
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        // 타겟이 설정되지 않았다면 스크립트 비활성화
        if (target == null)
        {
            Debug.LogError("ThirdPersonCamera: Target Transform이 설정되지 않았습니다!");
            enabled = false;
        }
    }

    void Update()
    {
        if (target == null) return;

        // 1. 회전 입력 처리 (마우스)
        HandleRotationInput();

        // ESC 키로 커서 해제
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ToggleCursorLock();
        }
    }

    void ToggleCursorLock()
    {
        if (Cursor.lockState == CursorLockMode.Locked)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }

    // FixedUpdate 대신 LateUpdate를 사용해 모든 오브젝트의 이동이 끝난 후 카메라를 움직여 부자연스러움을 줄입니다.
    void LateUpdate()
    {
        if (target == null) return;

        // 2. 최종 위치 및 회전 계산
        HandlePositionAndRotation();
    }

    // --- 회전 입력 처리 함수 ---
    void HandleRotationInput()
    {
        // 마우스 X축 움직임에 따라 수평 회전 각도(Yaw) 업데이트
        currentX += Input.GetAxis("Mouse X") * mouseSensitivity;

        // 마우스 Y축 움직임에 따라 수직 회전 각도(Pitch) 업데이트
        currentY -= Input.GetAxis("Mouse Y") * mouseSensitivity;

        // 수직 회전 각도(Pitch)를 제한하여 카메라가 타겟의 발밑이나 머리 위로 넘어가지 않게 합니다.
        currentY = Mathf.Clamp(currentY, Y_ANGLE_MIN, Y_ANGLE_MAX);
    }

    // --- 최종 위치 및 회전 적용 함수 ---
    void HandlePositionAndRotation()
    {
        // 1. 회전 계산

        Quaternion rotation = Quaternion.Euler(currentY, currentX, 0);

        // 2. 위치 계산
        Vector3 direction = rotation * Vector3.forward;
        Vector3 targetPosition = target.position - direction * distance;

        // 3. 카메라 이동 및 회전 적용
        transform.position = Vector3.Lerp(transform.position, targetPosition, smoothSpeed * Time.deltaTime);

        // 카메라 회전을 부드럽게 적용하여 항상 타겟을 바라보게 합니다.
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, smoothSpeed * Time.deltaTime);


        // transform.LookAt(target);
    }
}
