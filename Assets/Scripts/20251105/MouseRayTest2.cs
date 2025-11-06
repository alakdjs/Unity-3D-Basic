using UnityEngine;

public class MouseRayTest2 : MonoBehaviour
{
    private Transform _targetTr;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            RaycastHit[] hits;

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            hits = Physics.RaycastAll(ray);

            for (int i = 0; i < hits.Length; i++)
            {
                if (i == 0)
                {
                    _targetTr = hits[i].collider.transform;
                }
                else
                {
                    if (_targetTr.position.z < hits[i].collider.transform.position.z)
                    {
                        _targetTr = hits[i].transform;
                    }
                }
            }

            if (_targetTr != null)
            {
                Destroy(_targetTr.gameObject);
            }

            /*
            foreach (var obj in hits)
            {
                Destroy(obj.collider.gameObject);
            }
            */
        }
    }
}
