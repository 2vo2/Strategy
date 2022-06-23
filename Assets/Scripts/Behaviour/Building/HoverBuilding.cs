using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoverBuilding : IHover
{
    private Transform _transform;

    public HoverBuilding(Transform transform)
    {
        _transform = transform;
    } 

    public void Hover()
    {
        _transform.localScale = new Vector3(1f, 1.1f, 1f);
    }

    public void Unhover()
    {
        _transform.localScale = new Vector3(1f, 1f, 1f);
    }
}
