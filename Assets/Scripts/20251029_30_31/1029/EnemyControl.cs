using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum EnemyType
{
    Pig,
    Cow,
    AllMove,
    AllStop
};

public class EnemyControl : MonoBehaviour
{
    [SerializeField] private EnemyType _type = EnemyType.AllMove;

    List<PatrolTest> _enemyList = new List<PatrolTest>();

    PatrolTest[] _objs;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _objs = GetComponentsInChildren<PatrolTest>();
        Debug.Log($"obj.Length = {_objs.Length}");
    }

    // Update is called once per frame
    void Update()
    {
        switch(_type)
        {
            case EnemyType.Cow:
                foreach (var obj in _objs)
                {
                    if (obj.GetType() == typeof(Pig))
                    {
                        obj.Stop();
                    }
                    else
                    {
                        obj.Move();
                    }
                }
                break;

            case EnemyType.Pig:
                foreach (var obj in _objs)
                {
                    if (obj.GetType() == typeof(Cow))
                    {
                        obj.Stop();
                    }
                    else
                    {
                        obj.Move();
                    }
                }
                break;

            case EnemyType.AllMove:
                foreach (var obj in _objs)
                {
                    obj.Move();
                }
                break;

            case EnemyType.AllStop:
                foreach (var obj in _objs)
                {
                    obj.Stop();
                }
                break;
        }
    }
}
