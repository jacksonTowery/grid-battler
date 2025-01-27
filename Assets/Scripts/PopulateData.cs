using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.UI;

public class PopulateData : MonoBehaviour
{
    //fetches character file
    [SerializeField] private Character yourChar;

    //these will set the rest from character file
    [SerializeField] private Text StatBlock;
    [SerializeField] private Text Abilities;
    [SerializeField] private Image charImage;

    // Start is called before the first frame update
    void Start()
    {
            yourChar = UnityEngine.GameObject.Find("CharacterObject").GetComponentInChildren<Character>();
            //Autofills data
            StatBlock.text = "Attack: " + yourChar.getAtk() + "\r\nDefense: " + yourChar.getDef() + "\r\nMovement: " + yourChar.getmRange();

            //Right now will need to manually fill out description. Maybe in future attach description to the character object?
            Abilities.text = "Ability Description\r\nit does stuff\r\nbasic description here yfeel";

            //Pulls charSprite from character object.
            charImage.sprite = yourChar.getSprite();
    }
}
