using UnityEngine;

public class TriggerArea : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    protected virtual void OnStart(Collider col)
    {
        Debug.Log("base.OnStart");
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log($"OnTriggerEnter");
        if (other.CompareTag("Player"))
        {
            OnStart(other);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
