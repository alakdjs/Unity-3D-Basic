using UnityEngine;

public class EventMessageTest : MonoBehaviour
{
    [SerializeField] private bool isUpdate = false;
    [SerializeField] private bool isFixedUpdate = false;
    [SerializeField] private bool isLateUpdate = false;

    private void Reset()
    {
        Debug.Log($"{this.gameObject.name} -- Reset");
        isUpdate = false;
        isFixedUpdate = false;
        isLateUpdate = false;
    }

    private void Awake() // 컴포넌트가 생성될때 한 번 호출
    {
        Debug.Log($"{this.gameObject.name} -- Awake()");
    }

    private void OnEnable() // 컴포넌트가 활성화 될 때
    {
        Debug.Log($"{this.gameObject.name} -- OnEnable");
    }

    private void OnDisable() // 컴포넌트가 비활성화 될 때 
    {
        Debug.Log($"{this.gameObject.name} -- OnDisable");
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() // Update 메세지가 발생되기 직전에 Start 메세지가 한 번 발생
    {
        Debug.Log($"{this.gameObject.name} -- Start()");
    }

    private void FixedUpdate() // default: 0.02초 마다 한 번씩 호출
    {
        if (isFixedUpdate)
        {
            Debug.Log($"{this.gameObject.name} -- isFixedUpdate");
        }
    }

    // Update is called once per frame
    void Update() // 매 프레임, 반복적으로 처리할 작업
    {
        if (isUpdate)
        {
            Debug.Log($"{this.gameObject.name} -- isUpdate");
        }
    }

    private void LateUpdate()
    {
        if (isLateUpdate)
        {
            Debug.Log($"{this.gameObject.name} -- isLateUpdate");
        }
    }
}
