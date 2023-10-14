using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;
using TMPro;

public class SkinManager : MonoBehaviour
{
    public SpriteRenderer sr;
    public List<Sprite> skins = new List<Sprite>();
    public List<string> textchar = new List<string>();
    public int textcharID;
    private int selectedSkin = 0;
    public GameObject playerskin;
    public TextMeshProUGUI textcharText;


    public void NextOption()
    {
        selectedSkin = selectedSkin + 1;
        if (selectedSkin == skins.Count)
        {
            selectedSkin = 0;
        }
        sr.sprite = skins[selectedSkin];
        textcharText.text = textchar[selectedSkin];
    }

    public void BackOption()
    {
        selectedSkin = selectedSkin - 1;
        if (selectedSkin < 0)
        {
            selectedSkin = skins.Count - 1;
        }
        sr.sprite = skins[selectedSkin];
        textcharText.text = textchar[selectedSkin];
    }
}