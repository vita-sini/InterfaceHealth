using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarEnemy : BarEnemy
{
    private void OnEnable()
    {
        Enemy.HealthChanged += OnValueChanged;
        Slider.fillAmount = 1;
    }

    private void OnDisable()
    {
        Enemy.HealthChanged -= OnValueChanged;
    }
}
