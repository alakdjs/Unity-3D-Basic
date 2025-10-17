using UnityEngine;


public class TriangleCreator : MonoBehaviour
{
    // ✅ Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        TriangleCreate();
    }

    private void TriangleCreate()
    {
        // 버텍스 버퍼(정점버퍼)
        Vector3[] vertices = new Vector3[]
        {
            new Vector3(-1.0f, -1.0f, 0.0f), // 0
            new Vector3(0.0f, 1.0f, 0.0f), // 1
            new Vector3(1.0f, -1.0f, 0.0f) // 2
        };

        // 인덱스 버퍼
        int[] triangles = new int[] { 0, 1, 2 };

        Mesh mesh = new Mesh(); // 메쉬객체를 생성
        mesh.vertices = vertices; // 출력할 정점 정보를 버텍스버퍼에 전달
        mesh.triangles = triangles; // 정점 버퍼에 입력된 정점으로 삼각형을 어떤 순서로 그릴 것인지에 대한
                                    // 정보를 인덱스 버퍼에 전달

        mesh.RecalculateBounds();
        mesh.RecalculateNormals();

        GetComponent<MeshFilter>().mesh = mesh; // 출력할 메쉬데이터를 메쉬필터 컴포넌트에 전달

        Material material = new Material(Shader.Find("Standard"));

        GetComponent<MeshRenderer>().material = material;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
