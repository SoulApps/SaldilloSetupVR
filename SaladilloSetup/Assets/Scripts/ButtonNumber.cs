﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ButtonNumber : MonoBehaviour
{
    public string text;

    public Text ipAdress;

    // Use this for initialization
    void Start()
    {
        GetComponentInChildren<Text>().text = text;
    }


    public void Click()
    {
        if (text.Equals("Back") && !String.IsNullOrEmpty(ipAdress.text))
        {
            ipAdress.text = ipAdress.text.Remove(ipAdress.text.Length - 1);
        }

        else if (text.Equals("Clear") && !String.IsNullOrEmpty(ipAdress.text))
        {
            ipAdress.text = "";
        }
        else
        {
            ipAdress.text += text;
        }
    }
}