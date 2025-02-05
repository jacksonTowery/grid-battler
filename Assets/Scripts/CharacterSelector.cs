using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelector : MonoBehaviour
{
    private Character selectedCharacter;
    private Character[] personalParty = new Character[3];
    private void Start()
    {
        if (Singleton.Instance.getTeam() == null)
        {
            for (int i = 0; i < personalParty.Length; i++)
            {
                personalParty[i] = new Character();
            }
        }
        else
        {
            personalParty = Singleton.Instance.getTeam();
        }
    }

    public void updateSelectedCharacter(Character chara)
    {
        selectedCharacter = chara;
    }

    public void sendParty()
    {
        string temp = ("Team: ");
        foreach (Character chara in Singleton.Instance.getTeam(Singleton.Instance.getTeamNumber()))
        {
            temp += chara.getName() + ", ";
        }
        Debug.Log(temp);

        Singleton.Instance.setTempParty(personalParty);
    }

    public void callUpdateSlot(int slotNumber)
    {
        Debug.Log(slotNumber + "; calling singleton method...");
        Singleton.Instance.updateSlot(slotNumber, selectedCharacter);
    }
}
