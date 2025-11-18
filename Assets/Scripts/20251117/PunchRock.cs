using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PunchRock : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Punch")
        {
            Destroy(this.gameObject);
        }
    }


}
