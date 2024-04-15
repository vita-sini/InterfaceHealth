using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class RunAnimation : MonoBehaviour
{
    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            _animator.Play("Attack1");
        }
    }

    public void AnimationRun()
    {
        _animator.SetFloat("Run", Mathf.Abs(Input.GetAxisRaw("Horizontal")));
    }
}
