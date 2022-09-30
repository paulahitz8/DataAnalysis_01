﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Player
{
    public string Name;
    public string Country;
    public DateTime Date;
    public string Php = "AddPlayer.php";

    public string GetData()
    {
        return "?Name=" + Name + "&Country=" + Country + "&Date=" + Date.ToString();
    }
}


public class AnalyticsController : MonoBehaviour
{
    private void OnEnable()
    {
        Simulator.OnNewPlayer += OnNewPlayer;
        Simulator.OnNewSession += OnNewSession;
        Simulator.OnEndSession += OnEndSession;
        Simulator.OnBuyItem += OnBuyItem;
    }

    private void OnNewPlayer(string name, string country, DateTime date)
    {
        var player = new Player();
        player.Name = name;
        player.Country = country;
        player.Date = date;
        string url = CreateURL(player.Php, player.GetData());

        StartCoroutine(SendInfo(url));
    }

    private string CreateURL(string php, string data)
    {
        return "https://citmalumnes.upc.es/~paulahm/" + php + data;
    }

    private IEnumerator SendInfo(string url)
    {
        WWW www = new WWW(url);
        yield return www;

        if (www.text == "0")
        {
            Debug.Log("User created successfully.");
        }
        else
        {
            Debug.Log("User creation failed. Error #" + www.text);
        }
    }
    private void OnNewSession(DateTime obj)
    {

    }

    private void OnEndSession(DateTime obj)
    {

    }

    private void OnBuyItem(int arg1, DateTime arg2)
    {

    }

}
