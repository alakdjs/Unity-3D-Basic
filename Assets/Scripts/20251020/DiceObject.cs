using UnityEngine;

public class DiceObject : MonoBehaviour
{
    [SerializeField] private Texture _texture;

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

            new Vector3(1.0f, -1.0f, -1.0f), // 3 > 4
            new Vector3(1.0f, 1.0f, -1.0f), // 2 > 5
            new Vector3(1.0f, 1.0f, 1.0f), // 4 > 6
            new Vector3(1.0f, -1.0f, 1.0f), // 5 > 7

            new Vector3(1.0f, -1.0f, 1.0f), // 5 > 7 > 8
            new Vector3(1.0f, 1.0f, 1.0f), // 4 > 6 > 9
            new Vector3(-1.0f, 1.0f, 1.0f), // 6 > 10
            new Vector3(-1.0f, -1.0f, 1.0f), // 7 > 11

            new Vector3(-1.0f, 1.0f, 1.0f), // 6 > 10 > 12
            new Vector3(-1.0f, -1.0f, 1.0f), // 7 > 11 > 13
            new Vector3(-1.0f, 1.0f, -1.0f), // 1 > 14
            new Vector3(-1.0f, -1.0f, -1.0f), // 0 > 15

            new Vector3(-1.0f, 1.0f, -1.0f), // 1 > 14 > 16
            new Vector3(-1.0f, 1.0f, 1.0f), // 6 > 10 > 12 > 17
            new Vector3(1.0f, 1.0f, 1.0f), // 4 > 6 > 9 > 18
            new Vector3(1.0f, 1.0f, -1.0f), // 2 > 5 > 19

            new Vector3(-1.0f, -1.0f, 1.0f), // 7 > 11 > 13 > 20
            new Vector3(-1.0f, -1.0f, -1.0f), // 0 > 15 > 21
            new Vector3(1.0f, -1.0f, -1.0f), // 3 > 4 > 22
            new Vector3(1.0f, -1.0f, 1.0f), // 5 > 7 > 8 > 23
        };


        // 인덱스 버퍼에 저장할 Data
        int[] triangles = new int[]
        {
            0, 1, 2,
            0, 2, 3, // 앞

            4, 5, 6,
            4, 6, 7, // 오

            8, 9, 10,
            8, 10, 11, // 뒤

            13, 12, 14,
            13, 14, 15, // 왼

            16, 17, 18,
            16, 18, 19, // 위

            20, 21, 22,
            20, 22, 23 // 아래
        };

        Vector2[] uvs = new Vector2[]
        {
            new Vector3(0.0f, 0.0f), // 0
            new Vector3(0.0f, 0.33333f), // 1
            new Vector3(0.5f, 0.33333f), // 2
            new Vector3(0.5f, 0.0f), // 3

            new Vector3(0.0f, 0.33333f), // 4
            new Vector3(0.0f, 0.66666f), // 5
            new Vector3(0.5f, 0.66666f), // 6
            new Vector3(0.5f, 0.33333f), // 7

            new Vector3(0.0f, 0.66666f), // 8
            new Vector3(0.0f, 1.0f), // 9
            new Vector3(0.5f, 1.0f), // 10
            new Vector3(0.5f, 0.66666f), // 11
            
            new Vector3(0.5f, 1.0f), // 12
            new Vector3(0.5f, 0.66666f), // 13
            new Vector3(1.0f, 1.0f), // 15
            new Vector3(1.0f, 0.66666f), // 14
           
            new Vector3(0.5f, 0.66666f), // 16
            new Vector3(0.5f, 0.33333f), // 17
            new Vector3(1.0f, 0.33333f), // 18
            new Vector3(1.0f, 0.66666f), // 19

            new Vector3(0.5f, 0.33333f), // 20
            new Vector3(0.5f, 0.0f), // 21
            new Vector3(1.0f, 0.0f), // 22
            new Vector3(1.0f, 0.33333f) // 23
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

    void Update()
    {

    }
}
