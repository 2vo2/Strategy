using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : State
{
    private Building _building;
    private Animator _animator;

    public AttackState(Animator animator)
    {
        _animator = animator;
    }

    public override void Enter()
    {
        _animator.SetBool("Attack", true);
    }
}
