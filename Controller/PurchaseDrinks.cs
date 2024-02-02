using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurchaseDrinks : MonoBehaviour
{
    public List<Drink> loadDrink()
    {
        List<Drink> drinkList = new List<Drink>();

        for (int i = 1; i <= 5; i++)
        {
            DrinksDB drinkDb = new DrinksDB();
            Drink drink = drinkDb.LoadDrinkData("BRAND" + i);
            drinkList.Add(drink);
        }
        return drinkList;
    }

    public bool checkDrinksAvailability(string drinksBrand)
    {
       
        DrinksDB drinkDb = new DrinksDB();
        Drink drink = drinkDb.LoadDrinkData(drinksBrand);
        
        if(drink.quantity > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public double checkDrinksPrice(string drinksBrand)
    {
        DrinksDB drinkDb = new DrinksDB();
        Drink drink = drinkDb.LoadDrinkData(drinksBrand);
        return drink.price;
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

    public bool checkCoinValidity(Coin coin)
    {

        //dosomemethod
        if(coin.type == "10c" || coin.type == "20c" || coin.type == "50c" || coin.type == "RM1")
        {
            double update = updateAccumulatedCoins(coin);
            return true;
        }
        else
        {
            bool reject = rejectInvalidCoin(false);
            return reject;
        }
    }

    public bool rejectInvalidCoin(bool coinInvalid)
    {
        return coinInvalid;
    }

    public double updateAccumulatedCoins(Coin coin)
    {
        if(coin.type == "10c")
        {
            counter.accumulatedCoin += 0.1;
            //counter.tenCent ++;
        }
        else if(coin.type == "20c")
        {
            counter.accumulatedCoin += 0.2;
            //counter.twentyCent ++;
        }
        else if(coin.type == "50c")
        {
            counter.accumulatedCoin += 0.5;
            //counter.fiftyCent ++;
        }
        else
        {
            counter.accumulatedCoin += 1;
            //counter.RM1 ++;
        }
        return counter.accumulatedCoin;
    }

    public bool checkCoinSufficiency(string drinksBrand)
    {
        double price = checkDrinksPrice(drinksBrand);
        if (counter.accumulatedCoin >= price)
        {
            updateRevenue();
            return true;
        }
        else
        {
            return false;
        }
    }

    public double checkChangeAmount(Drink drink)
    {
        TransactionDB txndb = new TransactionDB();
        Transaction transaction = txndb.LoadTransactionData();
        double change;
        if(transaction.userPayment != drink.price)
        {
            change = transaction.userPayment - drink.price;

            return change;
        }
        else
        {
            return 0;
        }
    }

    public CoinArray checkChangeAvailability(double change)
    {
        CoinsDB coinsdb = new CoinsDB();
        CoinArray coinarray = coinsdb.LoadCoinData();
        int rm1Count = 0;
        int fiftyCentCount = 0;
        int twentyCentCount = 0;
        int tenCentCount = 0;

        int rm1Balance = coinarray.numRM1;
        int fiftyCentBalance = coinarray.num50c;
        int twentyCentBalance = coinarray.num20c;
        int tenCentBalance = coinarray.num10c;

        while (change >= 1)
        {
            rm1Count ++;
            if(rm1Balance < rm1Count)
            {
                rm1Count--;
            }
            else
            {
                change = change - 1;
                rm1Balance--;
            }
        }
        while(change >= 0.5)
        {
            fiftyCentCount++;
            if (fiftyCentBalance < fiftyCentCount)
            {
                fiftyCentCount--;
            }
            else
            {
                change = change - 0.5;
                fiftyCentBalance--;
            }
        }
        while(change >= 0.2)
        {
            twentyCentCount++;
            if (twentyCentBalance < twentyCentCount)
            {
                twentyCentCount--;
            }
            else
            {
                change = change - 0.2;
                twentyCentBalance--;
            }
        }
        while(change >= 0.1)
        {
            tenCentCount++;
            if (tenCentBalance < tenCentCount)
            {
                tenCentCount--;
            }
            else
            {
                change = change - 0.1;
                tenCentBalance--;
            }
        }

        CoinArray returnCoin = new CoinArray();
        
        if (change == 0)
        {
            returnCoin.num10c = tenCentCount;
            returnCoin.num20c = twentyCentCount;
            returnCoin.num50c = fiftyCentCount;
            returnCoin.numRM1 = rm1Count;

            CoinArray returnBalance = new CoinArray();

            returnBalance.num10c = tenCentBalance;
            returnBalance.num20c = twentyCentBalance;
            returnBalance.num50c = fiftyCentBalance;
            returnBalance.numRM1 = rm1Balance;

            coinsdb.SaveCoinData(returnBalance);
;        }
        else
        {
            returnCoin.num10c = 0;
            returnCoin.num20c = 0;
            returnCoin.num50c = 0;
            returnCoin.numRM1 = 0;
        }

        counter.accumulatedCoin = 0;
        return returnCoin;
    }


    public void updateRevenue()
    {
        TransactionDB txndb = new TransactionDB();
        Transaction transaction = new Transaction();
        transaction.userPayment = counter.accumulatedCoin;
        transaction.brands = counter.drinksBrand;
        transaction.sumPayment = sumRevenue();
        txndb.SaveTransactionData(transaction);
    }

    public double sumRevenue()
    {
        TransactionDB txndb = new TransactionDB();
        Transaction transaction = txndb.LoadTransactionData();
        double sum = counter.accumulatedCoin + transaction.sumPayment;
        return sum;
    }

    void CalculateDenomination(float amount)
    {
        //refactor check change availability
    }

    public void CancelTransaction()
    {
        counter.accumulatedCoin = 0;
    }

}
