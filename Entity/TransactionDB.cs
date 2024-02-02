using UnityEngine;

[System.Serializable]
public class Transaction
{
    public double userPayment;
    public string brands;
    public double sumPayment;
}

public class TransactionDB 
{
    // Save transaction data
    public void SaveTransactionData(Transaction transaction)
    {
        string json = JsonUtility.ToJson(transaction);
        PlayerPrefs.SetString("TransactionData", json);
        PlayerPrefs.Save();
    }

    // Load transaction data
    public Transaction LoadTransactionData()
    {
        string json = PlayerPrefs.GetString("TransactionData", "{}");
        return JsonUtility.FromJson<Transaction>(json);
    }
}
