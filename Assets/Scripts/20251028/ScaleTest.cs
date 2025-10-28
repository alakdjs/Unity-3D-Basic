using UnityEngine;

public class ScaleTest : MonoBehaviour
{
    void Start()
    {
        /*
        this.transform.localScale = new Vector3(4.0f, 4.0f, 4.0f);
        Debug.Log($"lossyScale = {this.transform.lossyScale}");
        // lossyScale�� �б⸸ ���� �������� ������ ��

        Debug.Log($"localScale = {this.transform.localScale}"); 
        // localScale�� �б�, ���� ���� ����� ������ ��
        */

        GameObject parentObj = GameObject.Find("Cube");

        this.transform.SetParent(parentObj.transform); //  �θ������Ʈ�� �ڽĿ�����Ʈ�� Attach
        Debug.Log($"lossyScale = {this.transform.lossyScale}"); // lossyScale�� �б⸸ ���� �������� ������ ��
        Debug.Log($"localScale = {this.transform.localScale}"); //  localScale�� �б�, ���� ���� ����� ������ ��


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
