using UnityEngine;

public class OnCollsionTest : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    private void OnCollisionEnter(Collision collision) // 충돌 순간
    {
        if ((collision.collider.tag.Contains("CollisionTest")))
        {
            Debug.Log("OnCollisionEnter");
        }
    }

    private void OnCollisionStay(Collision collision) // 충돌 유지
    {
        if ((collision.collider.tag.Contains("CollisionTest")))
        {
            Debug.Log("OnCollisionStay");
        }
    }

    private void OnCollisionExit(Collision collision) // 충돌 해소
    {
        if ((collision.collider.tag.Contains("CollisionTest")))
        {
            Debug.Log("OnCollisionExit");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
