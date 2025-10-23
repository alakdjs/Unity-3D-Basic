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

    private void Awake() // ������Ʈ�� �����ɶ� �� �� ȣ��
    {
        Debug.Log($"{this.gameObject.name} -- Awake()");
    }

    private void OnEnable() // ������Ʈ�� Ȱ��ȭ �� ��
    {
        Debug.Log($"{this.gameObject.name} -- OnEnable");
    }

    private void OnDisable() // ������Ʈ�� ��Ȱ��ȭ �� �� 
    {
        Debug.Log($"{this.gameObject.name} -- OnDisable");
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() // Update �޼����� �߻��Ǳ� ������ Start �޼����� �� �� �߻�
    {
        Debug.Log($"{this.gameObject.name} -- Start()");
    }

    private void FixedUpdate() // default: 0.02�� ���� �� ���� ȣ��
    {
        if (isFixedUpdate)
        {
            Debug.Log($"{this.gameObject.name} -- isFixedUpdate");
        }
    }

    // Update is called once per frame
    void Update() // �� ������, �ݺ������� ó���� �۾�
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
