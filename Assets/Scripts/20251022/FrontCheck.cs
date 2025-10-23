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
        // 적을 향하는 벡터를 만든다.
        Vector3 enemyVec = _enemyTr.position - transform.position;

        // transform.forward (로컬좌표계를 기준으로 한 전방벡터)
        float angle = Vector3.Dot(transform.forward, enemyVec.normalized);

        if (angle > 0)
        {
            Debug.Log($"angle = {angle} 적이 앞에 있습니다.\n");
            GetComponent<Renderer>().material.color = Color.red;
        }
        else
        {
            Debug.Log($"angle = {angle} 적이 뒤에 있습니다.\n");
            GetComponent<Renderer>().material.color = Color.white;
        }
    }

    // 적이 위에 있는지, 아래에 있는지 체크하는 메소드 만들기
    void Front_UpDownCheck()
    {
        // 적을 향하는 벡터를 만든다.
        Vector3 enemyVec = _enemyTr.position - transform.position;

        // transform.forward (로컬좌표계를 기준으로 한 벡터)
        float angle = Vector3.Dot(transform.up, enemyVec.normalized);
        float angle2 = Vector3.Dot(transform.forward, enemyVec.normalized);

        if (angle2 > 0.0f)
        {
            if (angle > 0)
            {
                Debug.Log($"angle = {angle} 적이 전방 위에 있습니다.\n");
                GetComponent<Renderer>().material.color = Color.yellow;
            }
            else
            {
                Debug.Log($"angle = {angle} 적이 전방 아래에 있습니다.\n");
                GetComponent<Renderer>().material.color = Color.green;
            }
        }
        else
        {
            if (angle > 0)
            {
                Debug.Log($"angle = {angle} 적이 후방 위에 있습니다.\n");
                GetComponent<Renderer>().material.color = Color.red;
            }
            else
            {
                Debug.Log($"angle = {angle} 적이 후방 아래에 있습니다.\n");
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
