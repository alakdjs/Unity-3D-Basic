using UnityEngine;

public class OneContinueMonsterTrigger : TriggerArea
{
    [SerializeField] private Transform _RegenTr;
    [SerializeField] private MonsterTest _TriggerMonster;

    private static int _limitedMonsterCount = 3;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    private void CreateMonster(Collider col)
    {
        var monster = Instantiate(_TriggerMonster.gameObject, _RegenTr.position, _RegenTr.rotation);

        monster.GetComponent<MonsterTest>().SetTarget(col.gameObject.transform);
    }

    protected override void OnStart(Collider col)
    {
        base.OnStart(col);

        if (col.gameObject.tag.Contains("Player"))
        {
            if (_limitedMonsterCount-- > 0)
            {
                CreateMonster(col);
            }
        }

    }
}
