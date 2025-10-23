using UnityEngine;

public class ObjInvokeGo : MonoBehaviour
{
    [SerializeField] private GameObject[] _gameObjects;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        foreach (var obj in _gameObjects)
        {
            obj.GetComponent<CarRaceTest>().Go();
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
