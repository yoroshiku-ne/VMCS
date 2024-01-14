using UnityEngine;

[System.Serializable]
public class Drink
{
    public string brand;
    public int quantity;
    public float price;
}

public class DrinksDB 
{
    // Save drink data
    public void SaveDrinkData(Drink drink)
    {
        string json = JsonUtility.ToJson(drink);
        PlayerPrefs.SetString("DrinkData", json);
        PlayerPrefs.Save();
    }

    // Load drink data
    public Drink LoadDrinkData()
    {
        string json = PlayerPrefs.GetString("DrinkData", "{}");
        return JsonUtility.FromJson<Drink>(json);
    }
}

