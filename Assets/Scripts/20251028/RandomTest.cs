using UnityEngine;

public class RandomTest : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // �������� �޼ҵ�
        float randomValue = Random.value; // 0.0f ~ 1.0f
        Debug.Log($"randomValue = {randomValue}");

        int randomRangeInt = Random.Range(0, 100); // 0 ~ 99 ������ ���� ���������� ������ (100�� ���Ե��� �ʽ��ϴ�.)
        Debug.Log($"randomRangeInt = {randomRangeInt}");

        float randomRangeFlost = Random.Range(0.0f, 100.0f); // 0.0f ~ 100.0f (100.0f�� ������)
        int randomValue2 = (int)(randomRangeInt * 1000.0f);

        // ..........................
        Vector2 randomInsideUnitCircle = Random.insideUnitCircle; // �������� 1.0�� �� ������ ��ǥ�� ������.
        Debug.Log($"randomInsideUnitCircle = {randomInsideUnitCircle}");

        Quaternion randomRotation = Random.rotation; // ���� ȸ������ ������.
        Debug.Log($"randomRotation = {randomRotation.eulerAngles}");

        Color randomColor = Random.ColorHSV(); // �������� �÷����� ������
        this.GetComponent<MeshRenderer>().material.color = randomColor;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
