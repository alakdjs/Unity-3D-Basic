using UnityEngine;

public class FrontCheck : MonoBehaviour
{
    [SerializeField] private Transform _enemyTr;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    void Front_Check()
    {
        // ���� ���ϴ� ���͸� �����.
        Vector3 enemyVec = _enemyTr.position - transform.position;

        // transform.forward (������ǥ�踦 �������� �� ���溤��)
        float angle = Vector3.Dot(transform.forward, enemyVec.normalized);

        if (angle > 0)
        {
            Debug.Log($"angle = {angle} ���� �տ� �ֽ��ϴ�.\n");
            GetComponent<Renderer>().material.color = Color.red;
        }
        else
        {
            Debug.Log($"angle = {angle} ���� �ڿ� �ֽ��ϴ�.\n");
            GetComponent<Renderer>().material.color = Color.white;
        }
    }

    // ���� ���� �ִ���, �Ʒ��� �ִ��� üũ�ϴ� �޼ҵ� �����
    void Front_UpDownCheck()
    {
        // ���� ���ϴ� ���͸� �����.
        Vector3 enemyVec = _enemyTr.position - transform.position;

        // transform.forward (������ǥ�踦 �������� �� ����)
        float angle = Vector3.Dot(transform.up, enemyVec.normalized);
        float angle2 = Vector3.Dot(transform.forward, enemyVec.normalized);

        if (angle2 > 0.0f)
        {
            if (angle > 0)
            {
                Debug.Log($"angle = {angle} ���� ���� ���� �ֽ��ϴ�.\n");
                GetComponent<Renderer>().material.color = Color.yellow;
            }
            else
            {
                Debug.Log($"angle = {angle} ���� ���� �Ʒ��� �ֽ��ϴ�.\n");
                GetComponent<Renderer>().material.color = Color.green;
            }
        }
        else
        {
            if (angle > 0)
            {
                Debug.Log($"angle = {angle} ���� �Ĺ� ���� �ֽ��ϴ�.\n");
                GetComponent<Renderer>().material.color = Color.red;
            }
            else
            {
                Debug.Log($"angle = {angle} ���� �Ĺ� �Ʒ��� �ֽ��ϴ�.\n");
                GetComponent<Renderer>().material.color = Color.blue;
            }
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        Front_Check();
        Front_UpDownCheck();
    }
}
