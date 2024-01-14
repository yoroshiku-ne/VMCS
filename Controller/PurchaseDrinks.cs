using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurchaseDrinks : MonoBehaviour
{
    public void checkAvailability(int drinksQuantity, string drinksBrand)
    {
        //dosomemethod
    }

    public void checkCoinSufficiency(float drinksPrice, Coin coin)
    {
        //dosomemethod
    }

    public float checkChangeAmount(Drink drink, Transaction transaction)
    {
        float changeRequired = 0.00f;

        //dosomemethod

        return changeRequired;
    }

    public Coin changeAvailability(float changeRequired)
    {
        Coin coin = new Coin();

        //dosomemethod

        return coin;
    }
}
