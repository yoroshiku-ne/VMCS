using UnityEngine;

[System.Serializable]
public class Coin
{
    public int quantity;
    public string type;
}

public class CoinsDB 
{
    // Save coin data
    public void SaveCoinData(Coin coin)
    {
        string json = JsonUtility.ToJson(coin);
        PlayerPrefs.SetString("CoinData", json);
        PlayerPrefs.Save();
    }

    // Load coin data
    public Coin LoadCoinData()
    {
        string json = PlayerPrefs.GetString("CoinData", "{}");
        return JsonUtility.FromJson<Coin>(json);
    }
}

