using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class main : MonoBehaviour
{

    public static main Instance;
    public web Web;
    private profileDB profileDB;

    //public userInfo userInfo;


    void Start()
    {
        Instance = this;
        Web = GetComponent<web>();
        profileDB = GetComponent<profileDB>();

        //userInfo = GetComponent<userInfo>();
    }


}
