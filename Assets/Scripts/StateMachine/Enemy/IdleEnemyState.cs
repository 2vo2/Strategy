using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleEnemyState : State
{
    private Animator _animator;

    public IdleEnemyState(Animator animator)
    {
        _animator = animator;
    }

    public override void Enter()
    {
        _animator.SetBool("Run", false);
    }
}
