using UnityEngine;

public class LeftRightCheck : MonoBehaviour
{
    [SerializeField] private Transform _enemyTr;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    void LeftRight()
    {
        Vector3 enemyVec = _enemyTr.position - transform.position;
        Vector3 nVector = Vector3.Cross(transform.forward, enemyVec); // ¿ÜÀû

        float angle = Vector3.Dot(Vector3.up, nVector);

        if(angle > 0)
        {
            _enemyTr.GetComponent<MeshRenderer>().material.color = Color.blue;
        }
        else
        {
            _enemyTr.GetComponent<MeshRenderer>().material.color= Color.red;
        }
    }

    // Update is called once per frame
    void Update()
    {
        LeftRight();
    }
}
