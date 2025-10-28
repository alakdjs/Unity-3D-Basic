using UnityEngine;

public class RandomTest : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // 랜덤관련 메소드
        float randomValue = Random.value; // 0.0f ~ 1.0f
        Debug.Log($"randomValue = {randomValue}");

        int randomRangeInt = Random.Range(0, 100); // 0 ~ 99 사이의 값을 랜덤값으로 돌려줌 (100은 포함되지 않습니다.)
        Debug.Log($"randomRangeInt = {randomRangeInt}");

        float randomRangeFlost = Random.Range(0.0f, 100.0f); // 0.0f ~ 100.0f (100.0f은 미포함)
        int randomValue2 = (int)(randomRangeInt * 1000.0f);

        // ..........................
        Vector2 randomInsideUnitCircle = Random.insideUnitCircle; // 반지름이 1.0인 원 안쪽의 좌표를 돌려줌.
        Debug.Log($"randomInsideUnitCircle = {randomInsideUnitCircle}");

        Quaternion randomRotation = Random.rotation; // 랜덤 회전값을 돌려줌.
        Debug.Log($"randomRotation = {randomRotation.eulerAngles}");

        Color randomColor = Random.ColorHSV(); // 랜덤으로 컬러값을 돌려줌
        this.GetComponent<MeshRenderer>().material.color = randomColor;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
