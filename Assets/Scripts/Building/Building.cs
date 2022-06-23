using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : SelectableObject
{
    [SerializeField] private int _price;
    [SerializeField] private int _xSize = 3;
    [SerializeField] private int _zSize = 3;
    [SerializeField] private Renderer _renderer;
    [SerializeField] protected GameObject _menu;

    private Color _startColor;

    public int Price => _price;
    public int XSize => _xSize;
    public int ZSize => _zSize;

    private void Awake() 
    {
        SetHoverBehaviour(new HoverBuilding(transform));
        OnHover();
        OnUnhover(); 

        SetSelectBehaviour(new SelectBuilding(_indecator, _menu));
        OnSelect();
        OnUnselect();

        _startColor = _renderer.material.color;
    }

    private void OnDrawGizmos() 
    {
        float cellSize = FindObjectOfType<BuildingPlacer>().CellSize;

        for (int x = 0; x < _xSize; x++)
        {
            for (int z = 0; z < _zSize; z++)
            {
                Gizmos.DrawWireCube(transform.position + new Vector3(x, 0, z) * cellSize, new Vector3(1f, 0f, 1f) * cellSize);
            }
        }
    }

    public void DisplayUnacceptablePosition() => _renderer.material.color = Color.red;

    public void DisplayAcceptablePosition() => _renderer.material.color = _startColor;

    public override void MoveToPoitOnGround(Vector3 point){}
}
