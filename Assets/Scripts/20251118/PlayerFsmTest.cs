using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFsmTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Contains("Axe"))
        {
            this.gameObject.GetComponent<MeshRenderer>().material.color = Color.red;

        }
        //Debug.Log("Player Damage Enter");
        //Debug.Log($"Weapn name = {collision.gameObject.tag}");
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag.Contains("Axe"))
        {
            this.gameObject.GetComponent<MeshRenderer>().material.color = Color.white;

        }

        //Debug.Log("Player Damage Exit");
    }

}
