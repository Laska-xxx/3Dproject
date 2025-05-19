using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MoneyController : MonoBehaviour
{
    [SerializeField] int MoneyReward;
    [SerializeField] TextMeshProUGUI MoneyCounterText;
    int balanceMoney;

    public void AddMoney()
    {
        balanceMoney += MoneyReward;
        MoneyCounterText.text = "Money: " + balanceMoney.ToString();
    }
}
