using UnityEngine;
using UnityEngine.UI; 
using TMPro;

public class Profile : MonoBehaviour
{    
    public int currentPlayer;
    public GameObject[] player;
    public GameObject arrowLeft;
    public GameObject arrowRight;
    // public TextMeshProUGUI noName;
    // public TMP_InputField Texttype; 
    public GameObject iconPanel;
    public GameObject profilePanel;
    public TextMeshProUGUI usernameText;


    void Start()
    {
        aMethod();
        // arrowLeft.SetActive(false);
    }

    void Update()
    {
    }

    void delayforleftandrightstate()
    {   
        if (currentPlayer < player.Length - 1)
        {
            arrowLeft.SetActive(true);
            arrowRight.SetActive(true);
        }
        if (currentPlayer == 0)
        {
            arrowLeft.SetActive(false);
        }
        if (currentPlayer == player.Length - 1)
        {
            arrowRight.SetActive(false);
        }
    }

    public void leftrightstate(bool temp) 
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

    public void SetSelectedPlayer()
    {
        PlayerPrefs.SetInt("currentselectedPlayer", currentPlayer);
        // PlayerPrefs.SetString("name", Texttype.text); 
        // Debug.Log(Texttype.text);
        // noName.text = PlayerPrefs.GetString("name");
        iconPanel.SetActive(false);
        profilePanel.SetActive(true);
    }

    public void aMethod()
    {
        // Retrieve the username from PlayerPrefs
        if (PlayerPrefs.HasKey("LoggedInUsername"))
        {
            string username = PlayerPrefs.GetString("LoggedInUsername");
            usernameText.text = "welcome, " + username + ", please select an icon"; // Display the username in your UI
        }
    }
}