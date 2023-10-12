using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpManager : MonoBehaviour
{
    public GameObject popUpPanel;

    void Start()
    {
        popUpPanel.SetActive(false);
    }

    public void TogglePopUp()
    {
        bool currentState = popUpPanel.activeSelf;
        popUpPanel.SetActive(!currentState);
    }
}
