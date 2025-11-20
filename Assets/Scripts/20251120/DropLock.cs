using System.Collections;
using UnityEngine;

public class DropLock : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine("Destruct");
    }

    IEnumerator Destruct()
    {
        yield return new WaitForSeconds(3.0f);

        Destroy(this.gameObject);
    }

}
