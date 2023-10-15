
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class profileU : MonoBehaviour
{
    public GameObject userprofileimage;
    public TextMeshProUGUI textname;
    public Profile profile;
    void Start()
    {
        profile.UpdateUserProfileImage();
        textname.text = PlayerPrefs.GetString("LoggedInUsername");
    }
}