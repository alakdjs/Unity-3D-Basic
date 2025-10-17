using Unity.VisualScripting;
using UnityEngine;

public class SquareDirectionalRotate : MonoBehaviour
{
    [SerializeField] private Texture _DiffuseTexture;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        MakeSquare();
    }

    void MakeSquare()
    {
        // 정점버퍼에 입력할 Data
        Vector3[] vertices = new Vector3[]
        {
            new Vector3(-2.0f, -2.0f, 0.0f), // 0
            new Vector3(-2.0f, 2.0f, 0.0f), // 1
            new Vector3(2.0f, 2.0f, 0.0f), // 2
            new Vector3(2.0f, -2.0f, 0.0f) // 3
        };

        // 인덱스 버퍼에 저장할 Data
        int[] triangles = new int[]
        {
            0, 1, 2,
            0, 2, 3
        };

        // uv 좌표에 저장할 Data
        Vector2[] uvs = new Vector2[]
        {
            new Vector2(0.0f, 0.0f), // 0
            new Vector2(0.0f, 1.0f), // 1
            new Vector2(1.0f, 1.0f), // 2
            new Vector2(1.0f, 0.0f) // 3
        };

        Mesh mesh = new Mesh();
        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.uv = uvs;

        mesh.RecalculateBounds();
        mesh.RecalculateNormals();

        GetComponent<MeshFilter>().mesh = mesh;

        Material material = new Material(Shader.Find("Custom/DirectionalLightShader"));

        GetComponent<MeshRenderer>().material = material;
        material.SetTexture("_DiffuseTex", _DiffuseTexture);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
