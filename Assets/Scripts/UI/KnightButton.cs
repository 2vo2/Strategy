using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightButton : ButtonFactory<Unit>
{
    private Transform _spawnPoint;
    private Unit _unitPrefab;

    public KnightButton(Transform spawnPoint, Unit unitPrefab)
    {
        _spawnPoint = spawnPoint;
        _unitPrefab = unitPrefab;
    }

    public override Unit ButtonLogic()
    {
        if(GameResources.Instance.Money >= _unitPrefab.Price)
        {
            var spawnedUnit = Instantiate(_unitPrefab, _spawnPoint.position, Quaternion.identity);
            GameResources.Instance.NegativeMoneyChange(_unitPrefab.Price);
            Vector3 position = _spawnPoint.position + new Vector3(Random.Range(1.5f, -1.5f), 0f, Random.Range(1.5f, -1.5f));
            spawnedUnit.MoveToPoitOnGround(position);
            return spawnedUnit;
        }
        else
            return null;
    }
}
