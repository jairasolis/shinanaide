using UnityEngine;
using TMPro;
using System.Collections.Generic;

[System.Serializable]
public class SkinOption
{
    public Sprite sprite;
    public GameObject prefab;
    public string skinName;
}

public class SkinManager : MonoBehaviour
{
    public GameObject skinPreviewObject; 
    public TextMeshProUGUI skinNameText;
    public List<SkinOption> skinOptions = new List<SkinOption>();
    private int selectedSkinIndex = 0;

    private void Start()
    {
        UpdateSkinPreview();
    }

    public void NextOption()
    {
        selectedSkinIndex = (selectedSkinIndex + 1) % skinOptions.Count;
        UpdateSkinPreview();
    }

    public void BackOption()
    {
        selectedSkinIndex = (selectedSkinIndex - 1 + skinOptions.Count) % skinOptions.Count;
        UpdateSkinPreview();
    }

    public void EquipSkin()
    {
        GameObject selectedPrefab = skinOptions[selectedSkinIndex].prefab;



        UpdateSkinPreview();
    }

    private void UpdateSkinPreview()
    {
        SpriteRenderer spriteRenderer = skinPreviewObject.GetComponent<SpriteRenderer>();
        if (spriteRenderer != null)
        {
            spriteRenderer.sprite = skinOptions[selectedSkinIndex].sprite;
        }

        skinNameText.text = skinOptions[selectedSkinIndex].skinName;
    }
}