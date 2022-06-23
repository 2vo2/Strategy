using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectUnit : ISelect
{
    private GameObject _indecator;

    public SelectUnit(GameObject indecator) => _indecator = indecator;

    public void Select() => _indecator.SetActive(true);

    public void Unselect() => _indecator.SetActive(false);
}
