using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoMaintenance 
{
    public bool VerifyPassword(string password)
    {
        if(password == "123456")
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void RestockDrinks(Drink drinks)
    {
        //somemethod
    }

    public void CollectCoin(Transaction transaction)
    {
        //somemethod
    }

    public void RestockChange(Coin coin)
    {
        //somemethods
    }

    public void doorUnlock(bool doorLock)
    {
        if(doorLock == true)
        {
            doorLock = false;
        }
    }

    public void terminateTransaction()
    {
        //terminate transaction
    }


}
