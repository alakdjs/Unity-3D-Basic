using System.Collections;
using UnityEngine;

public class ThreeMonsterTrigger : TriggerArea
{
    [SerializeField] private Transform[] _RegenTr;
    [SerializeField] private MonsterTest _TriggerMonster;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    IEnumerator CreateMonster(Collider col)
    {
        foreach (var tr in _RegenTr)
        {
            var monster = Instantiate(_TriggerMonster.gameObject, tr.position, tr.rotation);

            monster.GetComponent<MonsterTest>().SetTarget(col.gameObject.transform);

            yield return new WaitForSeconds(1.0f);
        }
    }

    protected override void OnStart(Collider col)
    {
        base.OnStart(col);

        StartCoroutine(CreateMonster(col));
    }

}
