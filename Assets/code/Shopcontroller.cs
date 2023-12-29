using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Shopcontroller : MonoBehaviour
{
    public static int moneyAmount;
    int isbird1, isbird2, isbird3;
    public Button buy, buy2, buy3 ,select1, select2 , select3;

    void Start()
    {
        moneyAmount = PlayerPrefs.GetInt("coin");
        buy2.gameObject.SetActive(true);
        buy.gameObject.SetActive(true);
        buy3.gameObject.SetActive(true);



    }
    void Update()
    {
        isbird1 = PlayerPrefs.GetInt("bird1");
        if (Coin.moneyAmount >= 1 && isbird1 == 0)
            buy.interactable = true;
        else buy.gameObject.SetActive(false);

        isbird2 = PlayerPrefs.GetInt("bird2");
        if (moneyAmount >= 1 && isbird2 == 0)
            buy2.interactable = true;
        else
            buy2.gameObject.SetActive(false);

        isbird3 = PlayerPrefs.GetInt("bird3");
        if (moneyAmount >= 1 && isbird3 == 0)
            buy3.interactable = true;
        else
            buy3.gameObject.SetActive(false);
    }
    public void bird1()
    {
        Coin.moneyAmount -= 1;
        PlayerPrefs.SetInt("bird1", 1);
        buy.gameObject.SetActive(false);

    }
    public void bird2()
    {
        Coin.moneyAmount -= 1;
        PlayerPrefs.SetInt("bird2", 1);
        buy2.gameObject.SetActive(false);
    }
    public void bird3()
    {
        Coin.moneyAmount -= 1;
        PlayerPrefs.SetInt("bird3", 1);
        buy3.gameObject.SetActive(false);
    } public void Select1()
    {
        PlayerPrefs.SetInt("bird1", 1);
        PlayerPrefs.SetInt("bird2", 2);
        PlayerPrefs.SetInt("bird3", 2);
        buy.gameObject.SetActive(false);

    }
    public void Select2()
    {
        PlayerPrefs.SetInt("bird2", 1);
        PlayerPrefs.SetInt("bird1", 2);
        PlayerPrefs.SetInt("bird3", 2);
        buy2.gameObject.SetActive(false);
    }
    public void Select3()
    {
        PlayerPrefs.SetInt("bird3", 1);
        PlayerPrefs.SetInt("bird2", 2);
        PlayerPrefs.SetInt("bird1", 2);
        buy3.gameObject.SetActive(false);
    }
    public void exitShop()
    {
        PlayerPrefs.SetInt("coin", moneyAmount);
        SceneManager.LoadScene("Menu");
    }
    public void reset()
    {
        moneyAmount = 0;
        buy.gameObject.SetActive(true);
        buy2.gameObject.SetActive(true);
        buy3.gameObject.SetActive(true);
        PlayerPrefs.DeleteAll();
    }

}
