using UnityEngine;

public class MouseTest : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // 좌측 마우스 버튼 클릭 시
        {
            Debug.Log($"{Input.mousePosition}");
            Debug.Log("Left MouseButtonDown");
        }

        if (Input.GetMouseButtonUp(0))
        {
            Debug.Log($"{Input.mousePosition}");
            Debug.Log("Left MouseButtonUp");
        }

        if (Input.GetMouseButtonDown(1)) // 우측 마우스 버튼 클릭 시
        {
            Debug.Log($"{Input.mousePosition}"); // Input.mousePosition 은 현재 마우스 커서의 스크린좌표계 위치
            Debug.Log("Right MouseButtonDown");
        }

        if (Input.GetMouseButtonUp(1))
        {
            Debug.Log($"{Input.mousePosition}");
            Debug.Log("Right MouseButtonUp");
        }

        if (Input.GetMouseButtonDown(2)) // 휠 마우스 버튼 클릭 시
        {
            Debug.Log($"{Input.mousePosition}");
            Debug.Log("Wheel MouseButtonDown");
        }
        
        if (Input.GetMouseButtonUp(2))
        {
            Debug.Log($"{Input.mousePosition}");
            Debug.Log("Wheel MouseButtonUp");
        }
    }
}
