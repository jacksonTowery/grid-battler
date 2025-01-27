using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour
{
    public int teamSelection = 0;
    //0 means no team
    //1 means team 1
    //2 means team 2


    public void ToTitle()
    {
        SceneManager.LoadScene("TitleScreen");
    }

    public void ToBattle()
    {
        SceneManager.LoadScene("BattleScreen");
    }

    public void setTeamSelection(int team)
    {
        teamSelection = team;
    }

    public void ToTeamSelection()
    {
        SceneManager.LoadScene("Team" + teamSelection + "Selection");
    }
}
