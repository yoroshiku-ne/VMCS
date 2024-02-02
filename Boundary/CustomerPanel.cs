using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class CustomerPanel : MonoBehaviour
{
    public PurchaseDrinks purchaseDrinks;
    public void Start()
    {
        PurchaseDrinks pd = new PurchaseDrinks();
        List<Drink> drinkList = pd.loadDrink();
        Debug.Log(drinkList);
    }
    public void selectDrinksBrand(string selectedDrinksBrand)
    {
        PurchaseDrinks pd = new PurchaseDrinks();
        bool availability = pd.checkDrinksAvailability(selectedDrinksBrand);
        if(availability == true)
        {
            Debug.Log("Available");
        }
        else
        {
            Debug.Log("Unavailable");
        }
        Debug.Log(availability);
    }
    public void displayDrinksPrice(string selectedDrinksBrand)
    {
        PurchaseDrinks pd = new PurchaseDrinks();
        double price = pd.checkDrinksPrice(counter.drinksBrand);
        Debug.Log(price);
    }

    public void insertCoin(Coin coin)
    {
        PurchaseDrinks pd = new PurchaseDrinks();
        pd.checkCoinValidity(coin);
        bool dispense = pd.checkCoinSufficiency(counter.drinksBrand);
        bool availability = pd.checkDrinksAvailability(counter.drinksBrand);
        if(dispense == true && availability == true)
        {
            dispenseDrink();
        }
        //somemethod
    }

    //public void displayCoinAmount()
    //{
    //    //somemethod
    //}

    public void dispenseDrink()
    {
        Debug.Log("Drinks Dispensed");
        //somemethod
    }

    public void displayCoinInvalid(Coin coin)
    {
        //somemethod
        PurchaseDrinks pd = new PurchaseDrinks();
        bool available = pd.checkCoinValidity(coin);
        Debug.Log(available);
    }

    public void displayAccumulatedCoins()
    {
        Debug.Log(counter.accumulatedCoin);
    }

    public void dispenseChange()
    {
        double change = counter.accumulatedCoin - counter.price;
        PurchaseDrinks pd = new PurchaseDrinks();
        CoinArray available = pd.checkChangeAvailability(change);
        if(available.num10c == 0 && available.num20c == 0 && available.num50c == 0 && available.numRM1 == 0)
        {
            Debug.Log("Insufficient Balance");
        }
        else
        {
            Debug.Log("Dispensing Change");
        }

        //somemethod
    }
    public void terminateTransaction()
    {
        double displayReturnCash = counter.accumulatedCoin;
        Debug.Log(displayReturnCash);
        PurchaseDrinks pd = new PurchaseDrinks();
        pd.CancelTransaction();
        
    }

}
