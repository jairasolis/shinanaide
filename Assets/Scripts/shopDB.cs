using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class shopDB : MonoBehaviour
{
    public TextMeshProUGUI gambasText;

    void Start()
    {
        string gambas = PlayerPrefs.GetString("userGambas");
        gambasText.text = gambas;
    }

}
