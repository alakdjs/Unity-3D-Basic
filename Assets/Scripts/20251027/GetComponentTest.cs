using UnityEngine;

public class GetComponentTest : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // 1. 동일한 게임오브젝트 상에 있는 component를 불러올 때.
        /*
        var com = this.GetComponent<EatTest>();
        com?.Eat();
        */

        // 2. 동일한 오브젝트 상에 있는 모든 컴포넌트를 불러올 때.
        /*
        var coms = this.GetComponents<EatTest>();

        Debug.Log($"Eat Test Component Count: {coms.Length}");
        
        foreach(var eat in coms)
        {
            eat.Move();
        }
        */

        // 3. 자식오브젝트에 장착된 컴포넌트 포함하여 처음 찾는 컴포넌트 구한다.

        /*
        var com2 = this.GetComponentInChildren<EatTest>();
        com2.Eat();
        */

        // 4. 계층구조상에 자식오브젝트에 장착된 컴포넌트를 모두 찾을 때 사용.
        /*
        var com3 = this.GetComponentsInChildren<EatTest>();
        foreach(var eat in com3)
        {
            eat.Move();
        }
        */

        
        // 5. 계층구조상에 부모 오브젝트에 있는 컴포넌트를 찾을 때.
        var com4 = this.GetComponentInParent<EatTest>();
        com4.Move();
        

        // 6. 계층구조상에 부모오브젝트에 있는 모든 컴포넌트를 찾을 때
        var com5 = this.GetComponentsInParent<EatTest>();
        foreach(var com in com5)
        {
            com4.Move();
        }


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
