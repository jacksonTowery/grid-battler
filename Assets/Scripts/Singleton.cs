using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Singleton : MonoBehaviour
{
    public static Singleton Instance { get; private set; }

    public Character[] Party1 = null;
    public Character[] Party2 = null;
    public static Character[] tempParty = null;
    public int currentTeam = 0;
    
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        
        Instance = this;
    }

    public void updateParty(Character[] oldparty, Character[] newparty)
    {
        oldparty = newparty;
    }

    public void updateParty(Character[] newparty)
    {
        newparty = tempParty;
    }

    public void updateParty()
    {
        updateParty(getTeam());
    }

    public Character[] getTempParty()
    {
        return tempParty;
    }

    public Character[] setTempParty(Character[] party)
    {
        tempParty = party;
        return tempParty;
    }

    public int getTeamNumber()
    {
        return currentTeam;
    }

    public Character[] getTeam(int teamFetch)
    {
        if (teamFetch == 1)
        {
            return Party1;
        }

        else if (teamFetch == 2)
        {
            return Party2;
        }

        else
            return null;
    }

    public Character[] getTeam()
    {
        return getTeam(getTeamNumber());
    }

    public void setTeam(int num)
    {
        currentTeam = num;

        setTempParty(getTeam(num));
    }

    //using slot-1 format again for simplicity
    public void updateSlot(int slot, Character chara)
    {

        tempParty[slot - 1] = chara;
        GameObject.Find("Slot" + slot).GetComponentInChildren<SpriteRenderer>().sprite = chara.getSprite();
    }

}
