using UnityEngine;

public class TextureRectangleCreate : MonoBehaviour
{
    [SerializeField] private Texture _texture;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        MakeSquare();    
    }

    void MakeSquare()
    {
        // 정점 버퍼에 입력할 정점 데이터
        Vector3[] vertices = new Vector3[]
        {
            new Vector3(-1.0f, -1.0f, 0.0f), // 0
            new Vector3(-1.0f, 1.0f, 0.0f), // 1
            new Vector3(1.0f, 1.0f, 0.0f), // 2
            new Vector3(1.0f, -1.0f, 0.0f), // 3
            new Vector3(0.0f, 2.0f, 0.0f)
        };

        // 인덱스버퍼에 전달할 삼각형 Data
        int[] triangles = new int[]
        {
            0, 1, 2,
            0, 2, 3,
            1, 4, 2
        };

        // uv 좌표에 저장할 Data
        Vector2[] uvs = new Vector2[]
        {
            new Vector2(0.0f, 0.0f),
            new Vector2(0.0f, 1.0f),
            new Vector2(1.0f, 1.0f),
            new Vector2(1.0f, 0.0f),
            new Vector2(0.5f, 1.25f),
        };

        Mesh mesh = new Mesh();
        mesh.vertices = vertices; // 정점버퍼에 정점 데이터 전달
        mesh.triangles = triangles; // 인덱스버퍼에 삼각형 정보 전달
        mesh.uv = uvs; // 삼각형에 입힐 Texture uv 좌표값 정보 전달

        GetComponent<MeshFilter>().mesh = mesh; // MeshFilter 컴포넌트에 구성된 메쉬정보 전달

        Material material = new Material(Shader.Find("Standard")); // 면의 재질 설정

        GetComponent<MeshRenderer>().material = material;

        material.SetTexture("_MainTex", _texture);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
