using UnityEngine;

[System.Serializable]
public class Transaction
{
    public float userPayment;
    public string brands;
    public float sumPayment;
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
