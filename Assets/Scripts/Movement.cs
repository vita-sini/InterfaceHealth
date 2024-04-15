using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Movement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private SpriteRenderer spriteRenderer;

    private RunAnimation _animation;

    private void Awake()
    {
        _animation = GetComponent<RunAnimation>();
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        int jumpForce = 3;

        _animation.AnimationRun();

        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(_speed * Time.deltaTime, 0, 0);
            spriteRenderer.flipX = false;
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(_speed * Time.deltaTime * -1, 0, 0);
            spriteRenderer.flipX = true;
        }

        if (Input.GetKey(KeyCode.Space))
        {
            transform.Translate(0, _speed * Time.deltaTime * jumpForce, 0);
        }
    }
}
