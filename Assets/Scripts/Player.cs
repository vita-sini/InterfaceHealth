using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private int _damage;

    private int _healthMax = 10;

    private int _currentHealth;

    public int HealthMax => _healthMax;
    public int CurrentHealth => _currentHealth;

    public event UnityAction<int, int> HealthChanged;

    private void Awake()
    {
        _currentHealth = _healthMax;
    }

    public void Healing(int health)
    {
        HealthChanged?.Invoke(_currentHealth, _healthMax);

        if (_currentHealth < _healthMax)
            _currentHealth += health;
    }

    public void ApplyDamage(int damage)
    {
        _currentHealth -= damage;

        HealthChanged?.Invoke(_currentHealth, _healthMax);
    }
}
