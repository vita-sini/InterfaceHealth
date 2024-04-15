using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BarPlayer : MonoBehaviour
{
    [SerializeField] protected Image Slider;
    [SerializeField] protected Player Player;

    public TMP_Text HealthText;

    private float _step = 0.1f;
    private Coroutine _coroutine;

    private void Start()
    {
        HealthText.text = Player.CurrentHealth.ToString() + "/" + Player.HealthMax.ToString();
    }

    public void OnValueChanged(int value, int maxValue)
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);

        float targetValue = (float)value / maxValue;
        _coroutine = StartCoroutine(ChangeBar(targetValue));
    }

    private IEnumerator ChangeBar(float targetValue)
    {
        while (Slider.fillAmount != targetValue)
        {
            Slider.fillAmount = Mathf.MoveTowards(Slider.fillAmount, targetValue, _step * Time.deltaTime);
            HealthText.text = Player.CurrentHealth.ToString() + "/" + Player.HealthMax.ToString();

            yield return null;
        }
    }
}
