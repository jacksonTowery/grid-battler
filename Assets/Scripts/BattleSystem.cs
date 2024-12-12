using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public enum BattleState { START, PLAYERTURN, WON, LOST } //declaring what a battleState enum can hold

public class BattleSystem : MonoBehaviour
{
    public static BattleState state; //current state of battle
    public static int CurrentPlayer = 0; //set to 0 because no player assigned yet
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
        int player = Random.Range(1, 3); //SHOULD generate either 1 or 2

        if (player == 1) //send to player 1's turn
        {
            state = BattleState.PLAYERTURN;
            Player1Turn();
        }

        else if(player == 2)
        {
            state = BattleState.PLAYERTURN;
            Player2Turn(); //send to player 2's turn
        }

        else //error error, you done goofed up in your code if this reads out ever
        {
            Debug.Log("ERROR! CURRENTPLAYER != 1 OR 2");
        }
    }

    void Player1Turn()
    {
        
    }

    void Player2Turn()
    {

    }
}
