using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Pig : PatrolTest
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        this.GetComponent<MeshRenderer>().material.color = Color.red;
    }

    // Update is called once per frame
    private new void Update()
    {
        base.Update();
    }
}
