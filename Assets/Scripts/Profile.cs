using UnityEngine;
using UnityEngine.UI; // Add this line to include the UnityEngine.UI namespace

public class Profile : MonoBehaviour
{
    public GameObject[] player;
    public int currentPlayer;

    public GameObject arrowLeft;
    public GameObject arrowRight;
    public Text noName;
    public InputField Texttype; 

    void Start()
    {
        // Initialization code if needed
    }

    void Update()
    {
        // Update code if needed
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
        PlayerPrefs.SetString("name", Texttype.text); 
        noName.text = PlayerPrefs.GetString("name");
    }
}
