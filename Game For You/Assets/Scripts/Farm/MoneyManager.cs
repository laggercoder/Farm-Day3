using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MoneyManager : MonoBehaviour
{
    public float money = 0;
    public float AddMoney(float moneyAdd)
    {
       return money += moneyAdd;
    }
    public float PreviousMoney(float moneyPrv)
    {
        if (money <= 0) return 0;
        if (money < moneyPrv) return money;
        return money -= moneyPrv;
    }
}
