using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BarrackButton : ButtonFactory<Building>
{
    private BuildingPlacer _buildingPlacer;
    private Building _barrackPrefab;

    public BarrackButton(BuildingPlacer buildingPlacer, Building buildingPrefab)
    {
        _barrackPrefab = buildingPrefab;
        _buildingPlacer = buildingPlacer;
    }

    public override Building ButtonLogic()
    {
        int price = _barrackPrefab.Price;

        if(GameResources.Instance.Money >= price)
        {
            GameResources.Instance.NegativeMoneyChange(price);
            return _buildingPlacer.CreateBuilding(_barrackPrefab);
        }
        else
            return null;
    }
}
