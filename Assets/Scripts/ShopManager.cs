using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopManager : MonoBehaviour
{
    public int gambas;
    public TMP_Text gambasUI;
    public ShopItemSO[] shopItemsSO;
    public GameObject[] shopPanelsGO;
    public ShopTemplate[] shopPanels;
    public Button[] myPurchaseBtns;

    void Start()
    {
        for (int i = 0; i < shopItemsSO.Length; i++)
            shopPanelsGO[i].SetActive(true);
        gambasUI.text = "Gambas: " + gambas.ToString();
        LoadPanels();
        CheckPurchaseable();
    }

    public void AddGambas()
    {
        gambas++;
        gambasUI.text = "Gambas: " + gambas.ToString();
        CheckPurchaseable();
    }
    
    public void CheckPurchaseable()
    {
        for (int i = 0; i < shopItemsSO.Length; i++)
        {
            if (gambas >= shopItemsSO[i].baseCost)
                myPurchaseBtns[i].interactable = true;
            else
                myPurchaseBtns[i].interactable = false;
        }
    }
    
    
    public void PurchaseItem(int btnNo)
    {
        if (gambas >= shopItemsSO[btnNo].baseCost)
        {
            gambas = gambas - shopItemsSO[btnNo].baseCost;
            gambasUI.text = "Gambas: " + gambas.ToString();
            CheckPurchaseable();
        }
    }
    
    
    public void LoadPanels()
    {
        for (int i = 0; i < shopItemsSO.Length; i++)
        {
            shopPanels[i].titleTxt.text = shopItemsSO[i].title;
            shopPanels[i].descriptionTxt.text = shopItemsSO[i].description;
            shopPanels[i].costTxt.text = "Gambas: " + shopItemsSO[i].baseCost.ToString();
        }
    }
    
}
