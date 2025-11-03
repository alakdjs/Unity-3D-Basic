using UnityEngine;

public class Cow : PatrolTest
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        this.GetComponent<MeshRenderer>().material.color = Color.blue;
    }

    // Update is called once per frame
    private new void Update()
    {
        base.Update();
    }
}
