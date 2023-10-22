using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSelection : MonoBehaviour
{
    public GameObject[] characterPrefabs;
    public GameObject[] puckPrefabs;
    private int selectedCharacter = 0;
    private int selectedPuck = 0;
    private bool isCharacterPreview = true;
    public GameObject characterContainer;
    public GameObject puckContainer;

    void Start()
    {
        UpdatePreview();
    }

    public void TogglePreview()
    {
        isCharacterPreview = !isCharacterPreview;
        UpdatePreview();
    }

    public void Next()
    {
        if (isCharacterPreview)
        {
            selectedCharacter = (selectedCharacter + 1) % characterPrefabs.Length;
        }
        else if (puckPrefabs.Length > 0)
        {
            selectedPuck = (selectedPuck + 1) % puckPrefabs.Length;
        }
        UpdatePreview();
    }

    public void Previous()
    {
        if (isCharacterPreview)
        {
            selectedCharacter = (selectedCharacter - 1 + characterPrefabs.Length) % characterPrefabs.Length;
        }
        else if (puckPrefabs.Length > 0)
        {
            selectedPuck = (selectedPuck - 1 + puckPrefabs.Length) % puckPrefabs.Length;
        }
        UpdatePreview();
    }

    private void UpdatePreview()
    {
        characterContainer.SetActive(isCharacterPreview);
        puckContainer.SetActive(!isCharacterPreview);

        if (isCharacterPreview)
        {
            selectedCharacter = Mathf.Clamp(selectedCharacter, 0, characterPrefabs.Length - 1);
            for (int i = 0; i < characterPrefabs.Length; i++)
            {
                characterPrefabs[i].SetActive(i == selectedCharacter);
            }
        }
        else
        {
            selectedPuck = Mathf.Clamp(selectedPuck, 0, puckPrefabs.Length - 1);
            for (int i = 0; i < puckPrefabs.Length; i++)
            {
                puckPrefabs[i].SetActive(i == selectedPuck);
            }
        }
    }

    public void StartGame()
    {
        PlayerPrefs.SetInt("selectedCharacter", selectedCharacter);
        PlayerPrefs.SetInt("selectedPuck", selectedPuck);
        SceneManager.LoadScene(9, LoadSceneMode.Single);
    }
}
