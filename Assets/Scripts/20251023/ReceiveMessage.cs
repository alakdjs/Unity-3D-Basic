using UnityEngine;

public class ReceiveMessage : MonoBehaviour
{
    private static int count = 0;
    [SerializeField] private bool _isFlat = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    private void Eat() // Eat 메세지를 받는 메소드
    {
        if (_isFlat)
        {
            Debug.Log($"ReceiveMessage {this.gameObject.name} -- Eat {count++}");
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}
