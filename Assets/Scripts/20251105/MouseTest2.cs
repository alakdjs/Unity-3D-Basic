using UnityEngine;

public class MouseTest2 : MonoBehaviour
{
    [SerializeField] private Transform _CubeTr;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 pos = Input.mousePosition; // 클릭한 위치에 스크린 좌표값을 가지고 온다.
            pos.z = 10.0f;
            Vector3 wpos = Camera.main.ScreenToWorldPoint(pos); // 스크린 상의 좌표를 월드 공간상에 좌표값으로 바꿔준다.

            _CubeTr.position = wpos;
            Debug.Log($"pos = {pos}, wpos = {wpos}");
        }
        
    }
}
