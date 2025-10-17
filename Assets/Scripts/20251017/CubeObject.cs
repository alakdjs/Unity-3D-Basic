using UnityEngine;

public class CubeObject : MonoBehaviour
{
    void Start()
    {
        MakeCube();
    }
    void MakeCube()
    {
        // 정점버퍼에 입력할 Data
        Vector3[] vertices = new Vector3[]
        {
            new Vector3(-1.0f, -1.0f, -1.0f), // 0
            new Vector3(-1.0f, 1.0f, -1.0f), // 1
            new Vector3(1.0f, 1.0f, -1.0f), // 2
            new Vector3(1.0f, -1.0f, -1.0f), // 3

            // 3
            // 2
            new Vector3(1.0f, 1.0f, 1.0f), // 4
            new Vector3(1.0f, -1.0f, 1.0f), // 5

            // 5
            // 4
            new Vector3(-1.0f, 1.0f, 1.0f), // 6
            new Vector3(-1.0f, -1.0f, 1.0f), // 7

            // 6
            // 7
            // 1
            // 0

            // 1
            // 7
            // 4
            // 2

            // 6
            // 0
            // 3
            // 5
        };


        // 인덱스 버퍼에 저장할 Data
        int[] triangles = new int[]
        {
            0, 1, 2,
            0, 2, 3, // 앞

            3, 2, 4, 
            3, 4, 5, // 오

            5, 4, 6, 
            5, 6, 7, // 뒤

            7, 6, 1, 
            7, 1, 0, // 왼

            1, 6, 4, 
            1, 4, 2, // 위

            7, 0, 3, 
            7, 3, 5, // 아래
        };

        Mesh mesh = new Mesh();
        mesh.vertices = vertices;

        mesh.triangles = triangles;

        mesh.RecalculateBounds();
        mesh.RecalculateNormals();

        GetComponent<MeshFilter>().mesh = mesh;

        Material material = new Material(Shader.Find("Custom/NormalMappingShader"));

        GetComponent<MeshRenderer>().material = material;
    }

    void Update()
    {
        
    }
}
