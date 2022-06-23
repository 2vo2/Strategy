using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Unit : SelectableObject
{
    [SerializeField] private Animator _animator;
    [SerializeField] private NavMeshAgent _navMeshAgent;
    [SerializeField] private int _price;
    
    public int Price => _price;
    
    private void Awake() 
    {
        SetHoverBehaviour(new HoverUnit(transform, _animator));
        OnHover();
        OnUnhover(); 

        SetSelectBehaviour(new SelectUnit(_indecator));
        OnSelect();
        OnUnselect();
    }

    private void Update() 
    {
        if (!_navMeshAgent.pathPending)
        {
            if (_navMeshAgent.remainingDistance <= _navMeshAgent.stoppingDistance)
            {
                if (!_navMeshAgent.hasPath || _navMeshAgent.velocity.sqrMagnitude == 0f)
                {
                    _animator.SetBool("Run", false);
                }
            }
        }   
    }

    public override void MoveToPoitOnGround(Vector3 point)
    {
        _navMeshAgent.SetDestination(point);
        _animator.SetBool("Run", true);
        
    }
}
