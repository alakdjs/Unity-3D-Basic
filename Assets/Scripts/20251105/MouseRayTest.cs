using UnityEngine;

public class MouseRayTest : MonoBehaviour
{
    [SerializeField] private Transform _PlayerObj;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            // 클릭된 스크린좌표에서 가상의 월드 공간으로 향하는 반직선(ray)를 만든다.

            RaycastHit hit;

            if (Physics.Raycast(ray, out hit)) // 반직선(ray)와 교차된 오브젝트를 찾아서 hit에 넣어준다.
            {
                Debug.Log($"hit point = {hit.point}");
                // Destroy(hit.collider.gameObject);

                Vector3 pos = hit.point;
                _PlayerObj.GetComponent<CubeMoveScript>().SetPosition(pos);
            }
        }
    }
}
