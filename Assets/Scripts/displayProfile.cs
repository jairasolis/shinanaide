using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class displayProfile : MonoBehaviour
{
    public GameObject userprofileimage;
    public TextMeshProUGUI textname;
    public Profile playing;


    // Start is called before the first frame update
    void Start()
    {
        userprofileimage.GetComponent<Image>().sprite = playing.player[PlayerPrefs.GetInt("currentselectedPlayer")].GetComponent<Image>().sprite;
        textname.text=PlayerPrefs.GetString("name");
    
    }   

    // Update is called once per frame
    void Update()
    {
        
    }
}
