using Mono.Cecil;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using UnityEngine;
using UnityEngine.Events;
using static UnityEngine.GraphicsBuffer;

[RequireComponent(typeof(Patrolling))]
public class Enemy : MonoBehaviour
{
    [SerializeField] Transform targetPlayer;
    [SerializeField] SpriteRenderer _spriteRenderer;
    [SerializeField] private Enemy _enemy;

    Patrolling patrolling;

    public LayerMask layerMask;

    public Vector2 DetectorSize = Vector2.one;

    private int _healthMax = 10;

    private int _currentHealth;

    private Vector3 previousPosition;

    public int HealthMax => _healthMax;
    public int CurrentHealth => _currentHealth;

    public event UnityAction<int, int> HealthChanged;

    private void Awake()
    {
        _currentHealth = _healthMax;
    }

    private void Start()
    {
        patrolling = GetComponent<Patrolling>();

        previousPosition = _enemy.transform.position;
    }

    private void Update()
    {
        Vector3 currentPosition = _enemy.transform.position;

        Collider2D collider = Physics2D.OverlapBox(transform.position, DetectorSize, 0, layerMask);

        if (collider != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPlayer.position, patrolling._speed * Time.deltaTime);
        }
        else
        {
            patrolling.Patrol();
        }

        if (currentPosition.x > previousPosition.x)
            _spriteRenderer.flipX = true;
        else
            _spriteRenderer.flipX = false;


        previousPosition = currentPosition;
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
