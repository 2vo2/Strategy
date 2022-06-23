using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameResources : MonoBehaviour
{
    public static GameResources Instance;// плохо
    [SerializeField] private int _money;
    [SerializeField] private Text _moneyText;

    public int Money => _money;

    private void Awake() 
    {
        if(Instance == null)
            Instance = this;
        else if(Instance == this) 
            Destroy(gameObject);    
    }

    private void Start() 
    {
        _moneyText.text = _money.ToString();    
    }

    public void NegativeMoneyChange(int price)
    {
        if(price < 0)
            return;

        _money -= price;
        _moneyText.text = _money.ToString();
    }

    public void PositiveMoneyChange(int price)
    {
        if(price < 0)
            return;

        _money += price;
        _moneyText.text = _money.ToString();
    }
}
