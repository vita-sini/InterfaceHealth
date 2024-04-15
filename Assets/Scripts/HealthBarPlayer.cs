using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class HealthBarPlayer : BarPlayer
{
    private void OnEnable()
    {
        Player.HealthChanged += OnValueChanged;
        Slider.fillAmount = 1;
    }

    private void OnDisable()
    {
        Player.HealthChanged -= OnValueChanged;
    }
}
