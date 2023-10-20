using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class main : MonoBehaviour
{

    public static main Instance;
    public web Web;


    void Start()
    {
        Instance = this;
        Web = GetComponent<web>();
    }

    
}
