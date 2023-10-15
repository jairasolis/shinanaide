using UnityEngine;
using TMPro;

public class WinScene : MonoBehaviour
{
    public TextMeshProUGUI resultText;

    void Start()
    {
        string gameResult = PlayerPrefs.GetString("GameResult", "Game Over");

        resultText.text = gameResult;
    }
}
