using UnityEngine;

public class FrogGun : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject.tag.CompareTo("Frog") == 0)
                {
                    hit.collider.gameObject.GetComponent<FrogCube>().Hit();
                }
            }
        }
    }
}
