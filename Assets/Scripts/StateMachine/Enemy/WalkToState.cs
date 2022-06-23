using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WalkToState : State
{
    private NavMeshAgent _navMeshAgent;
    private Vector3 _position;
    private Animator _animator;

    public WalkToState(NavMeshAgent navMeshAgent,Vector3 position, Animator animator)
    {
        _navMeshAgent = navMeshAgent;
        _position = position;
        _animator = animator;
    }

    public override void Enter()
    {
        _navMeshAgent.SetDestination(_position);
        _animator.SetBool("Run", true);
    }

    public override void Exit()
    {
        //_navMeshAgent.isStopped = true;
        _animator.SetBool("Run", false);
    }
}
