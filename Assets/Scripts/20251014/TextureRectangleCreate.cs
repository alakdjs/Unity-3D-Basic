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
        // ���� ���ۿ� �Է��� ���� ������
        Vector3[] vertices = new Vector3[]
        {
            new Vector3(-1.0f, -1.0f, 0.0f), // 0
            new Vector3(-1.0f, 1.0f, 0.0f), // 1
            new Vector3(1.0f, 1.0f, 0.0f), // 2
            new Vector3(1.0f, -1.0f, 0.0f), // 3
            new Vector3(0.0f, 2.0f, 0.0f)
        };

        // �ε������ۿ� ������ �ﰢ�� Data
        int[] triangles = new int[]
        {
            0, 1, 2,
            0, 2, 3,
            1, 4, 2
        };

        // uv ��ǥ�� ������ Data
        Vector2[] uvs = new Vector2[]
        {
            new Vector2(0.0f, 0.0f),
            new Vector2(0.0f, 1.0f),
            new Vector2(1.0f, 1.0f),
            new Vector2(1.0f, 0.0f),
            new Vector2(0.5f, 1.25f),
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
    // Update is called once per frame
    void Update()
    {
        
    }
}
