using UnityEngine;

[System.Serializable]
public class Coin
{
    public int quantity;
    public string type;
}

public class CoinArray
{
    public int num10c;
    public int num20c;
    public int num50c;
    public int numRM1;
}

public class CoinsDB 
{
    // Save coin data
    public void SaveCoinData(CoinArray coinArray)
    {
        string json = JsonUtility.ToJson(coinArray);
        PlayerPrefs.SetString("CoinData", json);
        PlayerPrefs.Save();
    }

    // Load coin data
    public CoinArray LoadCoinData()
    {
        string json = PlayerPrefs.GetString("CoinData", "{}");
        return JsonUtility.FromJson<CoinArray>(json);
    }
}

