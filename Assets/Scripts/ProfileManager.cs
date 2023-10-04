using UnityEngine;
using UnityEngine.UI;

public class ProfileManager : MonoBehaviour
{
    public InputField playerNameInput;

    public void SavePlayerProfile()
    {
        string playerName = playerNameInput.text;
        PlayerPrefs.SetString("PlayerName", playerName);
        PlayerPrefs.Save();
    }
}
