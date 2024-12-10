using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BattleState { START, PLAYER1TURN, PLAYER2TURN, WON, LOST }

public class BattleSystem : MonoBehaviour
{
    public static BattleState state;

    public BattleState getState()
    {
        return state;
    }

    // Start is called before the first frame update
    void Start()
    {
        state = BattleState.START;
        SetupBattle();
    }

    void SetupBattle()
    {
        //useless right now, but frame work for when later we need to run multiple instantiations at setup

        PlayerTurn();
    }

    void PlayerTurn()
    {
        state = BattleState.PLAYER1TURN;
    }
}
