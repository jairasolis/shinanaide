using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class userInfo : MonoBehaviour
{
    string userUsername;
    string userPassword;
    string gambas;
    string wins;

    public void setInfo(string username, string password)
    {
        userUsername = username;
        userPassword = password;     
    }


}
