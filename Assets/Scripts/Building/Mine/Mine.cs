using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mine : Building
{
    [SerializeField] private int _mineBonus;

    private void Start() 
    {
        StartCoroutine(MineBonus());
    }

    private IEnumerator MineBonus()
    {
        while(true)
        {
            yield return new WaitForSeconds(5f);
            GameResources.Instance.PositiveMoneyChange(_mineBonus);
        }
    }
}
