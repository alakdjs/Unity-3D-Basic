using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RectangleCreate : MonoBehaviour
{
    float _rotSpeed = 40.0f;
    float _angle = 0.0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        MakeRectangle();    
    }

    void MakeRectangle()
    {
        // 정점버퍼에 입력할 정점.
        Vector3[] vertices = new Vector3[]
        {
            new Vector3(-1.0f, -1.0f, 0.0f), // 0
            new Vector3(-1.0f, 1.0f, 0.0f), // 1
            new Vector3(1.0f, 1.0f, 0.0f), // 2
            new Vector3(1.0f, -1.0f, 0.0f), // 3
        };

        // 인덱스 버퍼에 저장할 Data
        int[] triangles = new int[]
        {
            0, 1, 2,
            0, 2, 3
        };

        Mesh mesh = new Mesh();
        mesh.vertices = vertices; // 정점버퍼에 정점 데이터 전달
        mesh.triangles = triangles; // 인덱스버퍼에 폴리곤(삼각형)의 인덱스값을 전달

        mesh.RecalculateBounds();
        mesh.RecalculateNormals();

        GetComponent<MeshFilter>().mesh = mesh;

        Material material = new Material(Shader.Find("Standard"));

        GetComponent<MeshRenderer>().material = material;
    }

    // Update is called once per frame
    void Update()
    {
        _angle += Time.deltaTime * _rotSpeed;
        this.transform.rotation = Quaternion.Euler(0.0f, 0.0f, _angle);
    }
}
