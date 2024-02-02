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
    public void SaveDrinkData(Drink drink, string brand)
    {
        string json = JsonUtility.ToJson(drink);
        PlayerPrefs.SetString(brand, json);
        PlayerPrefs.Save();
    }

    // Load drink data
    public Drink LoadDrinkData(string brand)
    {
        string json = PlayerPrefs.GetString(brand, "{}");
        return JsonUtility.FromJson<Drink>(json);
    }
}

