using UnityEngine;

public class SquareRotate : MonoBehaviour
{
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

        Mesh mesh = new Mesh();
        mesh.vertices = vertices;
        mesh.triangles = triangles;

        mesh.RecalculateBounds();
        mesh.RecalculateNormals();

        GetComponent<MeshFilter>().mesh = mesh;

        Material material = new Material(Shader.Find("Custom/RotateShader"));

        GetComponent<MeshRenderer>().material = material;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
