using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Gauge : MonoBehaviour
{
    [SerializeField] private Image _gaugeImageBar;
    [SerializeField] private Text _gaugeText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    void OnEnable()
    {
        StartCoroutine(FillGauge());
    }

    void OnDisable()
    {
        _gaugeImageBar.fillAmount = 0;
    }

    public void SetFillGauge(float value)
    {
        _gaugeImageBar.fillAmount = value;
        _gaugeText.text = value.ToString("N2");
    }

    IEnumerator FillGauge()
    {
        float value = 0.0f;

        while (true)
        {
            yield return new WaitForSeconds(0.1f);

            SetFillGauge(value);

            value += 0.02f;

            if (value > 1.0f)
            {
                value = 1.0f;

                break;
            }

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
