using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Profile : MonoBehaviour
{
    public GameObject[] player;
    public int currentPlayer;

    public GameObject arrowLeft;
    public GameObject arrowRight;
    public GameObject selectedPlayer;
    public InputField userName;
    public Text noName;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void delayforleftandrightstate()
    {
        if (currentPlayer<player.length-1)
        {
            arrowLeft.SetActive(true);
            arrowRight.SetActive(true);
        }
        if (currentPlayer == 0)
        {
            arrowLeft.SetActive(false);
        }
        if (currentPlayer == player.length - 1)
        {
            arrowRight.SetActive(false);
        }
    }
    public void leftrightstate()
    {
        player[currentPlayer].SetActive(false);
        if (temp)
        {
            currentPlayer++;
        }
        else if (!temp)
        {
            currentPlayer--;
        }
        delayforleftandrightstate();
        player[currentPlayer].SetActive(true);

    }
    public void selectedPlayer()
    {
        PlayerPrefs.SetInt("currentselectedPlayer", currentPlayer);
        PlayerPrefs.SetString("name",Texttype.text);
        noName.text = PlayerPrefs.GetString("name");
    }
    
}
