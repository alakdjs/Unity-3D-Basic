using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponTest : MonoBehaviour
{
    [SerializeField] private BoxCollider _myCollider;

    // Start is called before the first frame update
    void Start()
    {
        _myCollider.enabled = false;
    }

    public void TurnOnCollider()
    {
        _myCollider.enabled = true;
    }


    public void TurnOffCollider()
    {
        _myCollider.enabled = false;
    }
    // Update is called once per frame
    void Update()
    {

    }
}
