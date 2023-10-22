using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;


public class inventoryScript : MonoBehaviour
{
    public GameObject puck1; //no pun intended
    public GameObject puck2;
    public GameObject puck3;
    public GameObject puck4;
    public GameObject puck5;

    void Start()
    {
        StartCoroutine(getItems());
    }

    public IEnumerator getItems()
    {
        WWWForm form = new WWWForm();
        form.AddField("loginUser", PlayerPrefs.GetString("LoggedInUsername"));

        UnityWebRequest www = UnityWebRequest.Post("https://shinanaide.000webhostapp.com/getItems.php", form);
        yield return www.SendWebRequest();

        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(www.error);
        }
        else
        {
            string response = www.downloadHandler.text;
            Debug.Log(response);

            string[] parts = response.Split('-');

            List<string> values = new List<string>();

            values.AddRange(parts);

            string[] valuesArray = values.ToArray();

            setActiveItems(valuesArray);

            foreach (var puck in valuesArray)
            {
                Debug.Log(puck);
            }
        }
    }

    public void setActiveItems(string[] puckArray)
    {
        foreach (string name in puckArray)
        {
            if (name == "ertBall")
            {
                puck1.SetActive(true);
            }
            else if (name == "dirtBall")
            {
                puck2.SetActive(true);
            }
            else if (name == "waterBall")
            {
                puck3.SetActive(true);
            }
            else if (name == "fireBall")
            {
                puck4.SetActive(true);
            }
            else if (name == "magmaBall")
            {
                puck5.SetActive(true);
            }
        }
    }

}
