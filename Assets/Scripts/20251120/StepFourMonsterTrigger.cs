using UnityEngine;

public class StepFourMonsterTrigger : TriggerArea
{
    [SerializeField] private Transform[] _RegenTr;
    [SerializeField] private MonsterTest _TriggerMonster;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    protected override void OnStart(Collider col)
    {
        base.OnStart(col);

        foreach (var tr in _RegenTr)
        {
            var monster = Instantiate(_TriggerMonster.gameObject, tr.position, tr.rotation);

            monster.GetComponent<MonsterTest>().SetTarget(col.gameObject.transform);
        }
    }

}
