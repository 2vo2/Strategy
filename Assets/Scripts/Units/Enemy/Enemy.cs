using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [SerializeField] private NavMeshAgent _navMeshAgent;
    [SerializeField] private Animator _animator;
    [SerializeField] private float _distanceToAttack;
    private Building _closesBuilding;
    private StateMachine _stateMachine;
    private BuildingPlacer _buildingPlacer;

    private void Start() 
    {
        _buildingPlacer = FindObjectOfType<BuildingPlacer>();
        _stateMachine = new StateMachine();
        _stateMachine.Initialize(new IdleEnemyState(_animator));    
    }

    private void Update() 
    {
        FindClosesBuilding();
        if(_closesBuilding != null)
        {
            _stateMachine.ChangeState(new WalkToState(_navMeshAgent, _closesBuilding.transform.position, _animator));
            
            float distance = Vector3.Distance(transform.position, _closesBuilding.transform.position);
            
            if(distance < _distanceToAttack)
            {
                _stateMachine.ChangeState(new AttackState(_animator));
            }   
        }
    }

    private Building FindClosesBuilding()
    {
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;

        foreach (Building building in _buildingPlacer.BuildingsInScene)
        {
            Vector3 differenceVectors = building.transform.position - position;
            float currentDistance = differenceVectors.sqrMagnitude;
            if(currentDistance < distance)
            {
                _closesBuilding = building;
                distance = currentDistance;
            }   
        }

        return _closesBuilding;
    }
}
