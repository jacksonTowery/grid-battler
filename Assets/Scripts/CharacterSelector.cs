using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelector : MonoBehaviour
{
    private Character selectedCharacter;
    private Character[] personalParty = new Character[3];

    public void updateSelectedCharacter(Character chara)
    {
        selectedCharacter = chara;
    }

    public void sendParty()
    {
        Singleton.Instance.setTempParty(personalParty);
    }

    public void callUpdateSlot(int slotNumber)
    {
        Debug.Log("Character: " + selectedCharacter.getName());
        Debug.Log("Slot #: " + slotNumber);
        Debug.Log("Team #: " + Singleton.Instance.getTeamNumber());
        string temp = ("Team: ");
        foreach (Character chara in Singleton.Instance.getTeam(Singleton.Instance.getTeamNumber())) {
            temp+= chara.getName() + ", ";
        }
        Debug.Log(temp);


        Singleton.Instance.updateSlot(Singleton.Instance.getTeam(Singleton.Instance.getTeamNumber()), slotNumber, selectedCharacter);
    }
}
