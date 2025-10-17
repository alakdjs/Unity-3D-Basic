using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    [SerializeField] private Transform _Target_Object;

    private float _speed = 3.0f;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direct = _Target_Object.position - transform.position;

        this.transform.position += direct.normalized * _speed * Time.deltaTime;
    }
}
