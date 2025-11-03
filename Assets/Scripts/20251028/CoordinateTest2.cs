using UnityEngine;

public class CoordinateTest2 : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Vector3 worldPos = new Vector3(3.0f, 3.0f, 2.0f);

        // 월드 좌표를 로컬좌표로 변환 (위치값)
        Vector3 localPosition = transform.InverseTransformPoint(worldPos);

        Debug.Log($"world position = {worldPos}");
        Debug.Log($"local Position = {localPosition}");

        /*
        // 월드 방향을 로컬방향으로 변환
        Vector3 worldDirect = new Vector3(0.0f, 0.0f, 1.0f);

        Vector3 localDirect = transform.InverseTransformPoint(worldDirect);
        Debug.Log($"World Direction = {worldPos}");
        Debug.Log($"local Direction = {localPosition}");
        */
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
