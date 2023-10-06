using UnityEngine;
using UnityEngine.UI;

public class ProfileDisplay : MonoBehaviour
{
    public Text playerNameText;

    void Start()
    {
        if (PlayerPrefs.HasKey("PlayerName"))
        {
            string playerName = PlayerPrefs.GetString("PlayerName");
            playerNameText.text = "Player Name: " + playerName;
        }
        else
        {
            playerNameText.text = "Player Name: Not Set";
        }
    }
}
