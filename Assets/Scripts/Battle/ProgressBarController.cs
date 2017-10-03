using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[RequireComponent(typeof(Image))]
public class ProgressBarController : MonoBehaviour
{
    [SerializeField]
    Image gaugeImage;

    float minValue = 0;
    float maxValue = 100;
    float currentValue;
    float newValue;
    bool isInitialized = false;
    [SerializeField]
    float tick;

    public void Init(int initValue)
    {
        if (isInitialized)
        {
            StartCoroutine(AddingAnimation(initValue));
            return;
        }


        this.maxValue = initValue;
        isInitialized = true;
    }

    public void AddOne()
    {
        StartCoroutine(AddingAnimation(5));
    }

    public void Add(int i)
    {
        StartCoroutine(AddingAnimation(i));
    }

    IEnumerator SetAnimation(float i)
    {
        float valueToAddOnTick = i / tick;
        while (currentValue == i)
        {
            currentValue += tick;
            gaugeImage.fillAmount = currentValue / maxValue;
            if (currentValue >= maxValue)
                currentValue = 0;
            yield return null;
        }
    }

    IEnumerator AddingAnimation(float i)
    {
        float valueToAddOnTick = i / tick;
        while (valueToAddOnTick > 0)
        {
            currentValue += tick;
            valueToAddOnTick--;
            gaugeImage.fillAmount = currentValue / maxValue;
            if (currentValue >= maxValue)
                currentValue = 0;
            yield return null;
        }
    }

    public void UpdateScroll(double i, double max)
    {
        UpdateScroll((float)i, (float)max);
    }

    public void UpdateScroll(float i, float max)
    {
        if (max != 0)
            gaugeImage.fillAmount = i / max;
    }

    public void UpdateToMax()
    {
        UpdateScroll(1, 1);
    }
}
