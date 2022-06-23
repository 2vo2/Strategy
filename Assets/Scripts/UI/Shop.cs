using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField] private BuildingPlacer _buildingPlacer;
    [SerializeField] private Building _barrackPrefab;
    [SerializeField] private Building _minePrefab;
    private ButtonFactory<Building> _factory;

    public void TryBuyBarrack()
    {
        _factory = new BarrackButton(_buildingPlacer, _barrackPrefab);
        _factory.ButtonLogic();
    }

    public void TryBuyMine()
    {
        _factory = new MineButton(_buildingPlacer, _minePrefab);
        _factory.ButtonLogic();
    }
}
