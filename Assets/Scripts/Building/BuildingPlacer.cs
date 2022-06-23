using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingPlacer : MonoBehaviour
{
    [SerializeField] private float _cellSize;
    [SerializeField] private Camera _rayCastCamera;
    
    private Dictionary<Vector2Int, Building> _buildingDictionary = new Dictionary<Vector2Int, Building>();
    private List<Building> _buildingsInScene = new List<Building>();
    private Plane _plane;
    private Building _currentBuilding;

    public List<Building> BuildingsInScene => _buildingsInScene;
    public float CellSize => _cellSize;
    
    private void Start() 
    {
        _plane = new Plane(Vector3.up, Vector3.zero);    
    }

    private void Update() 
    {
        if(_currentBuilding == null)
            return;

        Ray ray = _rayCastCamera.ScreenPointToRay(Input.mousePosition);

        float distance;
        _plane.Raycast(ray, out distance);
        Vector3 point = ray.GetPoint(distance) / _cellSize;

        int roundX = Mathf.RoundToInt(point.x);
        int roundZ = Mathf.RoundToInt(point.z);

        _currentBuilding.transform.position = new Vector3(roundX, 0, roundZ) * _cellSize;

        if(CheckAllow(roundX, roundZ, _currentBuilding))
        {
            _currentBuilding.DisplayAcceptablePosition();

            if(Input.GetMouseButtonDown(0))
            {
                InstallBuilding(roundX, roundZ, _currentBuilding);
                _buildingsInScene.Add(_currentBuilding);
                _currentBuilding = null;
            }
        }
        else
        {
            _currentBuilding.DisplayUnacceptablePosition();
        }
    }

    private bool CheckAllow(int xPosition, int zPosition, Building building)
    {
        for (int x = 0; x < building.XSize; x++)
        {
            for (int z = 0; z < building.ZSize; z++)
            {
                Vector2Int coordinate = new Vector2Int(xPosition + x, zPosition + z);
                if(_buildingDictionary.ContainsKey(coordinate))
                {
                    return false;
                }
            }
        }

        return true;
    }

    private void InstallBuilding(int xPosition, int zPosition, Building building)
    {
        for (int x = 0; x < building.XSize; x++)
        {
            for (int z = 0; z < building.ZSize; z++)
            {
                Vector2Int coordinate = new Vector2Int(xPosition + x, zPosition + z);
                _buildingDictionary.Add(coordinate, _currentBuilding);
            }
        }
    }

    public Building CreateBuilding(Building buildingPrefab)
    {
        Building newBuilding = Instantiate(buildingPrefab);
        _currentBuilding = newBuilding;

        return newBuilding;
    }
}
