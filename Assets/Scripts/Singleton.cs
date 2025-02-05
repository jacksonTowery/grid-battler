using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Singleton : MonoBehaviour
{
    public static Singleton Instance { get; private set; }

    public Character[] Party1 = new Character[3];
    public Character[] Party2 = new Character[3];
    public static Character[] tempParty = new Character[3];
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

    public void setTeam(int num)
    {
        currentTeam = num;

        setTempParty(getTeam(num));

        Debug.Log("it is now team " + currentTeam + "'s time to shine.");
    }

    //using slot-1 format again for simplicity
    public void updateSlot(Character[] team, int slot, Character chara)
    {
        team[slot - 1] = chara;
    }

}
