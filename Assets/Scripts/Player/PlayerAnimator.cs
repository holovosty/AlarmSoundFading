using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]

public class PlayerAnimator : MonoBehaviour
{
    private Animator _animator;

    private const string _isMove = "IsMove";
    private const string _hit = "Hit";


    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void StartMove()
    {
        _animator.SetBool(_isMove, true);
    }

    public void StopMove()
    {
        _animator.SetBool(_isMove, false);
    }

    public void TakeDamage()
    {
        _animator.SetTrigger(_hit);
    }
}
