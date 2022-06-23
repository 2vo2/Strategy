using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectBuilding : ISelect
{
    private GameObject _indecator;
    private GameObject _menu;

    public SelectBuilding(GameObject indecator, GameObject menu)
    {
        _indecator = indecator;
        _menu = menu;
    }

    public void Select()
    {
        _indecator.SetActive(true);
        _menu.SetActive(true);
    }

    public void Unselect()
    {
        _indecator.SetActive(false);
        _menu.SetActive(false);
    }
}
