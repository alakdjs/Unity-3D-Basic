using UnityEngine;

public class ThirdPersonCameraRig : MonoBehaviour
{
    [Header("타겟 (플레이어)")]
    public Transform target;  // 플레이어

    [Header("카메라 설정")]
    public Transform cameraTransform;  // 실제 카메라

    [Header("거리 설정")]
    public float distance = 5f;        // 카메라와 플레이어 거리
    public float height = 2f;          // 카메라 높이 오프셋
    public float heightDamping = 2f;   // 높이 스무딩
    public float rotationDamping = 3f; // 회전 스무딩

    [Header("마우스 설정")]
    public float mouseSensitivityX = 3f;
    public float mouseSensitivityY = 3f;

    [Header("카메라 제한")]
    public float minVerticalAngle = -30f;
    public float maxVerticalAngle = 60f;

    [Header("줌 설정")]
    public bool enableZoom = true;
    public float minDistance = 2f;
    public float maxDistance = 10f;
    public float zoomSpeed = 2f;

    [Header("충돌 감지")]
    public bool enableCollision = true;
    public LayerMask collisionLayers;
    public float collisionOffset = 0.3f;

    // 회전 값
    private float currentRotationX = 0f;
    private float currentRotationY = 0f;

    // 현재 거리 (충돌 대응)
    private float currentDistance;

    void Start()
    {
        // 초기 설정
        currentDistance = distance;

        // 커서 설정
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        // CameraRig가 타겟의 자식이 아니면 경고
        if (transform.parent != target)
        {
            Debug.LogWarning("CameraRig는 플레이어의 자식이어야 합니다!");
        }

        // 카메라가 없으면 자동으로 찾기
        if (cameraTransform == null)
        {
            cameraTransform = GetComponentInChildren<Camera>().transform;
        }
    }

    void LateUpdate()
    {
        if (target == null || cameraTransform == null)
            return;

        HandleInput();
        UpdateCameraPosition();

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ToggleCursor();
        }
    }

    // 입력 처리
    void HandleInput()
    {
        // 마우스 입력
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivityX;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivityY;

        // 수평 회전 (좌우)
        currentRotationY += mouseX;

        // 수직 회전 (상하)
        currentRotationX -= mouseY;
        currentRotationX = Mathf.Clamp(currentRotationX, minVerticalAngle, maxVerticalAngle);

        // 마우스 휠로 줌
        if (enableZoom)
        {
            float scroll = Input.GetAxis("Mouse ScrollWheel");
            distance -= scroll * zoomSpeed;
            distance = Mathf.Clamp(distance, minDistance, maxDistance);
        }
    }

    // 카메라 위치 업데이트
    void UpdateCameraPosition()
    {
        // Rig 회전 (플레이어 주위를 회전)
        Quaternion targetRotation = Quaternion.Euler(currentRotationX, currentRotationY, 0);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * rotationDamping);

        // 카메라를 Rig 뒤쪽으로 배치
        Vector3 targetCameraPos = new Vector3(0, height, -distance);

        // 충돌 감지
        if (enableCollision)
        {
            targetCameraPos = HandleCameraCollision(targetCameraPos);
        }

        // 카메라 위치 적용 (부드럽게)
        cameraTransform.localPosition = Vector3.Lerp(
           cameraTransform.localPosition,
           targetCameraPos,
           Time.deltaTime * heightDamping
        );

        // 카메라가 Rig 중심을 바라보도록
        cameraTransform.LookAt(transform.position);
    }

    // 카메라 충돌 처리
    Vector3 HandleCameraCollision(Vector3 targetPos)
    {
        Vector3 direction = cameraTransform.position - transform.position;
        //float targetDistance = targetPos.magnitude;
        float targetDistance = direction.magnitude;

        direction = direction.normalized;
        // Rig 위치에서 카메라 방향으로 레이캐스트
        RaycastHit hit;

        Debug.DrawRay(transform.position, direction, Color.yellow);
        if (Physics.Raycast(transform.position, direction, out hit, targetDistance, collisionLayers))
        {
            Debug.Log("Hit -------");
            // 충돌 지점까지의 거리
            float collisionDistance = hit.distance - collisionOffset;
            collisionDistance = Mathf.Max(collisionDistance, minDistance);

            // 충돌 지점 앞으로 카메라 이동
            targetPos = direction * collisionDistance;
        }

        return targetPos;
    }

    void ToggleCursor()
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

    // Gizmos
    void OnDrawGizmos()
    {
        if (cameraTransform == null) return;

        // Rig 위치
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, 0.2f);

        // 카메라 위치
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(cameraTransform.position, 0.3f);

        // Rig에서 카메라로 선
        Gizmos.color = Color.green;
        Gizmos.DrawLine(transform.position, cameraTransform.position);

        // 시야 범위
        Gizmos.color = Color.blue;
        Gizmos.DrawRay(cameraTransform.position, cameraTransform.forward * 10f);
    }
}
