using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Highlighter : MonoBehaviour
{
    [SerializeField] private Camera _mainCamera;
    private SelectableObject _hovered;
    private RaycastHit _hit;
    public SelectableObject Hovered => _hovered;
    public RaycastHit Hit => _hit;

    private void Update() 
    {
        Ray ray = _mainCamera.ScreenPointToRay(Input.mousePosition);

        if(Physics.Raycast(ray, out _hit))
        {
            if(_hit.collider.TryGetComponent(out SelectableCollider selectableCollider))
            {
                SelectableObject hitSelectable = selectableCollider.SelectableObject;
                if(_hovered)
                {
                    if(_hovered != hitSelectable)
                    {
                        _hovered.OnUnhover();
                        _hovered = hitSelectable;
                        _hovered.OnHover();
                    }
                }
                else
                {
                    _hovered = hitSelectable;
                    _hovered.OnHover();
                }
            }
            else
                UnhoverCurrent();    
        }
        else
            UnhoverCurrent();
    }

    private void UnhoverCurrent()
    {
        if(_hovered)
        {
            _hovered.OnUnhover();
            _hovered = null;
        }
    }
}
