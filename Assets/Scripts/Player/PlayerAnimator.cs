using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]

public class PlayerAnimator : MonoBehaviour
{
    private Animator _animator;

    public static class Stats
    {
        public const string IsMove = "IsMove";
        public const string Hit = "Hit";
    }

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void StartMove()
    {
        _animator.SetBool(Stats.IsMove, true);
    }

    public void StopMove()
    {
        _animator.SetBool(Stats.IsMove, false);
    }

    public void TakeDamage()
    {
        _animator.SetTrigger(Stats.Hit);
    }
}
