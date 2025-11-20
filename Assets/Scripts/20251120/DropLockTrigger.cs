using UnityEngine;

public class DropLockTrigger : TriggerArea
{
    [SerializeField] private GameObject _DropLockPrefab;

    private GameObject _DropLock;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    void DropLock()
    {
        Vector3 dropPosition = this.transform.position;
        dropPosition.y += 10;

        _DropLock = Instantiate(_DropLockPrefab);
        _DropLock.GetComponent<Transform>().position = dropPosition;
        _DropLock.GetComponent<Transform>().rotation = Quaternion.identity;
        _DropLock.GetComponent<Rigidbody>().useGravity = true;
    }

    protected override void OnStart(Collider col)
    {
        base.OnStart(col);

        DropLock();

    }

}
