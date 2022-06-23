using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineButton : ButtonFactory<Building>
{
    private BuildingPlacer _buildingPlacer;
    private Building _minePrefab;

    public MineButton(BuildingPlacer buildingPlacer, Building buildingPrefab)
    {
        _minePrefab = buildingPrefab;
        _buildingPlacer = buildingPlacer;
    }

    public override Building ButtonLogic()
    {
        int price = _minePrefab.Price;

        if(GameResources.Instance.Money >= price)
        {
            GameResources.Instance.NegativeMoneyChange(price);
            return _buildingPlacer.CreateBuilding(_minePrefab);
        }
        else
            return null;
    }
}
