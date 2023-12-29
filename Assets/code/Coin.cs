using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Coin : MonoBehaviour
{
    public Text moneyText;
    public static int moneyAmount;
 
    void Start()
    {
        moneyAmount = PlayerPrefs.GetInt("coin");
        if (moneyAmount < 0) moneyAmount = 0;
    }
    void Update()
    {
        moneyText.text = "" + moneyAmount.ToString() + "$";
        PlayerPrefs.SetInt("coin", moneyAmount);
    }
    public void gotoShop()
    {
        PlayerPrefs.SetInt("coin", moneyAmount);
        SceneManager.LoadScene("Shop");
    }
}
