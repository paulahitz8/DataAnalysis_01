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
    public int PlayerID;
    public string Php = "Players.php";

    public string GetData()
    {
        return "?Name=" + Name + "&Country=" + Country + "&Date=" + Date.ToString("yyyy-MM-dd HH:mm:ss");
    }
}

[Serializable]
public class Item
{
    public int PlayerID;
    public int SessionID;
    public int ItemID;
    public DateTime BuyDate;

    public string Php = "Purchases.php";

    public string GetData()
    {
        return "?PlayerID=" + PlayerID.ToString() + "&SessionID=" + SessionID.ToString() + "&ItemID=" + ItemID.ToString() + "&BuyDate=" + BuyDate.ToString("yyyy-MM-dd HH:mm:ss");
    }
}

[Serializable]
public class Session
{
    public int PlayerID;
    public DateTime SessionStart;
    public DateTime SessionEnd;
    public int SessionID;

    public string Php = "Sessions.php";

    public string GetData()
    {
        return "?PlayerID=" + PlayerID.ToString() + "&SessionStart=" + SessionStart.ToString("yyyy-MM-dd HH:mm:ss") + "&SessionEnd=" + SessionEnd.ToString("yyyy-MM-dd HH:mm:ss");
    }
}


public class AnalyticsController : MonoBehaviour
{
    public Player player;
    public Session session;

    private void OnEnable()
    {
        Simulator.OnNewPlayer += OnNewPlayer;
        Simulator.OnNewSession += OnNewSession;
        Simulator.OnEndSession += OnEndSession;
        Simulator.OnBuyItem += OnBuyItem;
    }

    private void OnNewPlayer(string name, string country, DateTime date)
    {
        player = new Player();
        player.Name = name;
        player.Country = country;
        player.Date = date;

        string url = CreateURL(player.Php, player.GetData());

        StartCoroutine(SendPlayerInfo(url, player));
    }

    private string CreateURL(string php, string data)
    {
        return "https://citmalumnes.upc.es/~paulahm/" + php + data;
    }

    private IEnumerator SendPlayerInfo(string url, Player player)
    {
        Debug.Log(url);
        WWW www = new WWW(url);
        yield return www;
       
        if (www.text == "0")
        {
            Debug.Log("Error#");
        }
        else
        {
            Debug.Log("User created successfully" + www.text);

            player.PlayerID = Int16.Parse(www.text);

            CallbackEvents.OnAddPlayerCallback?.Invoke((uint)player.PlayerID);
        }
    }

    private IEnumerator SendSessionInfo(string url, Session session)
    {
        Debug.Log(url);
        WWW www = new WWW(url);
        yield return www;

        if (www.text == "0")
        {
            Debug.Log("Error#");
        }
        else
        {
            Debug.Log("Session created successfully" + www.text);

            session.SessionID = Int16.Parse(www.text);

            CallbackEvents.OnEndSessionCallback?.Invoke((uint)player.PlayerID);
        }
    }

    private IEnumerator SendItemInfo(string url, Item item)
    {
        Debug.Log(url);
        WWW www = new WWW(url);
        yield return www;

        if (www.text == "0")
        {
            Debug.Log("Error#");
        }
        else
        {
            Debug.Log("Item created successfully" + www.text);

           CallbackEvents.OnItemBuyCallback?.Invoke();
        }
    }

    private void OnNewSession(DateTime date)
    {
        session = new Session();
        session.SessionStart = date;
        session.PlayerID = player.PlayerID;

        CallbackEvents.OnNewSessionCallback?.Invoke((uint)player.PlayerID);
    }

    private void OnEndSession(DateTime date)
    {
        session.SessionEnd = date;

        string url = CreateURL(session.Php, session.GetData());
        StartCoroutine(SendSessionInfo(url, session));
    }

    private void OnBuyItem(int itemID, DateTime buyDate)
    {
        Item item = new Item();
        item.ItemID = itemID;
        item.BuyDate = buyDate;
        item.PlayerID = player.PlayerID;
        item.SessionID = session.SessionID;

        string url = CreateURL(item.Php, item.GetData());
        StartCoroutine(SendItemInfo(url, item));
    }

}
