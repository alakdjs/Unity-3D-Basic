using UnityEngine;

public class EatTest : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    public void Eat()
    {
        this.gameObject.SetActive(false);
    }

    public void Move()
    {
        this.transform.position += new Vector3(1.0f, 0.0f, 0.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
