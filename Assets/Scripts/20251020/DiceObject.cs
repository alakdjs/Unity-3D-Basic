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
        // �������ۿ� �Է��� Data
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


        // �ε��� ���ۿ� ������ Data
        int[] triangles = new int[]
        {
            0, 1, 2,
            0, 2, 3, // ��

            4, 5, 6,
            4, 6, 7, // ��

            8, 9, 10,
            8, 10, 11, // ��

            13, 12, 14,
            13, 14, 15, // ��

            16, 17, 18,
            16, 18, 19, // ��

            20, 21, 22,
            20, 22, 23 // �Ʒ�
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
        mesh.vertices = vertices; // �������ۿ� ���� ������ ����
        mesh.triangles = triangles; // �ε������ۿ� �ﰢ�� ���� ����
        mesh.uv = uvs; // �ﰢ���� ���� Texture uv ��ǥ�� ���� ����

        GetComponent<MeshFilter>().mesh = mesh; // MeshFilter ������Ʈ�� ������ �޽����� ����

        Material material = new Material(Shader.Find("Standard")); // ���� ���� ����

        GetComponent<MeshRenderer>().material = material;

        material.SetTexture("_MainTex", _texture);
    }

    void Update()
    {

    }
}
